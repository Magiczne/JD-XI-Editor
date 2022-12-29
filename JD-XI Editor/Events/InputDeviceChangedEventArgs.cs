using System;

namespace JD_XI_Editor.Events
{
    internal class InputDeviceChangedEventArgs : EventArgs
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of InputDeviceChangedEventArgs
        /// </summary>
        /// <param name="device">Device ID</param>
        public InputDeviceChangedEventArgs(int device)
        {
            DeviceId = device;
        }

        /// <summary>
        ///     Device ID
        /// </summary>
        public int DeviceId { get; }
    }
}