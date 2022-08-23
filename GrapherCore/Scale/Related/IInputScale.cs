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
        double PickValueTo(Wave wave, Spectrum spectrum, double size);

        /// <summary>
        /// if the scale is looping, return how much it looped, otherwise return 0
        /// </summary>
        int GetCumulativeStackNumber(Wave wave, Spectrum spectrum, double size);
    }
}
