using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Sys;
using JD_XI_Editor.Utils;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Sys
{
    internal class Common : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public void Reset()
        {
            MasterTune = 0; //TODO: Figure out 440.0 Value
            MasterKeyShift = -24; //TODO: Figure out 
            MasterLevel = 50; //TODO: Figure out 

            ProgramControlChannel = ProgramControlChannel.Channel16;

            ReceiveProgramChange = true;
            ReceiveBankSelect = true;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(ByteUtils.NumberTo4Packets((int) (MasterTune * 5))); // TODO: Replace 5 with something
            bytes.Add((byte) (MasterKeyShift + 64));
            bytes.Add((byte) MasterLevel);

            bytes.AddRange(ByteUtils.RepeatReserve(11));

            bytes.Add((byte) ProgramControlChannel);

            bytes.AddRange(ByteUtils.RepeatReserve(23));

            bytes.Add(ByteUtils.BooleanToByte(ReceiveProgramChange));
            bytes.Add(ByteUtils.BooleanToByte(ReceiveBankSelect));

            return bytes.ToArray();
        }

        #region Fields

        /// <summary>
        ///     Master Tune
        /// </summary>
        private decimal _masterTune;

        /// <summary>
        ///     Master Key shift
        /// </summary>
        private int _masterKeyShift;

        /// <summary>
        ///     Master Level
        /// </summary>
        private int _masterLevel;

        /// <summary>
        ///     Program Control Channel
        /// </summary>
        private ProgramControlChannel _programControlChannel;

        /// <summary>
        ///     Receive Program Change
        /// </summary>
        private bool _receiveProgramchange;

        /// <summary>
        ///     Reveice Bank Select
        /// </summary>
        private bool _receiveBankSelect;

        #endregion

        #region Properties

        /// <summary>
        ///     Master Tune
        /// </summary>
        public decimal MasterTune
        {
            get => _masterTune;
            set
            {
                if (value != _masterTune)
                {
                    _masterTune = value;
                    NotifyOfPropertyChange(nameof(MasterTune));
                }
            }
        }

        /// <summary>
        ///     Master Key Shift
        /// </summary>
        public int MasterKeyShift
        {
            get => _masterKeyShift;
            set
            {
                if (value != _masterKeyShift)
                {
                    _masterKeyShift = value;
                    NotifyOfPropertyChange(nameof(MasterKeyShift));
                }
            }
        }

        /// <summary>
        ///     Master Level
        /// </summary>
        public int MasterLevel
        {
            get => _masterLevel;
            set
            {
                if (value != _masterLevel)
                {
                    _masterLevel = value;
                    NotifyOfPropertyChange(nameof(MasterLevel));
                }
            }
        }

        /// <summary>
        ///     Program Control Channel
        /// </summary>
        public ProgramControlChannel ProgramControlChannel
        {
            get => _programControlChannel;
            set
            {
                if (value != _programControlChannel)
                {
                    _programControlChannel = value;
                    NotifyOfPropertyChange(nameof(ProgramControlChannel));
                }
            }
        }

        /// <summary>
        ///     Receive Program Change
        /// </summary>
        public bool ReceiveProgramChange
        {
            get => _receiveProgramchange;
            set
            {
                if (value != _receiveProgramchange)
                {
                    _receiveProgramchange = value;
                    NotifyOfPropertyChange(nameof(ReceiveProgramChange));
                }
            }
        }

        /// <summary>
        ///     Reveice Bank Select
        /// </summary>
        public bool ReceiveBankSelect
        {
            get => _receiveBankSelect;
            set
            {
                if (value != _receiveBankSelect)
                {
                    _receiveBankSelect = value;
                    NotifyOfPropertyChange(nameof(ReceiveBankSelect));
                }
            }
        }

        #endregion
    }
}