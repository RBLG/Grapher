using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public interface ITimeScale : IScale
    {
        EnvStatus GetEnvStatus(double time, double timeoff);
    }
}
