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
        int sample;

        //private IModule engine;
        double beginning = 0;
        double time = 0;
        private SharedStuff shared;

        public void Begin(double be)
        {
            beginning = be;
        }

        public OutputWaveProvider32(SharedStuff nshared)
        {
            shared = nshared;
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            double interval = 1000d / sampleRate;//in millis
            for (int n = 0; n < sampleCount; n++)
            {

                Spectrum spec = shared.Module.GetSpectrum(time, shared.Pitch);
                float sum = 0;
                foreach (Wave w in spec.Waves)
                {
                    float val = (float)(w.Amplitude * Math.Sin((2 * Math.PI * sample * w.Frequency) / sampleRate));
                    sum += val;
                    //Console.WriteLine("val:" + val);
                }
                // Console.WriteLine("sum:" + sum * 100);
                //Console.WriteLine("time:" + time);
                buffer[n + offset] = sum;//(float)(Amplitude * Math.Sin((2 * Math.PI * sample * Frequency) / sampleRate));
                time += interval;
                sample++;
                if (sample >= sampleRate) sample = 0;
            }
            return sampleCount;
        }
    }
}
