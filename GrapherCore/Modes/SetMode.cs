using Grapher.GuiElement.ScaleSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Modes
{
    public class SetMode : IMode
    {
        public double Max {
            get => max;
            set {
                max = value;
                offset = (1 - max) / 2;
                //range = max * 2;
            }
        }

        //protected double range = 2;
        protected double offset = 0;
        protected double max = 1;

        public Control GetControl() => new ModeSetGui(this);

        public virtual double Process(double value, double tab)
        {
            return offset + tab * max;
            //return tab * range - max;
        }
    }
}
