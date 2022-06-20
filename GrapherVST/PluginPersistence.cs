namespace GrapherVST
{
    using Grapher.Modules;
    using GrapherVST.SynthHandling;
    using Jacobi.Vst.Core;
    using Jacobi.Vst.Plugin.Framework;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    internal sealed class PluginPersistence : IVstPluginPersistence
    {
        //private readonly MapNoteItemList _noteMap;
        private readonly Encoding _encoding = Encoding.ASCII;
        private readonly ModuleProvider _moduleProvider;

        public PluginPersistence(ModuleProvider modprov)
        {
            _moduleProvider = modprov ?? throw new ArgumentNullException(nameof(modprov));
        }

        #region IVstPluginPersistence Members

        public bool CanLoadChunk(VstPatchChunkInfo chunkInfo)
        {
            return true;
        }

        public void ReadPrograms(Stream stream, VstProgramCollection programs)
        {
            var reader = new BinaryReader(stream, _encoding);

            IModule nroot = Cereal.Deserialize<IModule>(reader.ReadString());
            _moduleProvider.SetRootModule(nroot);
        }

        public void WritePrograms(Stream stream, VstProgramCollection programs)
        {
            var writer = new BinaryWriter(stream, _encoding);

            IModule root = _moduleProvider.GetRootModule();
            string str = Cereal.Serialize<IModule>(root);
            //to fix this stupid behavior that add double curly brackets
            str = str.Replace("{{", "{");
            str = str.Replace("}}", "}");
            writer.Write(str);
            //throw new Exception(str);

        }



        #endregion




    }
}
