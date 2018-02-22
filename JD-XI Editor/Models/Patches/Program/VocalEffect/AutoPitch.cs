using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class AutoPitch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Type,
                (byte) Scale,
                (byte) Key,
                (byte) Note,
                (byte) (Gender + 10),
                (byte) Octave,
                (byte) DryWetBalance
            };
        }

        #region Fields

        /// <summary>
        ///     Auto Pitch Switch
        /// </summary>
        private bool _on;

        /// <summary>
        ///     Auto Pitch Type
        /// </summary>
        private Type _type;

        /// <summary>
        ///     Auto Pitch Scale
        /// </summary>
        private Scale _scale;

        /// <summary>
        ///     Auto Pitch Key
        /// </summary>
        private Key _key;

        /// <summary>
        ///     Auto Pitch Note
        /// </summary>
        private Note _note;

        /// <summary>
        ///     Auto Pitch Gender
        /// </summary>
        private int _gender;

        /// <summary>
        ///     Auto Pitch Octave
        /// </summary>
        private Octave _octave;

        /// <summary>
        ///     Auto Pitch Balance
        /// </summary>
        private int _dryWetBalance;

        #endregion

        #region Properties

        /// <summary>
        ///     Auto Pitch Switch
        /// </summary>
        public bool On
        {
            get => _on;
            set
            {
                if (value != _on)
                {
                    _on = value;
                    NotifyOfPropertyChange(nameof(On));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Type
        /// </summary>
        public Type Type
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    NotifyOfPropertyChange(nameof(Type));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Scale
        /// </summary>
        public Scale Scale
        {
            get => _scale;
            set
            {
                if (value != _scale)
                {
                    _scale = value;
                    NotifyOfPropertyChange(nameof(Scale));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Key
        /// </summary>
        public Key Key
        {
            get => _key;
            set
            {
                if (value != _key)
                {
                    _key = value;
                    NotifyOfPropertyChange(nameof(Key));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Note
        /// </summary>
        public Note Note
        {
            get => _note;
            set
            {
                if (value != _note)
                {
                    _note = value;
                    NotifyOfPropertyChange(nameof(Note));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Gender
        /// </summary>
        public int Gender
        {
            get => _gender;
            set
            {
                if (value != _gender)
                {
                    _gender = value;
                    NotifyOfPropertyChange(nameof(Gender));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Octave
        /// </summary>
        public Octave Octave
        {
            get => _octave;
            set
            {
                if (value != _octave)
                {
                    _octave = value;
                    NotifyOfPropertyChange(nameof(Octave));
                }
            }
        }

        /// <summary>
        ///     Auto Pitch Balance
        /// </summary>
        public int DryWetBalance
        {
            get => _dryWetBalance;
            set
            {
                if (value != _dryWetBalance)
                {
                    _dryWetBalance = value;
                    NotifyOfPropertyChange(nameof(DryWetBalance));
                }
            }
        }

        #endregion
    }
}