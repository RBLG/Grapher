using Grapher.Editor3d.Processing;
using Grapher.GuiElement;
using Grapher.MathSpatial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.Editor3d.UserInput
{
    public class MouseDragEvent
    {
        public MouseButtons Type { get; init; }
        public Action<Neo3DEditor, G3DPoint[,], RawTable, float, float> Action { get; init; } //HACK abstract the editor

        public MouseDragEvent(MouseButtons ntype, Action<Neo3DEditor, G3DPoint[,], RawTable, float, float> naction) {
            Type = ntype;
            Action = naction;
        }
    }
}
