using Grapher.Modules;
using Grapher.SoundProcessing;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Grapher.GuiElement
{
    public partial class MainSettings : UserControl
    {
        private Boolean inInit = true;

        public MainSettings()
        {
            InitializeComponent();
            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            //doesnt work, it give the wrong one as it does it before load take place
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(ChainProvider.RootModule.GetType());
            inInit = false;
        }

        public class HollowModuleProvider : IModuleChainProvider
        {
            public HollowModuleProvider(IModule module) { RootModule = module; }
            public IModule RootModule { get; set; }
            public double TimeOffDelay { get; set; } = 500;
            public double Detune { get; set; } = 0;
        }

        /// <summary>
        /// old way that need rework
        /// </summary>
        public readonly SharedStuff shared = new(440, new HollowModuleProvider(new TableModule()));

        public IModuleChainProvider ChainProvider {
            get => shared.ModuleProvider;
            set {
                shared.ModuleProvider = value;
                //MyRefresh();//doesnt work
            }
        }

        private ModuleForm? inputform = null;

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            //MyRefresh();//it work but its too late
            var root = ChainProvider.RootModule;
            var control = root.GetControl();
            if (control == null)
            { return; }
            if (inputform == null || inputform.IsDisposed)
            {
                inputform = new(control, root.Name);
                inputform.Show();
            }
            else
            { inputform.Dispose(); }
        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            if (item == null)
            { return; }
            if (inputform != null && !inputform.IsDisposed)
            { inputform.Dispose(); }
            ChainProvider.RootModule = item.Factory();
        }

        public void MyRefresh()
        {
            inInit = true;
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(ChainProvider.RootModule.GetType());
            ReleaseDelayUd.Value = (decimal)ChainProvider.TimeOffDelay;
            ChainProvider.Detune = Detuner.Value;
            inInit = false;
        }

        private void ReleaseDelayUd_ValueChanged(object sender, EventArgs e)
        {
            ChainProvider.TimeOffDelay = (double)ReleaseDelayUd.Value;
        }

        private void Detuner_Scroll(object sender, EventArgs e)
        {
            ChainProvider.Detune = Detuner.Value;
        }
    }
}
