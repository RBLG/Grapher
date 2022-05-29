using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Modes
{
    public interface IProcesser
    {
        void Process(Wave wave, double tabvalue);
    }
}
