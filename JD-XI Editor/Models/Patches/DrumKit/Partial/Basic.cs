using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Basic : PropertyChangedBase, IPatchPart
    {
        #region Fields

        /// <summary>
        ///     Partial name
        /// </summary>
        private string _name;

        #endregion

        /// <inheritdoc />
        public Basic()
        {
            Reset();
        }

        #region Properties

        public string Name
        {
            get => _name;
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyOfPropertyChange(nameof(Name));
                }
            }
        }

        #endregion

        /// <inheritdoc />
        public void Reset()
        {
            Name = "Init Partial";
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