using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Units
{
    public class Harmonics : IFrequencyUnit
    {
        private IFrequencyUnit First { get; set; }

        public int Harmony { get; set; }

        public Harmonics(IFrequencyUnit nfirst, int nhar)
        {
            First = nfirst;
            Harmony = nhar;
        }
        public double GetValue()
        {
            return First.GetValue()* Harmony;
        }

        public IFrequencyUnit ModulateBy(double factor, double min, double max)
        {
            throw new NotImplementedException();
        }
    }
}
