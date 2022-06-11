namespace GrapherVST
{
    using GrapherVST.SynthHandling;
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Plugin.Framework;
    using Jacobi.Vst.Plugin.Framework.Common;
    using System;

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
            _uiWrapper.Open(hWnd);
        }

        public void ProcessIdle()
        {
            _uiWrapper.SafeInstance.ProcessIdle();
        }

        #endregion
    }
}
