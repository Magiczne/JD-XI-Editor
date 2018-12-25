﻿using System;
using Caliburn.Micro;
using JD_XI_Editor.Utils;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Analog
{
    internal class Filter : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Filter
        /// </summary>
        public Filter()
        {
            Envelope = new Adsr(0, 0, 127, 0);
            Reset();

            Envelope.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Envelope));
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = true;
            Cutoff = 127;
            Resonance = 0;
            CutoffKeyfollow = 0;
            Envelope.Set(0, 0, 127, 0);
            EnvelopeDepth = 0;
            EnvelopeVelocitySensitivity = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Filter filter)
            {
                On = filter.On;
                Cutoff = filter.Cutoff;
                Resonance = filter.Resonance;
                CutoffKeyfollow = filter.CutoffKeyfollow;
                Envelope.CopyFrom(filter.Envelope);
                EnvelopeDepth = filter.EnvelopeDepth;
                EnvelopeVelocitySensitivity = filter.EnvelopeVelocitySensitivity;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) Cutoff,
                (byte) (CutoffKeyfollow / 10 + 64),
                (byte) Resonance,
                (byte) (EnvelopeVelocitySensitivity + 64),
                (byte) Envelope.Attack,
                (byte) Envelope.Decay,
                (byte) Envelope.Sustain,
                (byte) Envelope.Release,
                (byte) (EnvelopeDepth + 64)
            };
        }

        #region Properties

        /// <summary>
        ///     Is filter on
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Cutoff
        /// </summary>
        public int Cutoff { get; set; }

        /// <summary>
        ///     Resonance
        /// </summary>
        public int Resonance { get; set; }

        /// <summary>
        ///     Cutoff keyfollow
        /// </summary>
        public int CutoffKeyfollow { get; set; }

        /// <summary>
        ///     Envelope
        /// </summary>
        [DoNotNotify]
        public Adsr Envelope { get; }

        /// <summary>
        ///     Envelope depth
        /// </summary>
        public int EnvelopeDepth { get; set; }

        /// <summary>
        ///     Envelope velocity sensitivity
        /// </summary>
        public int EnvelopeVelocitySensitivity { get; set; }

        #endregion
    }
}