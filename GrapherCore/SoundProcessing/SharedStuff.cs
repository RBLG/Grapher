using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.SoundProcessing
{
    /// <summary>
    /// quick workaround to have things in the wave32provider and at the root at the same time.
    /// rework required
    /// </summary>
    public class SharedStuff
    {
        public SharedStuff(double npitch, IModuleChainProvider nmod)
        {
            Pitch = npitch;
            ModuleProvider = nmod;
        }

        public double Pitch { set; get; }
        public IModuleChainProvider ModuleProvider { set; get; }



    }
}
