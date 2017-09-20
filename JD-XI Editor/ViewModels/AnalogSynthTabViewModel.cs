using JD_XI_Editor.Managers;
using JD_XI_Editor.Models.Analog;
using JD_XI_Editor.Models.Enums;
using JD_XI_Editor.ViewModels.Abstract;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class AnalogSynthTabViewModel : TabViewModel
    {
        /// <summary>
        /// Patch manager
        /// </summary>
        private readonly AnalogPatchManager _manager;

        #region Properties

        /// <summary>
        /// Patch model
        /// </summary>
        public AnalogPatch Patch { get; }

        /// <summary>
        /// Pulse Width Enabled
        /// </summary>
        public bool IsPulseWidthEnabled => Patch.Oscillator.Shape == AnalogOscillatorShape.Square;

        #endregion

        #region Methods

        public void Dump()
        {
            var data = _manager.GetPatchMidiData(Patch);
            var msg = new SysExMessage(data);

            if (MainWindowViewModel.SelectedOutputDevice != -1)
            {
                using (var output = new OutputDevice(MainWindowViewModel.SelectedOutputDevice))
                {
                    output.Send(msg);
                }
            }
        }

        /// <summary>
        /// Reset patch to initial state
        /// </summary>
        public void InitPatch()
        {
            Patch.Reset();
        }

        #endregion

        /// <summary>
        /// Creates new instance of AnalogSynthTabViewModel
        /// </summary>
        public AnalogSynthTabViewModel(AnalogPatchManager manager)
        {
            _manager = manager;

            DisplayName = "Analog Synth";
            Patch = new AnalogPatch();
            Patch.PropertyChanged += (sender, args) =>
            {
                Dump();
                if (args.PropertyName == nameof(Patch.Oscillator))
                {
                    NotifyOfPropertyChange(nameof(IsPulseWidthEnabled));
                }
            };
        }
    }
}