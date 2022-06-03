using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class MeiFrequencyScale : IScale
    {
        public static readonly double min = ToMei(LinearFrequencyScale.min + 1);
        public static readonly double max = ToMei(LinearFrequencyScale.max + 1);
        public static readonly double range = max - min;

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
            return ToMei(notscaled);
        }

        public double To01(double notscaled)
        {
            return (ToMei(notscaled) - min) / range;
        }

        private static double ToMei(double lfreq)
        {
            return 2595 * Math.Log10(1 + lfreq / 700);
        }

        public double GetUnscaled(double scaled)
        {
            return FromMei(scaled);
        }

        public double From01(double scaled)
        {
            return FromMei(scaled / range + min);
        }

        private static double FromMei(double lfreq)
        {
            return (Math.Pow(10, lfreq / 2595) + 1) / 700;
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
            throw new NotImplementedException();
        }

        private readonly string label = "f(Hz)";

        public string GetLabel()
        {
            return label;
        }
    }
}
