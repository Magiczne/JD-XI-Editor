using System;
using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using JD_XI_Editor.Events;
using JD_XI_Editor.Logging;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Serializing;
using MahApps.Metro.Controls.Dialogs;

namespace JD_XI_Editor.ViewModels.Abstract
{
    internal abstract class PatchTabViewModel : Screen, IHandle<InputDeviceChangedEventArgs>, IHandle<OutputDeviceChangedEventArgs>
    {
        /// <summary>
        ///     Patch serializer
        /// </summary>
        protected readonly PatchSerializer Serializer;

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of TabViewModel
        /// </summary>
        protected PatchTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator, IPatchManager patchManager)
        {
            EventAggregator = eventAggregator;
            DialogCoordinator = dialogCoordinator;
            PatchManager = patchManager;
            Serializer = new PatchSerializer();

            EventAggregator.SubscribeOnPublishedThread(this);

            AutoSync = true;
        }

        /// <summary>
        ///     Load patch from file
        /// </summary>
        public abstract void LoadPatch();

        /// <summary>
        ///     Save patch to file
        /// </summary>
        public abstract void SavePatch();

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

        /// <summary>
        /// Init logger
        /// </summary>
        /// <param name="type"></param>
        public void InitLogger(Type type)
        {
            Logger = LoggerFactory.FullSet(type);
        }

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
        /// Event aggregator instance
        /// </summary>
        protected IEventAggregator EventAggregator;

        /// <summary>
        /// Dialog coordinator instance
        /// </summary>
        protected IDialogCoordinator DialogCoordinator;

        /// <summary>
        /// Patch manager
        /// </summary>
        protected IPatchManager PatchManager;

        /// <summary>
        /// Logger instance
        /// </summary>
        protected ILogger Logger;

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
        public Task HandleAsync(InputDeviceChangedEventArgs message, CancellationToken cancellationToken)
        {
            SelectedInputDeviceId = message.DeviceId;

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        /// <summary>
        ///     Handles the output device change
        /// </summary>
        public Task HandleAsync(OutputDeviceChangedEventArgs message, CancellationToken cancellationToken)
        {
            SelectedOutputDeviceId = message.DeviceId;

            return Task.CompletedTask;
        }

        #endregion
    }
}