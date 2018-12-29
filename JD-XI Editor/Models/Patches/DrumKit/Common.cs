using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.DrumKit
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Common()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Name = "Init sound";
            Level = 127;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Common c)
            {
                Name = c.Name;
                Level = c.Level;
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

            Name = Encoding.ASCII.GetString(data.Take(12).ToArray());
            Level = data[12];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name.Length > 12 ? Name.Substring(0, 12) : Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(ByteUtils.RepeatReserve(12 - nameBytes.Length, 0x20));

            bytes.Add((byte) Level);

            bytes.AddRange(ByteUtils.RepeatReserve(5));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 18;

        /// <summary>
        ///     Drum kit name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Drum kit Level
        /// </summary>
        public int Level { get; set; }

        #endregion
    }
}