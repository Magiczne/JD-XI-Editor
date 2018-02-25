using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;
using Type = JD_XI_Editor.Models.Enums.Program.VocalEffect.Type;

namespace JD_XI_Editor.Models.Patches.Program
{
    internal class CommonAndVocalEffectPatch : PropertyChangedBase, IPatch
    {
        public CommonAndVocalEffectPatch()
        {
            Common = new Common();
            VocalEffect = new VocalEffect.VocalEffect();

            Common.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Common.VocalEffectType))
                {
                    switch (Common.VocalEffectType)
                    {
                        case Type.Off:
                            VocalEffect.AutoPitch.On = false;
                            VocalEffect.Vocoder.On = false;
                            break;

                        case Type.Vocoder:
                            VocalEffect.AutoPitch.On = false;
                            VocalEffect.Vocoder.On = true;
                            break;

                        case Type.AutoPitch:
                            VocalEffect.AutoPitch.On = true;
                            VocalEffect.Vocoder.On = false;
                            break;

                        default:
                            VocalEffect.AutoPitch.On = false;
                            VocalEffect.Vocoder.On = false;
                            break;
                    }
                }

                NotifyOfPropertyChange(nameof(Common));
            };
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
        [DoNotNotify]
        public Common Common { get; }

        /// <summary>
        ///     Program Vocal Effect
        /// </summary>
        [DoNotNotify]
        public VocalEffect.VocalEffect VocalEffect { get; }

        #endregion
    }
}