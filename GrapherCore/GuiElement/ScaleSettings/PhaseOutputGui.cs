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
    public partial class PhaseOutputGui : UserControl
    {
        private readonly PhaseOutputScale scale;
        public PhaseOutputGui(PhaseOutputScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            CheckBoxIsAbsolute.Checked = scale.IsAbsolute;
            NumUdOffset.Value = (decimal)scale.Offset;
        }

        private void CheckBoxIsAbsolute_CheckedChanged(object sender, EventArgs e)
        {
            scale.IsAbsolute = CheckBoxIsAbsolute.Checked;
        }

        private void NumUdOffset_ValueChanged(object sender, EventArgs e)
        {
            scale.Offset = (double)NumUdOffset.Value;
        }
    }
}
