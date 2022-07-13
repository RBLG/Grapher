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
    public partial class PhaseModuloGui : UserControl
    {
        private readonly PhaseModuloScale scale;
        public PhaseModuloGui(PhaseModuloScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            NumUdDetune.Value = (decimal)scale.Detune;
            NumUdCount.Value = (decimal)scale.CycleCount;
            NumUdSeed.Value = (decimal)scale.Seed;
            CheckBoxIsLooping.Checked = scale.IsLooping;
            CheckBoxIsRandom.Checked = scale.IsRandom;
        }

        private void CheckBoxIsRandom_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsRandom = CheckBoxIsRandom.Checked;
        }

        private void CheckBoxIsLooping_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsLooping = CheckBoxIsLooping.Checked;
        }

        private void NumUdSeed_ValueChanged(object sender, EventArgs e)
        {
            scale.Seed = (double)NumUdSeed.Value;
        }

        private void NumUdDetune_ValueChanged(object sender, EventArgs e)
        {
            scale.Detune = (double)NumUdDetune.Value;
        }

        private void NumUdCount_ValueChanged(object sender, EventArgs e)
        {
            scale.CycleCount = (double)NumUdCount.Value;
        }

    }
}
