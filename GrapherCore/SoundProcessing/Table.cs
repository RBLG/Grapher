using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        //moved from canvas3D
        public readonly Point3D xaxis = new(0.7, 0.2, 0);
        public readonly Point3D yaxis = new(0, -1, 0);
        public readonly Point3D zaxis = new(0.5, -0.3, 0);
        public Point3D Origin = new(10, 216, 0);

        //private Canvas3D gui;

        //temp public
        public List<List<Table3DDot>> dots;
        public InterpolationType Interpolation { get; set; }

        public Table()
        {
            Interpolation = InterpolationType.Linear;
            dots = new();
            foreach (int itx in Enumerable.Range(0, deflength))
            {
                var row = new List<Table3DDot>();
                dots.Add(row);
                foreach (int itz in Enumerable.Range(0, defwidth))
                {
                    row.Add(CreateDot(itx, itz, defwidth, deflength));
                }
            }
        }

        public int Height { get; set; } = (int)MAX;

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
                    pt.Z = itz * (Canvas3D.tablevisualwidth / Math.Max(2, dots[0].Count - 1)) + Canvas3D.oripadding;
                    //pt.X = itx * (dots.Count / gui.tablevisualwidth) + gui.oripadding;
                }
            }
        }

        private Table3DDot CreateDot(int itx, int itz, int width, int length)
        {
            double vz = itz * (Canvas3D.tablevisualwidth / Math.Max(2, width - 1)) + Canvas3D.oripadding;
            double vx = itx * Canvas3D.lengthspacing + Canvas3D.oripadding;
            double vy = defval;
            return new Table3DDot(() => Origin, () => xaxis, () => yaxis, () => zaxis, vx, vy, vz);
        }

        public double Get01ValueFrom0101(double wval, double lval)
        {
            return Get01ValueFromWL(wval * Width, lval * Length);
        }

        public double Get01ValueFromWL(double wval, double lval)
        {
            return (GetOnMaxValueFromWL(wval, lval) - MIN) / MAX;
        }

        public double GetOnMaxValueFromWL(double wval, double lval)
        {
            if (wval < 0 || Width <= wval || lval < 0 || Length <= lval)
            { return 0; }
            //wval *= dots[0].Count - 1;
            //lval *= dots.Count - 1;

            if (Interpolation == InterpolationType.None)
            { return GetNotInterpolatedValue(lval, wval); }
            else
            { return GetLinearInterpolatedValue(lval, wval); }
        }

        private double GetNotInterpolatedValue(double index1, double index2)
        {
            return dots[(int)index1][(int)index2].Y;
        }

        private double GetLinearInterpolatedValue(double index1, double index2)
        {
            int col1 = (int)index2;
            int col2 = (index2 == col1) ? col1 : col1 + 1; //faster (int)Math.Ceiling(index2);
            if (col2 >= dots[0].Count)
            { col2 = 0; }

            int row1 = (int)index1;
            int row2 = (index1 == row1) ? row1 : row1 + 1; //faster (int)Math.Ceiling(index1);
            if (row2 >= dots.Count)
            { row2 = 0; }
            double rmix = index1 % 1;
            double mrmix = 1 - rmix;


            if (col1 == col2)//all this so it doesnt have to compute much more if interpolation has no effect
            {
                if (row1 == row2)
                { return dots[row1][col1].Y; }
                else
                { return dots[row1][col1].Y * mrmix + dots[row2][col1].Y * rmix; }
            }
            else
            {
                double cmix = index2 % 1;
                double mcmix = 1 - cmix;
                if (row1 == row2)
                { return dots[row1][col1].Y * mcmix + dots[row1][col2].Y * cmix; }
                else
                {
                    double ri1 = dots[row1][col1].Y * mrmix + dots[row2][col1].Y * rmix;
                    double ri2 = dots[row1][col2].Y * mrmix + dots[row2][col2].Y * rmix;
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
