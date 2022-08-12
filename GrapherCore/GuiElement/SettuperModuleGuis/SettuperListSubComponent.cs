using Grapher.Modules;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.GuiElement.SettuperModuleGui
{
    public partial class SettuperListSubComponent : UserControl
    {
        public SettupedHarmonic harmo;
        protected Action<SettuperListSubComponent> deleter;


        public SettuperListSubComponent() : this(new(), (s) => { }) { }

        public SettuperListSubComponent(SettupedHarmonic nharmo, Action<SettuperListSubComponent> ndel)
        {
            harmo = nharmo;
            deleter = ndel;
            InitializeComponent();
            NumUdHarmonic.Value = harmo.Multiplier;
            NumUdAmplitude.Value = (decimal)harmo.Amplitude;
        }

        private void NumUdAmplitude_ValueChanged(object sender, EventArgs e)
        {
            harmo.Amplitude = (double)NumUdAmplitude.Value;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            deleter(this);
        }

        private void NumUdHarmonic_ValueChanged(object sender, EventArgs e)
        {
            harmo.Multiplier = (int)NumUdHarmonic.Value;
        }
    }
}
