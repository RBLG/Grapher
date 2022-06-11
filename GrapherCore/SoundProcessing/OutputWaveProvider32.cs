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
        double time = 0;
        private readonly SharedStuff shared;

        public void Begin()
        { time = 0; }

        public OutputWaveProvider32(SharedStuff nshared)
        { shared = nshared; }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            var mod = shared.Module.GetRootModule();
            int sampleRate = WaveFormat.SampleRate;
            double interval = 1000d / sampleRate;//in millis
            for (int n = 0; n < sampleCount; n++)
            {
                Spectrum spec = mod.GetSpectrum(time,-1, shared.Pitch);
                float sum = 0;
                foreach (Wave w in spec.Waves)
                {
                    float val = (float)(w.Amplitude * Math.Sin((2 * Math.PI * w.Frequency * time) / 1000));
                    sum += val;
                }
                buffer[n + offset] = sum;
                time += interval;
            }
            return sampleCount;
        }
    }
}
