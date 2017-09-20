using Caliburn.Micro;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Common : PropertyChangedBase
    {
        #region Fields

        /// <summary>
        ///     Portamento
        /// </summary>
        private bool _portamento;

        /// <summary>
        ///     Legato
        /// </summary>
        private bool _legato;

        /// <summary>
        ///     Portamento time
        /// </summary>
        private int _portamentoTime;

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

        #endregion

        #region Properties

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

        #endregion

        /// <inheritdoc />
        /// <summary>
        /// Creates new instance of AnalogCommon
        /// </summary>
        public Common()
        {
            Portamento = false;
            Legato = false;
            PortamentoTime = 20;
            OctaveShift = 0;
            PitchBendRangeUp = 2;
            PitchBendRangeDown = 2;
        }

        /// <summary>
        /// Reset data to initial patch
        /// </summary>
        public void Reset()
        {
            Portamento = false;
            Legato = false;
            PortamentoTime = 20;
            OctaveShift = 0;
            PitchBendRangeUp = 2;
            PitchBendRangeDown = 2;
        }

        /// <summary>
        /// Get bytes
        /// </summary>
        /// <returns></returns>
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) (Portamento ? 0x01 : 0x00),
                (byte) PortamentoTime,
                (byte) (Legato ? 0x01 : 0x00),
                (byte) (OctaveShift + 64),
                (byte) PitchBendRangeUp,
                (byte) PitchBendRangeDown
            };
        }
    }
}