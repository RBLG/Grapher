using Grapher.GuiElement.ScaleSettings;
using Grapher.Modes;
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
    public class NoScale : IInputScale, IOutputScale
    {
        public string Label => "none";

        public bool Continuous => true;
        public bool IsLooping => false;


        public Control GetControl() => new BlankScaleGui();

        public List<Graduation> GetMilestones()
        {
            return new();
        }

        public double PickValueTo(Wave wave, Spectrum spectrum, uint size) => 0;

        public (uint, uint, double) PickValueTo2(Wave wave, Spectrum spectrum, uint size)
        { return (0, 0, 0); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, IMode mode, double tval)
        { return; }


    }
}
