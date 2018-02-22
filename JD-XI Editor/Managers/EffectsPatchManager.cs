using System.Collections.Generic;
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
        /// <summary>
        ///     Offset for specified effect
        /// </summary>
        private static IEnumerable<byte> EffectOffset(Effect effect) => new byte[] {0x18, 0x00, (byte) effect, 0x00};

        #region Methods

        /// <summary>
        ///     Get sysex data for patch
        /// </summary>
        private static byte[] GetSysexDataForPatch(IPatch patch, Effect effect)
        {
            var patchBytes = patch.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(EffectOffset(effect));
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, EffectOffset(effect)));
            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        #endregion

        #region IEffectsPatchManager

        /// <inheritdoc />
        public void DumpEffect(EffectPatch patch, Effect effect, int deviceId)
        {
            var data = GetSysexDataForPatch(patch, effect);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var effectPatch = (Patch) patch;

            var effect1Data = GetSysexDataForPatch(effectPatch.Effect1, Effect.Effect1);
            var effect2Data = GetSysexDataForPatch(effectPatch.Effect2, Effect.Effect2);
            var delayData = GetSysexDataForPatch(effectPatch.Delay, Effect.Delay);
            var reverbData = GetSysexDataForPatch(effectPatch.Reverb, Effect.Reverb);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(effect1Data));
                output.Send(new SysExMessage(effect2Data));
                output.Send(new SysExMessage(delayData));
                output.Send(new SysExMessage(reverbData));
            }
        }

        #endregion
    }
}