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
        private List<List<Table3DDot>> dots;
        public InterpolationType Interpolation { get; set; }

        public Table(List<List<Table3DDot>> dots)
        {
            Interpolation = InterpolationType.Linear;
            this.dots = dots;
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

            double ri1 = dots[row1][col1].Y * mrmix + dots[row2][col1].Y * rmix;
            double ri2 = dots[row1][col2].Y * mrmix + dots[row2][col2].Y * rmix;
            return ri1 * cmix + ri2 * (1 - cmix);
        }

        public enum InterpolationType
        {
            None, Linear
        }


    }
}
