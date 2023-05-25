using Grapher.GuiElement.SettuperModuleGui;
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

namespace Grapher.GuiElement.SettuperModuleGuis
{
    public partial class SettuperListComponent : UserControl
    {

        public SettupedMainWave wave;
        protected Action<SettuperListComponent> deleter;
        protected Action<int> updater; //forgot how to do a lambda without parameter or return

        public SettuperListComponent() : this(new(), (s) => { }, (e) => { }) { }

        public SettuperListComponent(SettupedMainWave nwave, Action<SettuperListComponent> ndel, Action<int> nupd) {
            wave = nwave;
            deleter = ndel;
            updater = nupd;
            InitializeComponent();
            CreateWaveGui();
            NumUdFrequency.Value = (decimal)wave.Frequency;
            ampTrackBar.Value = (int)(wave.Amplitude * 1000 * 5);
        }

        public void CreateWaveGui() {
            foreach (SettupedHarmonic wave in wave.Harmonics) {
                AddHarmonicGui(wave);
            }
        }

        private void AddHarmonicButton_Click(object sender, EventArgs e) {
            SettupedHarmonic nharmo = new();
            wave.Harmonics.Add(nharmo);
            AddHarmonicGui(nharmo);
            updater(0);
        }

        private void AddHarmonicGui(SettupedHarmonic harmo) {
            SettuperListSubComponent comp = new(harmo, RemoveHarmonic);
            HarmonicsFlPanel.SuspendLayout();
            HarmonicsFlPanel.Controls.Add(comp);
            HarmonicsFlPanel.ResumeLayout(true);
        }


        private void RemoveHarmonic(SettuperListSubComponent comp) {
            HarmonicsFlPanel.SuspendLayout();
            wave.Harmonics.Remove(comp.harmo);
            HarmonicsFlPanel.Controls.Remove(comp);
            updater(0);
            HarmonicsFlPanel.ResumeLayout(true);
        }

        private void NumUdFrequency_ValueChanged(object sender, EventArgs e) {
            wave.Frequency = (double)NumUdFrequency.Value;
        }

        private void DeleteButton_Click(object sender, EventArgs e) {
            deleter(this);
        }

        private void ampTrackBar_Scroll(object sender, EventArgs e) {
            wave.Amplitude = ampTrackBar.Value / 1000d * 0.2d;
        }
    }
}
