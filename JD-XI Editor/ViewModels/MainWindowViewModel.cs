using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models;
using JD_XI_Editor.ViewModels.Digital;
using JD_XI_Editor.ViewModels.Effects;
using JD_XI_Editor.ViewModels.Program;
using Sanford.Multimedia.Midi;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    internal sealed class MainWindowViewModel
        : Conductor<Screen>.Collection.OneActive
    {
        public MainWindowViewModel(IEventAggregator eventAggregator)
        {
            DisplayName = "JD-XI Editor";

            Items.AddRange(new List<Screen>
            {
                new HomeTabViewModel(),
                new DigitalSynthTabViewModel(eventAggregator, DigitalSynth.First),
                new DigitalSynthTabViewModel(eventAggregator, DigitalSynth.Second),
                // TODO: Drums
                new AnalogSynthTabViewModel(eventAggregator),

                new EffectsTabViewModel(eventAggregator),

                new CommonAndVocalFxTabViewModel(eventAggregator)
            });
            _eventAggregator = eventAggregator;

            GetMidiDevices();
        }

        #region Methods

        /// <summary>
        ///     Get input and output MIDI devices
        /// </summary>
        public void GetMidiDevices()
        {
            var inputDevices = new BindableCollection<MidiInputDeviceInfo>();
            var outputDevices = new BindableCollection<MidiOutputDeviceInfo>();

            for (var i = 0; i < InputDevice.DeviceCount; i++)
                inputDevices.Add(new MidiInputDeviceInfo(InputDevice.GetDeviceCapabilities(i)));

            for (var i = 0; i < OutputDeviceBase.DeviceCount; i++)
                outputDevices.Add(new MidiOutputDeviceInfo(OutputDeviceBase.GetDeviceCapabilities(i)));

            InputDevices = inputDevices;
            OutputDevices = outputDevices;

            var jdXiInput = InputDevices.FirstOrDefault(d => d.Name == "JD-Xi");
            var jdXiOutput = OutputDevices.FirstOrDefault(d => d.Name == "JD-Xi");

            SelectedInputDeviceId = jdXiInput == null ? -1 : InputDevices.IndexOf(jdXiInput);
            SelectedOutputDeviceId = jdXiOutput == null ? -1 : OutputDevices.IndexOf(jdXiOutput);
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
                    NotifyOfPropertyChange(nameof(SelectedInputDeviceId));
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
                    NotifyOfPropertyChange(nameof(SelectedOutputDeviceId));
                }
            }
        }

        #endregion
    }
}