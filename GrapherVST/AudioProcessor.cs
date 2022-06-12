namespace GrapherVST
{
    using GrapherVST.SynthHandling;
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Plugin.Framework.Plugin;
    using System;

    /// <summary>
    /// Implements the audio processing of the plugin using the <see cref="SampleManager"/>.
    /// </summary>
    internal sealed class AudioProcessor : VstPluginAudioProcessor
    {
        private readonly ModuleProvider _modprovider;


        public override float SampleRate {
            get { return _modprovider.SampleRate; }
            set {
                _modprovider.SampleRate = value;
                _modprovider.interval = 1000d / value;
            }
        }

        public AudioProcessor(ModuleProvider nmoddprovider) : base(1, 2, 100, noSoundInStop: true)
        {
            _modprovider = nmoddprovider ?? throw new ArgumentNullException(nameof(nmoddprovider));
        }

        public override void Process(VstAudioBuffer[] inChannels, VstAudioBuffer[] outChannels)
        {
            if (_modprovider.IsPlaying)
            { _modprovider.PlayAudio(outChannels); }
            else // audio thru //need it?
            { base.Process(inChannels, outChannels); }
        }
    }
}
