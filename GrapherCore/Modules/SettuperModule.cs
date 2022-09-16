using Grapher.GuiElement.SettuperModuleGuis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Modules
{
    public class SettuperModule : IModule
    {
        public List<SettupedMainWave> MainWaves { get; private set; } = new();


        private Spectrum spectrum = new();
        //private Spectrum buffer = new();

        //public double BaseFrequency { get; set; } = 808;
        //public double BaseAmplitude { get; set; } = 0.3;
        //public double BasePadding { get; set; } = 0.5;


        public string Name => "Settup Module";

        public IModule? Input => null;

        public SettuperModule()
        {
            AddWave(new(0, 0.5));
        }

        public void AddWave(SettupedMainWave mwave)
        {
            MainWaves.Add(mwave);
            UpdateStock();
        }

        public void RemoveWave(SettupedMainWave mwave)
        {
            MainWaves.Remove(mwave);
            UpdateStock();
        }



        public void UpdateStock()
        {
            Spectrum nspectrum = new();
            foreach (SettupedMainWave mwave in MainWaves)
            {
                nspectrum.Waves.Add(new Wave(WaveType.Sinus, mwave.Frequency, mwave.Amplitude));
                foreach (SettupedHarmonic wave in mwave.Harmonics)
                {
                    double freq = mwave.Frequency * wave.Multiplier;
                    double amp = mwave.Amplitude * wave.Amplitude;
                    nspectrum.Waves.Add(new Wave(WaveType.Sinus, freq, amp));
                }
            }
            spectrum = nspectrum;
        }

        private void ResetValues2(double time, double nfreq)
        {
            foreach (Wave wave in spectrum.Waves)
            {
                //wave.Amplitude = BaseAmplitude;
                //wave.Frequency = BaseFrequency;
                //wave.Type = WaveType.Sinus;
                wave.Phase = 0;
                wave.Padding = 0.5;
                wave.Time = time;

            }

            int it = 0;
            foreach (SettupedMainWave mwave in MainWaves)
            {
                if (it >= spectrum.Waves.Count) { return; }//cheap fix for concurrency issues
                Wave waave = spectrum.Waves[it];
                waave.Amplitude = mwave.Amplitude;
                waave.Frequency = mwave.Frequency;
                if (waave.Frequency <= 0)
                { waave.Frequency = nfreq; }

                it++;
                foreach (SettupedHarmonic wave in mwave.Harmonics)
                {
                    if (it >= spectrum.Waves.Count) { return; }
                    Wave waave2 = spectrum.Waves[it];
                    waave2.Amplitude = waave.Amplitude * wave.Amplitude;
                    waave2.Frequency = waave.Frequency * wave.Multiplier;
                    it++;
                }
            }
        }

        private void ResetValues(double time, double nfreq)
        {//TODO separate from reset val2 for list edit concurrency issues
            ResetValues2(time, nfreq);
        }

        public UserControl? GetControl() => new SettuperModuleGui(this);

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed)
        {
            ResetValues(time, bpitch);
            return spectrum;
        }

        public void SetInput(IModule input) { }
    }

    public class SettupedMainWave
    {
        public List<SettupedHarmonic> Harmonics { get; set; } = new();

        //if Frequency is below 0 then the note is used instead
        public double Frequency { get; set; } = 0;
        public double Amplitude { get; set; } = 0.5;

        public SettupedMainWave() { }
        public SettupedMainWave(double frequency, double amplitude)
        {
            Frequency = frequency;
            Amplitude = amplitude;
        }
    }

    public class SettupedHarmonic
    {
        public int Multiplier { get; set; } = 2;
        public double Amplitude { get; set; } = 1;
    }
}
