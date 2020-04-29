using System.Collections.Generic;
using System.Linq;
using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models;
using JD_XI_Editor.ViewModels.Digital;
using JD_XI_Editor.ViewModels.Drums;
using JD_XI_Editor.ViewModels.Effects;
using JD_XI_Editor.ViewModels.Program;
using MahApps.Metro.Controls.Dialogs;
using PropertyChanged;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class MainWindowViewModel
        : Conductor<Screen>.Collection.OneActive
    {
        public MainWindowViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
        {
            DisplayName = "JD-XI Editor";

            Items.AddRange(new List<Screen>
            {
                new HomeTabViewModel(),

                new DigitalSynthTabViewModel(eventAggregator, dialogCoordinator, DigitalSynth.First),
                new DigitalSynthTabViewModel(eventAggregator, dialogCoordinator, DigitalSynth.Second),
                new DrumKitTabViewModel(eventAggregator, dialogCoordinator),
                new AnalogSynthTabViewModel(eventAggregator, dialogCoordinator),

                new EffectsTabViewModel(eventAggregator, dialogCoordinator),

                new CommonAndVocalFxTabViewModel(eventAggregator, dialogCoordinator)
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
        ///     Selected input device ID
        /// </summary>
        private int _selectedInputDeviceId;

        /// <summary>
        ///     Selected output device ID
        /// </summary>
        private int _selectedOutputDeviceId;

        #endregion

        #region Properties

        /// <summary>
        ///     Input MIDI devices
        /// </summary>
        public BindableCollection<MidiInputDeviceInfo> InputDevices { get; set; }

        /// <summary>
        ///     Selected input device ID
        /// </summary>
        [DoNotNotify]
        public int SelectedInputDeviceId
        {
            get => _selectedInputDeviceId;
            set
            {
                if (value != _selectedInputDeviceId)
                {
                    _selectedInputDeviceId = value;
                    _eventAggregator.PublishOnUIThreadAsync(new InputDeviceChangedEventArgs(_selectedInputDeviceId));
                    NotifyOfPropertyChange(nameof(SelectedInputDeviceId));
                }
            }
        }

        /// <summary>
        ///     Output MIDI devices
        /// </summary>
        public BindableCollection<MidiOutputDeviceInfo> OutputDevices { get; set; }

        /// <summary>
        ///     Selected Output Device
        /// </summary>
        [DoNotNotify]
        public int SelectedOutputDeviceId
        {
            get => _selectedOutputDeviceId;
            set
            {
                if (value != _selectedOutputDeviceId)
                {
                    _selectedOutputDeviceId = value;
                    _eventAggregator.PublishOnUIThreadAsync(new OutputDeviceChangedEventArgs(_selectedOutputDeviceId));
                    NotifyOfPropertyChange(nameof(SelectedOutputDeviceId));
                }
            }
        }

        #endregion
    }
}