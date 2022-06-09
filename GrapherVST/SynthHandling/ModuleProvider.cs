using Jacobi.Vst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapherVST.SynthHandling
{
    internal class ModuleProvider
    {
        public bool IsPlaying { get; internal set; }

        internal void PlayAudio(VstAudioBuffer[] outChannels)
        {
            //throw new NotImplementedException();
        }

        internal void ProcessNoteOffEvent(byte v)
        {
            //throw new NotImplementedException();
        }

        internal void ProcessNoteOnEvent(byte v)
        {
            //throw new NotImplementedException();
        }
    }
}
