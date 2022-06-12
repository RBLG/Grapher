using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class ExponantialFrequencyScale : IScale
    {
        public static readonly double min = Math.Log(LinearFrequencyScale.min + 1);
        public static readonly double max= Math.Log(LinearFrequencyScale.max + 1);
        public readonly double range = max - min;
        public double Min { get; } = min;
        public double Max { get; } = max;

        private readonly List<Graduations> milestones;
        public ExponantialFrequencyScale()
        {
            milestones = new List<Graduations>() {
            new Graduations("20", 0),
            new Graduations("200", ScaleTo01(200)),
            new Graduations("2000", ScaleTo01(2000)),
            new Graduations("20 000", 1)
            };
        }

        public double Scale(double notscaled)
        { //+1 so no positive value can give negative value (not that it matter)
            return Math.Log(notscaled + 1);
        }
        public double Unscale(double scaled)
        {
            return Math.Exp(scaled) - 1;
        }

        public double ScaleTo01(double notscaled)
        {
            return (Scale(notscaled) - min) / range;
        }
        public double UnscaleFrom01(double scaled)
        {
            return Unscale(scaled * range + min);
        }

        public double ScaleTo(double notscaled, double max)
        {
            return ScaleTo01(notscaled) * max;
        }
        public double UnscaleFrom(double scaled, double max)
        {
            return UnscaleFrom01(scaled / max);
        }

        public double PickValue(Wave wave, double time, Spectrum spectrum)
        {
            return wave.Frequency;
        }
        public void SetValue(double value, Wave wave, double time, Spectrum spectrum)
        {
            wave.Frequency = value;
        }

        public List<Graduations> GetMilestones()
        {
            return milestones;
        }

        public bool IsContinuous()
        { return true; }

        public string Label { get; } = "f(Hz)";

    }
}
