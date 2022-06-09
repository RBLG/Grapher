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

        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        /// <param name="plugin">Must not be null.</param>
        public AudioProcessor(ModuleProvider nmoddprovider) : base(1, 1, 0, noSoundInStop: true)
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
