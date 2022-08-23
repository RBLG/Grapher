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
    public class HarmonicScale : IInputScale, IOutputScale
    {
        //need to change the structure so that scale can be aware of pitch
        //public double Max => 1;
        //public double Min => 0;

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        {
            return (wave.Frequency / spectrum.Waves[0].Frequency) - 1;
        }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            double bpitch = spectrum.Waves[0].Frequency;
            double val = wave.Frequency / bpitch - 1;
            val = mode.Process(val, tval);
            wave.Frequency = val * bpitch;
        }

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new BlankScaleGui();

        public string Label => "f(*base)";

        public bool Continuous => false;
        public bool IsLooping => false;

        public int GetCumulativeStackNumber(Wave wave, Spectrum spectrum, double size)
        {
            return 0;
        }
    }
}
