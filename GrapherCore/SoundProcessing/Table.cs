﻿using Grapher.Modes;
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
    // the grid/table of values
    public class Table
    {
        public static readonly double MAX = 100; //rework to have value between 0 and 1
        public static readonly double MIN = 0;
        public static readonly double defval = 50;

        public static readonly int defwidth = 10;
        public static readonly int deflength = 30;

        /*
        public readonly Point3D xaxis = new(0.7, 0.2, 0);
        public readonly Point3D yaxis = new(0, -1, 0);
        public readonly Point3D zaxis = new(0.5, -0.3, 0);
        public readonly Point3D Origin = new(10, 216, 0);

        public IInputScale Wscale { get; set; } = new FrequencyExponantialScale();
        public IInputScale Lscale { get; set; } = new TimeLinearScale();
        public IOutputScale Hscale { get; set; } = new AmplitudeLinearScale();
        public IMode Mode { get; set; } = new SetMode();


        //temp public
        public List<List<Table3DDot>> dots;

        [JsonIgnore]
        private double[] arrayble = Array.Empty<double>();
        [JsonIgnore]
        private int count1;
        [JsonIgnore]
        private int count2;

        //public InterpolationType Interpolation { get; set; }

        /// <summary>
        /// constructor for the deserializer
        /// </summary>
        [JsonConstructor]
        public Table(
            List<List<Table3DDot>> Dots,
            IInputScale wscale,
            IInputScale lscale,
            IOutputScale hscale,
            IMode mode
            //InterpolationType interpolation
            )
        {
            dots = Dots;
            Wscale = wscale;
            Lscale = lscale;
            Hscale = hscale;
            Mode = mode;
            //Interpolation = interpolation;
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
            //Interpolation = InterpolationType.Linear;
            dots = new(deflength);
            foreach (int itx in Enumerable.Range(0, deflength))
            {
                var row = new List<Table3DDot>();
                dots.Add(row);
                foreach (int itz in Enumerable.Range(0, defwidth))
                {
                    row.Add(CreateDot(itx, itz, defwidth, deflength, defval));
                }
            }
            RefreshArrayble();
        }

        [JsonIgnore]
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
                        list.Add(CreateDot(itx, list.Count, dots.Count, list.Count + 1, dots[itx][list.Count - 1].Y));
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
                            list.Add(CreateDot(trueitx, itz, trueitx + 1, dots[0].Count, dots[trueitx - 1][itz].Y));
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

        public Table3DDot CreateDot(int itx, int itz, int width, int length, double yval)
        {
            double vz = itz * (Canvas3D.tablevisualwidth / Math.Max(2, width - 1)) + Canvas3D.oripadding;
            double vx = itx * Canvas3D.lengthspacing + Canvas3D.oripadding;
            double vy = yval;
            var dot = new Table3DDot(vx, vy, vz);
            dot.SetReferencial(() => Origin, () => xaxis, () => yaxis, () => zaxis);
            return dot;
        }

        public void Apply(Spectrum.Wave wave, Spectrum spectrum)
        {
            double wval = (count2 == 1) ? 0 : Wscale.PickValueTo(wave, spectrum, count2);
            double lval = (count1 == 1) ? 0 : Lscale.PickValueTo(wave, spectrum, count1);
            double tval = GetValueFromWL(wval, lval);
            if (!double.IsNaN(tval))
            { Hscale.ProcessValue(wave, spectrum, Height, Mode, tval); }
        }

        public void Apply2(Spectrum.Wave wave, Spectrum spectrum)
        {
            int w1, w2, l1, l2;
            double wmix, lmix;
            if (count2 == 1) { wmix = w1 = w2 = 0; }
            else
            { (w1, w2, wmix) = Wscale.PickValueTo2(wave, spectrum, count2); }

            if (count1 == 1) { lmix = l1 = l2 = 0; }
            else
            { (l1, l2, lmix) = Lscale.PickValueTo2(wave, spectrum, count1); }

            double tval = GetValueFromQuadIndex(w1, w2, wmix, l1, l2, lmix);
            if (!double.IsNaN(tval))
            { Hscale.ProcessValue(wave, spectrum, Height, Mode, tval); }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetValueFromWL(double wval, double lval)
        {
            if (wval < 0 || Width <= wval || lval < 0 || Length <= lval)
            { return double.NaN; }

            //if (Interpolation == InterpolationType.None)
            //{ return GetNotInterpolatedValue(lval, wval); }
            //else{
            return (GetContinuousLinearInterpolatedValue(wval, lval) - MIN) / MAX;
            //}
        }

        //will impl interpolation type choice in the future

        //[MethodImpl(MethodImplOptions.AggressiveInlining)]
        //private double GetNotInterpolatedValue(double index1, double index2)
        //{return GetTableValue((int)index1, (int)index2);}

        /// <summary>
        /// does interpolation between 2 and 2 continuous values
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private double GetContinuousLinearInterpolatedValue(double wval, double lval)
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
            double cmix = wval - col1;//% 1;//also faster %1

            int row1 = (int)lval;
            int row2 = (lval == row1) ? row1 : row1 + 1; //faster (int)Math.Ceiling(index1);
            if (row2 >= count1)
            {
                if (Lscale.IsLooping)
                { row2 = 0; }
                else
                { row2 = row1; }
            }
            double rmix = lval - row1;//% 1;//faster %1 ?

            return GetLinearInterpolatedValue(row1, row2, rmix, col1, col2, cmix);
        }
        
        /////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static (int, int, double) PrepareInterpolation(double val, int count, bool islooping)
        {
            //i1 and i2 are the two index to interpolate between, mix is where between both the value is
            int i1 = (int)val;
            int i2 = (val == i1) ? i1 : i1 + 1; //faster (int)Math.Ceiling(index2);
            if (i2 >= count)
            {
                i2 = islooping ? 0 : i1;
            }
            double mix = val - i1;//% 1;//also faster %1

            return (i1, i2, mix);
        }

        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetValueFromQuadIndex(int w1, int w2, double wmix, int l1, int l2, double lmix)
        {
            if (w1 < 0 || Width <= w1 || l1 < 0 || Length <= l1 ||
                w2 < 0 || Width <= w2 || l2 < 0 || Length <= l2)
            { return double.NaN; }

            return (GetLinearInterpolatedValue(w1, w2, wmix, l1, l2, lmix) - MIN) / MAX;
        }

        /// <summary>
        /// does interpolation between 2 and 2 non continuous table values
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public double GetLinearInterpolatedValue(int w1, int w2, double wmix, int l1, int l2, double lmix)
        {
            double mwmix = 1 - wmix;
            double mlmix = 1 - lmix;

            if (w1 == w2)//avoiding unecessary table access (are those ifs faster than array access?)
            {
                if (l1 == l2)
                { return GetTableValue(l1, w1); }
                else
                { return GetTableValue(l1, w1) * mlmix + GetTableValue(l2, w1) * lmix; }
            }
            else
            {
                if (l1 == l2)
                { return GetTableValue(l1, w1) * mwmix + GetTableValue(l1, w2) * wmix; }
                else
                {
                    double ri1 = GetTableValue(l1, w1) * mlmix + GetTableValue(l2, w1) * lmix;
                    double ri2 = GetTableValue(l1, w2) * mlmix + GetTableValue(l2, w2) * lmix;
                    return ri1 * mwmix + ri2 * wmix;
                }
            }
        }
        */

    }
    //public enum InterpolationType { None, Linear }




}
