using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
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
            Type = Effect2Type.Thru;
            Level = 127;
            DelaySendLevel = 50;
            ReverbSendLevel = 50;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is BasicData data)
            {
                Type = data.Type;
                Level = data.Level;
                DelaySendLevel = data.DelaySendLevel;
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

            Type = (Effect2Type) data[0];
            Level = data[1];
            DelaySendLevel = data[2];
            ReverbSendLevel = data[3];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) Type,
                (byte) Level,
                (byte) DelaySendLevel,
                (byte) ReverbSendLevel,
                0x00 //Reserve
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 5;

        /// <summary>
        ///     Effect Type
        /// </summary>
        public Effect2Type Type { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        public int DelaySendLevel { get; set; }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        #endregion
    }
}