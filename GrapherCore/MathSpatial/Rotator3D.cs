using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.MathSpatial
{
    public class Rotator3D
    {
        public const float PI2 = 2 * MathF.PI; //circumference of the circle of radius 1
        public const float Angle45d = 2 * MathF.PI * 1 / 8f;
        public const float Angle90d = 2 * MathF.PI * 2 / 8f;
        public const float Angle135d = 2 * MathF.PI * 3 / 8f;
        public const float Angle180d = 2 * MathF.PI * 4 / 8f;
        public const float Angle225d = 2 * MathF.PI * 5 / 8f;
        public const float Angle270d = 2 * MathF.PI * 6 / 8f;
        public const float Angle315d = 2 * MathF.PI * 7 / 8f;

        private float z;
        private float x;
        private float y;

        public float X { get => x; set { x = value % PI2; xrot = GetMultiplicatorX(x); } }
        public float Y { get => y; set { y = value % PI2; yrot = GetMultiplicatorY(y); } }
        public float Z { get => z; set { z = value % PI2; zrot = GetMultiplicatorZ(z); } }


        private Multiplicator3D xrot;
        private Multiplicator3D yrot;
        private Multiplicator3D zrot;

        public Rotator3D(float nx, float ny, float nz) {
            X = nx;
            Y = ny;
            Z = nz;
            xrot = GetMultiplicatorX(x);
            yrot = GetMultiplicatorY(y);
            zrot = GetMultiplicatorZ(z);
        }

        public G3DPoint Apply(G3DPoint pt) {
            pt = zrot.Translate(pt);
            pt = yrot.Translate(pt);
            pt = xrot.Translate(pt);
            return pt;
        }

        public Rotator3D GetReverse() {
            return new Rotator3D(-x, -y, -z); //HACK ?
        }


        private static Multiplicator3D GetMultiplicatorZ(float angle) { // maaaagic! (i hope!)
            float c = MathF.Cos(angle);
            float s = MathF.Sin(angle);
            return Multiplicator3D.NewAsNormal(
                       c, -s, 0,
                        s, c, 0,
                        0, 0, 1);
        }

        private static Multiplicator3D GetMultiplicatorY(float angle) {
            float c = MathF.Cos(angle);
            float s = MathF.Sin(angle);
            return Multiplicator3D.NewAsNormal(
                       c, 0, s,
                       0, 1, 0,
                      -s, 0, c);
        }

        private static Multiplicator3D GetMultiplicatorX(float angle) {
            float c = MathF.Cos(angle);
            float s = MathF.Sin(angle);
            return Multiplicator3D.NewAsNormal(
                        1, 0, 0,
                        0, c, -s,
                        0, s, c);
        }
    }
}
