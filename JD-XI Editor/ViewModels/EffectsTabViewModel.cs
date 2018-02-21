using Caliburn.Micro;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Enums.Effects;
using JD_XI_Editor.ViewModels.Abstract;
using Effect1Patch = JD_XI_Editor.Models.Patches.Program.Effects.Effect1.Patch;
using Effect2Patch = JD_XI_Editor.Models.Patches.Program.Effects.Effect2.Patch;
using DelayPatch = JD_XI_Editor.Models.Patches.Program.Effects.Delay.Patch;
using ReverbPatch = JD_XI_Editor.Models.Patches.Program.Effects.Reverb.Patch;
using EffectPatch = JD_XI_Editor.Models.Patches.Program.Effects.Patch;

using Effect1BasicData = JD_XI_Editor.Models.Patches.Program.Effects.Effect1.BasicData;
using Effect2BasicData = JD_XI_Editor.Models.Patches.Program.Effects.Effect2.BasicData;
using DelayBasicData = JD_XI_Editor.Models.Patches.Program.Effects.Delay.BasicData;
using ReverbBasicData = JD_XI_Editor.Models.Patches.Program.Effects.Reverb.BasicData;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    /// <inheritdoc />
    /// <summary>
    ///     Creates new instance of AnalogSynthTabViewModel
    /// </summary>
    internal sealed class EffectsTabViewModel : PatchTabViewModel
    {
        public EffectsTabViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator, new EffectsPatchManager())
        {
            DisplayName = "Effects";

            Effect1 = new Effect1Patch();
            Effect2 = new Effect2Patch();
            Delay = new DelayPatch();
            Reverb = new ReverbPatch();

            Effect1.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Effect1Patch.Basic))
                {
                    NotifyOfPropertyChange(nameof(IsDistortionSelected));
                    NotifyOfPropertyChange(nameof(IsFuzzSelected));
                    NotifyOfPropertyChange(nameof(IsCompressorSelected));
                    NotifyOfPropertyChange(nameof(IsBitCrusherSelected));
                }

                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(Effect1, Effect.Effect1, SelectedOutputDeviceId);
                }
            };

            Effect2.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Effect2Patch.Basic))
                {
                    NotifyOfPropertyChange(nameof(IsFlangerSelected));
                    NotifyOfPropertyChange(nameof(IsPhaserSelected));
                    NotifyOfPropertyChange(nameof(IsRingModSelected));
                    NotifyOfPropertyChange(nameof(IsSlicerSelected));
                }

                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(Effect2, Effect.Effect2, SelectedOutputDeviceId);
                }
            };

            Delay.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(Delay, Effect.Delay, SelectedOutputDeviceId);
                }
            };

            Reverb.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(Reverb, Effect.Reverb, SelectedOutputDeviceId);
                }
            };
        }

        /// <inheritdoc />
        public override void Dump()
        {
            if (SelectedOutputDeviceId != -1)
            {
                var patch = new EffectPatch
                {
                    Effect1 = Effect1,
                    Effect2 = Effect2,
                    Delay = Delay,
                    Reverb = Reverb
                };

                PatchManager.Dump(patch, SelectedOutputDeviceId);
            }
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Effect1.Reset();
            Effect2.Reset();
            Delay.Reset();
            Reverb.Reset();
        }

        #region Properties

        /// <summary>
        ///     Effect 1
        /// </summary>
        public Effect1Patch Effect1 { get; }

        /// <summary>
        ///     Effect 2
        /// </summary>
        public Effect2Patch Effect2 { get; }

        /// <summary>
        ///     Delay
        /// </summary>
        public DelayPatch Delay { get; }

        /// <summary>
        ///     Reverb
        /// </summary>
        public ReverbPatch Reverb { get; }

        /// <summary>
        ///     Is distortion selected
        /// </summary>
        public bool IsDistortionSelected => ((Effect1BasicData) Effect1.Basic).Type == Effect1Type.Distortion;

        /// <summary>
        ///     Is fuzz selected
        /// </summary>
        public bool IsFuzzSelected => ((Effect1BasicData) Effect1.Basic).Type == Effect1Type.Fuzz;

        /// <summary>
        ///     Is compressor selected
        /// </summary>
        public bool IsCompressorSelected => ((Effect1BasicData) Effect1.Basic).Type == Effect1Type.Compressor;

        /// <summary>
        ///     Is bit crusher selected
        /// </summary>
        public bool IsBitCrusherSelected => ((Effect1BasicData) Effect1.Basic).Type == Effect1Type.BitCrusher;

        public bool IsFlangerSelected => ((Effect2BasicData) Effect2.Basic).Type == Effect2Type.Flanger;

        public bool IsPhaserSelected => ((Effect2BasicData)Effect2.Basic).Type == Effect2Type.Phaser;

        public bool IsRingModSelected => ((Effect2BasicData)Effect2.Basic).Type == Effect2Type.RingMod;

        public bool IsSlicerSelected => ((Effect2BasicData)Effect2.Basic).Type == Effect2Type.Slicer;

        #endregion
    }
}