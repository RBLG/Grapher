using Grapher.MathSpatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Misc
{
    public class OrthoCamera
    {
        //from internal 3D coords to screen coords
        protected Scalator3D prescale = new(-1, 1, 1);
        protected Translator3D preoffset = new(0, 0, 0);
        protected Rotator3D rotation = new(0, 0, 0);
        protected Scalator3D postscale = new(1, 1, 1);
        protected Translator3D postoffset = new(0, 0, 0);

        public float SideRotation { get => rotation.Z; set => rotation.Z = value; }
        public float HeightRotation { get => rotation.X; set => rotation.X = Math.Clamp(value, Rotator3D.Angle90d, Rotator3D.Angle180d); }
        public float CanvasWidth { set { postoffset.x = value / 2; } }
        public float CanvasHeight { set { postoffset.y = value / 2; } }

        public OrthoCamera() {
            SideRotation = -Rotator3D.Angle135d + Rotator3D.Angle45d / 2;
            HeightRotation = Rotator3D.Angle90d + Rotator3D.Angle45d / 2;
        }

        public G2DPoint ToScreenSpace(G3DPoint pt) {
            pt = ToViewSpace(pt);
            return new(pt.x, pt.y);
        }

        public G3DPoint ToViewSpace(G3DPoint pt) {
            pt = prescale.Apply(pt);
            pt = preoffset.Apply(pt);
            pt = rotation.Apply(pt);
            pt = postscale.Apply(pt);
            pt = postoffset.Apply(pt);
            return pt;
        }

        public G3DPoint GetDirection() {
            G3DPoint pt = new(1, 1, 1);
            return ToViewSpace(pt);
        }
    }
}
