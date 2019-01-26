using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
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

        /// TODO: Set
        /// <inheritdoc />
        public int DumpLength { get; }

        public string Name { get; set; }

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
            throw new NotImplementedException();
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
    }
}