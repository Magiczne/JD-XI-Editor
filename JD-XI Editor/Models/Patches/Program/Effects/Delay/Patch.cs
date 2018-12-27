using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Patches.Program.Abstract;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class Patch : EffectPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Delay Patch
        /// </summary>
        public Patch()
        {
            Basic = new BasicData();
            Parameters = new Parameters();

            Basic.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Basic));
            Parameters.PropertyChanged += (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
        }

        /// <inheritdoc />
        public override void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Basic.CopyFrom(data.Take(4).ToArray());
            Parameters.CopyFrom(data.Skip(4).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Basic.GetBytes());
            bytes.AddRange(Parameters.GetBytes());

            return bytes.ToArray();
        }

        /// <inheritdoc />
        public override int DumpLength { get; } = 100;
    }
}