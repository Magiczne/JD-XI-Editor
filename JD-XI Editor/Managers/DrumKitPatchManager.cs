using System;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.Utils;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Managers
{
    internal class DrumKitPatchManager : IDrumKitPatchManager
    {
        #region Fields

        /// <summary>
        ///     Common address offset
        /// </summary>
        private readonly byte[] _commonAddressOffset = {0x19, 0x70, 0x00, 0x00};

        #endregion

        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

        #endregion

        #region Methods

        /// <summary>
        ///     Partial address offset
        /// </summary>
        private static byte[] PartialAddressOffset(DrumKey key)
        {
            return new byte[] { 0x19, 0x70, (byte) key, 0x00 };
        }

        #endregion

        #region IPatchManager

        /// <inheritdoc />
        public void Dump(IPatch patch, int deviceId)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void Read(int inputDeviceId, int outputDeviceId)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IDrumKitPatchManager

        /// <inheritdoc />
        public void DumpCommon(Common common, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(_commonAddressOffset, common.GetBytes()));
            }
        }

        /// <inheritdoc />
        public void DumpPartial(Partial partial, int deviceId)
        {
            using (var output = new OutputDevice(deviceId))
            {
                output.Send(SysExUtils.GetMessage(PartialAddressOffset(partial.Key), partial.GetBytes()));
            }
        }

        #endregion
    }
}