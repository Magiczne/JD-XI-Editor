using System;
using System.Threading;
using System.Windows;
using Caliburn.Micro;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;
using Timer = System.Timers.Timer;

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
        ///     VFX offset address
        /// </summary>
        private static readonly byte[] VfxEffectsOffset = {0x18, 0x00, 0x01, 0x00};

        /// <summary>
        ///     Common dump request
        /// </summary>
        private static readonly byte[] CommonDumpRequest = {0x00, 0x00, 0x00, 0x1F};

        /// <summary>
        ///     VFX dump request
        /// </summary>
        private static readonly byte[] VfxDumpRequest = { 0x00, 0x00, 0x00, 0x18 };

        /// <summary>
        ///     Expected common dump length
        /// </summary>
        private const int ExpectedCommonDumpLength = 31;

        /// <summary>
        ///     Expected VFX dump length
        /// </summary>
        private const int ExpectedVfxDumpLength = 24;

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            var vfxPatch = (CommonAndVocalEffectPatch) patch;

            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(CommonOffset, vfxPatch.Common.GetBytes()));
                output.Send(SysExUtils.GetMessage(VfxEffectsOffset, vfxPatch.VocalEffect.GetBytes()));
                output.Send(SysExUtils.GetMessage(AutoNoteOffset, new[] { ByteUtils.BooleanToByte(vfxPatch.Common.AutoNote) }));
            }
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            var device = new InputDevice(inputDeviceId);
            var timer = new Timer(1);

            const int commonDumpLength = ExpectedCommonDumpLength + SysExUtils.DumpPaddingSize;
            const int vfxDumpLength = ExpectedVfxDumpLength + SysExUtils.DumpPaddingSize;

            var dumpCount = 0;

            SysExMessage common = null;
            SysExMessage vfx = null;

            // Setup event handler for receiving SysEx messages
            device.SysExMessageReceived += (sender, args) =>
            {
                if (args.Message.Length == commonDumpLength)
                {
                    common = args.Message;
                }
                else if (args.Message.Length == vfxDumpLength)
                {
                    vfx = args.Message;
                }

                dumpCount++;

                if (dumpCount == 2)
                {
                    timer.Stop();
                    timer.Dispose();

                    device.StopRecording();
                    device.Dispose();

                    DataDumpReceived?.Invoke(this, new CommonAndVocalFxDumpReceivedEventArgs(new CommonAndVocalEffectPatch(common, vfx)));
                }
            };

            timer.Elapsed += (sender, args) =>
            {
                timer.Stop();
                timer.Dispose();

                device.StopRecording();
                device.Dispose();

                // TODO: FIXME: It is throwing in another thread. 
                throw new TimeoutException("Read data operation timeout");
            };

            // Start recording input from device
            device.StartRecording();

            // Request data dump from device
            using (var output = new OutputDevice(outputDeviceId))
            {
                output.Send(SysExUtils.GetRequestDumpMessage(CommonOffset, CommonDumpRequest));
                output.Send(SysExUtils.GetRequestDumpMessage(VfxEffectsOffset, VfxDumpRequest));
                timer.Start();
            }
        }

        /// <inheritdoc />
        public void DumpCommon(IPatchPart common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(CommonOffset, common.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpVocalEffects(IPatchPart vocalFx, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(VfxEffectsOffset, vocalFx.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void SetAutoNote(bool value, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(AutoNoteOffset, new[] { ByteUtils.BooleanToByte(value) }));
            }
        }
    }
}