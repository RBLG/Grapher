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
        public double Max { get; } = 1;
        public double Min { get; } = 0;

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
            return notscaled;
        }
        public double UnscaleFrom01(double scaled)
        {
            return scaled;
        }

        public double ScaleTo(double notscaled, double max)
        {
            return notscaled;
        }
        public double UnscaleFrom(double scaled, double max)
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

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public bool IsContinuous()
        { return true; }

        public string Label { get; } = "a(??)";
    }
}
