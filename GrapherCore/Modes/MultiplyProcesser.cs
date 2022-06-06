using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Modes
{
    public class MultiplyProcesser : IMode
    {
        public double Process(double value, double tab)
        {
            return value * tab * 2;//*2 so that 0,5 make stuff unchanged
        }
    }
}
