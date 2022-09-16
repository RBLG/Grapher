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
    public class PaddingScale : IOutputScale, IInputScale
    {
        public static double Min => 0;
        public static double Max => 1;

        public string Label => "Padding";

        public List<Graduation> GetMilestones()
        {
            return new()
            {
                new Graduation("right",0),
                new Graduation("left",1)
            };
        }

        public Control GetControl() => new BlankScaleGui();


        public bool Continuous => true;
        public bool IsLooping => false;

        public double PickValueTo(Wave wave, Spectrum spectrum, int size)
        {
            return wave.Padding * size;
        }

        public (int, int, double) PickValueTo2(Wave wave, Spectrum spectrum, int size)
        { return Table.PrepareInterpolation(PickValueTo(wave, spectrum, size), size, IsLooping); }

        public void ProcessValue(Wave wave, Spectrum spectrum, double size, Modes.IMode mode, double tval)
        {
            wave.Padding = Math.Clamp(mode.Process(wave.Padding, tval), Min, Max);
        }
    }
}
