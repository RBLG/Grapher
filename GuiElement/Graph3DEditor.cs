using Grapher.GuiElement;
using Grapher.Modules;
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
        private ProtoModule module;

        public Canvas3D canvas3D1;
        public Graph3DEditor(ProtoModule nmodule)
        {
            InitializeComponent();

            //putting it here because graphical editor doesnt work if i put it in the designer
            module = nmodule;
            this.canvas3D1 = new Grapher.Canvas3D(nmodule)
            {
                BrushSize = 0D,
                Location = new System.Drawing.Point(84, 46),
                Name = "canvas3D1",
                Size = new System.Drawing.Size(822, 511),
                TabIndex = 1,
                Text = "canvas3D1"
            };
            this.Controls.Add(this.canvas3D1);

            //not sure those two do anything
            this.Select();
            this.canvas3D1.Focus();

            numWidth.Value = canvas3D1.module.table.Width;
            numLength.Value = canvas3D1.module.table.Length;
            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            InputComboBox.SelectedIndex = 0;
            //////
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

        }

        private void numWidth_ValueChanged(object sender, EventArgs e)
        {
            canvas3D1.module.table.Width = (int)Math.Max(1, numWidth.Value);
            numWidth.Value = canvas3D1.module.table.Width;
            canvas3D1.Invalidate();
        }

        private void numLength_ValueChanged(object sender, EventArgs e)
        {
            canvas3D1.module.table.Length = (int)Math.Max(1, numLength.Value);
            numLength.Value = canvas3D1.module.table.Length;
            canvas3D1.Invalidate();
        }

        private void numDuration_ValueChanged(object sender, EventArgs e)
        {
            canvas3D1.SetDura((int)Math.Max(1, numDuration.Value));
        }

        private void brushSizeX_Scroll(object sender, EventArgs e)
        {
            canvas3D1.BrushSize = brushSize.Value / 1000d;
        }

        public ScaleSettings ssets = null;

        private void AxisSettingsButton_Click(object sender, EventArgs e)
        {
            if (ssets == null || ssets.IsDisposed)
            {
                ScaleSettings settings = new ScaleSettings(this);
                ssets = settings;
                settings.Show();
            }

        }

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            var control = canvas3D1.Input.GetControl();
            if (control == null)
            {
                return;
            }
            ModuleForm moduleform = new ModuleForm(control, canvas3D1.Input.GetName());
            moduleform.Show();
        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            canvas3D1.Input = item.Factory();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
