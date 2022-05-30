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
        public static readonly double MAX = 254;
        public static readonly double MIN = 0;
        //temp public
        public List<List<Table3DDot>> dots;
        public InterpolationType Interpolation { get; set; }

        public int Width {
            get { return dots[0].Count; }
            set {
                if (value == dots[0].Count) { }
                else if (value < dots[0].Count)
                {
                    foreach (List<Table3DDot> list in dots)
                    {
                        list.RemoveRange(value, list.Count - value);
                    }
                }
                else
                {
                    int itx = 0;
                    foreach (List<Table3DDot> list in dots)
                    {
                        list.Add(CreateDot(itx, list.Count));
                        itx++;
                    }
                }

            }
        }
        public int Length {
            get { return dots.Count; }
            set {
                if (value == dots.Count) { }
                else if (value < dots.Count)
                {
                    dots.RemoveRange(value, dots.Count - value);
                }
                else
                {
                    foreach (int itx in Enumerable.Range(0, value - dots.Count))
                    {
                        int trueitx = dots.Count;
                        List<Table3DDot> list = new List<Table3DDot>();
                        foreach (int itz in Enumerable.Range(0, dots[0].Count))
                        {
                            list.Add(CreateDot(trueitx, itz));
                        }
                        dots.Add(list);
                    }
                }
            }
        }

        private Canvas3D gui;

        protected readonly int defsize = 10;
        protected readonly int deflength = 20;
        protected readonly double defval = 0;

        public Table(Canvas3D ngui)
        {
            gui = ngui;
            Interpolation = InterpolationType.Linear;
            dots = new List<List<Table3DDot>>();
            foreach (int itx in Enumerable.Range(0, deflength))
            {
                var row = new List<Table3DDot>();
                dots.Add(row);
                foreach (int itz in Enumerable.Range(0, defsize))
                {
                    row.Add(CreateDot(itx, itz));
                }
            }
        }

        private Table3DDot CreateDot(int itx, int itz)
        {
            double vx = itx * gui.spacing + gui.oripadding;
            double vy = defval;
            double vz = itz * gui.spacing + gui.oripadding;
            return new Table3DDot(() => gui.Origin, () => gui.xaxis, () => gui.yaxis, () => gui.zaxis, vx, vy, vz);
        }

        public double GetOn1Value(double freq, double time)
        {
            //Console.WriteLine("time:" + time);
            if (freq < 0 || 1 < freq)
            {
                //Console.WriteLine("out of range");
                return 0;
            }
            freq *= dots[0].Count - 1;
            time %= 1;//so it loop
            time *= dots.Count - 1;

            if (Interpolation == InterpolationType.None)
            {
                return GetNotInterpolatedValue(time, freq);
            }
            else
            {
                return GetLinearInterpolatedValue(time, freq);
            }
        }

        private double GetNotInterpolatedValue(double index1, double index2)
        {
            return dots[(int)Math.Floor(index1)][(int)Math.Floor(index2)].Y;
        }

        private double GetLinearInterpolatedValue(double index1, double index2)
        {
            int row1 = (int)Math.Floor(index1);
            int row2 = (int)Math.Ceiling(index1);
            if (row2 >= dots.Count)
            {
                row2 = 0;
            }
            double rmix = index1 % 1;
            double mrmix = 1 - rmix;

            int col1 = (int)Math.Floor(index2);
            int col2 = (int)Math.Ceiling(index2);
            double cmix = index2 % 1;
            double mcmix = 1 - cmix;

            double ri1 = dots[row1][col1].Y * mrmix + dots[row2][col1].Y * rmix;
            double ri2 = dots[row1][col2].Y * mrmix + dots[row2][col2].Y * rmix;
            return ri1 * mcmix + ri2 * cmix;
        }

        public enum InterpolationType
        {
            None, Linear
        }
    }
}
