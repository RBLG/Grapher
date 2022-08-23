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
    internal class AmplitudeLinearScale : IInputScale, IOutputScale
    {
        //public double Max => 1;
        //public double Min => 0;

        public string Label { get; } = "a(??)";

        public List<Graduation> GetMilestones()
        {
            throw new NotImplementedException();
        }

        public Control GetControl() => new BlankScaleGui();

        public bool Continuous => true;
        public bool IsLooping => false;

        public int GetCumulativeStackNumber(Wave wave, Spectrum spectrum, double size)
        {
            return 0;
        }

        public double PickValueTo(Wave wave, Spectrum spectrum, double size)
        { return wave.Amplitude * size; }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Amplitude = mode.Process(wave.Amplitude, tval);
        }
    }
}
