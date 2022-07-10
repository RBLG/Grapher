using Grapher.GuiElement;
using Grapher.Modules;
using Grapher.Scale;
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
        public Canvas3D canvas3D1;

        private readonly Boolean inInit = true;

        //not to be used, only to trick the visual framework into building it
        public Graph3DEditor() : this(new()) { }

        public Graph3DEditor(TableModule nmodule)
        {
            //putting it here because graphical editor doesnt work if i put it in the designer
            //module = nmodule;
            canvas3D1 = new Grapher.Canvas3D(nmodule)
            {
                BrushSize = 0D,
                Location = new System.Drawing.Point(254, 21),
                Size = new System.Drawing.Size(618, 451),
                Name = "canvas3D1",
                TabIndex = 25,
                Text = "canvas3D1",
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left,
            };
            InitializeComponent();
            //after init so it is in the background
            Controls.Add(canvas3D1);

            numWidth.Value = canvas3D1.module.Table.Width;
            numLength.Value = canvas3D1.module.Table.Length;
            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(canvas3D1.module.Input.GetType());

            scalesSettingsControl1.ActualConstructor(this);
            // ////
            inInit = false;
        }

        private void NumWidth_ValueChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            canvas3D1.module.Table.Width = (int)Math.Max(1, numWidth.Value);
            numWidth.Value = canvas3D1.module.Table.Width;
            canvas3D1.Custom_Resize(sender, e);
            canvas3D1.Invalidate();
        }

        private void NumLength_ValueChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            canvas3D1.module.Table.Length = (int)Math.Max(1, numLength.Value);
            numLength.Value = canvas3D1.module.Table.Length;
            canvas3D1.Custom_Resize(sender, e);
            canvas3D1.Invalidate();
        }

        private void BrushSizeX_Scroll(object sender, EventArgs e)
        { canvas3D1.BrushSize = brushSize.Value / 1000d; }


        private ModuleForm? inputform = null;

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            var control = canvas3D1.Input.GetControl();
            if (control == null)
            { return; }
            if (inputform == null || inputform.IsDisposed)
            {
                inputform = new(control, canvas3D1.Input.Name);
                inputform.Show();
            }
            else
            { inputform.Dispose(); }

        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            if (item == null)
            { return; }
            if (inputform != null && !inputform.IsDisposed)
            { inputform.Dispose(); }
            canvas3D1.Input = item.Factory();
        }


    }
}
