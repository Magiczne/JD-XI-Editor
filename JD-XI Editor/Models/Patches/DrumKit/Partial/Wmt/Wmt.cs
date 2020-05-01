using System;
using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt
{
    internal class Wmt : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Wmt()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            On = false;
            GroupType = 0; //TODO: WHAT
            GroupId = 0; //TODO: WHAT
            LeftWave = Wave.Off;
            RightWave = Wave.Off;
            WaveGain = WaveGain.Zero;

            Fxm = false;
            FxmColor = FxmWaveColor.One;
            FxmDepth = 0;

            TempoSync = false; //TODO: WHAT
            CoarseTune = 0;
            FineTune = 0;

            Panorama = 0;
            RandomPanorama = true;
            AlternatePanorama = AlternatePan.On;

            Level = 127;
            VelocityRangeLower = 1;
            VelocityRangeUpper = 127;
            VelocityFadeWidthLower = 0;
            VelocityFadeWidthUpper = 0;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Wmt wmt)
            {
                On = wmt.On;
                GroupType = wmt.GroupType;
                GroupId = wmt.GroupId;
                LeftWave = wmt.LeftWave;
                RightWave = wmt.RightWave;
                WaveGain = wmt.WaveGain;

                Fxm = wmt.Fxm;
                FxmColor = wmt.FxmColor;
                FxmDepth = wmt.FxmDepth;

                TempoSync = wmt.TempoSync;
                CoarseTune = wmt.CoarseTune;
                FineTune = wmt.FineTune;

                Panorama = wmt.Panorama;
                RandomPanorama = wmt.RandomPanorama;
                AlternatePanorama = wmt.AlternatePanorama;

                Level = wmt.Level;
                VelocityRangeLower = wmt.VelocityRangeLower;
                VelocityRangeUpper = wmt.VelocityRangeUpper;
                VelocityFadeWidthLower = wmt.VelocityFadeWidthLower;
                VelocityFadeWidthUpper = wmt.VelocityFadeWidthUpper;
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

            GroupType = data[1];
            GroupId = ByteUtils.NumberFrom4MidiPackets(data.Skip(2).Take(4).ToArray(), ByteUtils.Offset.None);
            LeftWave = (Wave) ByteUtils.NumberFrom4MidiPackets(data.Skip(6).Take(4).ToArray(), ByteUtils.Offset.None);
            RightWave = (Wave) ByteUtils.NumberFrom4MidiPackets(data.Skip(10).Take(4).ToArray(), ByteUtils.Offset.None);

            WaveGain = (WaveGain) data[14];
            Fxm = ByteUtils.ByteToBoolean(data[15]);
            FxmColor = (FxmWaveColor) data[16];
            FxmDepth = data[17];
            TempoSync = ByteUtils.ByteToBoolean(data[18]);

            CoarseTune = data[19] - 64;
            FineTune = data[20] - 64;
            Panorama = data[21] - 64;
            RandomPanorama = ByteUtils.ByteToBoolean(data[22]);
            AlternatePanorama = (AlternatePan) data[23];

            Level = data[24];
            VelocityRangeLower = data[25];
            VelocityRangeUpper = data[26];
            VelocityFadeWidthLower = data[27];
            VelocityFadeWidthUpper = data[28];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>
            {
                ByteUtils.BooleanToByte(On),
                (byte) GroupType
            };

            bytes.AddRange(ByteUtils.NumberTo4MidiPackets(GroupId, ByteUtils.Offset.None));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((int) LeftWave, ByteUtils.Offset.None));
            bytes.AddRange(ByteUtils.NumberTo4MidiPackets((int) RightWave, ByteUtils.Offset.None));

            bytes.Add((byte) WaveGain);
            bytes.Add(ByteUtils.BooleanToByte(Fxm));
            bytes.Add((byte) FxmColor);
            bytes.Add((byte) FxmDepth);
            bytes.Add(ByteUtils.BooleanToByte(TempoSync));
            bytes.Add((byte) (CoarseTune + 64));
            bytes.Add((byte) (FineTune + 64));
            bytes.Add((byte) (Panorama + 64));
            bytes.Add(ByteUtils.BooleanToByte(RandomPanorama));
            bytes.Add((byte) AlternatePanorama);
            bytes.Add((byte) Level);
            bytes.Add((byte) VelocityRangeLower);
            bytes.Add((byte) VelocityRangeUpper);
            bytes.Add((byte) VelocityFadeWidthLower);
            bytes.Add((byte) VelocityFadeWidthUpper);

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 29;

        /// <summary>
        ///     Switch
        /// </summary>
        public bool On { get; set; }

        /// <summary>
        ///     Wave group type
        /// </summary>
        public int GroupType { get; set; }

        /// <summary>
        ///     Group ID
        /// </summary>
        public int GroupId { get; set; }

        /// <summary>
        ///     Left wave number (mono)
        /// </summary>
        public Wave LeftWave { get; set; }

        /// <summary>
        ///     Right wave number
        /// </summary>
        public Wave RightWave { get; set; }

        /// <summary>
        ///     Wave gain
        /// </summary>
        public WaveGain WaveGain { get; set; }

        /// <summary>
        ///     FXM switch
        /// </summary>
        public bool Fxm { get; set; }

        /// <summary>
        ///     FXM Color
        /// </summary>
        public FxmWaveColor FxmColor { get; set; }

        /// <summary>
        ///     FXM Depth
        /// </summary>
        public int FxmDepth { get; set; }

        /// <summary>
        ///     Tempo sync
        /// </summary>
        public bool TempoSync { get; set; }

        /// <summary>
        ///     Coarse tune
        /// </summary>
        public int CoarseTune { get; set; }

        /// <summary>
        ///     Fine tune
        /// </summary>
        public int FineTune { get; set; }

        /// <summary>
        ///     Panorama
        /// </summary>
        public int Panorama { get; set; }

        /// <summary>
        ///     Random panorama switch
        /// </summary>
        public bool RandomPanorama { get; set; }

        /// <summary>
        ///     Alternate panorama switch
        /// </summary>
        public AlternatePan AlternatePanorama { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Velocity range lower
        /// </summary>
        public int VelocityRangeLower { get; set; }

        /// <summary>
        ///     Velocity range upper
        /// </summary>
        public int VelocityRangeUpper { get; set; }

        /// <summary>
        ///     Velocity fade width lower
        /// </summary>
        public int VelocityFadeWidthLower { get; set; }

        /// <summary>
        ///     Velocity fade width upper
        /// </summary>
        public int VelocityFadeWidthUpper { get; set; }

        #endregion
    }
}