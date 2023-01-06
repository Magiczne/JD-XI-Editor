using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.DrumKit;
using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.Serializing;
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
            InitLogger(typeof(DrumKitTabViewModel));

            Patch = new Patch();
            Editor = new DrumKitPartialEditorViewModel(Patch);

            // TODO: AutoSync dumping
            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var drumPatchManager = (IDrumKitPatchManager)PatchManager;

                    if (args.PropertyName == nameof(Patch.Common))
                    {
                        drumPatchManager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
                    }
                    else
                    {
                        var key = (DrumKey) Enum.Parse(typeof(DrumKey), args.PropertyName);
                        drumPatchManager.DumpPartial(Patch.Partials[key], SelectedOutputDeviceId);
                    }

                    Logger.AutoSync($"{args.PropertyName} changed");
                }
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is DrumKitPatchDumpReceivedEventArgs eventArgs)
                {
                    AutoSync = false;

                    Patch.CopyFrom(eventArgs.Patch);
                    Logger.DataDump("Received data dump");

                    AutoSync = true;
                }
            };

            PatchManager.OperationTimedOut += (sender, args) =>
            {
                Logger.Error("Device is not responding");
                ShowErrorMessage("Device is not responding, try again in a moment");
            };
        }

        #endregion

        #region PatchTabViewModel

        /// <inheritdoc />
        public override void LoadPatch()
        {
            var result = Serializer.Deserialize<Patch>();

            if (result.Status == DeserializationStatus.Success)
            {
                Patch.CopyFrom(result.Patch);
            }
            else if (result.Status == DeserializationStatus.InvalidFormat)
            {
                DialogCoordinator.ShowMessageAsync(this, "Error", "File was saved for another patch type or is corrupted", MessageDialogStyle.Affirmative, new MetroDialogSettings
                {
                    AnimateHide = false,
                    AnimateShow = false
                });
            }
        }

        /// <inheritdoc />
        public override void SavePatch()
        {
            Serializer.Serialize(Patch);
        }

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
                Logger.Error("Device selected as input is used by another application");
                ShowErrorMessage("Device selected as input is used by another application");
            }
            catch (OutputDeviceException)
            {
                Logger.Error("Device selected as output is used by another application");
                ShowErrorMessage("Device selected as output is used by another application");
            }
            catch (InvalidDumpSizeException)
            {
                Logger.Error("Data received from device is invalid");
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
                Logger.Error("Device selected as output is used by another application");
                ShowErrorMessage("Device selected as output is used by another application");
            }
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Patch.Reset();
            Logger.Info("Loaded init patch");
        }

        #endregion
    }
}