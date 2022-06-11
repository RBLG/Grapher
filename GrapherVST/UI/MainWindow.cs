using Grapher;
using Grapher.Modules;
using GrapherVST.SynthHandling;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

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

        public IModuleChainProvider ModuleProvider { get => settings.Chain; set => settings.Chain = value; }

        public void ProcessIdle()
        {

        }

    }
}
