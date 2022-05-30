﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    //scale where 10 has 10 less place on the table than 100
    public class LinearFrequencyScale : IScale
    {
        public const double min = 20;
        public const double max = 20_000;
        public const double range = max - min;

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
            return (notscaled - min) / range;
        }
    }
}
