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
            CheckBoxIsLooping.Checked = scale.IsLooping;
            CheckBoxIsRandom.Checked = scale.IsRandom;
            NumUdChunkSize.Value = (decimal)scale.Modulo;
            NumUdSeed.Value = (decimal)scale.Modulo;
        }

        private void CheckBoxIsRandom_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsRandom = CheckBoxIsRandom.Checked;
        }

        private void CheckBoxIsLooping_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsLooping = CheckBoxIsLooping.Checked;
        }

        private void NumUdChunkSize_ValueChanged(object sender, EventArgs e)
        {
            scale.Modulo = (double)NumUdChunkSize.Value;
        }

        private void NumUdSeed_ValueChanged(object sender, EventArgs e)
        {
            scale.Seed = (double)NumUdSeed.Value;
        }
    }
}
