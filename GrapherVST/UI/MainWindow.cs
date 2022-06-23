using Grapher;
using Grapher.Modules;
using GrapherVST.SynthHandling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;

namespace GrapherVST.UI
{
    /// <summary>
    /// The plugin custom editor UI.
    /// </summary>
    internal sealed partial class MainWindow : UserControl
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public IModuleChainProvider ModuleProvider { get => settings.ChainProvider; set => settings.ChainProvider = value; }

        public void ProcessIdle()
        {

        }
    }
}
