using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.DrumKit
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(Enumerable.Repeat<byte>(0x20, 12 - nameBytes.Length));

            bytes.Add((byte) Level);

            bytes.AddRange(Enumerable.Repeat<byte>(0x00, 6));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Drum kit name
        /// </summary>
        private string _name;

        /// <summary>
        ///     Drum kit level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Drum kit name
        /// </summary>
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

        /// <summary>
        ///     Drum kit Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        #endregion
    }
}