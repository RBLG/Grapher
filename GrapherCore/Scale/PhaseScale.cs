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

        public Control GetControl() => new PhaseGui();

        public bool Continuous => true;
        public bool IsLooping => false;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double val = spectrum.Time + wave.Phase;
            double modulo = val - (int)val;
            return modulo * size;
        }
        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Phase = mode.Process(wave.Phase, tval);
        }
    }
}
