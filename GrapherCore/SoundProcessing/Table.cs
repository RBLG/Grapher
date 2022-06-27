using Grapher.Modes;
using Grapher.Scale;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Grapher
{
    // list of the different rows of values
    public class Table
    {
        public static readonly double MAX = 100;
        public static readonly double MIN = 0;
        public static readonly double defval = 50;

        public static readonly int defwidth = 10;
        public static readonly int deflength = 30;

        public IInputScale Wscale { get; set; } = new FrequencyExponantialScale();
        public IInputScale Lscale { get; set; } = new TimeLinearScale();
        public IOutputScale Hscale { get; set; } = new AmplitudeLinearScale();
        public IMode Mode { get; set; } = new MultiplyMode();

        //moved from canvas3D
        public readonly Point3D xaxis = new(0.7, 0.2, 0);
        public readonly Point3D yaxis = new(0, -1, 0);
        public readonly Point3D zaxis = new(0.5, -0.3, 0);
        public readonly Point3D Origin = new(10, 216, 0);

        //temp public
        public List<List<Table3DDot>> dots;

        [JsonIgnore]
        private double[] arrayble = Array.Empty<double>();
        [JsonIgnore]
        private int count1;
        [JsonIgnore]
        private int count2;

        public InterpolationType Interpolation { get; set; }

        /// <summary>
        /// constructor for the deserializer
        /// </summary>
        [JsonConstructor]
        public Table(List<List<Table3DDot>> Dots, InterpolationType interpolation, int height)
        {
            dots = Dots;
            Interpolation = interpolation;
            Height = height;
            dots.ForEach((r) => r.ForEach((d) =>
            {
                d.SetReferencial(() => Origin, () => xaxis, () => yaxis, () => zaxis);
                d.RecalculateScreenXY();
            }
            ));
            RefreshArrayble();
        }

        public Table()
        {
            Interpolation = InterpolationType.Linear;
            dots = new(deflength);
            foreach (int itx in Enumerable.Range(0, deflength))
            {
                var row = new List<Table3DDot>();
                dots.Add(row);
                foreach (int itz in Enumerable.Range(0, defwidth))
                {
                    row.Add(CreateDot(itx, itz, defwidth, deflength));
                }
            }
            RefreshArrayble();
        }

        public int Height { get; set; } = (int)MAX;

        /// <summary>
        /// Width of the grid, changing it will resize the grid
        /// </summary>
        public int Width {//TODO make resize use last row/collumn values
            get { return dots[0].Count; }
            set {
                if (value < dots[0].Count)
                {
                    foreach (List<Table3DDot> list in dots)
                    {
                        list.RemoveRange(value, list.Count - value);
                    }
                    UpdateAll();
                }
                else if (value != dots[0].Count)
                {
                    int itx = 0;
                    foreach (List<Table3DDot> list in dots)
                    {
                        list.Add(CreateDot(itx, list.Count, dots.Count, list.Count + 1));
                        itx++;
                    }
                    UpdateAll();
                }
            }
        }

        /// <summary>
        /// length of the grid
        /// </summary>
        public int Length {
            get { return dots.Count; }
            set {
                if (value < dots.Count)
                {
                    dots.RemoveRange(value, dots.Count - value);
                    UpdateAll();
                }
                else if (value != dots.Count)
                {
                    foreach (int itx in Enumerable.Range(0, value - dots.Count))
                    {
                        int trueitx = dots.Count;
                        List<Table3DDot> list = new();
                        foreach (int itz in Enumerable.Range(0, dots[0].Count))
                        {
                            list.Add(CreateDot(trueitx, itz, trueitx + 1, dots[0].Count));
                        }
                        dots.Add(list);
                    }
                    UpdateAll();
                }
            }
        }

        public void UpdateAll()
        {
            foreach (int itx in Enumerable.Range(0, dots.Count))
            {
                foreach (int itz in Enumerable.Range(0, dots[0].Count))
                {
                    Table3DDot pt = dots[itx][itz];
                    pt.SetReferencial(() => Origin, () => xaxis, () => yaxis, () => zaxis);
                    pt.Z = itz * (Canvas3D.tablevisualwidth / Math.Max(2, dots[0].Count - 1)) + Canvas3D.oripadding;
                }
            }
            RefreshArrayble();
        }

        private void RefreshArrayble()
        {
            count1 = dots.Count;
            count2 = dots[0].Count;
            arrayble = new double[dots.Count * dots[0].Count];
            int itx = 0;
            foreach (List<Table3DDot> row in dots)
            {
                int ity = 0;
                foreach (Table3DDot dot in row)
                {
                    arrayble[itx + ity * count1] = dot.Y;
                    ity++;
                }
                itx++;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetTableValue(int x, int y)
        {
            //return dots[x][y].Y;
            return arrayble[x + y * count1];
        }

        public void AddToArrayble(int x, int y, double value)
        {
            double nval = arrayble[x + y * count1] + value;
            arrayble[x + y * count1] = Math.Clamp(nval, MIN, MAX);
        }

        private Table3DDot CreateDot(int itx, int itz, int width, int length)
        {
            double vz = itz * (Canvas3D.tablevisualwidth / Math.Max(2, width - 1)) + Canvas3D.oripadding;
            double vx = itx * Canvas3D.lengthspacing + Canvas3D.oripadding;
            double vy = defval;
            var dot = new Table3DDot(vx, vy, vz);
            dot.SetReferencial(() => Origin, () => xaxis, () => yaxis, () => zaxis);
            return dot;
        }

        public void Apply(Spectrum.Wave wave, Spectrum spectrum)
        {
            double wval = (count2 == 1) ? 0 : Wscale.PickValueTo(wave, spectrum, count2);
            double lval = (count1 == 1) ? 0 : Lscale.PickValueTo(wave, spectrum, count1);
            double tval = Get01ValueFromWL(wval, lval);
            Hscale.ProcessValue(wave, spectrum, Height, Mode, tval);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double Get01ValueFromWL(double wval, double lval)
        {
            return (GetOnMaxValueFromWL(wval, lval) - MIN) / MAX;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetOnMaxValueFromWL(double wval, double lval)
        {
            if (wval < 0 || Width <= wval || lval < 0 || Length <= lval)
            { return 0; }

            if (Interpolation == InterpolationType.None)
            { return GetNotInterpolatedValue(lval, wval); }
            else
            { return GetLinearInterpolatedValue(wval, lval); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetNotInterpolatedValue(double index1, double index2)
        {
            return GetTableValue((int)index1, (int)index2);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetLinearInterpolatedValue(double wval, double lval)
        {
            int col1 = (int)wval;
            int col2 = (wval == col1) ? col1 : col1 + 1; //faster (int)Math.Ceiling(index2);
            if (col2 >= count2)
            {
                if (Wscale.IsLooping)
                { col2 = 0; }
                else
                { col2 = col1; }
            }

            int row1 = (int)lval;
            int row2 = (lval == row1) ? row1 : row1 + 1; //faster (int)Math.Ceiling(index1);
            double rmix = lval - row1;//% 1;//faster %1 ?
            double mrmix = 1 - rmix;
            if (row2 >= count1)
            {
                if (Lscale.IsLooping)
                { row2 = 0; }
                else
                { row2 = row1; }
            }

            if (col1 == col2)//all this so it doesnt have to access much more if interpolation has no effect
            {
                if (row1 == row2)
                { return GetTableValue(row1, col1); }
                else
                { return GetTableValue(row1, col1) * mrmix + GetTableValue(row2, col1) * rmix; }
            }
            else
            {
                double cmix = wval - col1;//% 1;//also faster %1
                double mcmix = 1 - cmix;
                if (row1 == row2)
                { return GetTableValue(row1, col1) * mcmix + GetTableValue(row1, col2) * cmix; }
                else
                {
                    double ri1 = GetTableValue(row1, col1) * mrmix + GetTableValue(row2, col1) * rmix;
                    double ri2 = GetTableValue(row1, col2) * mrmix + GetTableValue(row2, col2) * rmix;
                    return ri1 * mcmix + ri2 * cmix;
                }
            }

        }

        public enum InterpolationType
        {
            None, Linear
        }
    }
}
