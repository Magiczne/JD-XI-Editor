using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Common;
using JD_XI_Editor.Models.Enums.Effects.Compressor;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class CompressorParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of Compressor parameters
        /// </summary>
        public CompressorParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Threshold = 40;
            Ratio = Ratio.FourToOne;
            Attack = Attack.ZeroPoint5;
            Release = Release.ZeroPoint05;
            Level = 50;
            Sidechain = false;
            SidechainSync = false;
            SidechainLevel = 0;
            SidechainNote = NotePitch.C2;
            SidechainTime = 60;
            SidechainRelease = 0;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Threshold));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Ratio));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Attack));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) Release));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Sidechain));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainLevel));
            bytes.AddRange(ByteUtils.NumberTo4Packets((byte) SidechainNote));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainTime));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainRelease));
            bytes.AddRange(ByteUtils.NumberTo4Packets(SidechainSync));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(21));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Threshold
        /// </summary>
        private int _threshold;

        /// <summary>
        ///     Ratio
        /// </summary>
        private Ratio _ratio;

        /// <summary>
        ///     Attack
        /// </summary>
        private Attack _attack;

        /// <summary>
        ///     Release
        /// </summary>
        private Release _release;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        /// <summary>
        ///     Sidechain
        /// </summary>
        private bool _sidechain;

        /// <summary>
        ///     Sidechan synchronization
        /// </summary>
        private bool _sidechainSync;
        
        /// <summary>
        ///     Sidechain level
        /// </summary>
        private int _sidechainLevel;

        /// <summary>
        ///     Sidechain note
        /// </summary>
        private NotePitch _sidechainNote;
        
        /// <summary>
        ///     Sidechain time
        /// </summary>
        private int _sidechainTime;

        /// <summary>
        ///     Sidechain release
        /// </summary>
        private int _sidechainRelease;

        #endregion

        #region Properties

        /// <summary>
        ///     Threshold
        /// </summary>
        public int Threshold
        {
            get => _threshold;
            set
            {
                if (value != _threshold)
                {
                    _threshold = value;
                    NotifyOfPropertyChange(nameof(Threshold));
                }
            }
        }

        /// <summary>
        ///     Ratio
        /// </summary>
        public Ratio Ratio
        {
            get => _ratio;
            set
            {
                if (value != _ratio)
                {
                    _ratio = value;
                    NotifyOfPropertyChange(nameof(Ratio));
                }
            }
        }

        /// <summary>
        ///     Attack
        /// </summary>
        public Attack Attack
        {
            get => _attack;
            set
            {
                if (value != _attack)
                {
                    _attack = value;
                    NotifyOfPropertyChange(nameof(Attack));
                }
            }
        }

        /// <summary>
        ///     Release
        /// </summary>
        public Release Release
        {
            get => _release;
            set
            {
                if (value != _release)
                {
                    _release = value;
                    NotifyOfPropertyChange(nameof(Release));
                }
            }
        }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level
        {
            get => _level;
            set
            {
                if (value != _level)
                {
                    _level = value;
                    NotifyOfPropertyChange(nameof(Level));
                }
            }
        }

        /// <summary>
        ///     Sidechain
        /// </summary>
        public bool Sidechain
        {
            get => _sidechain;
            set
            {
                if (value != _sidechain)
                {
                    _sidechain = value;
                    NotifyOfPropertyChange(nameof(Sidechain));
                }
            }
        }

        /// <summary>
        ///     Sidechain synchronization
        /// </summary>
        public bool SidechainSync
        {
            get => _sidechainSync;
            set
            {
                if (value != _sidechainSync)
                {
                    _sidechainSync = value;
                    NotifyOfPropertyChange(nameof(SidechainSync));
                }
            }
        }

        /// <summary>
        ///     Sidechain level
        /// </summary>
        public int SidechainLevel
        {
            get => _sidechainLevel;
            set
            {
                if (value != _sidechainLevel)
                {
                    _sidechainLevel = value;
                    NotifyOfPropertyChange(nameof(SidechainLevel));
                }
            }
        }

        /// <summary>
        ///     Sidechain note
        /// </summary>
        public NotePitch SidechainNote
        {
            get => _sidechainNote;
            set
            {
                if (value != _sidechainNote)
                {
                    _sidechainNote = value;
                    NotifyOfPropertyChange(nameof(SidechainNote));
                }
            }
        }

        /// <summary>
        ///     Sidechain Time
        /// </summary>
        public int SidechainTime
        {
            get => _sidechainTime;
            set
            {
                if (value != _sidechainTime)
                {
                    _sidechainTime = value;
                    NotifyOfPropertyChange(nameof(SidechainTime));
                }
            }
        }

        /// <summary>
        ///     Sidechain Release
        /// </summary>
        public int SidechainRelease
        {
            get => _sidechainRelease;
            set
            {
                if (value != _sidechainRelease)
                {
                    _sidechainRelease = value;
                    NotifyOfPropertyChange(nameof(SidechainRelease));
                }
            }
        }
        #endregion
    }
}