namespace Grapher
{
    public class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Point2D(double nx, double ny)
        {
            X = nx;
            Y = ny;
        }

        public Point2D() : this(0, 0) { }

    }
}