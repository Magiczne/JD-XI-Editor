using System.Collections.Generic;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class ProgramCommonAndVocalEffectsManager : IProgramCommonAndVocalEffectsManager
    {
        /// <summary>
        ///     Program common offset address
        /// </summary>
        private static readonly byte[] CommonOffset = {0x18, 0x00, 0x00, 0x00};

        /// <summary>
        ///     Program vocal effects offset address
        /// </summary>
        private static readonly byte[] VocalEffectsOffset = { 0x18, 0x00, 0x01, 0x00 };

        /// <summary>
        ///     Get sysex data
        /// </summary>
        private static byte[] GetSysexData(IPatchPart patch, byte[] offset)
        {
            var patchBytes = patch.GetBytes();

            var bytes = new List<byte>();
            bytes.AddRange(SysExUtils.Header);
            bytes.AddRange(offset);
            bytes.AddRange(patchBytes);
            bytes.Add(SysExUtils.CalculateChecksum(patchBytes, offset));
            bytes.Add(0xF7);

            return bytes.ToArray();
        }

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var commonAndVocalFxPatch = (CommonAndVocalEffectPatch) patch;

            var commonData = GetSysexData(commonAndVocalFxPatch.Common, CommonOffset);
            var vocalFxData = GetSysexData(commonAndVocalFxPatch.VocalEffect, VocalEffectsOffset);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(commonData));
                output.Send(new SysExMessage(vocalFxData));
            }
        }

        /// <inheritdoc />
        public void DumpCommon(IPatchPart common, int deviceId)
        {
            var data = GetSysexData(common, CommonOffset);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }

        /// <inheritdoc />
        public void DumpVocalEffects(IPatchPart vocalFx, int deviceId)
        {
            var data = GetSysexData(vocalFx, VocalEffectsOffset);

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(new SysExMessage(data));
            }
        }
    }
}