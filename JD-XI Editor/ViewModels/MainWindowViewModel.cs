using System.Collections.Generic;
using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models;
using JD_XI_Editor.ViewModels.Abstract;
using Sanford.Multimedia.Midi;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    internal sealed class MainWindowViewModel
        : Conductor<TabViewModel>.Collection.OneActive
    {
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            DisplayName = "JD-XI Editor";

            Items.AddRange(new List<TabViewModel>
            {
                new AnalogSynthTabViewModel(eventAggregator),
                new DigitalSynthTabViewModel(eventAggregator, DigitalSynth.First),
                new DigitalSynthTabViewModel(eventAggregator, DigitalSynth.Second)
            });
            _eventAggregator = eventAggregator;

            GetMidiDevices();
        }

        #region Methods

        /// <summary>
        ///     Get input and output MIDI devices
        /// </summary>
        private void GetMidiDevices()
        {
            var inputDevices = new BindableCollection<MidiInputDeviceInfo>();
            var outputDevices = new BindableCollection<MidiOutputDeviceInfo>();

            for (var i = 0; i < InputDevice.DeviceCount; i++)
                inputDevices.Add(new MidiInputDeviceInfo(InputDevice.GetDeviceCapabilities(i)));

            for (var i = 0; i < OutputDeviceBase.DeviceCount; i++)
                outputDevices.Add(new MidiOutputDeviceInfo(OutputDeviceBase.GetDeviceCapabilities(i)));

            InputDevices = inputDevices;
            OutputDevices = outputDevices;

            SelectedInputDeviceId = -1;
            SelectedOutputDeviceId = -1;
        }

        #endregion

        #region Fields

        /// <summary>
        ///     Event aggregator instance
        /// </summary>
        private readonly IEventAggregator _eventAggregator;

        /// <summary>
        ///     Input MIDI devices
        /// </summary>
        private BindableCollection<MidiInputDeviceInfo> _inputDevices;

        /// <summary>
        ///     Selected input device ID
        /// </summary>
        private int _selectedInputDeviceId;

        /// <summary>
        ///     Output MIDI devices
        /// </summary>
        private BindableCollection<MidiOutputDeviceInfo> _outputDevices;

        /// <summary>
        ///     Selected output device ID
        /// </summary>
        private int _selectedOutputDeviceId;

        #endregion

        #region Properties

        /// <summary>
        ///     Input MIDI devices
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
        ///     Selected input device ID
        /// </summary>
        public int SelectedInputDeviceId
        {
            get => _selectedInputDeviceId;
            set
            {
                if (value != _selectedInputDeviceId)
                {
                    _selectedInputDeviceId = value;
                    _eventAggregator.PublishOnUIThread(new InputDeviceChangedEventArgs(_selectedInputDeviceId));
                }
            }
        }

        /// <summary>
        ///     Output MIDI devices
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

        /// <summary>
        ///     Selected Output Device
        /// </summary>
        public int SelectedOutputDeviceId
        {
            get => _selectedOutputDeviceId;
            set
            {
                if (value != _selectedOutputDeviceId)
                {
                    _selectedOutputDeviceId = value;
                    _eventAggregator.PublishOnUIThread(new OutputDeviceChangedEventArgs(_selectedOutputDeviceId));
                }
            }
        }

        #endregion
    }
}