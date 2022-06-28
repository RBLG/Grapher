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

        public double Offset { set; get; } = 0;

        public Control GetControl() => new PhaseGui(this);

        public bool Continuous => true;
        public bool IsLooping => true;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            double val = wave.Frequency * ( spectrum.Time / 1000 + wave.Phase);
            val -= (int)val;//modulo
            return val * size;
        }
        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Phase = mode.Process(wave.Phase + Offset, tval);
        }
    }
}
