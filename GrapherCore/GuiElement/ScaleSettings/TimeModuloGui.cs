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
    public partial class TimeModuloGui : UserControl
    {
        private readonly TimeModuloScale scale;

        public TimeModuloGui(TimeModuloScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            this.CheckBoxIsLooping.Checked = scale.IsLooping;
            this.CheckBoxIsRandom.Checked = scale.IsRandom;
            this.NumUdChunkSize.Value = (decimal)scale.Modulo;
        }

        private void CheckBoxIsRandom_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsRandom = this.CheckBoxIsRandom.Checked;
        }

        private void CheckBoxIsLooping_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsLooping = this.CheckBoxIsLooping.Checked;
        }

        private void NumUdChunkSize_ValueChanged(object sender, EventArgs e)
        {
            scale.Modulo = (double)NumUdChunkSize.Value;
        }
    }
}
