using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public class ExponantialFrequencyScale : IScale
    {
        public static readonly double min = Math.Log(LinearFrequencyScale.min + 1);
        public static readonly double max = Math.Log(LinearFrequencyScale.max + 1);
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
            return Math.Log(notscaled + 1);//+1 so no positive value can give negative value (not that it matter)
        }

        public double To01(double notscaled)
        {
            return (Math.Log(notscaled + 1) -min) / range;
        }
    }
}
