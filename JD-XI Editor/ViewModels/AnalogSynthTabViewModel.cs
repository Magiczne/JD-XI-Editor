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
        public AnalogSynthTabViewModel(AnalogPatchManager manager, IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            _manager = manager;

            DisplayName = "Analog Synth";
            Patch = new Patch();
            Patch.PropertyChanged += (sender, args) =>
            {
                Dump();
                if (args.PropertyName == nameof(Patch.Oscillator))
                    NotifyOfPropertyChange(nameof(IsPulseWidthEnabled));
            };
        }

        #region Fields

        /// <summary>
        ///     Patch manager
        /// </summary>
        private readonly AnalogPatchManager _manager;

        #endregion

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
                _manager.Dump(Patch, SelectedOutputDeviceId);
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