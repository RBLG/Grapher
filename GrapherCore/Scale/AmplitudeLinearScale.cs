using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    internal class AmplitudeLinearScale : IScale
    {
        public double Max => 1;
        public double Min => 0;

        public string Label { get; } = "a(??)";

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public System.Windows.Forms.Control GetControl()
        {
            return new GuiElement.ScaleSettings.BlankScaleGui();
        }

        public bool Continuous => true;

        public double Scale(double notscaled) /*                */ => notscaled;
        public double ScaleTo01(double notscaled) /*            */ => notscaled;
        public double ScaleTo(double notscaled, double size) /* */ => notscaled * size;

        public double Unscale(double scaled) /*                 */ => scaled;
        public double UnscaleFrom01(double scaled) /*           */ => scaled;
        public double UnscaleFrom(double scaled, double size) /**/ => scaled / size;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return ScaleTo(wave.Amplitude, size); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Amplitude = UnscaleFrom01(mode.Process(ScaleTo01(wave.Amplitude), tval));
        }
    }
}
