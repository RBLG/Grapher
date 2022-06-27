using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    //scale where 10 has 10 less place on the table than 100
    public class FrequencyLinearScale : IInputScale, IOutputScale
    {
        public const double min = 20;
        public const double max = 20_000;
        public double Min => min;
        public double Max => max;
        public const double range = max - min;


        private readonly List<Graduations> milestones;
        public FrequencyLinearScale()
        {
            milestones = new List<Graduations>() {
            new Graduations("20", 0),
            new Graduations("200", ScaleTo01(200)),
            new Graduations("2000", ScaleTo01(2000)),
            new Graduations("20 000", 1)
            };
        }

        public double ScaleTo01(double notscaled)
        { return (notscaled - min) / range; }
        public double UnscaleFrom01(double scaled)
        { return scaled * range + min; }

        public double ScaleTo(double notscaled, double max)
        { return ScaleTo01(notscaled) * max; }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo01(wave.Frequency) * size; }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

        public List<Graduations> GetMilestones()
        {
            return milestones;
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.FrequencyLinearGui();
        }

        public bool Continuous => true;
        public bool IsLooping => false;
        public string Label { get; } = "f(Hz)";
    }
}
