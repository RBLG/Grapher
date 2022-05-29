using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Units
{
    public interface IFrequencyUnit
    {
        double GetValue();

        IFrequencyUnit ModulateBy(double factor,double min,double max);
    }
}
