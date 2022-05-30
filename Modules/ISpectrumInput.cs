using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    internal interface ISpectrumInput
    {
        Spectrum GetSpectrum(double time);

    }
}
