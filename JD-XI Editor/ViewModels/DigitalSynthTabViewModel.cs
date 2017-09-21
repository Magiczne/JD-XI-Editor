using Caliburn.Micro;
using JD_XI_Editor.Managers;
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
                if (AutoSync)
                    Dump();
            };
        }

        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

        #endregion

        #region Methods

        /// <inheritdoc />
        public override void Dump()
        {
            if (SelectedOutputDeviceId != -1)
            {
                PatchManager.Dump(Patch, SelectedOutputDeviceId);
            }
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Patch.Reset();
        }

        #endregion
    }
}