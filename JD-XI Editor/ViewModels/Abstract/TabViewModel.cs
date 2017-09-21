using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers;
// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels.Abstract
{
    internal abstract class TabViewModel
        : Screen, IHandle<InputDeviceChangedEventArgs>, IHandle<OutputDeviceChangedEventArgs>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of TabViewModel
        /// </summary>
        protected TabViewModel(IEventAggregator eventAggregator, IPatchManager patchManager)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);

            PatchManager = patchManager;

            AutoSync = true;
        }

        /// <summary>
        ///     Dump data to device
        /// </summary>
        public abstract void Dump();

        /// <summary>
        ///     Reset patch to initial state
        /// </summary>
        public abstract void InitPatch();

        #region Fields

        /// <summary>
        ///     Event aggregator instance
        /// </summary>
        protected IEventAggregator EventAggregator;

        /// <summary>
        ///     Patch manager
        /// </summary>
        protected IPatchManager PatchManager;

        /// <summary>
        ///     Auto syncrhonization
        /// </summary>
        private bool _autoSync;

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

        public bool AutoSync
        {
            get => _autoSync;
            set
            {
                if (value != _autoSync)
                {
                    _autoSync = value;
                    NotifyOfPropertyChange(nameof(AutoSync));
                }
            }
        }

        /// <summary>
        ///     Input device ID
        /// </summary>
        public int SelectedInputDeviceId
        {
            get => _selectedInputDeviceId;
            set
            {
                if (value != _selectedInputDeviceId)
                {
                    _selectedInputDeviceId = value;
                    NotifyOfPropertyChange(nameof(SelectedInputDeviceId));
                    NotifyOfPropertyChange(nameof(CanRead));
                }
            }
        }

        /// <summary>
        ///     Selected output device ID
        /// </summary>
        public int SelectedOutputDeviceId
        {
            get => _selectedOutputDeviceId;
            set
            {
                if (value != _selectedOutputDeviceId)
                {
                    _selectedOutputDeviceId = value;
                    NotifyOfPropertyChange(nameof(SelectedOutputDeviceId));
                    NotifyOfPropertyChange(nameof(CanDump));
                }
            }
        }

        /// <summary>
        ///     Can dump to device
        /// </summary>
        public bool CanDump => SelectedOutputDeviceId != -1;

        /// <summary>
        ///     Can read from device
        /// </summary>
        public bool CanRead => SelectedInputDeviceId != -1;

        #endregion

        #region IHandle members

        /// <inheritdoc />
        /// <summary>
        ///     Handles the input device change
        /// </summary>
        /// <param name="eventArgs"></param>
        public void Handle(InputDeviceChangedEventArgs eventArgs)
        {
            SelectedInputDeviceId = eventArgs.DeviceId;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Handles the output device change
        /// </summary>
        /// <param name="eventArgs"></param>
        public void Handle(OutputDeviceChangedEventArgs eventArgs)
        {
            SelectedOutputDeviceId = eventArgs.DeviceId;
        }

        #endregion
    }
}