using Caliburn.Micro;
using JD_XI_Editor.Events;

namespace JD_XI_Editor.ViewModels.Abstract
{
    internal abstract class TabViewModel
        : Screen, IHandle<InputDeviceChangedEventArgs>, IHandle<OutputDeviceChangedEventArgs>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of TabViewModel
        /// </summary>
        /// <param name="eventAggregator"></param>
        protected TabViewModel(IEventAggregator eventAggregator)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);
        }

        #region Fields

        /// <summary>
        ///     Event aggregator instance
        /// </summary>
        protected IEventAggregator EventAggregator;

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
        ///     Input device ID
        /// </summary>
        public int SelectedInputDeviceId
        {
            get => _selectedInputDeviceId;
            private set
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
            private set
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