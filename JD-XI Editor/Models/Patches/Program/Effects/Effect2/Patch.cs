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
                        case Effect2Type.Thru:
                            Parameters = new ThruEffectParameters();
                            break;
                        case Effect2Type.Flanger:
                            Parameters = new FlangerParameters();
                            break;
                        case Effect2Type.Phaser:
                            Parameters = new PhaserParameters();
                            break;
                        case Effect2Type.RingMod:
                            Parameters = new RingModulationParameters();
                            break;
                        case Effect2Type.Slicer:
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