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
            return 1; //it cannot work without base frequency, sooooooo
        }
        public double Unscale(double scaled)
        {
            return 1;
        }

        public double ScaleTo01(double notscaled)
        {
            return 1;
        }
        public double UnscaleFrom01(double scaled)
        {
            return 1;
        }

        public double ScaleTo(double notscaled, double max)
        { return ScaleTo01(notscaled) * max; }
        public double UnscaleFrom(double scaled, double max)
        { return UnscaleFrom01(scaled / max); }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            return wave.Frequency / spectrum.Waves[0].Frequency;
        }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            double bpitch = spectrum.Waves[0].Frequency;
            double val = wave.Frequency / bpitch;
            val = mode.Process(val, tval);
            wave.Frequency = val * bpitch;
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
