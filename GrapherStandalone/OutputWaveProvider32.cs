using Grapher.SoundProcessing;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher
{
    public class OutputWaveProvider32 : WaveProvider32
    {
        public double time = 0;
        private readonly SharedStuff shared;

        public void Begin()
        { time = 0; }

        public OutputWaveProvider32(SharedStuff nshared)
        { shared = nshared; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            var mod = shared.ModuleProvider.RootModule;
            int sampleRate = WaveFormat.SampleRate;
            double interval = 1000d / sampleRate;//in millis
            for (int n = 0; n < sampleCount; n++)
            {
                Spectrum spec = mod.GetSpectrum(time, -1, shared.Pitch, (int)(time / 3_000d));
                float sum = 0;
                foreach (Wave w in spec.Waves)
                {
                    float val = (float)(w.Amplitude * Math.Sin(2 * Math.PI * (w.Frequency * time / 1000d + w.Phase)));
                    sum += val;
                    w.Phase = 0.5;//dirty reset
                    //w.Padding = 0.5; //useless since there's no padding in the standalone version so far
                }
                buffer[n + offset] = sum;
                time += interval;
            }
            return sampleCount;
        }
    }
}
