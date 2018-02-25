using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers.Abstract;

namespace JD_XI_Editor.ViewModels.Abstract
{
    internal abstract class PatchTabViewModel
        : Screen, IHandle<InputDeviceChangedEventArgs>, IHandle<OutputDeviceChangedEventArgs>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of TabViewModel
        /// </summary>
        protected PatchTabViewModel(IEventAggregator eventAggregator, IPatchManager patchManager)
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

        #endregion

        #region Properties

        public bool AutoSync { get; set; }

        /// <summary>
        ///     Input device ID
        /// </summary>
        public int SelectedInputDeviceId { get; set; }

        /// <summary>
        ///     Selected output device ID
        /// </summary>
        public int SelectedOutputDeviceId { get; set; }

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