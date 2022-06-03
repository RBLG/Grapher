using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    internal class LinearAmplitudeScale : IScale
    {
        public double GetMax()
        {
            return 1;
        }

        public double GetMin()
        {
            return 0;
        }

        public double GetScaled(double notscaled)
        {
            return notscaled;
        }

        public double To01(double notscaled)
        {
            return notscaled;
        }

        public double GetUnscaled(double scaled)
        {
            return scaled;
        }

        public double From01(double scaled)
        {
            return scaled;
        }

        public double PickValue(Wave wave, double time, Spectrum spectrum)
        {
            return wave.Amplitude;
        }

        public void SetValue(double value, Wave wave, double time, Spectrum spectrum)
        {
            wave.Amplitude = value;
        }

        public List<Milestone> GetMilestones()
        {
            throw new NotImplementedException();
        }

        private readonly string label = "a(??)";

        public string GetLabel()
        {
            return label;
        }
    }
}
