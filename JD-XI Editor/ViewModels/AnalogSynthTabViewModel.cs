using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.Analog;
using JD_XI_Editor.Models.Patches.Analog;
using JD_XI_Editor.Serializing;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;
using System.Windows.Forms;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class AnalogSynthTabViewModel : PatchTabViewModel
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of AnalogSynthTabViewModel
        /// </summary>
        // ReSharper disable once SuggestBaseTypeForParameter
        public AnalogSynthTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
            : base(eventAggregator, dialogCoordinator, new AnalogPatchManager())
        {
            DisplayName = "Analog Synth";
            InitLogger(typeof(AnalogSynthTabViewModel));

            Patch = new Patch();

            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync)
                {
                    Dump();
                    Logger.AutoSync($"{args.PropertyName} changed");
                }
                    
                if (args.PropertyName == nameof(Patch.Oscillator))
                    NotifyOfPropertyChange(nameof(IsPulseWidthEnabled));
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is AnalogPatchDumpReceivedEventArgs eventArgs)
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

        #region Properties

        /// <summary>
        ///     Patch model
        /// </summary>
        public Patch Patch { get; }

        /// <summary>
        ///     Pulse Width Enabled
        /// </summary>
        public bool IsPulseWidthEnabled => Patch.Oscillator.Shape == OscillatorShape.Square;

        #endregion

        #region Methods

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