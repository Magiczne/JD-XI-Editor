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
            Patch.PropertyChanged += (sender, args) =>
            {
                //TODO: Dump only some parts of the patch if changed
                if (AutoSync)
                    Dump();

                if (args.PropertyName == nameof(Patch.Modifiers))
                    NotifyOfPropertyChange(nameof(IsEnvelopeLoopSyncNoteEnabled));
            };
        }

        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

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