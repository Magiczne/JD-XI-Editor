using System.Threading;
using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.Effects;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;
using JD_XI_Editor.ViewModels.Effects.Assignable;

namespace JD_XI_Editor.ViewModels.Effects
{
    internal class Effect1ViewModel : Conductor<Screen>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of Effect 1 View Model
        /// </summary>
        public Effect1ViewModel(Patch patch)
        {
            Patch = patch;

            ThruViewModel = new ThruViewModel();
            DistortionViewModel = new DistortionViewModel(patch.DistortionParameters);
            FuzzViewModel = new FuzzViewModel(patch.FuzzParameters);
            CompressorViewModel = new CompressorViewModel(patch.CompressorParameters);
            BitCrusherViewModel = new BitCrusherViewModel(patch.BitCrusherParameters);

            Patch.Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                    switch (((BasicData) Patch.Basic).Type)
                    {
                        case Effect1Type.Thru:
                            ActivateItemAsync(ThruViewModel, default);
                            break;

                        case Effect1Type.Distortion:
                            ActivateItemAsync(DistortionViewModel, default);
                            break;

                        case Effect1Type.Fuzz:
                            ActivateItemAsync(FuzzViewModel, default);
                            break;

                        case Effect1Type.Compressor:
                            ActivateItemAsync(CompressorViewModel, default);
                            break;

                        case Effect1Type.BitCrusher:
                            ActivateItemAsync(BitCrusherViewModel, default);
                            break;

                        default:
                            ActivateItemAsync(ThruViewModel, default);
                            break;
                    }
            };
        }

        #region Properties

        /// <summary>
        ///     Effect 1 patch
        /// </summary>
        public Patch Patch { get; }

        /// <summary>
        ///     Thru View Model
        /// </summary>
        public ThruViewModel ThruViewModel { get; }

        /// <summary>
        ///     Distortion View Model
        /// </summary>
        public DistortionViewModel DistortionViewModel { get; }

        /// <summary>
        ///     Fuzz View Model
        /// </summary>
        public FuzzViewModel FuzzViewModel { get; }

        /// <summary>
        ///     Compressor View Model
        /// </summary>
        public CompressorViewModel CompressorViewModel { get; }

        /// <summary>
        ///     Bit Crusher View Model
        /// </summary>
        public BitCrusherViewModel BitCrusherViewModel { get; }

        #endregion
    }
}