using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Basic : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Basic()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Name = "Init Partial";
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Basic basic)
            {
                Name = basic.Name;
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

            Name = Encoding.ASCII.GetString(data);
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name.Length > 12 ? Name.Substring(0, 12) : Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(ByteUtils.RepeatReserve(12 - nameBytes.Length, 0x20));

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 12;

        /// <summary>
        ///     Partial name
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}