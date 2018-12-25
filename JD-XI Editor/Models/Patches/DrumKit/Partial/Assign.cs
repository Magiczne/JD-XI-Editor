using System;
using Caliburn.Micro;
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
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) AssignType,
                (byte) MuteGroup
            };
        }

        #region Properties

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