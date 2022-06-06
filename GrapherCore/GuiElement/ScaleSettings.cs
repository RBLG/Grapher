using Grapher.Modes;
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
using static Grapher.Scale.AvailableScales;

namespace Grapher.GuiElement
{
    public partial class ScaleSettings : Form
    {
        public ScaleSettings(Graph3DEditor neditor)
        {
            Editor = neditor;
            InitializeComponent();
            WidthAxisComboBox.ValueMember = "Factory";
            WidthAxisComboBox.DisplayMember = "Name";
            WidthAxisComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            WidthAxisComboBox.SelectedIndex = AvailableScales.GetIndex(WidthAxis.GetType());
            oldwidth = WidthAxisComboBox.SelectedIndex;

            LengthAxisComboBox.ValueMember = "Factory";
            LengthAxisComboBox.DisplayMember = "Name";
            LengthAxisComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            LengthAxisComboBox.SelectedIndex = AvailableScales.GetIndex(LengthAxis.GetType());
            oldlength = LengthAxisComboBox.SelectedIndex;

            HeightAxisComboBox.ValueMember = "Factory";
            HeightAxisComboBox.DisplayMember = "Name";
            HeightAxisComboBox.Items.AddRange(AvailableScales.scales.ToArray());
            HeightAxisComboBox.SelectedIndex = AvailableScales.GetIndex(HeightAxis.GetType());

            ActionComboBox.ValueMember = "Factory";
            ActionComboBox.DisplayMember = "Name";
            ActionComboBox.Items.AddRange(AvailableModes.modes.ToArray());
            ActionComboBox.SelectedIndex = AvailableModes.GetIndex(HeightAction.GetType());

        }

        public Graph3DEditor Editor { get; set; }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private IScale WidthAxis { get => Editor.canvas3D1.module.Wscale; set => Editor.canvas3D1.module.Wscale = value; }
        private IScale LengthAxis { get => Editor.canvas3D1.module.Lscale; set => Editor.canvas3D1.module.Lscale = value; }
        private IScale HeightAxis { get => Editor.canvas3D1.module.Hscale; set => Editor.canvas3D1.module.Hscale = value; }
        private IMode HeightAction { get => Editor.canvas3D1.module.Mode; set => Editor.canvas3D1.module.Mode = value; }


        private int oldwidth;
        private void WidthAxisComboBox_Enter(object sender, EventArgs e)
        {
            oldwidth = WidthAxisComboBox.SelectedIndex;
        }

        private void WidthAxisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nwscale = AvailableScales.Get(WidthAxisComboBox.SelectedIndex);
            if (LengthAxisComboBox.SelectedIndex != -1 && nwscale.SType == AvailableScales.Get(LengthAxisComboBox.SelectedIndex).SType)
            {
                LengthAxis = WidthAxis;
                LengthAxisComboBox.SelectedIndex = oldlength = oldwidth;
            }
            //Console.WriteLine("wa set");
            oldwidth = WidthAxisComboBox.SelectedIndex;
            WidthAxis = nwscale.Factory();
        }

        private int oldlength;
        private void LengthAxisComboBox_Enter(object sender, EventArgs e)
        {
            oldlength = LengthAxisComboBox.SelectedIndex;
        }

        private void LengthAxisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nlscale = AvailableScales.Get(LengthAxisComboBox.SelectedIndex);
            if (WidthAxisComboBox.SelectedIndex != -1 && nlscale.SType == AvailableScales.Get(WidthAxisComboBox.SelectedIndex).SType)
            {
                WidthAxis = LengthAxis;
                WidthAxisComboBox.SelectedIndex = oldwidth = oldlength;
            }
            //Console.WriteLine("la set");
            oldlength = LengthAxisComboBox.SelectedIndex;
            LengthAxis = nlscale.Factory();
        }

        private void HeightAxisComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            HeightAxis = AvailableScales.Get(HeightAxisComboBox.SelectedIndex).Factory();
        }
    }
}
