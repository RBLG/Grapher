using System;
using System.Collections.Generic;
using System.Drawing;
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

        protected List<List<Gui3DDot>> points = new List<List<Gui3DDot>>();

        protected int slider = 0;
        protected Point3D xaxis = new Point3D(0.7, 0.2, 0);
        protected Point3D yaxis = new Point3D(0, -1, 0);
        protected Point3D zaxis = new Point3D(0.5, -0.3, 0);
        protected Point3D Origin = new Point3D(50, 300, 0);
        protected float size = 100;

        protected readonly float oripadding = 10;
        protected readonly float spacing = 15;
        protected readonly float dotsize = 3;

        public Canvas3D()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            this.MouseDown += this.MyOnMouseDown;
            this.MouseMove += this.MyOnMouseMove;
            this.MouseUp += this.MyOnMouseUp;
            foreach (int itx in Enumerable.Range(1, 50))
            {
                var row = new List<Gui3DDot>();
                points.Add(row);
                foreach (int itz in Enumerable.Range(1, 20))
                {
                    row.Add(new Gui3DDot(() => Origin, () => xaxis, () => yaxis, () => zaxis, itx * spacing + oripadding, 1, itz * spacing + oripadding));
                }
            }
        }

        private Gui3DDot moving = null;

        private void MyOnMouseMove(object sender, MouseEventArgs e)
        {
            if (moving != null)
            {
                //temporary till camera movement
                moving.ReverseY(Math.Min(e.Y,1000));
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
                Console.WriteLine("catched");
                double pres = 10;
                foreach (List<Gui3DDot> row in points)
                {
                    foreach (Gui3DDot point in row)
                    {
                        double dist= point.DistanceTo(e.Location);
                        if (dist<pres)
                        {
                            pres = dist;
                            moving = point;
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
            e.Graphics.DrawLine(blue, orix, oriy, orix + (float)zaxis.X * size, oriy + (float)zaxis.Y * size);
            e.Graphics.DrawLine(green, orix, oriy, orix + (float)yaxis.X * size, oriy + (float)yaxis.Y * size);
            e.Graphics.DrawLine(red, orix, oriy, orix + (float)xaxis.X * size, oriy + (float)xaxis.Y * size);
            foreach (int itx in Enumerable.Range(0, points.Count - 1))
            {
                foreach (int itz in Enumerable.Range(0, points[itx].Count - 1))
                {
                    Gui3DDot point = points[itx][itz];
                    if (itx != 0)
                    {
                        Gui3DDot last = points[itx - 1][itz];
                        e.Graphics.DrawLine(net1, (float)point.ScreenX, (float)point.ScreenY, (float)last.ScreenX, (float)last.ScreenY);
                    }
                    if (itz != 0)
                    {
                        Gui3DDot last = points[itx][itz - 1];
                        e.Graphics.DrawLine(net2, (float)point.ScreenX, (float)point.ScreenY, (float)last.ScreenX, (float)last.ScreenY);
                    }
                }
            }
            foreach (int itx in Enumerable.Range(0, points.Count - 1))
            {
                foreach (int itz in Enumerable.Range(0, points[itx].Count - 1))
                {
                    Gui3DDot point = points[itx][itz];
                    e.Graphics.FillRectangle(wave1, (float)point.ScreenX - 1, (float)point.ScreenY - 1, dotsize, dotsize);
                    e.Graphics.DrawRectangle(wave1border, (float)point.ScreenX-dotsize/2, (float)point.ScreenY - dotsize / 2, dotsize, dotsize);
                }
            }
        }

    }
}
