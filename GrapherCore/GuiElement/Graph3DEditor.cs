using Grapher.Brushes;
using Grapher.Editor3d.Processing;
using Grapher.GuiElement;
using Grapher.GuiElement.TableModule2Guis;
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
        public TableModule module;
        public Neo3DEditor canvas3D1; //HACK public to be available to other controls
        private IBrush brush = new RoundSharpBrush(100f);

        private Boolean inInit = true;

        //not to be used, only to trick the visual framework into building it
        public Graph3DEditor() : this(new()) { }


        public Graph3DEditor(TableModule nmodule) {
            module = nmodule;


            canvas3D1 = new Neo3DEditor(nmodule, () => this.brush) {
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

            numWidth.Value = module.Table.width_;
            numLength.Value = module.Table.height;
            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(module.Input.GetType());

            scalesSettingsControl1.ActualConstructor(this);
            // ////
            inInit = false;
        }

        private void NumWidth_ValueChanged(object sender, EventArgs e) {
            if (inInit) { return; }
            RawTable table = module.Table;
            int nwidth = Math.Max(1, (int)numWidth.Value);
            long diff = nwidth - table.width_;
            long start = table.width_ + Math.Min(0, diff);
            table = table.CloneAndRIColumns((uint)start, (int)diff);

            if (numWidth.Value != table.width_) {
                numWidth.Value = table.width_;
            }
            module.Table = table;
            canvas3D1.Invalidate();
        }

        private void NumLength_ValueChanged(object sender, EventArgs e) {
            if (inInit) { return; }
            RawTable table = module.Table;
            int nlength = Math.Max(1, (int)numLength.Value);
            long diff = nlength - table.height;
            long start= table.height + Math.Min(0, diff);
            table = table.CloneAndRIRows((uint)start, (int)diff);

            if (numLength.Value != table.height) {
                numLength.Value = table.height;
            }
            module.Table = table;
            canvas3D1.Invalidate();
        }

        private void BrushSizeX_Scroll(object sender, EventArgs e) { brush.Radius = brushSize.Value / 1000f; }


        private ModuleForm? inputform = null;

        private void EditInputButton_Click(object sender, EventArgs e) {
            var control = module.Input.GetControl();
            if (control == null) { return; }
            if (inputform == null || inputform.IsDisposed) {
                inputform = new(control, module.Input.Name);
                inputform.Show();
            }
            else { inputform.Dispose(); }

        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            if (inInit) { return; }
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            if (item == null) { return; }
            if (inputform != null && !inputform.IsDisposed) { inputform.Dispose(); }
            module.Input = item.Factory();
        }


    }
}
