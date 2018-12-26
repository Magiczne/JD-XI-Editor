using System;
using System.Collections.Generic;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.VocalEffect;
using JD_XI_Editor.Utils;
using Type = JD_XI_Editor.Models.Enums.Program.VocalEffect.Type;

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
            Name = "Init Program";
            Level = 127;
            Tempo = 140;

            VocalEffectType = Type.Off;
            VocalEffectNumber = EffectNumber.VocoderEnsemble;
            VocalEffectPart = Part.DigitalSynth1;

            AutoNote = false;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Common c)
            {
                Name = c.Name;
                Level = c.Level;
                Tempo = c.Tempo;

                VocalEffectType = c.VocalEffectType;
                VocalEffectNumber = c.VocalEffectNumber;
                VocalEffectPart = c.VocalEffectPart;

                AutoNote = c.AutoNote;
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <inheritdoc />
        public void CopyFrom(byte[] data)
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
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(Tempo * 100, ByteUtils.Offset.None));
            bytes.Add(0x00); // Reserve

            if (VocalEffectType != Type.Off)
            {
                bytes.Add((byte) VocalEffectType);

                bytes.AddRange(ByteUtils.RepeatReserve(5));

                bytes.Add((byte) VocalEffectNumber);
                bytes.Add((byte) VocalEffectPart);
            }

            if (VocalEffectType == Type.Vocoder) bytes.Add(ByteUtils.BooleanToByte(AutoNote));

            return bytes.ToArray();
        }

        #region Properties

        /// TODO: Set
        /// <inheritdoc />
        public int DumpLength { get; }

        /// <summary>
        ///     Program Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Program Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Tempo
        /// </summary>
        public int Tempo { get; set; }

        /// <summary>
        ///     Vocal Effect Type
        /// </summary>
        public Type VocalEffectType { get; set; }

        /// <summary>
        ///     Vocal Effect Number
        /// </summary>
        public EffectNumber VocalEffectNumber { get; set; }

        /// <summary>
        ///     Vocal Effect Part
        /// </summary>
        public Part VocalEffectPart { get; set; }

        /// <summary>
        ///     Auto Note
        /// </summary>
        public bool AutoNote { get; set; }

        #endregion
    }
}