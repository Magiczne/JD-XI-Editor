using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Lfo : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Lfo
        /// </summary>
        public Lfo()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Shape = LfoShape.Triangle;
            Rate = 53;
            FadeTime = 0;
            TempoSync = false;
            SyncNote = SyncNote.SixteenthNote;
            PitchDepth = 0;
            FilterDepth = 0;
            AmpDepth = 0;
            KeyTrigger = true;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Shape,
                (byte) Rate,
                (byte) FadeTime,
                ByteUtils.BooleanToByte(TempoSync),
                (byte) SyncNote,
                (byte) (PitchDepth + 64),
                (byte) (FilterDepth + 64),
                (byte) (AmpDepth + 64),
                ByteUtils.BooleanToByte(KeyTrigger)
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
        ///     Fade time
        /// </summary>
        private int _fadeTime;

        /// <summary>
        ///     Is tempo synchronization on
        /// </summary>
        private bool _tempoSync;

        /// <summary>
        ///     Tempo synchronization base note
        /// </summary>
        private SyncNote _syncNote;

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
        ///     Is key trigger on
        /// </summary>
        private bool _keyTrigger;

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
        ///     Fade time
        /// </summary>
        public int FadeTime
        {
            get => _fadeTime;
            set
            {
                if (value != _fadeTime)
                {
                    _fadeTime = value;
                    NotifyOfPropertyChange(nameof(FadeTime));
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
        ///     Is key trigger on
        /// </summary>
        public bool KeyTrigger
        {
            get => _keyTrigger;
            set
            {
                if (value != _keyTrigger)
                {
                    _keyTrigger = value;
                    NotifyOfPropertyChange(nameof(KeyTrigger));
                }
            }
        }

        #endregion
    }
}