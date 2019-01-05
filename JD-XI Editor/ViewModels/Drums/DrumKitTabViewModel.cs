using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal sealed class DrumKitTabViewModel : PatchTabViewModel
    {
        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

        /// <summary>
        ///     Partials editor view model
        /// </summary>
        public DrumKitPartialEditorViewModel Editor { get; }

        #endregion

        #region Methods

        public DrumKitTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
            : base(eventAggregator, dialogCoordinator, new DrumKitPatchManager())
        {
            DisplayName = "Drums";

            Patch = new Patch();
            Editor = new DrumKitPartialEditorViewModel(Patch);

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is DrumKitPatchDumpReceivedEventArgs eventArgs)
                    Patch.CopyFrom(eventArgs.Patch);
            };

            PatchManager.OperationTimedOut += (sender, args) =>
            {
                ShowErrorMessage("Device is not responding, try again in a moment");
            };
        }

        #endregion

        #region PatchTabViewModel

        /// <inheritdoc />
        public override void Read()
        {
            try
            {
                if (SelectedInputDeviceId != -1 && SelectedOutputDeviceId != -1)
                    PatchManager.Read(SelectedInputDeviceId, SelectedOutputDeviceId);
            }
            catch (InputDeviceException)
            {
                ShowErrorMessage("Device selected as input is used by another application");
            }
            catch (OutputDeviceException)
            {
                ShowErrorMessage("Device selected as output is used by another application");
            }
            catch (InvalidDumpSizeException)
            {
                ShowErrorMessage("Data received from device is invalid");
            }
        }

        /// <inheritdoc />
        public override void Dump()
        {
            try
            {
                if (SelectedOutputDeviceId != -1)
                    PatchManager.Dump(Patch, SelectedOutputDeviceId);
            }
            catch (OutputDeviceException)
            {
                ShowErrorMessage("Device selected as output is used by another application");
            }
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Patch.Reset();
        }

        #endregion
    }
}