using Grapher.Units;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Scale
{
    public interface IScale
    {
        double GetScaled(double notscaled);

        double GetMin();
        double GetMax();

        double To01(double notscaled);
    }
}
