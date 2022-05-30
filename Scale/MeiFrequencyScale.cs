using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public class MeiFrequencyScale : IScale
    {
        public static readonly double min = ToMei(LinearFrequencyScale.min + 1);
        public static readonly double max = ToMei(LinearFrequencyScale.max + 1);
        public static readonly double range = max - min;

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
            return ToMei(notscaled);
        }

        public double To01(double notscaled)
        {
            return (ToMei(notscaled) - min) / range;
        }

        private static double ToMei(double lfreq)
        {
            return 2595 * Math.Log10(1 + lfreq / 700);
        }
    }
}
