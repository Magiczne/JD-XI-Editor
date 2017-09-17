using System.Collections;
using System.Collections.Generic;
using Caliburn.Micro;
using Sanford.Multimedia.Midi;
using JD_XI_Editor.Models;
// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    internal sealed class MainWindowViewModel : Conductor<TabViewModel>.Collection.OneActive
    {
        #region Fields

        /// <summary>
        /// Input MIDI devices
        /// </summary>
        private BindableCollection<MidiInputDeviceInfo> _inputDevices;

        /// <summary>
        /// Output MIDI devices
        /// </summary>
        private BindableCollection<MidiOutputDeviceInfo> _outputDevices;

        #endregion

        #region Properties

        /// <summary>
        /// Input MIDI devices
        /// </summary>
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

        /// <summary>
        /// Output MIDI devices
        /// </summary>
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

        public MainWindowViewModel(IEnumerable<TabViewModel> tabs)
        {
            Items.AddRange(tabs);

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
