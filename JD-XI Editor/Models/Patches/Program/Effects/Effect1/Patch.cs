using System.Collections.Generic;
using JD_XI_Editor.Models.Enums.Program.Effects;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Utils;

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
            var thruEffectParameters = new ThruEffectParameters();
            DistortionParameters = new DistortionParameters();
            FuzzParameters = new FuzzParameters();
            CompressorParameters = new CompressorParameters();
            BitCrusherParameters = new BitCrusherParameters();

            Basic = new BasicData();
            Parameters = thruEffectParameters;

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (((BasicData) Basic).Type)
                    {
                        case Effect1Type.Thru:
                            Parameters = thruEffectParameters;
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
                            Parameters = thruEffectParameters;
                            break;
                    }

                    Parameters.PropertyChanged +=
                        (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
                }

                NotifyOfPropertyChange(nameof(Basic));
            };
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

        /// <summary>
        ///     Distortion parameters
        /// </summary>
        public DistortionParameters DistortionParameters { get; }

        /// <summary>
        ///     Fuzz parameters
        /// </summary>
        public FuzzParameters FuzzParameters { get; }

        /// <summary>
        ///     Compressor parameters
        /// </summary>
        public CompressorParameters CompressorParameters { get; }

        /// <summary>
        ///     Bit crusher parameters
        /// </summary>
        public BitCrusherParameters BitCrusherParameters { get; }

        #endregion
    }
}