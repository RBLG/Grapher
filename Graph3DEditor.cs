using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher
{
    public partial class Graph3DEditor : UserControl
    {
        public Graph3DEditor()
        {
            InitializeComponent();
            //worker.RunWorkerAsync();
            this.Select();
            this.canvas3D1.Focus();
        }

        private readonly HashSet<int> keys = new HashSet<int>();
        //private BackgroundWorker worker=new BackgroundWorker();

        private void Graph3DEditor_KeyDown(object sender, KeyEventArgs e)
        {
            keys.Add(e.KeyValue);
        }

        private void Graph3DEditor_KeyUp(object sender, KeyEventArgs e)
        {
            keys.Remove(e.KeyValue);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text!="running")
            {
                button1.Text = "running";
            }
            else
            {
                button1.Text="start";
            }
            this.canvas3D1.Graph3DEditor_KeyPress(sender, null);
        }
    }
}
