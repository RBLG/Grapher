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

        public int GetCumulativeStackNumber(Spectrum.Wave wave, Spectrum spectrum, double size)
        {
            return 0;
        }

        public Control GetControl() => new BlankScaleGui();

        public List<Graduation> GetMilestones()
        {
            return new();
        }

        public double PickValueTo(Spectrum.Wave wave, Spectrum spectrum, double size) => 0;

        public void ProcessValue(Spectrum.Wave wave, Spectrum spectrum, double size, IMode mode, double tval)
        { return; }


    }
}
