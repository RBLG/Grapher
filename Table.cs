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

        public Table(List<List<Table3DDot>> dots)
        {
            this.dots = dots;
        }

        public double GetOn1Value(double freq, double time)
        {
            if (freq < 0 || 1 < freq)
            {
                Console.WriteLine("out of range");
                return 0;
            }
            freq *= dots[0].Count - 1;
            //time *= (dots[0].Count - 1);
            time %= dots.Count;//so it loop

            //return dots[0][0].Y ;
            return dots[(int)Math.Floor(time)][(int)Math.Floor(freq)].Y;
            // return GetLinearInterpolatedValue(freq, time);
        }

        private double GetLinearInterpolatedValue(double index1, double index2)
        {
            int row1 = (int)Math.Floor(index1);
            int row2 = (int)Math.Ceiling(index1);
            double rmix = index1 % 1;

            int col1 = (int)Math.Floor(index2);
            int col2 = (int)Math.Ceiling(index2);
            double cmix = index2 % 1;


            double ri1 = dots[row1][col1].Y * rmix + dots[row2][col1].Y * (1 - rmix);
            double ri2 = dots[row1][col2].Y * rmix + dots[row2][col2].Y * (1 - rmix);
            return ri1 * cmix + ri2 * (1 - cmix);
        }




    }
}
