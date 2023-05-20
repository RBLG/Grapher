using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale.Related
{
    public interface IInputScale : IScaleCore
    {

        /// <summary>
        /// pick, scale and return the value corresponding to this scale
        /// </summary>
        double PickValueTo(Wave wave, Spectrum spectrum, uint size);

        /// <summary>
        /// same but allow 2 and 2 non continuous interpolation
        /// </summary>
        (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size);
    }
}
