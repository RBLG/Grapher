using Grapher.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    //scale where 10 has 10 less place on the table than 100
    public class LinearFrequencyScale : IScale
    {
        public static readonly int min = 20;
        public static readonly int max = 3_000;

        public double GetMax()
        {
            return max;
        }

        public double GetMin()
        {
            return min;
        }

        public double GetScaled(double notscaled)
        {
            return notscaled;
        }

        public double To01(double notscaled)
        {
            return (notscaled - min) / (max - min);
        }
    }
}
