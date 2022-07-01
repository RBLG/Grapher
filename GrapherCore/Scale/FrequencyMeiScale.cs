using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class FrequencyMeiScale : IInputScale, IOutputScale
    {
        public static readonly double min = ToMei(FrequencyLinearScale.min + 1);
        public static readonly double max = ToMei(FrequencyLinearScale.max + 1);
        public static readonly double range = max - min;

        public double Min => min;
        public double Max => max;

        public string Label => "f(Hz)";

        public List<Graduations> GetMilestones()
        {
            return new() {
            new Graduations("20", 0),
            new Graduations("200", ScaleTo01(200)),
            new Graduations("2000", ScaleTo01(2000)),
            new Graduations("20 000", 1)
            };
        }

        public Control GetControl() => new FrequencyMeiGui();

        public bool Continuous => true;
        public bool IsLooping => false;

        public double ScaleTo01(double notscaled) /*            */ => (ToMei(notscaled) - Min) / range;
        public double UnscaleFrom01(double scaled) /*           */ => FromMei(scaled / range + Min);

        private static double ToMei(double lfreq) /*            */ => 2595 * Math.Log10(1 + lfreq / 700);
        private static double FromMei(double lfreq) /*          */ => (Math.Pow(10, lfreq / 2595) + 1) / 700;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo01(wave.Frequency) * size; }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

    }
}
