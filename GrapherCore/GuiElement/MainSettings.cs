using Grapher.Modules;
using Grapher.SoundProcessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grapher.GuiElement
{
    public partial class MainSettings : UserControl
    {
        private readonly Boolean inInit = true;

        public MainSettings()
        {
            InitializeComponent();
            InputComboBox.ValueMember = "Factory";
            InputComboBox.DisplayMember = "Name";
            InputComboBox.Items.AddRange(AvailableModules.modules.ToArray());
            InputComboBox.SelectedIndex = 1;
            inInit = false;
        }

        public class HollowModuleProvider : IModuleChainProvider
        {
            public HollowModuleProvider(IModule mod)
            { root = mod; }

            private IModule root;

            public IModule GetRootModule()
            { return root; }

            public void SetRootModule(IModule module)
            { root = module; }
        }

        public readonly SharedStuff shared = new(440, new HollowModuleProvider(new DefaultPitchModule()));

        public IModuleChainProvider Chain {
            get => shared.Module;
            set {
                InputComboBox.SelectedIndex = AvailableModules.GetIndex(value.GetRootModule().GetType());
                shared.Module = value;
            }
        }

        private ModuleForm? inputform = null;

        private void EditInputButton_Click(object sender, EventArgs e)
        {
            var root = Chain.GetRootModule();
            var control = root.GetControl();
            if (control == null)
            { return; }
            if (inputform == null || inputform.IsDisposed)
            {
                inputform = new(control, root.Name);
                //here: if is 3Deditor, set it input to harmonics editor, maybe
                inputform.Show();
            }
            else
            { inputform.Dispose(); }
        }

        private void InputComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (inInit) { return; }
            var item = AvailableModules.modules.ElementAt(InputComboBox.SelectedIndex);
            Chain.SetRootModule(item.Factory());
        }

        private void MainSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
