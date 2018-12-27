using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;

namespace JD_XI_Editor.Models.Patches.Digital
{
    internal class Aftertouch : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Aftertouch
        /// </summary>
        public Aftertouch()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            CutoffAftertouchSensitivity = 9;
            LevelAftertouchSensitivity = 10;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Aftertouch aftertouch)
            {
                CutoffAftertouchSensitivity = aftertouch.CutoffAftertouchSensitivity;
                LevelAftertouchSensitivity = aftertouch.LevelAftertouchSensitivity;
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

            CutoffAftertouchSensitivity = data[0] - 64;
            LevelAftertouchSensitivity = data[1] - 64;
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new byte[]
            {
                (byte) (CutoffAftertouchSensitivity + 64),
                (byte) (LevelAftertouchSensitivity + 64),
                0x00,   //Reserve
                0x00    //Reserve
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 4;

        /// <summary>
        ///     Cutoff Aftertouch Sensitivity
        /// </summary>
        public int CutoffAftertouchSensitivity { get; set; }

        /// <summary>
        ///     Level Aftertouch Sensitivity
        /// </summary>
        public int LevelAftertouchSensitivity { get; set; }

        #endregion
    }
}