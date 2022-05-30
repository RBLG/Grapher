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

        private ProtoModule engine;
        double beginning = 0;
        double time = 0;

        public void Begin(double be)
        {
            beginning = be;
        }

        public OutputWaveProvider32(ProtoModule nen)
        {
            engine = nen;
        }

        public override int Read(float[] buffer, int offset, int sampleCount)
        {
            int sampleRate = WaveFormat.SampleRate;
            double interval = 1000 / (double)sampleRate;//in millis
            for (int n = 0; n < sampleCount; n++)
            {

                Spectrum spec = engine.GetSpectrum(time);
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
