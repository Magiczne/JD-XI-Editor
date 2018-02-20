using JD_XI_Editor.Models.Enums.Effects;
using JD_XI_Editor.Models.Patches.Program.Abstract;

// ReSharper disable SwitchStatementMissingSomeCases

namespace JD_XI_Editor.Models.Patches.Program.Effects.Effect2
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
                        case EffectType.Thru:
                            Parameters = new ThruEffectParameters();
                            break;
                        case EffectType.Flanger:
                            Parameters = new FlangerParameters();
                            break;
                        case EffectType.Phaser:
                            Parameters = new PhaserParameters();
                            break;
                        case EffectType.RingMod:
                            Parameters = new RingModulationParameters();
                            break;
                        case EffectType.Slicer:
                            Parameters = new SlicerParameters();
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