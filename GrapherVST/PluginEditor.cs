namespace GrapherVST
{
    using GrapherVST.SynthHandling;
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Plugin.Framework;
    using Jacobi.Vst.Plugin.Framework.Common;
    using System;
    using System.Threading.Tasks;
    using System.Windows.Threading;

    /// <summary>
    /// Implements the custom UI editor for the plugin.
    /// </summary>
    internal sealed class PluginEditor : IVstPluginEditor
    {
        private readonly WinFormsControlWrapper<UI.MainWindow> _uiWrapper = new();
        private readonly ModuleProvider _moduleProvider;

        public PluginEditor(ModuleProvider prov)
        {
            _moduleProvider = prov ?? throw new ArgumentNullException(nameof(prov));
            _uiWrapper.SafeInstance.ModuleProvider = _moduleProvider;
        }

        #region IVstPluginEditor Members

        public System.Drawing.Rectangle Bounds {
            get { return _uiWrapper.Bounds; }
        }

        public void Close()
        { _uiWrapper.Close(); }

        public bool KeyDown(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        { return false; }

        public bool KeyUp(byte ascii, VstVirtualKey virtualKey, VstModifierKeys modifers)
        { return false; }

        public VstKnobMode KnobMode { get; set; }

        public void Open(IntPtr hWnd)
        {
            _uiWrapper.SafeInstance.ModuleProvider = _moduleProvider;
            ///////////////////////////////////////////////////////////////////////
            ///A VERY UGLY FIX TO GET THE LOADED ROOT MODULE TO SHOW CORRECTLY IN THE INPUTCOMBOBOX
            var e = Dispatcher.CurrentDispatcher.BeginInvoke(
            new Action(async () =>
            {
                await Task.Delay(1000);
                _uiWrapper.SafeInstance.settings.MyRefresh();
            })
            );
            ///////////////////////////////////////////////////////////////////////
            _uiWrapper.Open(hWnd);
        }

        public void ProcessIdle()
        {
            _uiWrapper.SafeInstance.ProcessIdle();
        }

        #endregion
    }
}
