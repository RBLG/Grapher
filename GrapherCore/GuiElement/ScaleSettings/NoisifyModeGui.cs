﻿using Grapher.Modes;
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
    public partial class NoisifyModeGui : UserControl
    {
        private readonly NoisifyMode mode;
        public NoisifyModeGui(NoisifyMode nmode)
        {
            InitializeComponent();
            mode = nmode;
            NumUdIntensity.Value = (decimal)mode.Intensity;
        }

        private void NumUdIntensity_ValueChanged(object sender, EventArgs e)
        {
            mode.Intensity = (double)NumUdIntensity.Value;
        }

    }
}
