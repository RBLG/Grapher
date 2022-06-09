using GrapherVST.SynthHandling;
using Jacobi.Vst.Core;
using Jacobi.Vst.Plugin.Framework;
using Jacobi.Vst.Plugin.Framework.Plugin;
using Microsoft.Extensions.DependencyInjection;

namespace GrapherVST
{
    /// <summary>
    /// The Plugin root class that implements the interface manager and the plugin midi source.
    /// </summary>
    internal sealed class Plugin : VstPluginWithServices
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public Plugin()
            : base("Grapher Synth", 0x30313233,
                new VstProductInfo("Grapher synth", "some guy on the internet", 0001),
                VstPluginCategory.Synth)
        { }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ModuleProvider>()
                .AddSingletonAll<AudioProcessor>()
                .AddSingletonAll<PluginEditor>()
                .AddSingletonAll<MidiProcessor>()
                .AddSingletonAll<PluginPersistence>();
        }
    }
}
