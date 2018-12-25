using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class ThruEffectParameters : EffectParameters
    {
        /// <inheritdoc />
        public override void Reset()
        {
        }

        /// <inheritdoc />
        public override void CopyFrom(IPatchPart part)
        {
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            return ByteUtils.Repeat4MidiPacketsReserve(32);
        }
    }
}