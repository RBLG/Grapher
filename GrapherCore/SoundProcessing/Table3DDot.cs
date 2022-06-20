using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Grapher
{
    public class Table3DDot
    {
        [JsonIgnore]
        public Func<Point3D>? Ori { get; private set; }
        [JsonIgnore]
        public Func<Point3D>? Xaxis { get; private set; }
        [JsonIgnore]
        public Func<Point3D>? Yaxis { get; private set; }
        [JsonIgnore]
        public Func<Point3D>? Zaxis { get; private set; }

        private double x;
        private double y;
        private double z;
        public double X { get => x; set { x = value; RecalculateScreenXY(); } }
        public double Y { get => y; set { y = Math.Max(Table.MIN, Math.Min(Table.MAX, value)); RecalculateScreenXY(); } }
        public double Z { get => z; set { z = value; RecalculateScreenXY(); } }

        [JsonIgnore]
        public float ScreenX { get; private set; }
        [JsonIgnore]
        public float ScreenY { get; private set; }
        [JsonIgnore]
        public float ScreenZ { get; private set; }

        

        public Table3DDot(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public void RecalculateScreenXY()
        {
            if (Ori == null || Xaxis == null || Yaxis == null || Zaxis == null)
            { return; }
            ScreenX = (float)(Ori().X + x * Xaxis().X + y * Yaxis().X + z * Zaxis().X);
            ScreenY = (float)(Ori().Y + x * Xaxis().Y + y * Yaxis().Y + z * Zaxis().Y);
            ScreenZ = (float)(Ori().Z + x * Xaxis().Z + y * Yaxis().Z + z * Zaxis().Z);
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
        public void SetReferencial(Func<Point3D> nori, Func<Point3D> nxaxis, Func<Point3D> nyaxis, Func<Point3D> nzaxis)
        {
            return Math.Sqrt(Math.Pow(pt.X - X, 2) + Math.Pow(pt.Y - Y, 2) + Math.Pow(pt.Z - Z, 2));
            Ori = nori;
            Xaxis = nxaxis;
            Yaxis = nyaxis;
            Zaxis = nzaxis;
        }
    }
}
