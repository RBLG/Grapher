using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Modes
{
    public class AddMode : SetMode
    {
        public override double Process(double value, double tab)
        {
            return value + base.Process(value, tab);
        }
    }
}
