using System;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using PropertyChanged;
using Sanford.Multimedia.Midi;
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

                NotifyOfPropertyChange(nameof(Common));
            };
            VocalEffect.PropertyChanged += (sender, args) => NotifyOfPropertyChange(nameof(VocalEffect));
        }

        public CommonAndVocalEffectPatch(SysExMessage common, SysExMessage vfx) : this()
        {
            CopyFrom(common, vfx);
        }

        /// <inheritdoc />
        public void Reset()
        {
            Common.Reset();
            VocalEffect.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (patch is CommonAndVocalEffectPatch p)
            {
                Common.CopyFrom(p.Common);
                VocalEffect.CopyFrom(p.VocalEffect);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <summary>
        ///     Copy data from sysex dumps
        /// </summary>
        /// <param name="common">Common sysex message</param>
        /// <param name="vfx">VFX sysex message</param>
        public void CopyFrom(SysExMessage common, SysExMessage vfx)
        {
            // Skipping 12 bytes from front because it's header and address offset
            // Skipping 2 bytes from end because it's checksum and sysex footer

            var commonBytes = common.GetBytes().Skip(12).ToArray();
            var vfxBytes = vfx.GetBytes().Skip(12).ToArray();

            Common.CopyFrom(commonBytes.Take(commonBytes.Length - 2).ToArray());
            VocalEffect.CopyFrom(vfxBytes.Take(vfxBytes.Length - 2).ToArray());
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
        public Common Common { get; set; }

        /// <summary>
        ///     Program Vocal Effect
        /// </summary>
        [DoNotNotify]
        public VocalEffect.VocalEffect VocalEffect { get; set; }

        #endregion
    }
}