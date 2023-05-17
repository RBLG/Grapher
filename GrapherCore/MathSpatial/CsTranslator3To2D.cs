using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    public class CsTranslator3To2D
    {
        protected readonly G2DPoint origin;

        protected readonly float x1, y1, z1,
                                 x2, y2, z2,
                                 x3, y3, z3;

        public CsTranslator3To2D(G2DPoint norigin,
                                            float nx1, float ny1,
                                            float nx2, float ny2,
                                            float nx3, float ny3) {
            origin = norigin;

            x1 = nx1;
            y1 = ny1;

            x2 = nx2;
            y2 = ny2;

            x3 = nx3;
            y3 = ny3;
        }



        public G2DPoint Translate(G3DPoint pt) {
            float nx = pt.x * x1 + pt.y * x2 + pt.z * x3;
            float ny = pt.x * y1 + pt.y * y2 + pt.z * y3;
            nx += origin.x;
            ny += origin.y;
            return new G2DPoint(nx, ny);
        }
    }
}
