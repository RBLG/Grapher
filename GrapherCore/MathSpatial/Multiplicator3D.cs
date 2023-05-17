using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    public class Multiplicator3D
    {
        public float x1, y1, z1,
                     x2, y2, z2,
                     x3, y3, z3;

        public Multiplicator3D(float nx1, float ny1, float nz1,
                               float nx2, float ny2, float nz2,
                               float nx3, float ny3, float nz3
            ) {
            x1 = nx1;
            y1 = ny1;
            z1 = nz1;

            x2 = nx2;
            y2 = ny2;
            z2 = nz2;

            x3 = nx3;
            y3 = ny3;
            z3 = nz3;
        }

        public G3DPoint Translate(G3DPoint pt) {
            float nx = pt.x * x1 + pt.y * x2 + pt.z * x3;
            float ny = pt.x * y1 + pt.y * y2 + pt.z * y3;
            float nz = pt.x * z1 + pt.y * z2 + pt.z * z3;
            return new G3DPoint(nx, ny, nz);
        }

        public static Multiplicator3D NewAsMirrored(float nx1, float ny1, float nz1,
                                                    float nx2, float ny2, float nz2,
                                                    float nx3, float ny3, float nz3
            ) {
            return new Multiplicator3D(nx1, ny1, nz1, nx2, ny2, nz2, nx3, ny3, nz3);
        }

        public static Multiplicator3D NewAsNormal(float nx1, float nx2, float nx3,
                                                  float ny1, float ny2, float ny3,
                                                  float nz1, float nz2, float nz3
            ) {
            return new Multiplicator3D(nx1, ny1, nz1, nx2, ny2, nz2, nx3, ny3, nz3);
        }

    }
}
