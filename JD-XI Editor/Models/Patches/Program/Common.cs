using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.VocalEffect.Type;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class Common : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Common
        /// </summary>
        public Common()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
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

            bytes.AddRange(ByteUtils.RepeatReserve(4));

            bytes.Add((byte) Level);
            bytes.AddRange(ByteUtils.NumberTo4Packets(Tempo, ByteUtils.Offset.None));
            bytes.Add(0x00); // Reserve

            bytes.Add((byte) VocalEffectType);

            bytes.AddRange(ByteUtils.RepeatReserve(5));

            bytes.Add((byte) VocalEffectNumber);
            bytes.Add((byte) VocalEffectPart);

            bytes.Add(ByteUtils.BooleanToByte(AutoNote));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Program Name (12 chars)
        /// </summary>
        private string _name;

        /// <summary>
        ///     Program Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Program Tempo
        /// </summary>
        private int _tempo;

        /// <summary>
        ///     Vocal Effect Type
        /// </summary>
        private Type _vocalEffectType;

        /// <summary>
        ///     Vocal Effect Number
        /// </summary>
        private EffectNumber _vocaEffectNumber;

        /// <summary>
        ///     Vocal Effect Part
        /// </summary>
        private Part _vocalEffectPart;

        /// <summary>
        ///     Auto Note Switch
        /// </summary>
        private bool _autoNote;

        #endregion

        #region Properties

        /// <summary>
        ///     Program Name
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
        ///     Program Level
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

        /// <summary>
        ///     Tempo
        /// </summary>
        public int Tempo
        {
            get => _tempo;
            set
            {
                if (value != _tempo)
                {
                    _tempo = value;
                    NotifyOfPropertyChange(nameof(Tempo));
                }
            }
        }

        /// <summary>
        ///     Vocal Effect Type
        /// </summary>
        public Type VocalEffectType
        {
            get => _vocalEffectType;
            set
            {
                if (value != _vocalEffectType)
                {
                    _vocalEffectType = value;
                    NotifyOfPropertyChange(nameof(VocalEffectType));
                }
            }
        }
   
        /// <summary>
        ///     Vocal Effect Number
        /// </summary>
        public EffectNumber VocalEffectNumber
        {
            get => _vocaEffectNumber;
            set
            {
                if (value != _vocaEffectNumber)
                {
                    _vocaEffectNumber = value;
                    NotifyOfPropertyChange(nameof(VocalEffectNumber));
                }
            }
        }

        /// <summary>
        ///     Vocal Effect Part
        /// </summary>
        public Part VocalEffectPart
        {
            get => _vocalEffectPart;
            set
            {
                if (value != _vocalEffectPart)
                {
                    _vocalEffectPart = value;
                    NotifyOfPropertyChange(nameof(VocalEffectPart));
                }
            }
        }

        /// <summary>
        ///     Auto Note
        /// </summary>
        public bool AutoNote
        {
            get => _autoNote;
            set
            {
                if (value != _autoNote)
                {
                    _autoNote = value;
                    NotifyOfPropertyChange(nameof(AutoNote));
                }
            }
        }

        #endregion
    }
}