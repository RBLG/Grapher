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

        protected SolidBrush bg = new(Color.DarkBlue);//Color.FromArgb(255, 0, 91, 150)
        protected Pen red = new(Color.Red);
        protected Pen blue = new(Color.LightBlue);
        protected Pen green = new(Color.Green);
        protected SolidBrush wave1 = new(Color.Yellow);
        protected Pen wave1border = new(Color.DarkGoldenrod);
        protected Pen net1 = new(Color.LightGray);
        protected Pen net2 = new(Color.Blue);
        protected Pen wave2 = new(Color.Purple);

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
                    //drawing width vertices
                    if (itz != points[0].Count - 1 && module.Wscale.Continuous)
                    {
                        Table3DDot last = points[itx][itz + 1];
                        e.Graphics.DrawLine(net2, point.ScreenX, point.ScreenY, last.ScreenX, last.ScreenY);
                    }
                    //drawing length vertices
                    if (itx != points.Count - 1 && module.Lscale.Continuous)
                    {
                        Table3DDot last = points[itx + 1][itz];
                        e.Graphics.DrawLine(net1, point.ScreenX, point.ScreenY, last.ScreenX, last.ScreenY);
                    }
                    //drawing the point
                    e.Graphics.FillEllipse(wave1, point.ScreenX - halfdot, point.ScreenY - halfdot, dotsize, dotsize);
                    e.Graphics.DrawEllipse(wave1border, point.ScreenX - halfdot, point.ScreenY - halfdot, dotsize, dotsize);
                }
            }
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


                    if (module is HarmonicModule)//quick hack to get stylish harmonic editor render
                    {
                        e.Graphics.DrawLine(net1, px, py, px, oy);
                    }
                    else
                    {//drawing width vertices
                        if (itz != points[0].Count - 1 && module.Wscale.Continuous)
                        {
                            Table3DDot last = points[itx][itz + 1];
                            e.Graphics.DrawLine(net1, px, py, ox + (float)last.Z * 1.5f, oy - (float)last.Y);
                        }
                    }

                    //drawing the point
                    e.Graphics.FillEllipse(wave1, px - halfdot, py - halfdot, dotsize, dotsize);
                    e.Graphics.DrawEllipse(wave1border, px - halfdot, py - halfdot, dotsize, dotsize);
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

                    //drawing length vertices
                    if (itx != points.Count - 1 && module.Lscale.Continuous)
                    {
                        Table3DDot last = points[itx + 1][itz];
                        e.Graphics.DrawLine(net1, px, py, ox + (float)last.X, oy - (float)last.Y);
                    }
                    //drawing the point
                    e.Graphics.FillEllipse(wave1, px - halfdot, py - halfdot, dotsize, dotsize);
                    e.Graphics.DrawEllipse(wave1border, px - halfdot, py - halfdot, dotsize, dotsize);
                }
            }
        }

        private void Do1DPaint(PaintEventArgs e)
        {
            Do3DPaint(e);
        }

    }
}
