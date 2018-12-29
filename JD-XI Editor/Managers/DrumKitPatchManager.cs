using System;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.DrumKit;

namespace JD_XI_Editor.Managers
{
    internal class DrumKitPatchManager : IDrumKitPatchManager
    {
        #region Events

        /// <inheritdoc />
        public event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <inheritdoc />
        public event EventHandler<TimeoutException> OperationTimedOut;

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
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void DumpPartial(Patch patch, string key, int deviceId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}