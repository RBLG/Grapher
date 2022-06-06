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
        public double GetMax()
        {
            throw new NotImplementedException();
        }

        public double GetMin()
        {
            throw new NotImplementedException();
        }

        public double GetScaled(double notscaled)
        {
            throw new NotImplementedException();
        }

        public double To01(double notscaled)
        {
            throw new NotImplementedException();
        }

        public double GetUnscaled(double scaled)
        {
            throw new NotImplementedException();
        }

        public double From01(double scaled)
        {
            throw new NotImplementedException();
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

        public List<Milestone> GetMilestones()
        {
            throw new NotImplementedException();
        }

        private readonly string label = "f(*base)";

        public string GetLabel()
        {
            return label;
        }
    }
}
