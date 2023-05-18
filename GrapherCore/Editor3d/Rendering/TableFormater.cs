using Grapher.MathSpatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Editor3d.Rendering
{
    public class TableFormater
    {
        protected Func<RawTable> tableprovider;
        protected float widthgap;
        protected float lengthgap;
        protected float heightscale;
        protected float heightoffset;

        public TableFormater(float nwgap, float nlgap, float nhscale, float nhoffset, Func<RawTable> ntable) {
            widthgap = nwgap;
            lengthgap = nlgap;
            heightscale = nhscale;
            heightoffset = nhoffset;
            tableprovider = ntable;
        }

        public G3DPoint Format(uint x, uint y) {
            RawTable table = tableprovider();
            float nx = (x - table.width_ / 2f) * widthgap;
            float ny = (y - table.height / 2f) * lengthgap;
            float nz = (float)table.Get(x, y) * heightscale + heightoffset;
            return new(nx, ny, nz);
        }

        public G3DPoint FormatAsAtZ(float x, float y, float height) {
            RawTable table = tableprovider();
            float nx = (x - table.width_ / 2f) * widthgap;
            float ny = (y - table.height / 2f) * lengthgap;
            float nz = height * heightscale + heightoffset;
            return new(nx, ny, nz);
        }
    }
}
