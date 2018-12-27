using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Delay
{
    internal class BasicData : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates a new instance of BasicData
        /// </summary>
        public BasicData()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = true;
            Level = 0;
            ReverbSendLevel = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is BasicData data)
            {
                On = data.On;
                Level = data.Level;
                ReverbSendLevel = data.ReverbSendLevel;
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

            On = ByteUtils.ByteToBoolean(data[0]);
            Level = data[1];
            ReverbSendLevel = data[3];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Level,
                0x00, // Reserve
                (byte) ReverbSendLevel
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 4;

        /// <summary>
        ///     Is delay on
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        #endregion
    }
}