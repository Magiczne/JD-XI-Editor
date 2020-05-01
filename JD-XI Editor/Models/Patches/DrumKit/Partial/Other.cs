using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Other : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Other()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            OneShotMode = false;
            RelativeLevel = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Other oth)
            {
                OneShotMode = oth.OneShotMode;
                RelativeLevel = oth.RelativeLevel;
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

            OneShotMode = ByteUtils.ByteToBoolean(data[0]);
            RelativeLevel = data[1] - 64;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(OneShotMode),
                (byte) (RelativeLevel + 64)
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 2;

        /// <summary>
        ///     One shot mode
        /// </summary>
        public bool OneShotMode { get; set; }

        /// <summary>
        ///     Relative volume level
        /// </summary>
        public int RelativeLevel { get; set; }

        #endregion
    }
}