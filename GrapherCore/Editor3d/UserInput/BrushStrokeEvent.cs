using Grapher.Brushes;
using Grapher.Editor3d.Processing;
using Grapher.GuiElement;
using Grapher.MathSpatial;
using Grapher.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Editor3d.UserInput
{
    public class BrushStrokeEvent : MouseDragEvent
    {
        private readonly IBrush brush;
        private readonly double[,] initial = { };
        private readonly float[,] strength = { };
        private float ratio;
        private readonly bool valid = true;

        public BrushStrokeEvent(IBrush nbrush, G3DPoint[,] points, RawTable table, G3DPoint source) : base(MouseButtons.Left, (ed, pts, tb, mx, my) => { }) {
            Action = ApplyBrush;
            brush = nbrush;
            var asource = GetActualSource(points, table, source);
            if (asource == null) {
                valid = false;
                return;
            }
            initial = table.CopyToArray();

            strength = brush.Initiate(points, table, asource);
        }

        public void ApplyBrush(Neo3DEditor editor, G3DPoint[,] points, RawTable table, float mx, float my) {
            if (!valid) {
                return;
            }
            ratio += -my / 44f; //HACK

            brush.Apply(points, table, initial, strength, ratio);
            editor.Invalidate();
        }

        public G3DPoint? GetActualSource(G3DPoint[,] points, RawTable table, G3DPoint source) {
            G3DPoint? actual = null;
            float mindist = float.MaxValue;
            table.ForEach((itx, ity) => {
                //HACK too much geometry math for now, im not doing 3D face-line intersections
                //if (itx == 0 || ity == 0) {
                //    return;
                //}
                //var pt1 = points[itx - 1, ity - 1];
                //var pt2 = points[itx, ity - 1];
                //var pt3 = points[itx - 1, ity];

                var pt4 = points[itx, ity];
                float dist = GetDistance2d(source, pt4);
                if (dist < mindist) {
                    mindist = dist;
                    actual = pt4;
                }
            });
            return actual;
        }


        private static float GetDistance2d(G3DPoint pt1, G3DPoint pt2) {
            float dx = pt1.x - pt2.x,
                  dy = pt1.y - pt2.y;
            return MathF.Sqrt(dx * dx + dy * dy);
        }
    }
}

