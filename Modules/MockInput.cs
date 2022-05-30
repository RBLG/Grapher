using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class MockInput : ISpectrumInput
    {
        private Spectrum main = new Spectrum();
        private Spectrum buffer = new Spectrum();

        public MockInput()
        {
            double mfreq = 440;
            double mamp = 0.1;
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq, mamp));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 3, mamp / 3));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 5, mamp / 9));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 7, mamp / 27));

            foreach (Wave w in main.Waves)
            {
                buffer.Waves.Add(new Wave(w.Type, w.Frequency, w.Amplitude));
            }
        }
        public Spectrum GetSpectrum(double time)
        {
            for (int it = 0; it < main.Waves.Count; it++)
            {
                Wave mw = main.Waves[it];
                Wave bw = buffer.Waves[it];
                //bw.Type = mw.Type;
                bw.Frequency = mw.Frequency;
                bw.Amplitude = mw.Amplitude;

            }
            return buffer;
        }
    }
}
