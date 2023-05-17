using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    /// <summary>
    /// geometry point in 2 dimensional space
    /// </summary>
    public class G2DPoint
    {
        public readonly float x, y;

        public G2DPoint(float nx, float ny) {
            x = nx;
            y = ny;
        }
    }
}
