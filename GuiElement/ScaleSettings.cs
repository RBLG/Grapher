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

namespace Grapher.GuiElement
{
    public partial class ScaleSettings : Form
    {
        public ScaleSettings()
        {
            InitializeComponent();
            WidthAxisComboBox.ValueMember = "Factory";
            WidthAxisComboBox.DisplayMember = "Name";
            WidthAxisComboBox.Items.AddRange(AvailableScaleList.scales.ToArray());
            WidthAxisComboBox.SelectedIndex = 1;

            LengthAxisComboBox.ValueMember = "Factory";
            LengthAxisComboBox.DisplayMember = "Name";
            LengthAxisComboBox.Items.AddRange(AvailableScaleList.scales.ToArray());
            LengthAxisComboBox.SelectedIndex = 1;

            HeightAxisComboBox.ValueMember = "Factory";
            HeightAxisComboBox.DisplayMember = "Name";
            HeightAxisComboBox.Items.AddRange(AvailableScaleList.scales.ToArray());
            HeightAxisComboBox.SelectedIndex = 1;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
