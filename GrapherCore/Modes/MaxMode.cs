using Grapher.GuiElement.ScaleSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modes
{
    public class MaxMode : IMode
    {
        public double Intensity { get; set; } = 1;

        public Control GetControl() => new ModeMaxGui(this);

        public double Process(double value, double tab) {
            tab *= Intensity;
            if (value < 0) {
                return (-tab < value) ? value : -tab;
            } else {
                return (value < tab) ? value : tab;
            }
        }
    }
}
