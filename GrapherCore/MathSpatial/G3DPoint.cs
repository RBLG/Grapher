using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    /// <summary>
    /// geometry point in 3 dimensional space
    /// </summary>
    public class G3DPoint
    {
        public readonly float x, y, z;

        public G3DPoint(float nx, float ny, float nz) {
            x = nx;
            y = ny;
            z = nz;
        }

        public float DistanceTo(G3DPoint pt) {
            float dx = x - pt.x,
                  dy = y - pt.y,
                  dz = z - pt.z;
            return MathF.Sqrt(dx * dx + dy * dy + dz * dz);
        }
    }
}
