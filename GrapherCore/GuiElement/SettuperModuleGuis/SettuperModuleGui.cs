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
    public partial class SettuperModuleGui : UserControl
    {
        protected SettuperModule module;

        public SettuperModuleGui()
        {
            module = new();
            InitializeComponent();
            CreateWaveGui();
        }

        public SettuperModuleGui(SettuperModule nmodule)
        {
            module = nmodule;
            InitializeComponent();
            CreateWaveGui();
        }

        public void CreateWaveGui()
        {
            foreach (SettupedMainWave wave in module.MainWaves)
            {
                AddWaveGui(wave);
            }
        }

        private void AddWaveButton_Click(object sender, EventArgs e)
        {
            SettupedMainWave nwave = new();
            module.AddWave(nwave);
            AddWaveGui(nwave);
        }

        private void AddWaveGui(SettupedMainWave nwave)
        {
            SettuperListComponent comp = new(nwave, RemoveWave, UpdateWaves);
            comp.Anchor = AnchorStyles.Right & AnchorStyles.Left & AnchorStyles.Top;
            comp.Size = new(ComponentFlPanel.Size.Width, comp.Size.Height);
            ComponentFlPanel.SuspendLayout();
            ComponentFlPanel.Controls.Add(comp);
            ResizeControl(comp);
            ComponentFlPanel.ResumeLayout(true);
        }

        private void FlowResized(object sender, EventArgs e)
        {
            foreach (Control cont in ComponentFlPanel.Controls)
            {
                ResizeControl(cont);
            }
        }

        private void ResizeControl(Control cont)
        {
            int offset = cont.Location.X;
            int nwidth = ComponentFlPanel.Size.Width - 5 * 2 - 20;
            cont.Size = new(nwidth, cont.Size.Height);
            cont.MaximumSize = new(nwidth, 9999999);
        }

        private void RemoveWave(SettuperListComponent comp)
        {
            ComponentFlPanel.SuspendLayout();
            module.RemoveWave(comp.wave);
            ComponentFlPanel.Controls.Remove(comp);
            ComponentFlPanel.ResumeLayout(true);
        }

        private void UpdateWaves(int unused)
        {
            module.UpdateStock();
        }

        private void SettuperModuleGui_Load(object sender, EventArgs e)
        {
            FlowResized(sender, e);
        }
    }
}
