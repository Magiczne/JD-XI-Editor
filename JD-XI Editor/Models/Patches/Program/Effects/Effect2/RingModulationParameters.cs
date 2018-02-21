// ReSharper disable InvertIf

using System.Collections.Generic;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
{
    internal class RingModulationParameters : EffectParameters
    {
        /// <summary>
        ///     Creates new instance of Ring Modulation Parameters
        /// </summary>
        public RingModulationParameters()
        {
            Reset();
        }

        /// <inheritdoc />
        public sealed override void Reset()
        {
            Frequency = 60;
            Sensitivity = 80;
            DryWetBalance = 50;
            Level = 127;
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets(Frequency));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Sensitivity));
            bytes.AddRange(ByteUtils.NumberTo4Packets(DryWetBalance));
            bytes.AddRange(ByteUtils.NumberTo4Packets(Level));
            bytes.AddRange(ByteUtils.Repeat4PacketsReserve(28));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Frequency
        /// </summary>
        private int _frequency;

        /// <summary>
        ///     Sensitivity
        /// </summary>
        private int _sensitivity;

        /// <summary>
        ///     Dry/Wet balance
        /// </summary>
        private int _dryWetBalance;

        /// <summary>
        ///     Level
        /// </summary>
        private int _level;

        #endregion

        #region Properties

        /// <summary>
        ///     Frequency
        /// </summary>
        public int Frequency
        {
            get => _frequency;
            set
            {
                if (value != _frequency)
                {
                    _frequency = value;
                    NotifyOfPropertyChange(nameof(Frequency));
                }
            }
        }

        /// <summary>
        ///     Sensitivity
        /// </summary>
        public int Sensitivity
        {
            get => _sensitivity;
            set
            {
                if (value != _sensitivity)
                {
                    _sensitivity = value;
                    NotifyOfPropertyChange(nameof(Sensitivity));
                }
            }
        }

        /// <summary>
        ///     Dry/Wet Balance
        /// </summary>
        public int DryWetBalance
        {
            get => _dryWetBalance;
            set
            {
                if (value != _dryWetBalance)
                {
                    _dryWetBalance = value;
                    NotifyOfPropertyChange(nameof(DryWetBalance));
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

        #endregion
    }
}