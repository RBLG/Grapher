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
    public partial class PhaseGui : UserControl
    {
        private readonly PhaseScale scale;
        public PhaseGui(PhaseScale nscale)
        {
            InitializeComponent();
            scale = nscale;
            NumUdOffset.Value = (decimal)scale.Offset;
        }

        private void NumUdOffset_ValueChanged(object sender, EventArgs e)
        {
            scale.Offset = (double)NumUdOffset.Value;
        }
    }
}
