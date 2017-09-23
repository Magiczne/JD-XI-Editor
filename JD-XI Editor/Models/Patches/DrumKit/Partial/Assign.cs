using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.DrumKit;

// ReSharper disable InvertIf

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
        public byte[] GetBytes()
        {
            return new[]
            {
                (byte) AssignType,
                (byte) MuteGroup
            };
        }

        #region Fields

        /// <summary>
        ///     Assign type
        /// </summary>
        private AssignType _assignType;

        /// <summary>
        ///     Mute group
        /// </summary>
        private MuteGroup _muteGroup;

        #endregion

        #region Properties

        /// <summary>
        ///     Assign type
        /// </summary>
        public AssignType AssignType
        {
            get => _assignType;
            set
            {
                if (value != _assignType)
                {
                    _assignType = value;
                    NotifyOfPropertyChange(nameof(AssignType));
                }
            }
        }

        /// <summary>
        ///     Mute group
        /// </summary>
        public MuteGroup MuteGroup
        {
            get => _muteGroup;
            set
            {
                if (value != _muteGroup)
                {
                    _muteGroup = value;
                    NotifyOfPropertyChange(nameof(MuteGroup));
                }
            }
        }

        #endregion
    }
}