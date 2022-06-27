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
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(ChainProvider.GetRootModule().GetType());
            inInit = false;
        }

        public class HollowModuleProvider : IModuleChainProvider
        {
            private IModule root;
            public HollowModuleProvider(IModule module) { root = module; }
            public IModule GetRootModule() => root;
            public void SetRootModule(IModule module) { root = module; }
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
            var root = ChainProvider.GetRootModule();
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
            if (item == null)
            { return; }
            if (inputform != null && !inputform.IsDisposed)
            { inputform.Dispose(); }
            ChainProvider.SetRootModule(item.Factory());
        }

        public void MainSettings_Load(object sender, EventArgs e)
        {
            //MyRefresh();//doesnt work
        }

        public void MyRefresh()
        {
            inInit = true;
            InputComboBox.SelectedIndex = AvailableModules.GetIndex(ChainProvider.GetRootModule().GetType());
            inInit = false;
            //throw new Exception("type: " + ChainProvider.GetRootModule().GetType());
        }
    }
}
