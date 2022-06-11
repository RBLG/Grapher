using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.SoundProcessing
{
    public class SharedStuff
    {

        public SharedStuff(double npitch, IModuleChainProvider nmod)
        {
            Pitch = npitch;
            Module = nmod;
        }

        public double Pitch { set; get; }
        public IModuleChainProvider Module { set; get; }



    }
}
