using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.VocalEffect.AutoPitch.Type;

namespace JD_XI_Editor.Models.Patches.Program.VocalEffect
{
    internal class AutoPitch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AutoPitch
        /// </summary>
        public AutoPitch()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = false;
            Type = Type.Soft;
            Scale = Scale.MajorMinor;
            Key = Key.C;
            Gender = 0;
            Octave = Octave.Zero;
            DryWetBalance = 100;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is AutoPitch ap)
            {
                On = ap.On;
                Type = ap.Type;
                Scale = ap.Scale;
                Key = ap.Key;
                Gender = ap.Gender;
                Octave = ap.Octave;
                DryWetBalance = ap.DryWetBalance;
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

            On = ByteUtils.ByteToBoolean(data[0]);
            Type = (Type) data[1];
            Scale = (Scale) data[2];
            Key = (Key) data[3];
            Note = (Note) data[4];
            Gender = data[5] - 10;
            Octave = (Octave) data[6];
            DryWetBalance = data[7];
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

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 8;

        /// <summary>
        ///     Auto Pitch Switch
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Auto Pitch Type
        /// </summary>
        public Type Type { get; set; }

        /// <summary>
        ///     Auto Pitch Scale
        /// </summary>
        public Scale Scale { get; set; }

        /// <summary>
        ///     Auto Pitch Key
        /// </summary>
        public Key Key { get; set; }

        /// <summary>
        ///     Auto Pitch Note
        /// </summary>
        public Note Note { get; set; }

        /// <summary>
        ///     Auto Pitch Gender
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        ///     Auto Pitch Octave
        /// </summary>
        public Octave Octave { get; set; }

        /// <summary>
        ///     Auto Pitch Balance
        /// </summary>
        public int DryWetBalance { get; set; }

        #endregion
    }
}