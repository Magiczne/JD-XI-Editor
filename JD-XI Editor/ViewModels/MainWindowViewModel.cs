using Caliburn.Micro;
using Sanford.Multimedia.Midi;
using JD_XI_Editor.Models;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class MainWindowViewModel : Screen
    {
        #region Fields

        private BindableCollection<MidiInputDeviceInfo> _inputDevices;

        private BindableCollection<MidiOutputDeviceInfo> _outputDevices;

        #endregion

        #region Properties

        public BindableCollection<MidiInputDeviceInfo> InputDevices
        {
            get => _inputDevices;
            set
            {
                if (value != _inputDevices)
                {
                    _inputDevices = value;
                    NotifyOfPropertyChange(nameof(InputDevices));
                }
            }
        }

        public BindableCollection<MidiOutputDeviceInfo> OutputDevices
        {
            get => _outputDevices;
            set
            {
                if (value != _outputDevices)
                {
                    _outputDevices = value;
                    NotifyOfPropertyChange(nameof(OutputDevices));
                }
            }
        }

        #endregion

        public MainWindowViewModel()
        {
            GetMidiDevices();
        }

        #region Methods

        private void GetMidiDevices()
        {
            var inputDevices = new BindableCollection<MidiInputDeviceInfo>();
            var outputDevices = new BindableCollection<MidiOutputDeviceInfo>();

            for (var i = 0; i < InputDevice.DeviceCount; i++)
            {
                inputDevices.Add(new MidiInputDeviceInfo(InputDevice.GetDeviceCapabilities(i)));
            }

            for (var i = 0; i < OutputDevice.DeviceCount; i++)
            {
                outputDevices.Add(new MidiOutputDeviceInfo(OutputDevice.GetDeviceCapabilities(i)));
            }

            InputDevices = inputDevices;
            OutputDevices = outputDevices;
        }

        #endregion
    }
}
