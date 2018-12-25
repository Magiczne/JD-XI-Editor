using System;
using Caliburn.Micro;
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
        public byte[] GetBytes()
        {
            return new[]
            {
                ByteUtils.BooleanToByte(On),
                (byte) GroupType,

                (byte) ((GroupId >> 12) & 0xF),
                (byte) ((GroupId >> 8) & 0xF),
                (byte) ((GroupId >> 4) & 0xF),
                (byte) (GroupId & 0xF),

                (byte) (((int) LeftWave >> 12) & 0xF),
                (byte) (((int) LeftWave >> 8) & 0xF),
                (byte) (((int) LeftWave >> 4) & 0xF),
                (byte) ((int) LeftWave & 0xF),

                (byte) (((int) RightWave >> 12) & 0xF),
                (byte) (((int) RightWave >> 8) & 0xF),
                (byte) (((int) RightWave >> 4) & 0xF),
                (byte) ((int) RightWave & 0xF),

                (byte) WaveGain,
                ByteUtils.BooleanToByte(Fxm),
                (byte) FxmColor,
                (byte) FxmDepth,
                ByteUtils.BooleanToByte(TempoSync),
                (byte) (CoarseTune + 64),
                (byte) (FineTune + 64),
                (byte) (Panorama + 64),
                ByteUtils.BooleanToByte(RandomPanorama),
                (byte) AlternatePanorama,
                (byte) Level,
                (byte) VelocityRangeLower,
                (byte) VelocityRangeUpper,
                (byte) VelocityFadeWidthLower,
                (byte) VelocityFadeWidthUpper
            };
        }

        #region Properties

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