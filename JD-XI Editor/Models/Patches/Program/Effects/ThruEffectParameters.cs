using System.Linq;

namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class ThruEffectParameters : EffectParameters
    {
        public override void Reset()
        {
            
        }

        public override byte[] GetBytes()
        {
            return Enumerable.Repeat<byte>(0x00, 32 * 4).ToArray();
        }
    }
}