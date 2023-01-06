using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Serializing.Inspectors;
using Microsoft.Win32;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace JD_XI_Editor.Serializing
{
    internal class PatchSerializer
    {
        private readonly IDeserializer _deserializer;
        private readonly ISerializer _serializer;

        public PatchSerializer()
        {
            _deserializer = new DeserializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .Build();

            _serializer = new SerializerBuilder()
                .WithNamingConvention(PascalCaseNamingConvention.Instance)
                .WithTypeInspector(inspector => new DrumKitPartialInspector(inspector))
                .WithTypeInspector(inspector => new PatchPartInspector(inspector))
                .WithTypeInspector(inspector => new PropertyChangedBaseInspector(inspector))
                .Build();
        }

        public void Serialize(IPatch patch)
        {
            var saveFileDialog = new SaveFileDialog
            {
                AddExtension = true,
                DefaultExt = "yml",
                Filter = "JD-XI Editor patch file|*.yml"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                using (var writer = new StreamWriter(saveFileDialog.FileName))
                {
                    _serializer.Serialize(writer, patch);
                }
            }
        }

        public DeserializationResult<T> Deserialize<T>() where T : IPatch
        {
            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = "yml",
                Filter = "JD-XI Editor patch file|*.yml"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                using (var reader = new StreamReader(openFileDialog.FileName))
                {
                    return new DeserializationResult<T>(true, _deserializer.Deserialize<T>(reader));
                }
            }

            return new DeserializationResult<T>(false, default);
        }
    }
}
