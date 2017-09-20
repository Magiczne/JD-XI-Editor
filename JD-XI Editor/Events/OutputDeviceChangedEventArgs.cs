using System;

namespace JD_XI_Editor.Events
{
    internal class OutputDeviceChangedEventArgs : EventArgs
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new isntance of InputDeviceChangedEventArgs
        /// </summary>
        /// <param name="device"></param>
        public OutputDeviceChangedEventArgs(int device)
        {
            DeviceId = device;
        }

        /// <summary>
        ///     Device ID
        /// </summary>
        public int DeviceId { get; }
    }
}