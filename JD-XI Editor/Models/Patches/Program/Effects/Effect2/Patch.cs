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
            var thruEffectParameters = new ThruEffectParameters();
            FlangerParameters = new FlangerParameters();
            PhaserParameters = new PhaserParameters();
            RingModulationParameters = new RingModulationParameters();
            SlicerParameters = new SlicerParameters();

            Basic = new BasicData();
            Parameters = new ThruEffectParameters();

            Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                {
                    switch (((BasicData) Basic).Type)
                    {
                        case Effect2Type.Thru:
                            Parameters = thruEffectParameters;
                            break;
                        case Effect2Type.Flanger:
                            Parameters = FlangerParameters;
                            break;
                        case Effect2Type.Phaser:
                            Parameters = PhaserParameters;
                            break;
                        case Effect2Type.RingMod:
                            Parameters = RingModulationParameters;
                            break;
                        case Effect2Type.Slicer:
                            Parameters = SlicerParameters;
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

        #region Properties

        /// <summary>
        ///     Flanger parameters
        /// </summary>
        public FlangerParameters FlangerParameters { get; }

        /// <summary>
        ///     Phaser parameters
        /// </summary>
        public PhaserParameters PhaserParameters { get; }

        /// <summary>
        ///     Ring Modulation parameters
        /// </summary>
        public RingModulationParameters RingModulationParameters { get; }

        /// <summary>
        ///     Slicer paremeters
        /// </summary>
        public SlicerParameters SlicerParameters { get; }

        #endregion
    }
}