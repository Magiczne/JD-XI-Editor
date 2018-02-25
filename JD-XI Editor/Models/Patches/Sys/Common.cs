using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Sys;
using JD_XI_Editor.Utils;

namespace JD_XI_Editor.Models.Patches.Sys
{
    internal class Common : PropertyChangedBase, IPatch
    {
        /// <inheritdoc />
        public Common()
        {
            Reset();
        }

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

        #region Properties

        /// <summary>
        ///     Master Tune
        /// </summary>
        public decimal MasterTune { get; set; }

        /// <summary>
        ///     Master Key Shift
        /// </summary>
        public int MasterKeyShift { get; set; }

        /// <summary>
        ///     Master Level
        /// </summary>
        public int MasterLevel { get; set; }

        /// <summary>
        ///     Program Control Channel
        /// </summary>
        public ProgramControlChannel ProgramControlChannel { get; set; }

        /// <summary>
        ///     Receive Program Change
        /// </summary>
        public bool ReceiveProgramChange { get; set; }

        /// <summary>
        ///     Reveice Bank Select
        /// </summary>
        public bool ReceiveBankSelect { get; set; }

        #endregion
    }
}