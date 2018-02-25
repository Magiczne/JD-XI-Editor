using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.Effects;

// ReSharper disable InvertIf

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class BasicData : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of BasicData
        /// </summary>
        public BasicData()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            Type = Effect1Type.Thru;
            Level = 127;
            DelaySendLevel = 50;
            ReverbSendLevel = 50;
            OutputAssign = OutputAssign.Effect2;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) Type,
                (byte) Level,
                (byte) DelaySendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Properties

        /// <summary>
        ///     Effect Type
        /// </summary>
        public Effect1Type Type { get; set; }

        /// <summary>
        ///     Level
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        ///     Delay Send Level
        /// </summary>
        public int DelaySendLevel { get; set; }

        /// <summary>
        ///     Reverb Send Level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        /// <summary>
        ///     Output assign
        /// </summary>
        public OutputAssign OutputAssign { get; set; }

        #endregion
    }
}