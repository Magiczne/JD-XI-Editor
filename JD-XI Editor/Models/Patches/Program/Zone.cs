using System.Collections.Generic;
using System.Windows.Documents;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class Zone : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Zone()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            ArpeggioSwitch = false;
            ZoneOctaveShift = ZoneOctaveShift.Zero;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.RepeatReserve(3));
            bytes.Add(ByteUtils.BooleanToByte(ArpeggioSwitch));
            bytes.AddRange(ByteUtils.RepeatReserve(10));

            bytes.AddRange(ByteUtils.RepeatReserve(11));    //10 * 2 packets + 1
            bytes.Add((byte) ZoneOctaveShift);
            bytes.AddRange(ByteUtils.RepeatReserve(9));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Arpeggio Switch
        /// </summary>
        private bool _arpeggioSwitch;

        /// <summary>
        ///     Zone Octave Shift
        /// </summary>
        private ZoneOctaveShift _zoneOctaveShift;

        #endregion

        #region Properties

        /// <summary>
        ///     Arpeggio Switch
        /// </summary>
        public bool ArpeggioSwitch
        {
            get => _arpeggioSwitch;
            set
            {
                if (value != _arpeggioSwitch)
                {
                    _arpeggioSwitch = value;
                    NotifyOfPropertyChange(nameof(ArpeggioSwitch));
                }
            }
        }

        /// <summary>
        ///     Zone Octave Shift
        /// </summary>
        public ZoneOctaveShift ZoneOctaveShift
        {
            get => _zoneOctaveShift;
            set
            {
                if (value != _zoneOctaveShift)
                {
                    _zoneOctaveShift = value;
                    NotifyOfPropertyChange(nameof(ZoneOctaveShift));
                }
            }
        }

        #endregion
    }
}