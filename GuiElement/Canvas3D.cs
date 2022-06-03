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

        protected SolidBrush bg = new SolidBrush(Color.DarkBlue);
        protected Pen red = new Pen(Color.Red);
        protected Pen blue = new Pen(Color.LightBlue);
        protected Pen green = new Pen(Color.Green);
        protected SolidBrush wave1 = new SolidBrush(Color.Yellow);
        protected Pen wave1border = new Pen(Color.DarkGoldenrod);
        protected Pen net1 = new Pen(Color.LightGray);
        protected Pen net2 = new Pen(Color.Blue);
        protected Pen wave2 = new Pen(Color.Purple);

        //temporary till all fit in module
        //protected List<List<Table3DDot>> points = new List<List<Table3DDot>>();

        protected int slider = 0;
        //public readonly Point3D xaxis = new Point3D(0.7, 0.2, 0);
        //public readonly Point3D yaxis = new Point3D(0, -1, 0);
        //public readonly Point3D zaxis = new Point3D(0.5, -0.3, 0);
        //public readonly Point3D Origin = new Point3D(10, 300, 0);
        public static readonly float size = 100;
        public static readonly float oversize = 20;

        public static readonly float oripadding = 10;
        //public readonly float spacing = 20;
        public static readonly float dotsize = 3;

        public static readonly float tablevisualwidth = 300;
        //public readonly float tablevisuallength = 600;
        public static readonly float lengthspacing = 20;

        //to move
        public static readonly int samplerate = 32000;

        //temporary till all fit in module
        //public Table Table { get; private set; }

        //might need to remove
        public IModule Input { get => module.Input; set => module.Input = value; }

        public ProtoModule module;

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
            if (sc is DynamicToWholeTimeScale scale)
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
                double pres = 10;
                foreach (List<Table3DDot> row in module.table.dots)
                {
                    foreach (Table3DDot point in row)
                    {
                        double dist = point.DistanceTo(e.Location);
                        if (dist < pres)
                        {
                            pres = dist;
                            moving = new List<MovingDot>();
                            moving.Add(new MovingDot(point, 1));
                            //adding points in range of the brush
                            //Console.WriteLine("main pt added");
                            if (BrushSize > 0)
                            {
                                foreach (List<Table3DDot> row2 in module.table.dots)
                                {
                                    foreach (Table3DDot point2 in row2)
                                    {
                                        double dist2 = point.GetBrushDistanceTo(point2) / 20;
                                        //Console.WriteLine(dist2);
                                        if (dist2 < BrushSize && !point.Equals(point2))
                                        {
                                            //Console.WriteLine("autre pt added");
                                            moving.Add(new MovingDot(point2, 1 - dist2 / BrushSize));
                                        }
                                    }
                                }
                            }
                            lastmousey = e.Location.Y;
                        }
                    }
                }
            }

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //to remove so that background can be better
            e.Graphics.FillRectangle(bg, e.ClipRectangle);

            //result of moving then in table
            var Origin = module.table.Origin;
            var xaxis = module.table.xaxis;
            var yaxis = module.table.yaxis;
            var zaxis = module.table.zaxis;

            float ox = (float)Origin.X;
            float oy = (float)Origin.Y;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            //drawing axis
            float length = tablevisualwidth + oversize;
            e.Graphics.DrawLine(blue, ox, oy, ox + (float)zaxis.X * length, oy + (float)zaxis.Y * length);
            length = size + oversize;
            e.Graphics.DrawLine(green, ox, oy, ox + (float)yaxis.X * length, oy + (float)yaxis.Y * length);
            length = lengthspacing * 30 + oversize;
            e.Graphics.DrawLine(red, ox, oy, ox + (float)xaxis.X * length, oy + (float)xaxis.Y * length);

            var points = module.table.dots;
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
                    e.Graphics.FillEllipse(wave1, point.ScreenX - 1, point.ScreenY - 1, dotsize, dotsize);
                    e.Graphics.DrawEllipse(wave1border, point.ScreenX - dotsize / 2, point.ScreenY - dotsize / 2, dotsize, dotsize);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////





    }
}
