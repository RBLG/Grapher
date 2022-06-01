using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.SoundProcessing
{
    public class SharedStuff
    {

        public SharedStuff(double npitch, IModule nmod)
        {
            Pitch = npitch;
            Module = nmod;
        }

        public double Pitch { set; get; }
        public IModule Module { set; get; }



    }
}
