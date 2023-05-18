using Grapher.MathSpatial;
using Grapher.Misc;
using Grapher.Modules;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.GuiElement
{
    public class Neo3DEditor : Control
    {
        private readonly SolidBrush bg = new(Theme.Editor_3d_background);
        private readonly Pen red__ = new(Color.Red);
        private readonly Pen blue_ = new(Color.LightBlue);
        private readonly Pen green = new(Color.Green);
        private readonly Pen net = new(Theme.Editor_3d_gridlines);
        private readonly SolidBrush dot = new(Theme.Editor_3d_griddots);
        private readonly Pen netoff = new(Theme.Editor_3d_gridlines_off);

        // size of the grid point in pixel
        public const float dotsize = 3;
        public const float halfdot = dotsize / 2f;

        protected readonly OrthoCamera defaultcamera = new(); //HACK
        protected readonly OrthoCamera camera = new();
        protected readonly TableModule2 module;
        protected readonly TableFormater formater;

        public Neo3DEditor() : this(new()) { }//trick to get visual studio to compile it

        public Neo3DEditor(TableModule2 nmodule) {
            module = nmodule;
            formater = new(10, 10, 60, -30, () => module.Table);

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseDown += MyOnMouseDown;
            this.MouseMove += MyOnMouseMove;
            this.MouseUp += MyOnMouseUp;
            this.MouseWheel += MyOnMouseWheel;
            this.Resize += MyOnResize;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            RawTable table = module.Table;
            G3DPoint camdir = camera.GetDirection();

            //to remove for transparent background
            e.Graphics.FillRectangle(bg, e.ClipRectangle);
            //antialiasing on
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            //TODO
            bool isxcontinuous = true; //Module.Wscale.Continuous 
            bool isycontinuous = true; //Module.Lscale.Continuous

            //axis coordinates
            G2DPoint ori_ = camera.ToScreenSpace(formater.FormatAsAtZ(-1.2f, -1.2f, -0.3f));
            G2DPoint xtip = camera.ToScreenSpace(formater.FormatAsAtZ(table.width_ + 0.5f, -1.2f, -0.3f));
            G2DPoint ytip = camera.ToScreenSpace(formater.FormatAsAtZ(-1.2f, table.height + 0.5f, -0.3f));
            G2DPoint ztip = camera.ToScreenSpace(formater.FormatAsAtZ(-1.2f, -1.2f, 1.1f));

            //drawing axis
            e.Graphics.DrawLine(red__, ori_.x, ori_.y, xtip.x, xtip.y);
            e.Graphics.DrawLine(green, ori_.x, ori_.y, ytip.x, ytip.y);
            e.Graphics.DrawLine(blue_, ori_.x, ori_.y, ztip.x, ztip.y);

            //depth sorting by reverting the iteration order if needed
            var wrange = Enumerable.Range(0, (int)table.width_);
            var hrange = Enumerable.Range(0, (int)table.height);
            if (camdir.x < 0) {
                wrange = wrange.Reverse();
            }
            if (camdir.y < 0) {
                hrange = hrange.Reverse();
            }

            //convert the table to view coordinates
            G3DPoint[,] points = new G3DPoint[table.width_, table.height];
            foreach (uint itx in wrange) {
                foreach (uint ity in hrange) {
                    points[itx, ity] = camera.ToViewSpace(formater.Format(itx, ity));
                }
            }

            //draw the grid
            foreach (uint itx in wrange) {
                foreach (uint ity in hrange) {
                    G3DPoint point = points[itx, ity];
                    if ((!isxcontinuous) && (!isycontinuous)) { //drawing points
                        e.Graphics.FillEllipse(dot, point.x - halfdot, point.y - halfdot, dotsize, dotsize);
                    }
                    else {
                        if (ity != 0 && isxcontinuous) { //drawing width vertices
                            G3DPoint last = points[itx, ity - 1];
                            e.Graphics.DrawLine(net, point.x, point.y, last.x, last.y);
                        }
                        if (itx != 0 && isycontinuous) { //drawing length vertices
                            G3DPoint last = points[itx - 1, ity];
                            e.Graphics.DrawLine(net, point.x, point.y, last.x, last.y);
                        }
                    }
                }
            }
            //end of render
            this.reversetable = points;
            //e.Graphics.FillEllipse(dot, lastx, lasty, dotsize, dotsize);
        }

        private G3DPoint[,] reversetable = new G3DPoint[0, 0]; //HACK

        //find the minimal rectangle that contain the rendering of the table
        private G2DPoint ComputeRenderAreaSize() {
            float xmin, ymin, xmax, ymax;
            xmin = xmax = Width / 2;
            ymin = ymax = Height / 2;

            //calculate position of each corner both in max and min position
            foreach (var x in new float[] { 0, module.Table.width_ }) {
                foreach (var y in new float[] { 0, module.Table.height }) {
                    foreach (var z in new float[] { 0, 1 }) {
                        G2DPoint pt = defaultcamera.ToScreenSpace(formater.FormatAsAtZ(x, y, z));
                        xmin = MathF.Min(xmin, pt.x);
                        xmax = MathF.Max(xmax, pt.x);
                        ymin = MathF.Min(ymin, pt.y);
                        ymax = MathF.Max(ymax, pt.y);
                    }
                }
            }

            return new(xmax - xmin, ymax - ymin);
        }

        private readonly List<MouseDragEvent> mdevents = new();
        private int lastx;
        private int lasty;

        private void MyOnMouseDown(object? sender, MouseEventArgs e) {
            if (e.Button.HasFlag(MouseButtons.Middle)) {
                mdevents.Add(new(MouseButtons.Middle, (This, pts, tb, mx, my) => {
                    This.camera.SideRotation += mx / 200f;
                    This.camera.HeightRotation += my / 200f;
                    This.Invalidate();
                }));
            }
            if (e.Button.HasFlag(MouseButtons.Left)) {
                mdevents.Add(new BrushStrokeEvent(new TestBrush(50f), reversetable, module.Table, new(e.X, e.Y, 0)));
            }
            lastx = e.X;
            lasty = e.Y;
        }

        private void MyOnMouseMove(object? sender, MouseEventArgs e) {
            foreach (MouseDragEvent mdevent in mdevents) {
                mdevent.Action(this, reversetable, module.Table, e.X - lastx, e.Y - lasty);
            }
            lastx = e.X;
            lasty = e.Y;
        }

        private void MyOnMouseUp(object? sender, MouseEventArgs e) => mdevents.RemoveAll((ev) => e.Button.HasFlag(ev.Type));

        private void MyOnLoad(object? sender, EventArgs e) => MyOnResize(sender, e);

        private void MyOnResize(object? sender, EventArgs e) {
            camera.CanvasWidth = Width;
            camera.CanvasHeight = Height;
            var size = ComputeRenderAreaSize();
            if (size.x == 0 && size.y == 0) {
                return;
            }
            ratio = MathF.Min(Width / size.x, Height / size.y);
            camera.Zoom = ratio * zoom;
            Invalidate();
        }

        private float ratio = 1;
        private float zoom = 1;

        //windows constant
        public static readonly float WHEEL_DELTA = 120;

        private void MyOnMouseWheel(object? sender, MouseEventArgs e) {
            float delta = e.Delta / WHEEL_DELTA;
            float mod = 1 + 0.1f * delta;
            zoom *= mod;
            camera.Zoom = ratio * zoom;
            Invalidate();
        }

    }
}
