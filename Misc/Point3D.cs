using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    public class Point3D
    {
        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }

        public Point3D(double nx, double ny, double nz)
        {
            X = nx;
            Y = ny;
            Z = nz;
        }

        public Point3D() : this(0, 0, 0) { }
    }
}
