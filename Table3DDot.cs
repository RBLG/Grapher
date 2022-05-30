using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher
{
    public class Table3DDot
    {
        private readonly Func<Point3D> ori;
        private readonly Func<Point3D> xaxis;
        private readonly Func<Point3D> yaxis;
        private readonly Func<Point3D> zaxis;

        private double x;
        private double y;
        private double z;
        public double X { get => x; private set { x = value; ScreenX = ori().X + x * xaxis().X + y * yaxis().X + z * zaxis().X; } }
        public double Y { get => y; private set { y = Math.Max(0, Math.Min(100, value)); ScreenY = ori().Y + x * xaxis().Y + y * yaxis().Y + z * zaxis().Y; } }
        public double Z { get => z; private set { z = value; ScreenZ = ori().Z + x * xaxis().Z + y * yaxis().Z + z * zaxis().Z; } }
        public double ScreenX { get; private set; }
        public double ScreenY { get; private set; }
        public double ScreenZ { get; private set; }

        public Table3DDot(Func<Point3D> nori, Func<Point3D> nxaxis, Func<Point3D> nyaxis, Func<Point3D> nzaxis, double nx, double ny, double nz)
        {
            ori = nori;
            xaxis = nxaxis;
            yaxis = nyaxis;
            zaxis = nzaxis;
            x = nx;
            y = ny;
            z = nz;
            X = nx;
            Y = ny;
            Z = nz;
        }

        public void ReverseAddY(double y)
        {
            //temporary
            this.Y -= y * 1;
        }

        internal double DistanceTo(Point pt)
        {
            return Math.Sqrt(Math.Pow(pt.X - ScreenX, 2) + Math.Pow(pt.Y - ScreenY, 2));
        }

        public double GetBrushDistanceTo(Table3DDot pt)
        {
            return Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Z - Z, 2));
        }
    }
}
