using Caliburn.Micro;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Models.Enums;
using JD_XI_Editor.Models.Patches.Analog;
using JD_XI_Editor.ViewModels.Abstract;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class AnalogSynthTabViewModel : TabViewModel
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AnalogSynthTabViewModel
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        public AnalogSynthTabViewModel(IEventAggregator eventAggregator, AnalogPatchManager patchManager)
            : base(eventAggregator, patchManager)
        {
            DisplayName = "Analog Synth";
            Patch = new Patch();
            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync)
                    Dump();

                if (args.PropertyName == nameof(Patch.Oscillator))
                    NotifyOfPropertyChange(nameof(IsPulseWidthEnabled));
            };
        }

        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

        /// <summary>
        ///     Pulse Width Enabled
        /// </summary>
        public bool IsPulseWidthEnabled => Patch.Oscillator.Shape == AnalogOscillatorShape.Square;

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