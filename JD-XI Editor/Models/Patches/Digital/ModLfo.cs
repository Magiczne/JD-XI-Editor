using Caliburn.Micro;
using JD_XI_Editor.Models.Enums;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class ModLfo : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new intance of ModLfo
        /// </summary>
        public ModLfo()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Shape = LfoShape.Triangle;
            Rate = 88;
            TempoSync = false;
            SyncNote = SyncNote.SixteenthNote;
            PulseWidthShift = 127;
            PitchDepth = 16;
            FilterDepth = 0;
            AmpDepth = 0;
            PanDepth = 0;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) Rate,
                (byte) (TempoSync ? 0x01 : 0x00),
                (byte) SyncNote,
                (byte) PulseWidthShift,
                (byte) 0x00, //Reserve
                (byte) (PitchDepth + 64),
                (byte) (FilterDepth + 64),
                (byte) (AmpDepth + 64),
                (byte) (PanDepth + 64)
            };
        }

        #region Fields

        /// <summary>
        ///     LFO shape
        /// </summary>
        private LfoShape _shape;

        /// <summary>
        ///     Rate
        /// </summary>
        private int _rate;

        /// <summary>
        ///     Is tempo synchronization on
        /// </summary>
        private bool _tempoSync;

        /// <summary>
        ///     Tempo synchronization base note
        /// </summary>
        private SyncNote _syncNote;

        /// <summary>
        ///     Pulse width shift
        /// </summary>
        private int _pulseWidthShift;

        /// <summary>
        ///     Pitch depth
        /// </summary>
        private int _pitchDepth;

        /// <summary>
        ///     Filter depth
        /// </summary>
        private int _filterDepth;

        /// <summary>
        ///     Amplifier depth
        /// </summary>
        private int _ampDepth;

        /// <summary>
        ///     Pan depth
        /// </summary>
        private int _panDepth;

        #endregion

        #region Properties

        /// <summary>
        ///     LFO shape
        /// </summary>
        public LfoShape Shape
        {
            get => _shape;
            set
            {
                if (value != _shape)
                {
                    _shape = value;
                    NotifyOfPropertyChange(nameof(Shape));
                }
            }
        }

        /// <summary>
        ///     Rate
        /// </summary>
        public int Rate
        {
            get => _rate;
            set
            {
                if (value != _rate)
                {
                    _rate = value;
                    NotifyOfPropertyChange(nameof(Rate));
                }
            }
        }

        /// <summary>
        ///     Is tempo synchronization on
        /// </summary>
        public bool TempoSync
        {
            get => _tempoSync;
            set
            {
                if (value != _tempoSync)
                {
                    _tempoSync = value;
                    NotifyOfPropertyChange(nameof(TempoSync));
                }
            }
        }

        /// <summary>
        ///     Tempo synchronization base note
        /// </summary>
        public SyncNote SyncNote
        {
            get => _syncNote;
            set
            {
                if (value != _syncNote)
                {
                    _syncNote = value;
                    NotifyOfPropertyChange(nameof(SyncNote));
                }
            }
        }

        /// <summary>
        ///     Pulse width shift
        /// </summary>
        public int PulseWidthShift
        {
            get => _pulseWidthShift;
            set
            {
                if (value != _pulseWidthShift)
                {
                    _pulseWidthShift = value;
                    NotifyOfPropertyChange(nameof(PulseWidthShift));
                }
            }
        }

        /// <summary>
        ///     Pitch depth
        /// </summary>
        public int PitchDepth
        {
            get => _pitchDepth;
            set
            {
                if (value != _pitchDepth)
                {
                    _pitchDepth = value;
                    NotifyOfPropertyChange(nameof(PitchDepth));
                }
            }
        }

        /// <summary>
        ///     Filter depth
        /// </summary>
        public int FilterDepth
        {
            get => _filterDepth;
            set
            {
                if (value != _filterDepth)
                {
                    _filterDepth = value;
                    NotifyOfPropertyChange(nameof(FilterDepth));
                }
            }
        }

        /// <summary>
        ///     Amplifier depth
        /// </summary>
        public int AmpDepth
        {
            get => _ampDepth;
            set
            {
                if (value != _ampDepth)
                {
                    _ampDepth = value;
                    NotifyOfPropertyChange(nameof(AmpDepth));
                }
            }
        }

        /// <summary>
        ///     Panorama depth
        /// </summary>
        public int PanDepth
        {
            get => _panDepth;
            set
            {
                if (value != _panDepth)
                {
                    _panDepth = value;
                    NotifyOfPropertyChange(nameof(PanDepth));
                }
            }
        }

        #endregion
    }
}