namespace Grapher
{
    public class Point2D
    {
        public double X { get; private set; }
        public double Y { get; private set; }

        public Point2D(double nx, double ny)
        {
            X = nx;
            Y = ny;
        }

        public Point2D() : this(0, 0) { }

    }
}