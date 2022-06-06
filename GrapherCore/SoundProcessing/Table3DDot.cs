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
        public double X { get => x; set { x = value; RecalculateScreenXY(); } }
        public double Y { get => y; set { y = Math.Max(Table.MIN, Math.Min(Table.MAX, value)); RecalculateScreenXY(); } }
        public double Z { get => z; set { z = value; RecalculateScreenXY(); } }
        public float ScreenX { get; private set; }
        public float ScreenY { get; private set; }
        public float ScreenZ { get; private set; }

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

        private void RecalculateScreenXY()
        {
            ScreenX = (float)(ori().X + x * xaxis().X + y * yaxis().X + z * zaxis().X);
            ScreenY = (float)(ori().Y + x * xaxis().Y + y * yaxis().Y + z * zaxis().Y);
            ScreenZ = (float)(ori().Z + x * xaxis().Z + y * yaxis().Z + z * zaxis().Z);
        }

        //to remove
        public void ReverseAddY(double y)
        {
            this.Y -= y * 1;
        }

        internal double DistanceTo(Point pt)
        {
            return Math.Sqrt(Math.Pow(pt.X - ScreenX, 2) + Math.Pow(pt.Y - ScreenY, 2));
        }

        public double GetBrushDistanceTo(Table3DDot pt)
        {
            return Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Y - Y, 2) + Math.Pow(pt.Z - Z, 2));
        }
    }
}
