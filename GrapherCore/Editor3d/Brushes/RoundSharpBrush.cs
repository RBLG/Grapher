using Grapher.Editor3d.Processing;
using Grapher.MathSpatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grapher.Brushes
{
    public class RoundSharpBrush : IBrush
    {
        public float Radius { get; set; }

        public RoundSharpBrush(float nradius) {
            Radius = nradius;
        }

        public float[,] Initiate(G3DPoint[,] points, RawTable table, G3DPoint source) {
            float[,] strength = new float[table.width_, table.height];
            //define a strength coeficient to all points
            table.ForEach((itx, ity) => {
                float dist = source.DistanceTo(points[itx, ity]);
                //ceiling at 1 as it mean anything past that is outside the radius
                //then (1 - that) to get 1 at the center and 0 at the border
                strength[itx, ity] = 1 - MathF.Min(1, dist / Radius);
            });
            return strength;
        }

        public void Apply(G3DPoint[,] points, RawTable table, double[,] initial, float[,] strength, float ratio) {
            table.ForEach((itx, ity) => {
                table.Set(itx, ity, initial[itx, ity] + ratio * strength[itx, ity]);
            });
        }


    }
}
