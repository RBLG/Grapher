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
    public class FrequencyExponantialScale : IInputScale, IOutputScale
    {
        public static readonly double min = Math.Log(FrequencyLinearScale.min + 1);
        public static readonly double max = Math.Log(FrequencyLinearScale.max + 1);
        public readonly double range = max - min;
        public double Min { get; } = min;
        public double Max { get; } = max;

        public double Scale(double notscaled)//+1 so no positive value can give negative value (not that it matter)
        { return Math.Log(notscaled + 1); }
        public double Unscale(double scaled)
        { return Math.Exp(scaled) - 1; }

        public double ScaleTo01(double notscaled)
        { return (Scale(notscaled) - min) / range; }
        public double UnscaleFrom01(double scaled)
        { return Unscale(scaled * range + min); }

        public double ScaleTo(double notscaled, double size)
        { return ScaleTo01(notscaled) * size; }
        public double UnscaleFrom(double scaled, double size)
        { return UnscaleFrom01(scaled / size); }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Frequency, size); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

        public List<Graduation> GetMilestones()
        {
            return new List<Graduation>() {
            new Graduation("20", 0),
            new Graduation("200", ScaleTo01(200)),
            new Graduation("2000", ScaleTo01(2000)),
            new Graduation("20 000", 1)
            };
        }

        public Control GetControl() => new FrequencyExponentialGui();

        public bool Continuous => true;
        public string Label => "f(Hz)";
        public bool IsLooping => false;

        public bool IsCumulative => false;

    }
}
