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
        protected Pen blue = new Pen(Color.Blue);
        protected Pen green = new Pen(Color.Green);
        protected SolidBrush wave1 = new SolidBrush(Color.Yellow);
        protected Pen wave1border = new Pen(Color.DarkGoldenrod);
        protected Pen net1 = new Pen(Color.LightGray);
        protected Pen net2 = new Pen(Color.Blue);
        protected Pen wave2 = new Pen(Color.Purple);

        //temporary till all fit in module
        protected List<List<Table3DDot>> points = new List<List<Table3DDot>>();

        protected int slider = 0;
        public readonly Point3D xaxis = new Point3D(0.7, 0.2, 0);
        public readonly Point3D yaxis = new Point3D(0, -1, 0);
        public readonly Point3D zaxis = new Point3D(0.5, -0.3, 0);
        public readonly Point3D Origin = new Point3D(50, 300, 0);
        protected float size = 100;

        public readonly float oripadding = 10;
        public readonly float spacing = 20;
        public readonly float dotsize = 3;

        protected readonly int samplerate = 32000;

        //temporary till all fit in module
        public Table Table { get; private set; }

        public Canvas3D()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseDown += MyOnMouseDown;
            this.MouseMove += MyOnMouseMove;
            this.MouseUp += MyOnMouseUp;
            this.KeyPress += Graph3DEditor_KeyPress;
            Table = new Table(this);
            points = Table.dots;
            module = new ProtoModule(Table);
        }

        internal void SetDura(int ndura)
        {
            var sc = module.Tscale;
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

                double pres = 10;
                foreach (List<Table3DDot> row in points)
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
                                foreach (List<Table3DDot> row2 in points)
                                {
                                    foreach (Table3DDot point2 in row2)
                                    {
                                        double dist2 = point.GetBrushDistanceTo(point2) / spacing;
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
            e.Graphics.FillRectangle(bg, e.ClipRectangle);
            float orix = (float)Origin.X;
            float oriy = (float)Origin.Y;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            e.Graphics.DrawLine(blue, orix, oriy, orix + (float)zaxis.X * size, oriy + (float)zaxis.Y * size);
            e.Graphics.DrawLine(green, orix, oriy, orix + (float)yaxis.X * size, oriy + (float)yaxis.Y * size);
            e.Graphics.DrawLine(red, orix, oriy, orix + (float)xaxis.X * size, oriy + (float)xaxis.Y * size);
            foreach (int itx in Enumerable.Range(0, points.Count))
            {
                foreach (int itz in Enumerable.Range(0, points[itx].Count))
                {
                    Table3DDot point = points[itx][itz];
                    if (itx != 0)
                    {
                        Table3DDot last = points[itx - 1][itz];
                        e.Graphics.DrawLine(net1, (float)point.ScreenX, (float)point.ScreenY, (float)last.ScreenX, (float)last.ScreenY);
                    }
                    if (itz != 0)
                    {
                        Table3DDot last = points[itx][itz - 1];
                        e.Graphics.DrawLine(net2, (float)point.ScreenX, (float)point.ScreenY, (float)last.ScreenX, (float)last.ScreenY);
                    }
                }
            }
            foreach (int itx in Enumerable.Range(0, points.Count))
            {
                foreach (int itz in Enumerable.Range(0, points[itx].Count))
                {
                    Table3DDot point = points[itx][itz];
                    e.Graphics.FillRectangle(wave1, (float)point.ScreenX - 1, (float)point.ScreenY - 1, dotsize, dotsize);
                    e.Graphics.DrawRectangle(wave1border, (float)point.ScreenX - dotsize / 2, (float)point.ScreenY - dotsize / 2, dotsize, dotsize);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////

        private WaveOut waveOut;

        public void Graph3DEditor_KeyPress(object sender, KeyPressEventArgs e)
        {
            Console.WriteLine("pressed");
            StartStopSineWave();
        }

        private ProtoModule module;

        private void StartStopSineWave()
        {
            if (waveOut == null)
            {
                Console.WriteLine("start");
                var output = new OutputWaveProvider32(module);
                output.SetWaveFormat(samplerate, 1); // 16kHz mono
                waveOut = new WaveOut();
                waveOut.Init(output);
                waveOut.Play();
            }
            else
            {
                Console.WriteLine("stop");
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
            }
        }

    }
}
