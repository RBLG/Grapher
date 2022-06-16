using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class PaddingScale : IScale
    {
        public double Min => 0;
        public double Max => 1;

        public string Label => "Padding";

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.PaddingGui();
        }

        public bool Continuous => true;

        public double Scale(double notscaled) /*                    */ => notscaled;
        public double ScaleTo01(double notscaled) /*                */ => notscaled;
        public double ScaleTo(double notscaled, double size) /*     */ => notscaled * size;

        public double Unscale(double scaled) /*                     */ => scaled;
        public double UnscaleFrom01(double scaled) /*               */ => scaled;
        public double UnscaleFrom(double scaled, double size) /*    */ => scaled / size;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Padding, size); }
       
        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Padding = UnscaleFrom01(mode.Process(ScaleTo01(wave.Padding), tval));
        }
    }
}
