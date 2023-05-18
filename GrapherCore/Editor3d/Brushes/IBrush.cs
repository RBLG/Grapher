using Grapher.Editor3d.Processing;
using Grapher.MathSpatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Brushes
{
    public interface IBrush
    {
        public float[,] Initiate(G3DPoint[,] points, RawTable table, G3DPoint source);

        public void Apply(G3DPoint[,] points, RawTable table, double[,] initial, float[,] strength, float ratio);
    }
}
