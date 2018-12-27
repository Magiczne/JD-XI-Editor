using System;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Managers.Abstract
{
    internal interface IPatchManager
    {   
        /// <summary>
        /// Event handler called when data dump is received from device
        /// </summary>
        event EventHandler<PatchDumpReceivedEventArgs> DataDumpReceived;

        /// <summary>
        ///     Dump patch data to device
        /// </summary>
        void Dump(IPatch patch, int deviceId);

        /// <summary>
        ///     Request data dump from device
        /// </summary>
        void Read(int inputDeviceId, int outputDeviceId);
    }
}