using System;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Models.Patches.Program.Effects;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class EffectsPatchManager : IEffectsPatchManager
    {
        /// <inheritdoc />
        public void DumpEffect(EffectPatch patch, Effect effect, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(patch.GetBytes(), EffectOffset(effect)));
            }
        }

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var effectPatch = (Patch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(effectPatch.Effect1.GetBytes(), EffectOffset(Effect.Effect1)));
                output.Send(SysExUtils.GetMessage(effectPatch.Effect2.GetBytes(), EffectOffset(Effect.Effect2)));

                output.Send(SysExUtils.GetMessage(effectPatch.Delay.GetBytes(), EffectOffset(Effect.Delay)));
                output.Send(SysExUtils.GetMessage(effectPatch.Reverb.GetBytes(), EffectOffset(Effect.Reverb)));
            }
        }

        /// <summary>
        ///     Offset for specified effect
        /// </summary>
        private static byte[] EffectOffset(Effect effect)
        {
            return new byte[] {0x18, 0x00, (byte) effect, 0x00};
        }

        /// <summary>
        ///     SysEx message length
        /// </summary>
        private static byte[] EffectSysExMessageLength(Effect effect)
        {
            switch (effect)
            {
                case Effect.Effect1:
                case Effect.Effect2:
                    return new byte[] {0x00, 0x00, 0x01, 0x11};

                case Effect.Delay:
                    return new byte[] {0x00, 0x00, 0x00, 0x64};

                case Effect.Reverb:
                    return new byte[] {0x00, 0x00, 0x00, 0x63};

                default:
                    throw new ArgumentOutOfRangeException(nameof(effect), effect, null);
            }
        }
    }
}