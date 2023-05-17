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

            foreach (int itx2 in wrange) {
                uint itx = (uint)Math.Max(0, itx2);
                foreach (int ity2 in hrange) {
                    uint ity = (uint)Math.Max(0, ity2);
                    G2DPoint point = camera.ToScreenSpace(formater.Format(itx, ity));
                    if ((!isxcontinuous) && (!isycontinuous)) { //drawing points
                        e.Graphics.FillEllipse(dot, point.x - halfdot, point.y - halfdot, dotsize, dotsize);
                    }
                    else {
                        if (ity != 0 && isxcontinuous) { //drawing width vertices
                            G2DPoint last = camera.ToScreenSpace(formater.Format(itx, ity - 1));
                            e.Graphics.DrawLine(net, point.x, point.y, last.x, last.y);
                        }
                        if (itx != 0 && isycontinuous) { //drawing length vertices
                            G2DPoint last = camera.ToScreenSpace(formater.Format(itx - 1, ity));
                            e.Graphics.DrawLine(net, point.x, point.y, last.x, last.y);
                        }
                    }
                }
            }
            //end of render
        }

        private MouseButtons? etype = null;
        private int lastx;
        private int lasty;

        private void MyOnMouseDown(object? sender, MouseEventArgs e) {
            if (e.Button != MouseButtons.Right) {
                return;
            }
            etype = e.Button;
            lastx = e.X;
            lasty = e.Y;
        }

        private void MyOnMouseMove(object? sender, MouseEventArgs e) {
            if (etype == null) {
                return;
            }
            if (etype == MouseButtons.Right) {
                camera.SideRotation += (e.X - lastx) / 200f;
                camera.HeightRotation += (e.Y - lasty) / 200f;
                Invalidate();
            }
            else if (etype == MouseButtons.Left) {

            }
            lastx = e.X;
            lasty = e.Y;
        }

        private void MyOnMouseUp(object? sender, MouseEventArgs e) => etype = null;


        private void MyOnMouseWheel(object? sender, MouseEventArgs e) {
            //TODO
            Invalidate();
        }

        private void MyOnLoad(object? sender, EventArgs e) => MyOnResize(sender, e);

        private void MyOnResize(object? sender, EventArgs e) {
            camera.CanvasWidth = Width;
            camera.CanvasHeight = Height;
        }




    }
}
