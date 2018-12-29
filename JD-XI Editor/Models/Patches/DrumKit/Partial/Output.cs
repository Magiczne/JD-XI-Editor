using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Output : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Output()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            OutputLevel = 127;
            ChorusSendLevel = 0;
            ReverbSendLevel = 64;
            OutputAssign = OutputAssign.Reverb;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Output output)
            {
                OutputLevel = output.OutputLevel;
                ChorusSendLevel = output.ChorusSendLevel;
                ReverbSendLevel = output.ReverbSendLevel;
                OutputAssign = output.OutputAssign;
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

            OutputLevel = data[0];
            ChorusSendLevel = data[3];
            ReverbSendLevel = data[4];
            OutputAssign = (OutputAssign) data[5];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) OutputLevel,
                (byte) 0x00, //Reserve
                (byte) 0x00, //Reserve
                (byte) ChorusSendLevel,
                (byte) ReverbSendLevel,
                (byte) OutputAssign
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 6;

        /// <summary>
        ///     Output level
        /// </summary>
        public int OutputLevel { get; set; }

        /// <summary>
        ///     Chorus send level
        /// </summary>
        public int ChorusSendLevel { get; set; }

        /// <summary>
        ///     Reverb send level
        /// </summary>
        public int ReverbSendLevel { get; set; }

        /// <summary>
        ///     Output assign
        /// </summary>
        public OutputAssign OutputAssign { get; set; }

        #endregion
    }
}