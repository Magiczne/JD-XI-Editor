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
        public override byte[] GetBytes()
        {
            return ByteUtils.Repeat4PacketsReserve(32);
        }
    }
}