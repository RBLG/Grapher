using Grapher.GuiElement.SettuperModuleGuis;
using Grapher.Misc;
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

        private List<WaveModel> models = new();
        private Spectrum spectrum = new();

        public string Name => "Settup Module";

        public IModule? Input => null;

        public SettuperModule() {
            AddWave(new(0, 0.1));
        }

        public void AddWave(SettupedMainWave mwave) {
            MainWaves.Add(mwave);
            UpdateStock();
        }

        public void RemoveWave(SettupedMainWave mwave) {
            MainWaves.Remove(mwave);
            UpdateStock();
        }

        public void UpdateStock() {
            List<WaveModel> nmodels = new();
            foreach (SettupedMainWave mwave in MainWaves) {
                nmodels.Add(new() {
                    Frequency = (v) => {
                        double freq = mwave.Frequency;
                        return (freq == 0) ? v : freq;
                    },
                    Amplitude = (v) => mwave.Amplitude,
                });
                foreach (SettupedHarmonic wave in mwave.Harmonics) {
                    nmodels.Add(new() {
                        Frequency = (v) => {
                            double mfreq = mwave.Frequency;
                            return ((mfreq == 0) ? v : mfreq) * wave.FrequencyMultiplier;
                        },
                        Amplitude = (v) => mwave.Amplitude * wave.AmplitudeMultiplier / wave.FrequencyMultiplier,
                    });
                }
            }
            Spectrum nspec = new();
            foreach (WaveModel model in nmodels) {
                nspec.Waves.Add(new());
            }
            models = nmodels;
            spectrum = nspec;
        }

        public UserControl? GetControl() => new SettuperModuleGui(this);

        public Spectrum GetSpectrum(double time, double timeoff, double bpitch, double seed) {
            List<WaveModel> models = this.models;
            Spectrum spec = this.spectrum;
            spec.Reset(time, timeoff, bpitch, seed);

            var range = SRange.New(0, models.Count);//TODO remove the creation of a new range 43k time per second
            foreach (int it in range) {
                Wave wave = spec.Waves[it];
                WaveModel model = models[it];
                model.ApplyTo(wave, bpitch, 0.2, 0, 0.5, time);
            }
            return spec;
        }

        public void SetInput(IModule input) { }
    }

    public class SettupedMainWave
    {
        public List<SettupedHarmonic> Harmonics { get; set; } = new();

        //if Frequency is below 0 then the note is used instead
        public double Frequency { get; set; } = 0;
        public double Amplitude { get; set; } = 0.2;

        public SettupedMainWave() { }
        public SettupedMainWave(double frequency, double amplitude) {
            Frequency = frequency;
            Amplitude = amplitude;
        }
    }

    public class SettupedHarmonic
    {
        public double FrequencyMultiplier { get; set; } = 2;
        public double AmplitudeMultiplier { get; set; } = 0.5;
    }

    public class WaveModel
    {
        public Func<double, double> Frequency { get; set; } = (v) => v;
        public Func<double, double> Amplitude { get; set; } = (v) => v;
        public Func<double, double> Phase { get; set; } = (v) => v;
        public Func<double, double> Padding { get; set; } = (v) => v;
        public Func<double, double> Time { get; set; } = (v) => v;

        public void ApplyTo(Wave wave, double freq, double amp, double phase, double pad, double time) {
            wave.Frequency = Frequency(freq);
            wave.Amplitude = Amplitude(amp);
            wave.PhaseOffset = Phase(phase);
            wave.Padding = Padding(pad);
            wave.Time = Time(time);
        }
    }
}
