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
        private readonly List<MyMidiEvent> events = new();

        public class MyMidiEvent
        {
            private static int count = 0;
            public MyMidiEvent(int nnote)
            {
                note = nnote;
                count++;
                seed = count;
            }
            public double seed;
            public int note;
            public double time = 0;
            public double timeoff = double.NaN;//NaN till the off event happen
        }

        //double interval = 1000d / SampleRate;//in millis
        public double interval = 1000;

        public float SampleRate { get; set; }

        private readonly MidiNoteScale midi = new();

        public ModuleProvider() { }

        private IModule root = new TableModule();

        public IModule GetRootModule()
        { return root; }

        public void SetRootModule(IModule module)
        { root = module; }


        public bool IsPlaying { get { return events.Count != 0; } private set { } }

        public void PlayAudio(VstAudioBuffer[] outChannels)
        {
            for (int i = events.Count - 1; i >= 0; i--)
            {
                var evnt = events[i];
                var isover = root.IsOver(evnt.time, evnt.timeoff);
                if ((isover == EnvStatus.NotHandled && !Double.IsNaN(evnt.timeoff)) || isover.HasFlag(EnvStatus.Done))
                {
                    events.RemoveAt(i);
                    continue;
                }
                double pitch = midi.Unscale(evnt.note);
                for (int n = 0; n < outChannels[0].SampleCount; n++)
                {
                    Spectrum spec = root.GetSpectrum(evnt.time, evnt.timeoff, pitch, evnt.seed);
                    double sum = 0;
                    double sum2 = 0;
                    foreach (Wave w in spec.Waves)
                    {
                        double val = w.Amplitude * Math.Sin(w.Frequency * (2 * Math.PI * (evnt.time / 1000 + w.Phase)));
                        sum += val * w.Padding;
                        sum2 += val * (1 - w.Padding);
                        w.Phase = 0.5;//dirty reset
                        w.Padding = 0.5;
                    }
                    outChannels[0][n] += (float)sum;
                    outChannels[1][n] += (float)sum2;
                    evnt.time += interval;
                    evnt.timeoff += interval;
                }

            }
            //for (int n = 0; n < outChannels[0].SampleCount; n++)
            //{ outChannels[1][n] = outChannels[0][n]; }

        }

        public void ProcessNoteOffEvent(byte v)
        {
            foreach (MyMidiEvent e in events)
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
