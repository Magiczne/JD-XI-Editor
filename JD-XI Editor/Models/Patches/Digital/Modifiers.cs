using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Modifiers : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of modifiers
        /// </summary>
        public Modifiers()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            AttackTimeIntervalSensitivity = 0;
            ReleaseTimeIntervalSensitivity = 0;
            PortamentoTimeIntervalSensitivity = 0;
            EnvelopeLoopMode = EnvelopeLoopMode.Off;
            EnvelopeLoopSyncNote = SyncNote.QuarterNote;
            ChromaticPortamento = false;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>(new[]
            {
                (byte) 0x00, //Reserve
                (byte) AttackTimeIntervalSensitivity,
                (byte) ReleaseTimeIntervalSensitivity,
                (byte) PortamentoTimeIntervalSensitivity,
                (byte) EnvelopeLoopMode,
                (byte) EnvelopeLoopSyncNote,
                ByteUtils.BooleanToByte(ChromaticPortamento)
            });

            bytes.AddRange(ByteUtils.RepeatReserve(30));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Attack Time Interval Sensitivity
        /// </summary>
        private int _attackTimeIntervalSensitivity;

        /// <summary>
        ///     Release Time Interval Sens
        /// </summary>
        private int _releaseTimeIntervalSensitivity;

        /// <summary>
        ///     Portamento Time Interval Sensitivity
        /// </summary>
        private int _portamentoTimeIntervalSensitivity;

        /// <summary>
        ///     Envelope Loop Mode
        /// </summary>
        private EnvelopeLoopMode _envelopeEnvelopeLoopMode;

        /// <summary>
        ///     Envelope Loop Sync note
        /// </summary>
        private SyncNote _envelopeLoopSyncNote;

        /// <summary>
        ///     Envelope Loop Sync Note
        /// </summary>
        private bool _chromaticPortamento;

        #endregion

        #region Properties

        /// <summary>
        ///     Attack Time Interval Sensitivity
        /// </summary>
        public int AttackTimeIntervalSensitivity
        {
            get => _attackTimeIntervalSensitivity;
            set
            {
                if (value != _attackTimeIntervalSensitivity)
                {
                    _attackTimeIntervalSensitivity = value;
                    NotifyOfPropertyChange(nameof(AttackTimeIntervalSensitivity));
                }
            }
        }

        /// <summary>
        ///     Release Time Interval Sens
        /// </summary>
        public int ReleaseTimeIntervalSensitivity
        {
            get => _releaseTimeIntervalSensitivity;
            set
            {
                if (value != _releaseTimeIntervalSensitivity)
                {
                    _releaseTimeIntervalSensitivity = value;
                    NotifyOfPropertyChange(nameof(ReleaseTimeIntervalSensitivity));
                }
            }
        }

        /// <summary>
        ///     Portamento Time Interval Sensitivity
        /// </summary>
        public int PortamentoTimeIntervalSensitivity
        {
            get => _portamentoTimeIntervalSensitivity;
            set
            {
                if (value != _portamentoTimeIntervalSensitivity)
                {
                    _portamentoTimeIntervalSensitivity = value;
                    NotifyOfPropertyChange(nameof(PortamentoTimeIntervalSensitivity));
                }
            }
        }

        /// <summary>
        ///     Envelope Loop Mode
        /// </summary>
        public EnvelopeLoopMode EnvelopeLoopMode
        {
            get => _envelopeEnvelopeLoopMode;
            set
            {
                if (value != _envelopeEnvelopeLoopMode)
                {
                    _envelopeEnvelopeLoopMode = value;
                    NotifyOfPropertyChange(nameof(EnvelopeLoopMode));
                }
            }
        }

        /// <summary>
        ///     Envelope Loop Sync note
        /// </summary>
        public SyncNote EnvelopeLoopSyncNote
        {
            get => _envelopeLoopSyncNote;
            set
            {
                if (value != _envelopeLoopSyncNote)
                {
                    _envelopeLoopSyncNote = value;
                    NotifyOfPropertyChange(nameof(EnvelopeLoopSyncNote));
                }
            }
        }

        /// <summary>
        ///     Envelope Loop Sync Note
        /// </summary>
        public bool ChromaticPortamento
        {
            get => _chromaticPortamento;
            set
            {
                if (value != _chromaticPortamento)
                {
                    _chromaticPortamento = value;
                    NotifyOfPropertyChange(nameof(ChromaticPortamento));
                }
            }
        }

        #endregion
    }
}