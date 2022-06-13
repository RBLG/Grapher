using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    internal class PaddingScale : IScale
    {
        public double Min => 0;

        public double Max => 1;

        public string Label => "Padding";

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public bool IsContinuous()
        {
            return true;
        }

        public double PickValue(Spectrum.Wave wave, double time, Spectrum spectrum)
        {
            return wave.Padding;
        }

        public double Scale(double notscaled)
        {
            return notscaled;
        }

        public double ScaleTo(double notscaled, double max)
        {
            return notscaled;
        }

        public double ScaleTo01(double notscaled)
        {
            return notscaled;
        }

        public void SetValue(double value, Spectrum.Wave wave, double time, Spectrum spectrum)
        {
            wave.Padding = value;
        }

        public double Unscale(double scaled)
        {
            return scaled;
        }

        public double UnscaleFrom(double scaled, double max)
        {
            return scaled;
        }

        public double UnscaleFrom01(double scaled)
        {
            return scaled;
        }
    }
}
