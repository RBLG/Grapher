using Grapher.GuiElement.ScaleSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class HarmonicScale : IScale
    {
        //need to change the structure so that scale can be aware of pitch
        public double Max => 1;
        public double Min => 0;

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
        { return ScaleTo01(notscaled) * max; }
        public double UnscaleFrom(double scaled, double max)
        { return UnscaleFrom01(scaled / max); }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Frequency, size); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Frequency = UnscaleFrom01(mode.Process(ScaleTo01(wave.Frequency), tval));
        }

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl()
        {
            return new BlankScaleGui();
        }

        public string Label => "f(*base)";

        public Boolean Continuous => false;

    }
}
