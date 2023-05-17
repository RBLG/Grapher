using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    public class Translator3D
    {
        public float x, y, z;

        public Translator3D(float nx, float ny, float nz) {
            x = nx;
            y = ny;
            z = nz;
        }

        public G3DPoint Apply(G3DPoint pt) {
            return new(pt.x + x, pt.y + y, pt.z + z);
        }

        public Translator3D GetReverse() {
            return new Translator3D(-x, -y, -z);
        }
    }
}
