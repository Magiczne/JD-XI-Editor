using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AnalogCommon
        /// </summary>
        public Common()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Portamento = false;
            Legato = false;
            PortamentoTime = 20;
            OctaveShift = 0;
            PitchBendRangeUp = 2;
            PitchBendRangeDown = 2;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Common common)
            {
                Portamento = common.Portamento;
                Legato = common.Legato;
                PortamentoTime = common.PortamentoTime;
                OctaveShift = common.OctaveShift;
                PitchBendRangeUp = common.PitchBendRangeUp;
                PitchBendRangeDown = common.PitchBendRangeDown;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Portamento = ByteUtils.ByteToBoolean(data[0]);
            PortamentoTime = data[1];
            Legato = ByteUtils.ByteToBoolean(data[2]);
            OctaveShift = data[3] - 64;
            PitchBendRangeUp = data[4];
            PitchBendRangeDown = data[5];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(Portamento),
                (byte) PortamentoTime,
                ByteUtils.BooleanToByte(Legato),
                (byte) (OctaveShift + 64),
                (byte) PitchBendRangeUp,
                (byte) PitchBendRangeDown,
                (byte) 0x00 //Reserve
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 7;

        /// <summary>
        ///     Portamento
        /// </summary>
        public bool Portamento { get; set; }

        /// <summary>
        ///     Legato
        /// </summary>
        public bool Legato { get; set; }

        /// <summary>
        ///     Portamento time
        /// </summary>
        public int PortamentoTime { get; set; }

        /// <summary>
        ///     Octave shift
        /// </summary>
        public int OctaveShift { get; set; }

        /// <summary>
        ///     Pitch bend range up
        /// </summary>
        public int PitchBendRangeUp { get; set; }

        /// <summary>
        ///     Pitch bend range down
        /// </summary>
        public int PitchBendRangeDown { get; set; }

        #endregion
    }
}