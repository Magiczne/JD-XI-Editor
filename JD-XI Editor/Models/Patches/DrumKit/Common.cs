using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

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