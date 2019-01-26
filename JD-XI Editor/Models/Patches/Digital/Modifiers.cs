using System;
using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Utils;

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
        public void CopyFrom(IPatchPart part)
        {
            if (part is Modifiers mods)
            {
                AttackTimeIntervalSensitivity = mods.AttackTimeIntervalSensitivity;
                ReleaseTimeIntervalSensitivity = mods.ReleaseTimeIntervalSensitivity;
                PortamentoTimeIntervalSensitivity = mods.PortamentoTimeIntervalSensitivity;
                EnvelopeLoopMode = mods.EnvelopeLoopMode;
                EnvelopeLoopSyncNote = mods.EnvelopeLoopSyncNote;
                ChromaticPortamento = mods.ChromaticPortamento;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            /**
             * 12   -> SysEx header & address offset
             * 1    -> Reserve
             * 3    -> TimeIntervalSensitivities
             * 2    -> Envelope Loop
             * 1    -> Chromatic Portamento
             */

            AttackTimeIntervalSensitivity = data[1];
            ReleaseTimeIntervalSensitivity = data[2];
            PortamentoTimeIntervalSensitivity = data[3];
            EnvelopeLoopMode = (EnvelopeLoopMode)data[4];
            EnvelopeLoopSyncNote = (SyncNote)data[5];
            ChromaticPortamento = ByteUtils.ByteToBoolean(data[6]);
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

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 37;

        /// <summary>
        ///     Attack Time Interval Sensitivity
        /// </summary>
        public int AttackTimeIntervalSensitivity { get; set; }

        /// <summary>
        ///     Release Time Interval Sens
        /// </summary>
        public int ReleaseTimeIntervalSensitivity { get; set; }

        /// <summary>
        ///     Portamento Time Interval Sensitivity
        /// </summary>
        public int PortamentoTimeIntervalSensitivity { get; set; }

        /// <summary>
        ///     Envelope Loop Mode
        /// </summary>
        public EnvelopeLoopMode EnvelopeLoopMode { get; set; }

        /// <summary>
        ///     Envelope Loop Sync note
        /// </summary>
        public SyncNote EnvelopeLoopSyncNote { get; set; }

        /// <summary>
        ///     Envelope Loop Sync Note
        /// </summary>
        public bool ChromaticPortamento { get; set; }

        #endregion
    }
}