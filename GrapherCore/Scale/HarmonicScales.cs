using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class HarmonicScale : IScale
    {
        //need to change the structure so that scale can be aware of pitch
        public double Max { get; }
        public double Min { get; }

        public double Scale(double notscaled)
        {
            throw new NotImplementedException();
        }
        public double Unscale(double scaled)
        {
            throw new NotImplementedException();
        }

        public double ScaleTo01(double notscaled)
        {
            throw new NotImplementedException();
        }
        public double UnscaleFrom01(double scaled)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
            //return wave.Frequency;
        }

        public void SetValue(double value, Wave wave, double time, Spectrum spectrum)
        {
            throw new NotImplementedException();
            //return wave.Frequency;
        }

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public string Label { get; } = "f(*base)";

        public Boolean IsContinuous()
        {
            return false;
        }

    }
}
