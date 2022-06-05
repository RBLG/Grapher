using Grapher.GuiElement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class MockInput : IModule
    {
        private Spectrum main = new Spectrum();
        private Spectrum buffer = new Spectrum();

        public MockInput()
        {
            double mfreq = 100;
            double mamp = 0.3;
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq, mamp));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 3, mamp / Math.Pow(3, 1)));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 5, mamp / Math.Pow(3, 2)));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 7, mamp / Math.Pow(3, 3)));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 9, mamp / Math.Pow(3, 4)));
            main.Waves.Add(new Spectrum.Wave(Spectrum.WaveType.Sinus, mfreq * 11, mamp / Math.Pow(3, 5)));

            foreach (Wave w in main.Waves)
            {
                buffer.Waves.Add(new Wave(w.Type, w.Frequency, w.Amplitude));
            }
        }

        public UserControl GetControl()
        {
            return null;
        }

        public string GetName()
        {
            return "nothing";
        }

        public Spectrum GetSpectrum(double time, double bpitch)
        {
            for (int it = 0; it < main.Waves.Count; it++)
            {
                //Wave mw = main.Waves[it];
                Wave bw = buffer.Waves[it];
                //bw.Type = mw.Type;
                bw.Frequency = bpitch * (it * 2 + 1);//mw.Frequency;
                bw.Amplitude = 0.3 / (Math.Pow(3, it));//mw.Amplitude;

            }
            return buffer;
        }

        public IModule GetInput()
        {
            return null;
        }

        public void SetInput(IModule input)
        {
            return;
        }
    }
}
