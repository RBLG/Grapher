using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Units
{
    public class LinearFrequency :IFrequencyUnit
    {
        public double Frequency { get; set; }

        public LinearFrequency(double nfreq)
        {
            Frequency = nfreq;
        }

        public double GetValue()
        {
            return Frequency;
        }

        public IFrequencyUnit ModulateBy(double factor, double min, double max)
        {
            throw new NotImplementedException();
        }
    }
}
