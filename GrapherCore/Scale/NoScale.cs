using Grapher.GuiElement.ScaleSettings;
using Grapher.Modes;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Scale
{
    public class NoScale : IInputScale, IOutputScale
    {
        public string Label => "none";

        public bool Continuous => true;
        public bool IsLooping => false;

        public Control GetControl() => new BlankScaleGui();

        public List<Graduations> GetMilestones()
        {
            return new();
        }

        public double PickValueTo(Spectrum.Wave wave, Spectrum spectrum, double size) => 0;

        public void ProcessValue(Spectrum.Wave wave, Spectrum spectrum, double size, IMode mode, double tval)
        { return; }


    }
}
