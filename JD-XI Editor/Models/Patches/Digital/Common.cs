using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
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
            Name = "Init Tone";
            ToneLevel = 100;
            Portamento = false;
            PortamentoTime = 20;
            Mono = false;
            OctaveShift = 0;
            PitchBendRangeUp = 2;
            PitchBendRangeDown = 2;

            PartialOneSwitch = true;
            PartialTwoSwitch = false;
            PartialThreeSwitch = false;
            PartialOneSelect = true;
            PartialTwoSelect = false;
            PartialThreeSelect = false;

            Ring = false;
            Unison = false;
            PortamentoMode = PortamentoMode.Legato;
            Legato = true;
            AnalogFeel = 0;
            WaveShape = 0;
            ToneCategory = Category.FxAndOther;
            UnisonSize = UnisonSize.Eight;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            var nameBytes = Encoding.ASCII.GetBytes(Name.Length > 12 ? Name.Substring(0, 12) : Name);
            bytes.AddRange(nameBytes);
            bytes.AddRange(ByteUtils.RepeatReserve(12 - nameBytes.Length, 0x20));

            bytes.Add((byte) ToneLevel);

            bytes.AddRange(ByteUtils.RepeatReserve(5));

            bytes.AddRange(new[]
            {
                ByteUtils.BooleanToByte(Portamento),
                (byte) PortamentoTime,
                ByteUtils.BooleanToByte(Mono),
                (byte) (OctaveShift + 64),
                (byte) PitchBendRangeUp,
                (byte) PitchBendRangeDown,
                (byte) 0x00, //Reserve

                ByteUtils.BooleanToByte(PartialOneSwitch),
                ByteUtils.BooleanToByte(PartialOneSelect),
                ByteUtils.BooleanToByte(PartialTwoSwitch),
                ByteUtils.BooleanToByte(PartialTwoSelect),
                ByteUtils.BooleanToByte(PartialThreeSwitch),
                ByteUtils.BooleanToByte(PartialThreeSelect),

                ByteUtils.BooleanToByte(Ring),
            });

            bytes.AddRange(ByteUtils.RepeatReserve(14));

            bytes.Add(ByteUtils.BooleanToByte(Unison));

            bytes.AddRange(ByteUtils.RepeatReserve(2));

            bytes.AddRange(new[]
            {
                (byte) PortamentoMode,
                ByteUtils.BooleanToByte(Legato),
                (byte) 0x00, //Reserve
                (byte) AnalogFeel,
                (byte) WaveShape,
                (byte) ToneCategory
            });

            bytes.AddRange(ByteUtils.RepeatReserve(5));

            bytes.Add((byte) UnisonSize);

            bytes.AddRange(ByteUtils.RepeatReserve(3));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Tone name
        /// </summary>
        private string _name;

        /// <summary>
        ///     Tone level
        /// </summary>
        private int _toneLevel;

        /// <summary>
        ///     Portamento switch
        /// </summary>
        private bool _portamento;

        /// <summary>
        ///     Portamento time
        /// </summary>
        private int _portamentoTime;

        /// <summary>
        ///     Mono switch
        /// </summary>
        private bool _mono;

        /// <summary>
        ///     Octave shift
        /// </summary>
        private int _octaveShift;

        /// <summary>
        ///     Pitch bend range up
        /// </summary>
        private int _pitchBendRangeUp;

        /// <summary>
        ///     Pitch bend range down
        /// </summary>
        private int _pitchBendRangeDown;

        /// <summary>
        ///     Partial 1 Switch
        /// </summary>
        private bool _partialOneSwitch;

        /// <summary>
        ///     Partial 2 Switch
        /// </summary>
        private bool _partialTwoSwitch;

        /// <summary>
        ///     Partial 3 Switch
        /// </summary>
        private bool _partialThreeSwitch;

        /// <summary>
        ///     Partial 1 Select
        /// </summary>
        private bool _partialOneSelect;

        /// <summary>
        ///     Partial 2 Select
        /// </summary>
        private bool _partialTwoSelect;

        /// <summary>
        ///     Partial 3 Select
        /// </summary>
        private bool _partialThreeSelect;

        /// <summary>
        ///     Ring switch
        /// </summary>
        private bool _ring; //CARE 0->Off, 2->On

        /// <summary>
        ///     Unison switch
        /// </summary>
        private bool _unison;

        /// <summary>
        ///     Portamento mode
        /// </summary>
        private PortamentoMode _portamentoMode;

        /// <summary>
        ///     Legato switch
        /// </summary>
        private bool _legato;

        /// <summary>
        ///     Analog feel
        /// </summary>
        private int _analogFeel;

        /// <summary>
        ///     Wave shape
        /// </summary>
        private int _waveShape;

        /// <summary>
        ///     Tone category
        /// </summary>
        private Category _toneCategory;

        /// <summary>
        ///     Unison size
        /// </summary>
        private UnisonSize _unisonSize;

        #endregion

        #region Properties

        /// <summary>
        ///     Patch name
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
        ///     Tone Level
        /// </summary>
        public int ToneLevel
        {
            get => _toneLevel;
            set
            {
                if (value != _toneLevel)
                {
                    _toneLevel = value;
                    NotifyOfPropertyChange(nameof(ToneLevel));
                }
            }
        }

        /// <summary>
        ///     Portamento
        /// </summary>
        public bool Portamento
        {
            get => _portamento;
            set
            {
                if (value != _portamento)
                {
                    _portamento = value;
                    NotifyOfPropertyChange(nameof(Portamento));
                }
            }
        }

        /// <summary>
        ///     Portamento time
        /// </summary>
        public int PortamentoTime
        {
            get => _portamentoTime;
            set
            {
                if (value != _portamentoTime)
                {
                    _portamentoTime = value;
                    NotifyOfPropertyChange(nameof(PortamentoTime));
                }
            }
        }

        /// <summary>
        ///     Mono
        /// </summary>
        public bool Mono
        {
            get => _mono;
            set
            {
                if (value != _mono)
                {
                    _mono = value;
                    NotifyOfPropertyChange(nameof(Mono));
                }
            }
        }

        /// <summary>
        ///     Octave shift
        /// </summary>
        public int OctaveShift
        {
            get => _octaveShift;
            set
            {
                if (value != _octaveShift)
                {
                    _octaveShift = value;
                    NotifyOfPropertyChange(nameof(OctaveShift));
                }
            }
        }

        /// <summary>
        ///     Pitch bend range up
        /// </summary>
        public int PitchBendRangeUp
        {
            get => _pitchBendRangeUp;
            set
            {
                if (value != _pitchBendRangeUp)
                {
                    _pitchBendRangeUp = value;
                    NotifyOfPropertyChange(nameof(PitchBendRangeUp));
                }
            }
        }

        /// <summary>
        ///     Pitch bend range down
        /// </summary>
        public int PitchBendRangeDown
        {
            get => _pitchBendRangeDown;
            set
            {
                if (value != _pitchBendRangeDown)
                {
                    _pitchBendRangeDown = value;
                    NotifyOfPropertyChange(nameof(PitchBendRangeDown));
                }
            }
        }

        /// <summary>
        ///     Partial 1 Switch
        /// </summary>
        public bool PartialOneSwitch
        {
            get => _partialOneSwitch;
            set
            {
                if (value != _partialOneSwitch)
                {
                    _partialOneSwitch = value;
                    NotifyOfPropertyChange(nameof(PartialOneSwitch));
                }
            }
        }

        /// <summary>
        ///     Partial 2 Switch
        /// </summary>
        public bool PartialTwoSwitch
        {
            get => _partialTwoSwitch;
            set
            {
                if (value != _partialTwoSwitch)
                {
                    _partialTwoSwitch = value;
                    NotifyOfPropertyChange(nameof(PartialTwoSwitch));
                }
            }
        }

        /// <summary>
        ///     Partial 3 Switch
        /// </summary>
        public bool PartialThreeSwitch
        {
            get => _partialThreeSwitch;
            set
            {
                if (value != _partialThreeSwitch)
                {
                    _partialThreeSwitch = value;
                    NotifyOfPropertyChange(nameof(PartialThreeSwitch));
                }
            }
        }

        /// <summary>
        ///     Partial 1 Select
        /// </summary>
        public bool PartialOneSelect
        {
            get => _partialOneSelect;
            set
            {
                if (value != _partialOneSelect)
                {
                    _partialOneSelect = value;
                    NotifyOfPropertyChange(nameof(PartialOneSelect));
                }
            }
        }

        /// <summary>
        ///     Partial 2 Select
        /// </summary>
        public bool PartialTwoSelect
        {
            get => _partialTwoSelect;
            set
            {
                if (value != _partialTwoSelect)
                {
                    _partialTwoSelect = value;
                    NotifyOfPropertyChange(nameof(PartialTwoSelect));
                }
            }
        }

        /// <summary>
        ///     Partial 3 Select
        /// </summary>
        public bool PartialThreeSelect
        {
            get => _partialThreeSelect;
            set
            {
                if (value != _partialThreeSelect)
                {
                    _partialThreeSelect = value;
                    NotifyOfPropertyChange(nameof(PartialThreeSelect));
                }
            }
        }

        /// <summary>
        ///     Ring
        /// </summary>
        public bool Ring
        {
            get => _ring;
            set
            {
                if (value != _ring)
                {
                    _ring = value;
                    NotifyOfPropertyChange(nameof(Ring));
                }
            }
        }

        /// <summary>
        ///     Unison
        /// </summary>
        public bool Unison
        {
            get => _unison;
            set
            {
                if (value != _unison)
                {
                    _unison = value;
                    NotifyOfPropertyChange(nameof(Unison));
                }
            }
        }

        /// <summary>
        ///     Portamento mode
        /// </summary>
        public PortamentoMode PortamentoMode
        {
            get => _portamentoMode;
            set
            {
                if (value != _portamentoMode)
                {
                    _portamentoMode = value;
                    NotifyOfPropertyChange(nameof(PortamentoMode));
                }
            }
        }

        /// <summary>
        ///     Legato
        /// </summary>
        public bool Legato
        {
            get => _legato;
            set
            {
                if (value != _legato)
                {
                    _legato = value;
                    NotifyOfPropertyChange(nameof(Legato));
                }
            }
        }

        /// <summary>
        ///     Analog feel
        /// </summary>
        public int AnalogFeel
        {
            get => _analogFeel;
            set
            {
                if (value != _analogFeel)
                {
                    _analogFeel = value;
                    NotifyOfPropertyChange(nameof(AnalogFeel));
                }
            }
        }

        /// <summary>
        ///     Wave shape
        /// </summary>
        public int WaveShape
        {
            get => _waveShape;
            set
            {
                if (value != _waveShape)
                {
                    _waveShape = value;
                    NotifyOfPropertyChange(nameof(WaveShape));
                }
            }
        }

        /// <summary>
        ///     Tone category
        /// </summary>
        public Category ToneCategory
        {
            get => _toneCategory;
            set
            {
                if (value != _toneCategory)
                {
                    _toneCategory = value;
                    NotifyOfPropertyChange(nameof(ToneCategory));
                }
            }
        }

        /// <summary>
        ///     Unison size
        /// </summary>
        public UnisonSize UnisonSize
        {
            get => _unisonSize;
            set
            {
                if (value != _unisonSize)
                {
                    _unisonSize = value;
                    NotifyOfPropertyChange(nameof(UnisonSize));
                }
            }
        }

        #endregion
    }
}