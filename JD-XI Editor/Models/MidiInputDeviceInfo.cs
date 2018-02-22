using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models
{
    internal class MidiInputDeviceInfo
    {
        /// <summary>
        ///     Create new instance of MidiInputDeviceInfo
        /// </summary>
        /// <param name="caps"></param>
        public MidiInputDeviceInfo(MidiInCaps caps)
        {
            DriverVersion = caps.driverVersion;
            Mid = caps.mid;
            Name = caps.name;
            Pid = caps.pid;
            Support = caps.support;
        }

        /// <summary>
        ///     Version number of the device driver for the Midi device.
        ///     The high-order byte is the major version number, and the low-order byte is the minor version number.
        /// </summary>
        public int DriverVersion { get; }

        /// <summary>
        ///     Manufacturer identifier of the device driver for the Midi device.
        /// </summary>
        public short Mid { get; }

        /// <summary>
        ///     Product name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Product identifier of the Midi device.
        /// </summary>
        public short Pid { get; }

        /// <summary>
        ///     Optional functionality supported by the device.
        /// </summary>
        public int Support { get; }
    }
}