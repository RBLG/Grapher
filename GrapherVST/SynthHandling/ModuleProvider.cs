using Grapher;
using Grapher.Modules;
using Grapher.Scale;
using Jacobi.Vst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace GrapherVST.SynthHandling
{
    internal class ModuleProvider : IModuleChainProvider
    {
        private readonly List<OnGoingEvent> events = new();

        public class OnGoingEvent
        {
            public OnGoingEvent(int nnote)
            { note = nnote; }
            public int note;
            public double time = 0;
            public double timeoff = -1;
        }

        private readonly MidiNoteScale midi = new();

        public ModuleProvider() { }

        private IModule root = new DefaultPitchModule();

        public IModule GetRootModule()
        { return root; }

        public void SetRootModule(IModule module)
        { root = module; }


        public bool IsPlaying { get { return events.Count != 0; } private set { } }

        public void PlayAudio(VstAudioBuffer[] outChannels, double sampleRate)
        {


            for (int i = events.Count - 1; i >= 0; i--)
            {
                var evnt = events[i];
                var mod = root;
                //double sampleRate = samplerate;
                int offset = 0;
                double pitch = midi.GetUnscaled(evnt.note);
                double interval = 1000d / sampleRate;//in millis
                bool done = false;
                for (int n = 0; n < outChannels[0].SampleCount; n++)
                {
                    Spectrum spec = mod.GetSpectrum(evnt.time, evnt.timeoff, pitch);
                    float sum = 0;
                    foreach (Wave w in spec.Waves)
                    {
                        float val = (float)(w.Amplitude * Math.Sin(2 * Math.PI * w.Frequency * evnt.time / 1000));
                        sum += val;
                    }
                    outChannels[0][n + offset] = outChannels[1][n + offset] = sum;
                    evnt.time += interval;
                    done |= spec.IsOver;
                }
                if (done)
                { events.RemoveAt(i); }
            }

        }

        public void ProcessNoteOffEvent(byte v)
        {
            //events.RemoveAll((item) => item.note == v);
            foreach (OnGoingEvent e in events)
            {
                if (e.note == v)
                { e.timeoff = 0; }
            }
        }

        public void ProcessNoteOnEvent(byte v)
        {
            events.Add(new(v));
        }
    }
}
