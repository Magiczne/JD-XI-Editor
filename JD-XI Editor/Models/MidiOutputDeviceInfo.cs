using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.Models
{
    internal class MidiOutputDeviceInfo
    {
        /// <summary>
        ///     Create new instance of MidiOutputDeviceInfo
        /// </summary>
        /// <param name="caps"></param>
        public MidiOutputDeviceInfo(MidiOutCaps caps)
        {
            ChannelMask = caps.channelMask;
            DriverVersion = caps.driverVersion;
            Mid = caps.mid;
            Name = caps.name;
            Notes = caps.notes;
            Pid = caps.pid;
            Support = caps.support;
            Technology = caps.technology;
            Voices = caps.voices;
        }

        /// <summary>
        ///     Channels that an internal synthesizer device responds to,
        ///     where the least significant bit refers to channel 0 and the most significant bit to channel 15.
        ///     Port devices that transmit on all channels set this member to 0xFFFF.
        /// </summary>
        public short ChannelMask { get; }

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
        ///     Maximum number of simultaneous notes that can be played by an internal synthesizer device.
        ///     If the device is a port, this member is not meaningful and is set to 0.
        /// </summary>
        public short Notes { get; }

        /// <summary>
        ///     Product identifier of the Midi device.
        /// </summary>
        public short Pid { get; }

        /// <summary>
        ///     Optional functionality supported by the device.
        /// </summary>
        public int Support { get; }

        /// <summary>
        ///     Flags describing the type of the Midi output device.
        /// </summary>
        public short Technology { get; }

        /// <summary>
        ///     Number of voices supported by an internal synthesizer device.
        ///     If the device is a port, this member is not meaningful and is set to 0.
        /// </summary>
        public short Voices { get; }
    }
}