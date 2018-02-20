using Caliburn.Micro;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Patches.Program.Effects;
using JD_XI_Editor.ViewModels.Abstract;

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

            Patch = new Patch();
            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedInputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;

                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (args.PropertyName)
                    {
                        case nameof(Patch.Effect1):
                            effectsPatchManager.DumpEffect(Patch.Effect1, Effect.Effect1, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.Effect2):
                            effectsPatchManager.DumpEffect(Patch.Effect2, Effect.Effect2, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.Delay):
                            effectsPatchManager.DumpEffect(Patch.Delay, Effect.Delay, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.Reverb):
                            effectsPatchManager.DumpEffect(Patch.Reverb, Effect.Reverb, SelectedOutputDeviceId);
                            break;
                    }
                }
            };
        }

        #region Properties

        /// <summary>
        ///     Effects patch
        /// </summary>
        public Patch Patch { get; }

        #endregion

        /// <inheritdoc />
        public override void Dump()
        {
            if (SelectedOutputDeviceId != -1)
                PatchManager.Dump(Patch, SelectedOutputDeviceId);
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Patch.Reset();
        }
    }
}