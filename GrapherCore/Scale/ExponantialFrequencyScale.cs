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
        public static readonly double max = Math.Log(LinearFrequencyScale.max + 1);
        public static readonly double range = max - min;


        private readonly List<Milestone> milestones;
        public ExponantialFrequencyScale()
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
            return Math.Log(notscaled + 1);//+1 so no positive value can give negative value (not that it matter)
        }

        public double To01(double notscaled)
        {
            return (Math.Log(notscaled + 1) - min) / range;
        }

        public double GetUnscaled(double scaled)
        {
            return Math.Exp(scaled) - 1;
        }

        public double From01(double scaled)
        {
            return Math.Exp(scaled * range + min) - 1;
        }

        public double PickValue(Wave wave, double time, Spectrum spectrum)
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
