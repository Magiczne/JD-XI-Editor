using Caliburn.Micro;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.ViewModels.Abstract;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class DigitalSynthTabViewModel : TabViewModel
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of DigitalSynthTabViewModel
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        public DigitalSynthTabViewModel(IEventAggregator eventAggregator, DigitalPatchManager manager)
            : base(eventAggregator, manager)
        {
            DisplayName = "Digital Synth 1";

            Patch = new Patch();
            Editor = new DigitalPartialsEditorViewModel(Patch);

            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var digitalPatchManager = (IDigitalPatchManager) PatchManager;

                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (args.PropertyName)
                    {
                        case nameof(Patch.Common):
                            digitalPatchManager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.Modifiers):
                            digitalPatchManager.DumpModifiers(Patch.Modifiers, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialOne):
                            digitalPatchManager.DumpPartial(Patch.PartialOne, 1, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialTwo):
                            digitalPatchManager.DumpPartial(Patch.PartialTwo, 2, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialThree):
                            digitalPatchManager.DumpPartial(Patch.PartialThree, 3, SelectedOutputDeviceId);
                            break;
                    }
                }
                    
                if (args.PropertyName == nameof(Patch.Modifiers))
                    NotifyOfPropertyChange(nameof(IsEnvelopeLoopSyncNoteEnabled));
            };
        }

        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

        public DigitalPartialsEditorViewModel Editor { get; }

        /// <summary>
        ///     Is envelope loop sync note combo box enabled
        /// </summary>
        public bool IsEnvelopeLoopSyncNoteEnabled => Patch.Modifiers.EnvelopeLoopMode == EnvelopeLoopMode.TempoSync;

        #endregion

        #region Methods

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

        #endregion
    }
}