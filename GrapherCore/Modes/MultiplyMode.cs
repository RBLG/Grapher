using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modes
{
    public class MultiplyMode : IMode
    {
        public double Intensity { get; set; } = 1;

        public double Center { get; set; } = 0.5; //change the point where the 0 singularity happen

        public Control GetControl()
        {
            return new GuiElement.ScaleSettings.ModeMultiplyGui(this);
        }

        public double Process(double value, double tab)
        {
            tab = (tab - Center) * Intensity + Center;
            return value * tab * 2;
        }
    }
}
