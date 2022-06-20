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

        public Control GetControl()
        {
            return new GuiElement.ScaleSettings.ModeMultiplyGui(this);
        }

        public double Process(double value, double tab)
        {
            tab = (tab - 0.5) * Intensity + 0.5;
            return value * tab * 2;//*2 so that 0,5 make stuff unchanged
        }
    }
}
