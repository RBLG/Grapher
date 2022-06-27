using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale.Related
{
    public interface IOutputScale : IScaleCore
    {

        /// <summary>
        /// pick the value, scale it to 01, process it with mode then unscale it from 01 and set it back
        /// </summary>
        void ProcessValue(Spectrum.Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval);
    }
}
