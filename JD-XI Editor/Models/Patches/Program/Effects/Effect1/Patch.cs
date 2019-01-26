using System.Collections.Generic;
using System.Linq;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Models.Enums.Program.Effects;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Utils;
using PropertyChanged;

// ReSharper disable SwitchStatementMissingSomeCases

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect1
{
    internal class Patch : EffectPatch
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of Effect 1 Patch
        /// </summary>
        public Patch()
        {
            ThruEffectParameters = new ThruEffectParameters();
            DistortionParameters = new DistortionParameters();
            FuzzParameters = new FuzzParameters();
            CompressorParameters = new CompressorParameters();
            BitCrusherParameters = new BitCrusherParameters();

            Basic = new BasicData();
            Parameters = ThruEffectParameters;

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (((BasicData) Basic).Type)
                    {
                        case Effect1Type.Thru:
                            Parameters = ThruEffectParameters;
                            break;
                        case Effect1Type.Distortion:
                            Parameters = DistortionParameters;
                            break;
                        case Effect1Type.Fuzz:
                            Parameters = FuzzParameters;
                            break;
                        case Effect1Type.Compressor:
                            Parameters = CompressorParameters;
                            break;
                        case Effect1Type.BitCrusher:
                            Parameters = BitCrusherParameters;
                            break;
                        default:
                            Parameters = ThruEffectParameters;
                            break;
                    }

                    Parameters.PropertyChanged +=
                        (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
                }

                NotifyOfPropertyChange(nameof(Basic));
            };
        }

        /// <inheritdoc />
        public override void CopyFrom(byte[] data)
        {
            if (data.Length != DumpLength)
            {
                throw new InvalidDumpSizeException(DumpLength, data.Length);
            }

            Basic.CopyFrom(data.Take(5).ToArray());
            
            // Basic.PropertyChanges takes care of switching between parameters, so we don't
            // need to do anything more than that and we're just passing data to the method
            // that copies data from sysex dump
            Parameters.CopyFrom(data.Skip(17).Take(128).ToArray());
        }

        /// <inheritdoc />
        public override byte[] GetBytes()
        {
            var bytes = new List<byte>();

            bytes.AddRange(Basic.GetBytes());
            bytes.AddRange(ByteUtils.RepeatReserve(12));
            bytes.AddRange(Parameters.GetBytes());

            return bytes.ToArray();
        }

        #region Properties

        /// <inheritdoc />
        public override int DumpLength { get; } = 145;

        /// <summary>
        ///     Thru effect parameters
        /// </summary>
        [DoNotNotify]
        public ThruEffectParameters ThruEffectParameters { get; }

        /// <summary>
        ///     Distortion parameters
        /// </summary>
        [DoNotNotify]
        public DistortionParameters DistortionParameters { get; }

        /// <summary>
        ///     Fuzz parameters
        /// </summary>
        [DoNotNotify]
        public FuzzParameters FuzzParameters { get; }

        /// <summary>
        ///     Compressor parameters
        /// </summary>
        [DoNotNotify]
        public CompressorParameters CompressorParameters { get; }

        /// <summary>
        ///     Bit crusher parameters
        /// </summary>
        [DoNotNotify]
        public BitCrusherParameters BitCrusherParameters { get; }

        #endregion
    }
}