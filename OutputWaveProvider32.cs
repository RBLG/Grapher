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
        int sample;

        private SoundEngine engine;
        double beginning = 0;
        double time = 0;

        public void Begin(double be)
        {
            beginning = be;
        }

        public OutputWaveProvider32(SoundEngine nen)
        {
            engine = nen;
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            for (int n = 0; n < sampleCount; n++)
            {
                Spectrum spec = engine.GetSpectrum(time);
                float sum = 0;
                foreach (Wave w in spec.Waves)
                {
                    float val = (float)(w.Amplitude * Math.Sin((2 * Math.PI * sample * w.Frequency) / sampleRate));
                    sum += val;
                    Console.WriteLine("val:" + val);
                }
                buffer[n + offset] = sum;//(float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                time += (1000 / sampleRate);
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }
}
