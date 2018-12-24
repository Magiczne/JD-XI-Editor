using System;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class ProgramCommonAndVocalEffectsManager : IProgramCommonAndVocalEffectsManager
    {
        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <summary>
        ///     Program common offset address
        /// </summary>
        private static readonly byte[] CommonOffset = {0x18, 0x00, 0x00, 0x00};

        /// <summary>
        ///     Auto Note offset address
        /// </summary>
        private static readonly byte[] AutoNoteOffset = {0x18, 0x00, 0x00, 0x1E};

        /// <summary>
        ///     Program vocal effects offset address
        /// </summary>
        private static readonly byte[] VocalEffectsOffset = { 0x18, 0x00, 0x01, 0x00 };

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var vfxPatch = (CommonAndVocalEffectPatch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(vfxPatch.Common.GetBytes(), CommonOffset));
                output.Send(SysExUtils.GetMessage(vfxPatch.VocalEffect.GetBytes(), VocalEffectsOffset));
                output.Send(SysExUtils.GetMessage(new[] { ByteUtils.BooleanToByte(vfxPatch.Common.AutoNote) }, AutoNoteOffset));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void DumpCommon(IPatchPart common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(common.GetBytes(), CommonOffset));
            }
        }

        /// <inheritdoc />
        public void DumpVocalEffects(IPatchPart vocalFx, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(vocalFx.GetBytes(), VocalEffectsOffset));
            }
        }

        /// <inheritdoc />
        public void SetAutoNote(bool value, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(new[] { ByteUtils.BooleanToByte(value) }, AutoNoteOffset));
            }
        }
    }
}