using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Managers.Abstract;
using MahApps.Metro.Controls.Dialogs;

namespace JD_XI_Editor.ViewModels.Abstract
{
    internal abstract class PatchTabViewModel
        : Screen, IHandle<InputDeviceChangedEventArgs>, IHandle<OutputDeviceChangedEventArgs>
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of TabViewModel
        /// </summary>
        protected PatchTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator, IPatchManager patchManager)
        {
            EventAggregator = eventAggregator;
            EventAggregator.Subscribe(this);

            DialogCoordinator = dialogCoordinator;

            PatchManager = patchManager;

            AutoSync = true;
        }

        /// <summary>
        ///     Read data from device
        /// </summary>
        public abstract void Read();

        /// <summary>
        ///     Dump data to device
        /// </summary>
        public abstract void Dump();

        /// <summary>
        ///     Reset patch to initial state
        /// </summary>
        public abstract void InitPatch();

        #region Error handling

        /// <summary>
        ///     Show dialog with error message
        /// </summary>
        /// <param name="message">Message</param>
        protected void ShowErrorMessage(string message)
        {
            DialogCoordinator.ShowMessageAsync(this, "Error", message, MessageDialogStyle.Affirmative, new MetroDialogSettings
            {
                AnimateHide = false,
                AnimateShow = false
            });
        }

        #endregion

        #region Fields

        /// <summary>
        ///     Event aggregator instance
        /// </summary>
        protected IEventAggregator EventAggregator;

        /// <summary>
        ///     Dialog coordinator instance
        /// </summary>
        protected IDialogCoordinator DialogCoordinator;

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