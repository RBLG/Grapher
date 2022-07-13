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
    public partial class PhaseInputGui : UserControl
    {
        private readonly PhaseInputScale scale;
        public PhaseInputGui(PhaseInputScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            CheckBoxIsAbsolute.Checked = scale.IsAbsolute;
            NumUdDetune.Value = (decimal)scale.Detune;
            NumUdAmount.Value = 1/(decimal)scale.Multiplier;

        }

        private void CheckBoxIsAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsAbsolute = CheckBoxIsAbsolute.Checked;
        }

        private void NumUdDetune_ValueChanged(object sender, EventArgs e)
        {
            scale.Detune = (double)NumUdDetune.Value;
        }

        private void NumUdAmount_ValueChanged(object sender, EventArgs e)
        {
            scale.Multiplier = 1 / ((double)NumUdAmount.Value);
        }
    }
}
