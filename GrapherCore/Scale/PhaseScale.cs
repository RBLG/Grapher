using Grapher.GuiElement.ScaleSettings;
using Grapher.Scale.Related;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Grapher.Spectrum;

namespace Grapher.Scale
{
    public class PhaseScale : IInputScale, IOutputScale
    {
        //public double Min => 0;
        //public double Max => 1;

        public string Label => "Phase";

        public List<Graduations> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl()
        {
            return new PhaseGui();
        }

        public bool Continuous => true;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            return wave.Phase * size;
        }
        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Phase = mode.Process(wave.Phase, tval);
        }
    }
}
