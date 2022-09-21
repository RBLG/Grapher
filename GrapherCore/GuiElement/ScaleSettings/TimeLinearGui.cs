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

namespace Grapher.GuiElement.ScaleSettings
{
    public partial class TimeLinearGui : UserControl
    {
        private readonly TimeLinearScale scale;

        public TimeLinearGui(TimeLinearScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            this.NumUdLength.Value = (decimal)scale.Duration;
            this.ComboBoxMode.SelectedIndex = scale.IsLooping ? 0 : 1;
            this.NumUdHold.Value = (decimal)scale.Hold;
        }



        private void LoopLength_ValueChanged(object sender, EventArgs e)
        {
            scale.Duration = (double)NumUdLength.Value;
        }

        private void ComboBoxMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            scale.IsLooping = ComboBoxMode.SelectedIndex == 0;
            if (ComboBoxMode.SelectedIndex == 0)
            { NumUdHold.Enabled = false; }
            else
            { NumUdHold.Enabled = true; }
        }

        private void NumUdHold_ValueChanged(object sender, EventArgs e)
        {
            scale.Hold = (double)NumUdHold.Value;
        }
    }
}
