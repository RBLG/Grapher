using Grapher.GuiElement;
using Grapher.Modules;
using Grapher.Scale;
using NAudio.Wave;
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
    public class Canvas3D : Control
    {

        protected SolidBrush bg = new SolidBrush(Color.DarkBlue);//Color.FromArgb(255, 0, 91, 150)
        protected Pen red = new Pen(Color.Red);
        protected Pen blue = new Pen(Color.LightBlue);
        protected Pen green = new Pen(Color.Green);
        protected SolidBrush wave1 = new SolidBrush(Color.Yellow);
        protected Pen wave1border = new Pen(Color.DarkGoldenrod);
        protected Pen net1 = new Pen(Color.LightGray);
        protected Pen net2 = new Pen(Color.Blue);
        protected Pen wave2 = new Pen(Color.Purple);

        protected int slider = 0;
        public static readonly float size = 100;
        public static readonly float oversize = 20;

        public static readonly float oripadding = 10;
        //public readonly float spacing = 20;
        public static readonly float dotsize = 3;
        public static readonly float halfdot = dotsize / 2;

        public static readonly float tablevisualwidth = 300;
        //public readonly float tablevisuallength = 600;
        public static readonly float lengthspacing = 20;


        //might need to remove
        public IModule Input { get => module.Input; set => module.Input = value; }

        public ProtoModule module;

        public Canvas3D() : this(new ProtoModule()) { }

        public Canvas3D(ProtoModule nmodule)
        {
            module = nmodule;
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseDown += MyOnMouseDown;
            this.MouseMove += MyOnMouseMove;
            this.MouseUp += MyOnMouseUp;
            //Table = new Table(this);
            //Table = module.table;
            //points = Table.dots;
            //module = new ProtoModule(Table);
        }

        internal void SetDura(int ndura)
        {
            var sc = module.Lscale;
            if (sc is LoopingTimeScale scale)
            { //will be handled properly later with scale switching and menus
                scale.Max = ndura;
            }
        }

        private class MovingDot
        {

            public Table3DDot dot;
            public double strength;
            public MovingDot(Table3DDot ndot, double nstrength)
            {
                dot = ndot;
                strength = nstrength;
            }

        }

        private List<MovingDot> moving = null;
        //trick to get better cursor tracking till cam mov
        private double lastmousey = 0;

        public double BrushSize { get; set; } = 0;

        private void MyOnMouseMove(object sender, MouseEventArgs e)
        {

            if (moving != null)
            {
                double offset = e.Y - lastmousey;
                foreach (MovingDot dot in moving)
                {
                    //temporary till camera movement
                    dot.dot.ReverseAddY(offset * dot.strength);
                }
                lastmousey = e.Y;
                this.Invalidate();
            }
        }

        private void MyOnMouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                moving = null;
            }
        }

        private void MyOnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (true)//if on the visual of the X axis, slide
                {
                    //return;
                }

                //select the dots to move
                double pres = 20;
                foreach (List<Table3DDot> row in module.MTable.dots)
                {
                    foreach (Table3DDot point in row)
                    {
                        double dist = GetDistance(point, e.Location);
                        if (dist < pres)
                        {
                            pres = dist;
                            moving = new List<MovingDot>() { new MovingDot(point, 1) };
                            lastmousey = e.Location.Y;
                        }
                    }
                }
                if (moving != null && BrushSize > 0)
                {
                    AddDotsInBrushRange(moving[0].dot);
                }
            }
        }

        private double GetDistance(Table3DDot pt1, Point pt2)
        {
            var ori = module.MTable.Origin;
            if (module.MTable.Width != 1 && module.MTable.Length != 1)
            {
                return GetDistanceSub(pt1.ScreenX, pt1.ScreenY, pt2);
            }
            else if (module.MTable.Width != 1)
            {
                float pz = (float)ori.X + (float)pt1.Z * 1.5f;
                float py = (float)ori.Y + 50 - (float)pt1.Y;
                return GetDistanceSub(pz, py, pt2);
            }
            else if (module.MTable.Length != 1)
            {
                float px = (float)ori.X + (float)pt1.X;
                float py = (float)ori.Y + 50 - (float)pt1.Y;
                return GetDistanceSub(px, py, pt2);
            }
            return 0;
        }
        private double GetDistanceSub(double px, double py, Point pt2)
        {
            return Math.Sqrt(Math.Pow(pt2.X - px, 2) + Math.Pow(pt2.Y - py, 2));
        }

        private void AddDotsInBrushRange(Table3DDot point)
        {
            foreach (List<Table3DDot> row2 in module.MTable.dots)
            {
                foreach (Table3DDot point2 in row2)
                {
                    double dist2 = point.GetBrushDistanceTo(point2) / 20;
                    //Console.WriteLine(dist2);
                    if (dist2 < BrushSize && !point.Equals(point2))
                    {
                        moving.Add(new MovingDot(point2, 1 - dist2 / BrushSize));
                    }
                }
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //to remove for transparent background
            e.Graphics.FillRectangle(bg, e.ClipRectangle);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (module.MTable.Width != 1 && module.MTable.Length != 1)//3D editor view
            {
                Do3DPaint(e);
            }
            else if (module.MTable.Width != 1)//2D typically with horizontal axis being time
            {
                DoWidth2DPaint(e);
            }
            else if (module.MTable.Length != 1)//2D editor with horizontal axis being something of fixed width
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
            var xaxis = module.MTable.xaxis;
            var yaxis = module.MTable.yaxis;
            var zaxis = module.MTable.zaxis;

            float ox = (float)module.MTable.Origin.X;
            float oy = (float)module.MTable.Origin.Y;

            //drawing axis
            float length = tablevisualwidth + oversize;
            e.Graphics.DrawLine(blue, ox, oy, ox + (float)zaxis.X * length, oy + (float)zaxis.Y * length);
            length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox + (float)yaxis.X * length, oy + (float)yaxis.Y * length);
            length = lengthspacing * module.MTable.Length + oversize;
            e.Graphics.DrawLine(red, ox, oy, ox + (float)xaxis.X * length, oy + (float)xaxis.Y * length);

            var points = module.MTable.dots;
            for (int itx = 0; itx < points.Count; itx++)
            {
                for (int itz = 0; itz < points[itx].Count; itz++)
                {
                    Table3DDot point = points[itx][itz];
                    //drawing width vertices
                    if (itz != points[0].Count - 1)
                    {
                        Table3DDot last = points[itx][itz + 1];
                        e.Graphics.DrawLine(net2, point.ScreenX, point.ScreenY, last.ScreenX, last.ScreenY);
                    }
                    //drawing length vertices
                    if (itx != points.Count - 1)
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
            float ox = (float)module.MTable.Origin.X;
            float oy = (float)module.MTable.Origin.Y + 50;

            //drawing axis
            float length = tablevisualwidth + oversize;
            e.Graphics.DrawLine(blue, ox, oy, ox + length * 1.5f, oy);
            length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox, oy - length);

            var points = module.MTable.dots;
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
                        if (itz != points[0].Count - 1)
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
            float ox = (float)module.MTable.Origin.X;
            float oy = (float)module.MTable.Origin.Y + 50;

            //drawing axis
            float length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox, oy - length);
            length = lengthspacing * module.MTable.Length + oversize;
            e.Graphics.DrawLine(red, ox, oy, ox + length, oy);

            var points = module.MTable.dots;
            for (int itx = 0; itx < points.Count; itx++)
            {
                for (int itz = 0; itz < points[itx].Count; itz++)
                {
                    Table3DDot point = points[itx][itz];
                    float px = ox + (float)point.X;
                    float py = oy - (float)point.Y;

                    //drawing length vertices
                    if (itx != points.Count - 1)
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

        }




    }
}
