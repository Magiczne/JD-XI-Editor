using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
// ReSharper disable InvertIf

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
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(Enumerable.Repeat<byte>(0x20, 12 - nameBytes.Length));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Partial name
        /// </summary>
        private string _name;

        #endregion

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
    }
}