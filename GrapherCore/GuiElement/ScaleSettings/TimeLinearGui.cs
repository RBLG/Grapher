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
            this.CheckBoxIsLooping.Checked = scale.IsLooping;
            this.LoopLength.Value = (decimal)scale.Max;
        }

        private void CheckBoxIsLooping_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsLooping = this.CheckBoxIsLooping.Checked;
        }

        private void LoopLength_ValueChanged(object sender, EventArgs e)
        {
            scale.Max = (double)LoopLength.Value;
        }
    }
}
