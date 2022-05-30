using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    //default time is in millisecond
    public class DynamicToWholeTimeScale : IScale
    {
        public static readonly double min = 0;
        public double Max { get; set; } //represent the duration of the table (in millis)

        public DynamicToWholeTimeScale()
        {
            Max = 1000;
        }

        public double GetMax()
        {
            return Max;
        }

        public double GetMin()
        {
            return min;
        }

        public double GetScaled(double notscaled) //in millis
        {

            return notscaled * 1000 / Max;
        }

        public double To01(double notscaled) //in millis
        {
            return notscaled/Max;//basically in seconds
        }
    }
}
