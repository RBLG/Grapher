using Grapher.Modes;
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
    public partial class ModeSetGui : UserControl
    {
        private readonly SetMode mode;
        public ModeSetGui(SetMode nmode)
        {
            InitializeComponent();
            mode = nmode;
            this.NumUdIntensity.Value = (decimal)mode.Max;
        }

        private void NumUdIntensity_ValueChanged(object sender, EventArgs e)
        {
            mode.Max = (double)NumUdIntensity.Value;
        }
    }
}
