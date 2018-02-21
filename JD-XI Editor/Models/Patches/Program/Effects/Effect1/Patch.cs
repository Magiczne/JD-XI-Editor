using JD_XI_Editor.Models.Enums.Effects;
using JD_XI_Editor.Models.Patches.Program.Abstract;

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
            Basic = new BasicData();
            Parameters = new ThruEffectParameters();

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (((BasicData) Basic).Type)
                    {
                        case Effect1Type.Thru:
                            Parameters = new ThruEffectParameters();
                            break;
                        case Effect1Type.Distortion:
                            Parameters = new DistortionParameters();
                            break;
                        case Effect1Type.Fuzz:
                            Parameters = new FuzzParameters();
                            break;
                        case Effect1Type.Compressor:
                            Parameters = new CompressorParameters();
                            break;
                        case Effect1Type.BitCrusher:
                            Parameters = new BitCrusherParameters();
                            break;
                        default:
                            Parameters = new ThruEffectParameters();
                            break;
                    }

                    Parameters.PropertyChanged +=
                        (paramSender, paramArgs) => NotifyOfPropertyChange(nameof(Parameters));
                }

                NotifyOfPropertyChange(nameof(Basic));
            };
        }
    }
}