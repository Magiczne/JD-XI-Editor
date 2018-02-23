using Caliburn.Micro;
using JD_XI_Editor.Exceptions;

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class CommonAndVocalEffectPatch : PropertyChangedBase, IPatch
    {
        public CommonAndVocalEffectPatch()
        {
            Common = new Common();
            VocalEffect = new VocalEffect.VocalEffect();

            Common.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(Common));
            VocalEffect.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(VocalEffect));
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();
            VocalEffect.Reset();
        }

        /// <inheritdoc />
        public byte[] GetBytes()
        {
            throw new PatchNotConvertibleIntoBytes();
        }

        #region Properties

        /// <summary>
        ///     Program common
        /// </summary>
        public Common Common { get; }

        /// <summary>
        ///     Program Vocal Effect
        /// </summary>
        public VocalEffect.VocalEffect VocalEffect { get; }

        #endregion
    }
}