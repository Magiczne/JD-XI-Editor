using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.DrumKit;

namespace JD_XI_Editor.Models.Patches.DrumKit.Partial
{
    internal class Assign : PropertyChangedBase, IPatchPart
    {
        /// <inheritdoc />
        public Assign()
        {
            Reset();
        }

        /// <inheritdoc />
        public void Reset()
        {
            AssignType = AssignType.Multi;
            MuteGroup = MuteGroup.Off;
        }

        /// <inheritdoc />
        public void CopyFrom(IPatchPart part)
        {
            if (part is Assign assign)
            {
                AssignType = assign.AssignType;
                MuteGroup = assign.MuteGroup;
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

            AssignType = (AssignType) data[0];
            MuteGroup = (MuteGroup) data[1];
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) AssignType,
                (byte) MuteGroup
            };
        }

        #region Properties

        /// <inheritdoc />
        public int DumpLength { get; } = 2;

        /// <summary>
        ///     Assign type
        /// </summary>
        public AssignType AssignType { get; set; }

        /// <summary>
        ///     Mute group
        /// </summary>
        public MuteGroup MuteGroup { get; set; }

        #endregion
    }
}