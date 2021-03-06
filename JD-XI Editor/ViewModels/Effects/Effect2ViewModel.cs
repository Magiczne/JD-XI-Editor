﻿using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Program.Effects;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;
using JD_XI_Editor.ViewModels.Effects.Assignable;

namespace JD_XI_Editor.ViewModels.Effects
{
    internal class Effect2ViewModel : Conductor<Screen>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of Effect 2 View Model
        /// </summary>
        public Effect2ViewModel(Patch patch)
        {
            Patch = patch;

            ThruViewModel = new ThruViewModel();
            FlangerViewModel = new FlangerViewModel(patch.FlangerParameters);
            PhaserViewModel = new PhaserViewModel(patch.PhaserParameters);
            RingModulationViewModel = new RingModulationViewModel(patch.RingModulationParameters);
            SlicerViewModel = new SlicerViewModel(patch.SlicerParameters);

            Patch.Basic.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(BasicData.Type))
                    switch (((BasicData) Patch.Basic).Type)
                    {
                        case Effect2Type.Thru:
                            ActivateItemAsync(ThruViewModel, default);
                            break;

                        case Effect2Type.Flanger:
                            ActivateItemAsync(FlangerViewModel, default);
                            break;

                        case Effect2Type.Phaser:
                            ActivateItemAsync(PhaserViewModel, default);
                            break;

                        case Effect2Type.RingMod:
                            ActivateItemAsync(RingModulationViewModel, default);
                            break;

                        case Effect2Type.Slicer:
                            ActivateItemAsync(SlicerViewModel, default);
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
        ///     Flanger View Model
        /// </summary>
        public FlangerViewModel FlangerViewModel { get; }

        /// <summary>
        ///     Phaser View Model
        /// </summary>
        public PhaserViewModel PhaserViewModel { get; }

        /// <summary>
        ///     Ring Modulation View Model
        /// </summary>
        public RingModulationViewModel RingModulationViewModel { get; }

        /// <summary>
        ///     Slicer View Model
        /// </summary>
        public SlicerViewModel SlicerViewModel { get; }

        #endregion
    }
}