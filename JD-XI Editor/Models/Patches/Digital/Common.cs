using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Utils;

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
        public void CopyFrom(IPatchPart part)
        {
            if (part is Common common)
            {
                Name = common.Name;
                ToneLevel = common.ToneLevel;
                Portamento = common.Portamento;
                PortamentoTime = common.PortamentoTime;
                Mono = common.Mono;
                OctaveShift = common.OctaveShift;
                PitchBendRangeUp = common.PitchBendRangeUp;
                PitchBendRangeDown = common.PitchBendRangeDown;

                PartialOneSwitch = common.PartialOneSwitch;
                PartialTwoSwitch = common.PartialTwoSwitch;
                PartialThreeSwitch = common.PartialThreeSwitch;
                PartialOneSelect = common.PartialOneSelect;
                PartialTwoSelect = common.PartialTwoSelect;
                PartialThreeSelect = common.PartialThreeSelect;

                Ring = common.Ring;
                Unison = common.Unison;
                PortamentoMode = common.PortamentoMode;
                Legato = common.Legato;
                AnalogFeel = common.AnalogFeel;
                WaveShape = common.WaveShape;
                ToneCategory = common.ToneCategory;
                UnisonSize = common.UnisonSize;
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
             * 12   -> Patch name
             * 1    -> Tone level
             * 5    -> Reserve
             * 6    -> Portamento, Mono, OctaveShift, Pitch Bend
             * 1    -> Reserve
             * 6    -> Partial switches
             * 1    -> Ring
             * 14   -> Reserve
             * 1    -> Unison
             * 2    -> Reserve
             * 2    -> Portamento mode, Legato
             * 1    -> Reserve,
             * 3    -> AnalogFeel, WaveShape, Tone Category
             * 5    -> Reserve
             * 1    -> Unison Size
             * 3    -> Reserve
             */

            Name = Encoding.ASCII.GetString(data.Take(12).ToArray());
            ToneLevel = data[12];
            Portamento = ByteUtils.ByteToBoolean(data[18]);
            PortamentoTime = data[19];
            Mono = ByteUtils.ByteToBoolean(data[20]);
            OctaveShift = data[21] - 64;
            PitchBendRangeUp = data[22];
            PitchBendRangeDown = data[23];

            PartialOneSwitch = ByteUtils.ByteToBoolean(data[25]);
            PartialOneSelect = ByteUtils.ByteToBoolean(data[26]);
            PartialTwoSwitch = ByteUtils.ByteToBoolean(data[27]);
            PartialTwoSelect = ByteUtils.ByteToBoolean(data[28]);
            PartialThreeSwitch = ByteUtils.ByteToBoolean(data[29]);
            PartialThreeSelect = ByteUtils.ByteToBoolean(data[30]);

            Ring = ByteUtils.ByteToBoolean(data[31]);
            Unison = ByteUtils.ByteToBoolean(data[46]);

            PortamentoMode = (PortamentoMode)data[49];
            Legato = ByteUtils.ByteToBoolean(data[50]);

            AnalogFeel = data[52];
            WaveShape = data[53];
            ToneCategory = (Category)data[54];

            UnisonSize = (UnisonSize) data[60];
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

                ByteUtils.BooleanToByte(Ring)
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

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 64;

        /// <summary>
        ///     Patch name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Tone Level
        /// </summary>
        public int ToneLevel { get; set; }

        /// <summary>
        ///     Portamento
        /// </summary>
        public bool Portamento { get; set; }

        /// <summary>
        ///     Portamento time
        /// </summary>
        public int PortamentoTime { get; set; }

        /// <summary>
        ///     Mono
        /// </summary>
        public bool Mono { get; set; }

        /// <summary>
        ///     Octave shift
        /// </summary>
        public int OctaveShift { get; set; }

        /// <summary>
        ///     Pitch bend range up
        /// </summary>
        public int PitchBendRangeUp { get; set; }

        /// <summary>
        ///     Pitch bend range down
        /// </summary>
        public int PitchBendRangeDown { get; set; }

        /// <summary>
        ///     Partial 1 Switch
        /// </summary>
        public bool PartialOneSwitch { get; set; }

        /// <summary>
        ///     Partial 2 Switch
        /// </summary>
        public bool PartialTwoSwitch { get; set; }

        /// <summary>
        ///     Partial 3 Switch
        /// </summary>
        public bool PartialThreeSwitch { get; set; }

        /// <summary>
        ///     Partial 1 Select
        /// </summary>
        public bool PartialOneSelect { get; set; }

        /// <summary>
        ///     Partial 2 Select
        /// </summary>
        public bool PartialTwoSelect { get; set; }

        /// <summary>
        ///     Partial 3 Select
        /// </summary>
        public bool PartialThreeSelect { get; set; }

        /// <summary>
        ///     Ring
        /// </summary>
        public bool Ring { get; set; }

        /// <summary>
        ///     Unison
        /// </summary>
        public bool Unison { get; set; }

        /// <summary>
        ///     Portamento mode
        /// </summary>
        public PortamentoMode PortamentoMode { get; set; }

        /// <summary>
        ///     Legato
        /// </summary>
        public bool Legato { get; set; }

        /// <summary>
        ///     Analog feel
        /// </summary>
        public int AnalogFeel { get; set; }

        /// <summary>
        ///     Wave shape
        /// </summary>
        public int WaveShape { get; set; }

        /// <summary>
        ///     Tone category
        /// </summary>
        public Category ToneCategory { get; set; }

        /// <summary>
        ///     Unison size
        /// </summary>
        public UnisonSize UnisonSize { get; set; }

        #endregion
    }
}