using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class FrequencyMeiScale : IScale
    {
        public static readonly double min = ToMei(FrequencyLinearScale.min + 1);
        public static readonly double max = ToMei(FrequencyLinearScale.max + 1);
        public static readonly double range = max - min;

        private readonly List<Graduations> milestones;
        public FrequencyMeiScale()
        {
            milestones = new() {
            new Graduations("20", 0),
            new Graduations("200", ScaleTo01(200)),
            new Graduations("2000", ScaleTo01(2000)),
            new Graduations("20 000", 1)
            };
        }

        public double Min => min;
        public double Max => max;

        public string Label => "f(Hz)";

        public List<Graduations> GetMilestones()
        {
            return milestones;
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.FrequencyMeiGui();
        }

        public bool Continuous => true;

        public double Scale(double notscaled) /*                */ => ToMei(notscaled);
        public double ScaleTo01(double notscaled) /*            */ => (ToMei(notscaled) - min) / range;
        public double ScaleTo(double notscaled, double max) /*  */ => ScaleTo01(notscaled) * max;

        public double Unscale(double scaled) /*                 */ => FromMei(scaled);
        public double UnscaleFrom01(double scaled) /*           */ => FromMei(scaled / range + min);
        public double UnscaleFrom(double scaled, double max) /* */ => UnscaleFrom01(scaled / max);

        private static double ToMei(double lfreq) /*            */ => 2595 * Math.Log10(1 + lfreq / 700);
        private static double FromMei(double lfreq) /*          */ => (Math.Pow(10, lfreq / 2595) + 1) / 700;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Frequency, size); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

    }
}
