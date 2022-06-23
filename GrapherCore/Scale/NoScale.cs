using Grapher.Modes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Scale
{
    public class NoScale : IScale
    {
        public double Min => 0;

        public double Max => 0;

        public string Label => "none";

        public bool Continuous => true;

        public Control GetControl()
        {
            return new GuiElement.ScaleSettings.BlankScaleGui();
        }

        public List<Graduations> GetMilestones()
        {
            return new();
        }

        public double PickValueTo(Spectrum.Wave wave, Spectrum spectrum, double size) => 0;

        public void ProcessValue(Spectrum.Wave wave, Spectrum spectrum, double size, IMode mode, double tval)
        {
            return;
        }

        public double Scale(double notscaled) => 0;

        public double ScaleTo(double notscaled, double size) => 0;

        public double ScaleTo01(double notscaled) => 0;


        public double Unscale(double scaled) => 0;

        public double UnscaleFrom(double scaled, double size) => 0;

        public double UnscaleFrom01(double scaled) => 0;
    }
}
