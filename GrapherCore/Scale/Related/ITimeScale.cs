using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    /// <summary>
    /// a more specific interface for properties specifically related to time scales.
    /// </summary>
    public interface ITimeScale : IScale
    {
        EnvStatus GetEnvStatus(double time, double timeoff);
    }
}
