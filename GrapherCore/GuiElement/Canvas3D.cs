using Grapher.Misc;
using Grapher.Modules;
using Grapher.Scale;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher
{
    /// <summary>
    /// a Gui element that draw and allow interaction with the table/grid (whatever it should be called)
    /// </summary>
    public class Canvas3D : Control
    {

        protected SolidBrush bg = new(Theme.Editor_3d_background);
        protected Pen red = new(Color.Red);
        protected Pen blue = new(Color.LightBlue);
        protected Pen green = new(Color.Green);
        protected SolidBrush wave1 = new(Color.Yellow);
        protected Pen wave1border = new(Color.DarkGoldenrod);
        protected Pen net = new(Theme.Editor_3d_gridlines);
        protected Pen netoff = new(Theme.Editor_3d_gridlines_off);
        //protected Pen wave2 = new(Color.Purple);

        protected int slider = 0;//unused yet, to slide the length of the grid
        public static readonly float size = 100;//size of width and height (i think?)
        public static readonly float oversize = 20;//additional length of the length axis past grid size

        public static readonly float oripadding = 10;// the distance between the axis origin and the grid closest point
        //public readonly float spacing = 20;
        public static readonly float dotsize = 3;// size of the grid point in pixel
        public static readonly float halfdot = dotsize / 2;

        public static readonly float tablevisualwidth = 300;//width of the grid
        //public readonly float tablevisuallength = 600;
        public static readonly float lengthspacing = 20;//distance between points on the grid


        //might need to remove
        public IModule Input { get => module.Input; set => module.Input = value; }

        public TableModule module;// the module this gui element interact with

        public Canvas3D() : this(new TableModule()) { }//trick to get visual studio to compile it

        public Canvas3D(TableModule nmodule)
        {
            module = nmodule;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseDown += MyOnMouseDown;
            this.MouseMove += MyOnMouseMove;
            this.MouseUp += MyOnMouseUp;
            this.MouseWheel += MyOnMouseWheel;

            this.Resize += Custom_Resize;

            RecalculateFigureSize();
        }

        /// <summary>
        /// a holder to remember what points are being moven during an interaction. will get reworked eventually
        /// </summary>
        private class MovingDot
        {
            public Table3DDot dot;
            public double strength;
            public Point pos;
            public MovingDot(Table3DDot ndot, double nstrength, int x, int y)
            {
                dot = ndot;
                strength = nstrength;
                pos = new(x, y);
            }

        }

        private List<MovingDot>? moving = null;
        //trick to get better cursor tracking till cam mov
        private double lastmousey = 0;

        public double BrushSize { get; set; } = 0;

        private void MyOnMouseMove(object? sender, MouseEventArgs e)
        {
            if (moving != null)
            {//while the mouse is down, it update points values
                double offset = e.Y - lastmousey;
                foreach (MovingDot dot in moving)
                {
                    //temporary till camera movement
                    dot.dot.ReverseAddY(offset * dot.strength);
                    //temporary till table3DDot are eliminated
                    module.Table.AddToArrayble(dot.pos.X, dot.pos.Y, -offset * dot.strength);
                }
                lastmousey = e.Y;
                this.Invalidate();
            }
        }

        private void MyOnMouseUp(object? sender, MouseEventArgs e)
        {//terminate the edition of the grid
            if (e.Button == MouseButtons.Left)
            { moving = null; }
        }

        private void MyOnMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (true)//if on the visual of the X axis, slide
                {
                    //return;
                }

                //select the dots to move
                double pres = 20;
                int itx = 0;
                foreach (List<Table3DDot> row in module.Table.dots)
                {
                    int ity = 0;
                    foreach (Table3DDot point in row)
                    {
                        double dist = GetDistance(point, e.Location);
                        if (dist < pres)
                        {
                            pres = dist;
                            moving = new List<MovingDot>() { new MovingDot(point, 1, itx, ity) };
                            lastmousey = e.Location.Y;
                        }
                        ity++;
                    }
                    itx++;
                }
                if (moving != null && BrushSize > 0)
                { AddPointsInBrushRange(moving[0].dot); }
            }
        }

        /// <summary>
        /// return the distance between two point to be used for brush size handling
        /// </summary>
        private double GetDistance(Table3DDot pt1, Point pt2)
        {
            var ori = module.Table.Origin;
            if (module.Table.Width != 1 && module.Table.Length != 1)
            {
                return GetDistanceSub(pt1.ScreenX, pt1.ScreenY, pt2);
            }
            else if (module.Table.Width != 1)
            {
                float pz = (float)ori.X + (float)pt1.Z * 1.5f;
                float py = (float)ori.Y + 50 - (float)pt1.Y;
                return GetDistanceSub(pz, py, pt2);
            }
            else if (module.Table.Length != 1)
            {
                float px = (float)ori.X + (float)pt1.X;
                float py = (float)ori.Y + 50 - (float)pt1.Y;
                return GetDistanceSub(px, py, pt2);
            }
            return 0;
        }
        private static double GetDistanceSub(double px, double py, Point pt2)
        { return Math.Sqrt(Math.Pow(pt2.X - px, 2) + Math.Pow(pt2.Y - py, 2)); }

        private void AddPointsInBrushRange(Table3DDot point)
        {
            int itx = 0;
            foreach (List<Table3DDot> row2 in module.Table.dots)
            {
                int ity = 0;
                foreach (Table3DDot point2 in row2)
                {
                    double dist2 = point.GetBrushDistanceTo(point2) / 20;
                    //Console.WriteLine(dist2);
                    if (dist2 < BrushSize && !point.Equals(point2))
                    { moving!.Add(new MovingDot(point2, 1 - dist2 / BrushSize, itx, ity)); }
                    ity++;
                }
                itx++;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //to remove for transparent background
            e.Graphics.FillRectangle(bg, e.ClipRectangle);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (module.Table.Width != 1 && module.Table.Length != 1)//3D editor view
            {
                Do3DPaint(e);
            }
            else if (module.Table.Width != 1)//2D typically with horizontal axis being time
            {
                DoWidth2DPaint(e);
            }
            else if (module.Table.Length != 1)//2D editor with horizontal axis being something of fixed width
            {
                DoLength2DPaint(e);
            }
            else //1D editor, rarely usefull i guess but still nice to have
            {
                Do1DPaint(e);
            }
        }


        private void Do3DPaint(PaintEventArgs e)
        {
            //result of moving then in table
            var xaxis = module.Table.xaxis;
            var yaxis = module.Table.yaxis;
            var zaxis = module.Table.zaxis;

            float ox = (float)module.Table.Origin.X;
            float oy = (float)module.Table.Origin.Y;


            //drawing axis
            float length = tablevisualwidth + oversize;
            e.Graphics.DrawLine(blue, ox, oy, ox + (float)zaxis.X * length, oy + (float)zaxis.Y * length);
            length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox + (float)yaxis.X * length, oy + (float)yaxis.Y * length);
            length = lengthspacing * module.Table.Length + oversize;
            e.Graphics.DrawLine(red, ox, oy, ox + (float)xaxis.X * length, oy + (float)xaxis.Y * length);

            var points = module.Table.dots;
            for (int itx = 0; itx < points.Count; itx++)
            {
                for (int itz = 0; itz < points[itx].Count; itz++)
                {
                    Table3DDot point = points[itx][itz];
                    if ((!module.Table.Wscale.Continuous) && (!module.Lscale.Continuous))
                    {
                        //drawing the point
                        e.Graphics.FillEllipse(wave1, point.ScreenX - halfdot, point.ScreenY - halfdot, dotsize, dotsize);
                        //e.Graphics.DrawEllipse(wave1border, point.ScreenX - halfdot, point.ScreenY - halfdot, dotsize, dotsize);
                    }
                    else
                    {
                        //drawing width vertices
                        if (itz != 0 && module.Wscale.Continuous)
                        {
                            Table3DDot last = points[itx][itz - 1];
                            e.Graphics.DrawLine(net, point.ScreenX, point.ScreenY, last.ScreenX, last.ScreenY);
                        }
                        //drawing length vertices
                        if (itx != points.Count - 1 && module.Lscale.Continuous)
                        {
                            Table3DDot last = points[itx + 1][itz];
                            e.Graphics.DrawLine(net, point.ScreenX, point.ScreenY, last.ScreenX, last.ScreenY);
                        }
                    }
                }
            }

            //e.Graphics.DrawEllipse(netoff, (float)figmin.X, (float)figmin.Y, dotsize, dotsize);
            //e.Graphics.DrawEllipse(netoff, (float)figmid.X, (float)figmid.Y, dotsize, dotsize);
            //e.Graphics.DrawEllipse(netoff, (float)figmax.X, (float)figmax.Y, dotsize, dotsize);
        }


        private void DoWidth2DPaint(PaintEventArgs e)
        {
            float ox = (float)module.Table.Origin.X;
            float oy = (float)module.Table.Origin.Y + 50;

            //drawing axis
            float length = tablevisualwidth + oversize;
            e.Graphics.DrawLine(blue, ox, oy, ox + length * 1.5f, oy);
            length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox, oy - length);

            var points = module.Table.dots;
            for (int itx = 0; itx < points.Count; itx++)
            {
                for (int itz = 0; itz < points[itx].Count; itz++)
                {
                    Table3DDot point = points[itx][itz];
                    float px = ox + (float)point.Z * 1.5f;
                    float py = oy - (float)point.Y;

                    bool ishar = module is HarmonicModule;
                    if (ishar)//quick hack to get stylish harmonic editor render
                    {
                        e.Graphics.DrawLine(net, px, py, px, oy);
                    }

                    if (ishar || ((!module.Table.Wscale.Continuous) && (!module.Lscale.Continuous)))
                    {
                        //drawing the point
                        e.Graphics.FillEllipse(wave1, px - halfdot, py - halfdot, dotsize, dotsize);
                        //e.Graphics.DrawEllipse(wave1border, px - halfdot, py - halfdot, dotsize, dotsize);
                    }
                    else
                    {
                        //drawing width vertices
                        if (!ishar && itz != points[0].Count - 1 && module.Wscale.Continuous)
                        {
                            Table3DDot last = points[itx][itz + 1];
                            e.Graphics.DrawLine(net, px, py, ox + (float)last.Z * 1.5f, oy - (float)last.Y);
                        }
                    }



                }
            }
        }

        private void DoLength2DPaint(PaintEventArgs e)
        {
            float ox = (float)module.Table.Origin.X;
            float oy = (float)module.Table.Origin.Y + 50;

            //drawing axis
            float length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox, oy - length);
            length = lengthspacing * module.Table.Length + oversize;
            e.Graphics.DrawLine(red, ox, oy, ox + length, oy);

            var points = module.Table.dots;
            for (int itx = 0; itx < points.Count; itx++)
            {
                for (int itz = 0; itz < points[itx].Count; itz++)
                {
                    Table3DDot point = points[itx][itz];
                    float px = ox + (float)point.X;
                    float py = oy - (float)point.Y;

                    if ((!module.Table.Wscale.Continuous) && (!module.Lscale.Continuous))
                    {
                        //drawing the point
                        e.Graphics.FillEllipse(wave1, px - halfdot, py - halfdot, dotsize, dotsize);
                        //e.Graphics.DrawEllipse(wave1border, px - halfdot, py - halfdot, dotsize, dotsize);
                    }
                    else
                    {
                        //drawing length vertices
                        if (itx != points.Count - 1 && module.Lscale.Continuous)
                        {
                            Table3DDot last = points[itx + 1][itz];
                            e.Graphics.DrawLine(net, px, py, ox + (float)last.X, oy - (float)last.Y);
                        }
                    }

                }
            }
        }

        private void Do1DPaint(PaintEventArgs e)
        {
            Do3DPaint(e);
        }

        public void MyOnMouseWheel(object? sender, MouseEventArgs e)
        {
            int delta = e.Delta / WHEEL_DELTA;


            if (delta == 0) { }
            else if (delta < 0)
            {
                ds *= (float)Math.Pow(0.91f, -delta);
            }
            else
            {
                ds *= (float)Math.Pow(1.1f, delta);
            }
            module.Table.UpdateAll();
            this.Invalidate();
        }


        public void Custom_Resize(object? sender, EventArgs e)
        {
            //module.Table.Origin.Y = Size.Height / 2;
            //module.Table.UpdateAll();
            RecalculateFigureSize();
            module.Table.Origin.Y = (Size.Height / 2) - ori2corner.Y;
            module.Table.UpdateAll();
            //RecalculateFigureSize();
            Invalidate();
        }

        private void RecalculateFigureSize() //does not work because it is impacted by the current height of the corners
                                             //not the actual min/max values. to fix
        {
            double wmin = double.MaxValue, wmax = double.MinValue;
            double hmin = double.MaxValue, hmax = double.MinValue;

            var table = module.Table;
            Table3DDot oridot = new(0, 0, 0);
            oridot.SetReferencial(() => table.Origin, () => table.xaxis, () => table.yaxis, () => table.zaxis);
            oridot.RecalculateScreenXY();

            //three loops that iterate 2 time only but it improve clarity
            //it iterate through each corner of the table
            foreach (int xval in new int[] { 0, module.Table.Width - 1 })
            {
                foreach (int yval in new int[] { 0, module.Table.Length - 1 })
                {
                    foreach (double hval in new double[] { Table.MIN, Table.MAX })
                    {
                        wmin = RecalSub(xval, yval, hval, wmin, true, true);
                        wmax = RecalSub(xval, yval, hval, wmax, false, true);
                        hmin = RecalSub(xval, yval, hval, hmin, true, false);
                        hmax = RecalSub(xval, yval, hval, hmax, false, false);
                    }


                }
            }

            figurewidth = wmax - wmin;
            figureheight = hmax - hmin;

            ori2corner.X = wmin + figurewidth / 2 - oridot.ScreenX;
            ori2corner.Y = hmin + figureheight / 2 - oridot.ScreenY;


            //figmin = new(wmin, hmin);
            //figmid = new((wmin + wmax) / 2, (hmin + hmax) / 2);
            //figmax = new(wmax, hmax);


        }

        //private Point2D figmin = new();
        //private Point2D figmid = new();
        //private Point2D figmax = new();

        /// <summary>
        /// quick generic to avoid too much repeat above
        /// </summary>
        private double RecalSub(int tabx, int taby, double tabh, double cval, bool ismin, bool iswidth)
        {
            var table = module.Table;
            //Table3DDot dot2 = new(tabx, tabh, taby);
            //dot2.SetReferencial(() => table.Origin, () => table.xaxis, () => table.yaxis, () => table.zaxis);
            var dot2 = module.Table.CreateDot(taby, tabx, module.Table.Width, module.Table.Length, tabh);
            dot2.RecalculateScreenXY();
            double val = iswidth ? dot2.ScreenX : dot2.ScreenY;
            return ismin ? Math.Min(cval, val) : Math.Max(cval, val); ;
        }

        //size of whats drawn
        private float ds = 1; //mean draw scale //how everything is drawn has to be reworked first

        public readonly float basewidth = 618;
        public readonly float baseheight = 451;

        private double figurewidth = 0;
        private double figureheight = 0;

        private readonly Point2D ori2corner = new();

        //windows constant
        public static readonly int WHEEL_DELTA = 120;

    }
}
