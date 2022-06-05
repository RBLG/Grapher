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
        public const double range = max - min;


        private readonly List<Milestone> milestones;
        public LinearFrequencyScale()
        {
            milestones = new List<Milestone>() {
            new Milestone("20", 0),
            new Milestone("200", To01(200)),
            new Milestone("2000", To01(2000)),
            new Milestone("20 000", 1)
            };
        }
        public double GetMax()
        {
            return max;
        }

        public double GetMin()
        {
            return min;
        }

        public double GetScaled(double notscaled)
        {
            return notscaled;
        }

        public double To01(double notscaled)
        {
            return (notscaled - min) / range;
        }

        public double GetUnscaled(double scaled)
        {
            return scaled;
        }

        public double From01(double scaled)
        {
            return scaled * range + min;
        }

        public double PickValue(Spectrum.Wave wave, double time, Spectrum spectrum)
        {
            return wave.Frequency;
        }

        public void SetValue(double value, Wave wave, double time, Spectrum spectrum)
        {
            wave.Frequency = value;
        }

        public List<Milestone> GetMilestones()
        {
            return milestones;
        }

        private readonly string label = "f(Hz)";

        public string GetLabel()
        {
            return label;
        }
    }
}
