using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    //scale where 10 has 10 less place on the table than 100
    public class LinearFrequencyScale : IScale
    {
        public const double min = 20;
        public const double max = 20_000;
        public double Min { get; } = min;
        public double Max { get; } = max;
        public const double range = max - min;


        private readonly List<Graduations> milestones;
        public LinearFrequencyScale()
        {
            milestones = new List<Graduations>() {
            new Graduations("20", 0),
            new Graduations("200", ScaleTo01(200)),
            new Graduations("2000", ScaleTo01(2000)),
            new Graduations("20 000", 1)
            };
        }

        public double Scale(double notscaled)
        {
            return notscaled;
        }
        public double Unscale(double scaled)
        {
            return scaled;
        }

        public double ScaleTo01(double notscaled)
        {
            return (notscaled - min) / range;
        }
        public double UnscaleFrom01(double scaled)
        {
            return scaled * range + min;
        }

        public double ScaleTo(double notscaled, double max)
        {
            return ScaleTo01(notscaled) * max;
        }
        public double UnscaleFrom(double scaled, double max)
        {
            return UnscaleFrom01(scaled / max);
        }

        public double PickValue(Spectrum.Wave wave, double time, Spectrum spectrum)
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
