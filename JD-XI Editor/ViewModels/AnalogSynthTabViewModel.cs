using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.Analog;
using JD_XI_Editor.Models.Patches.Analog;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;

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
            Patch = new Patch();
            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync)
                    Dump();

                if (args.PropertyName == nameof(Patch.Oscillator))
                    NotifyOfPropertyChange(nameof(IsPulseWidthEnabled));
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is AnalogPatchDumpReceivedEventArgs eventArgs)
                    Patch.CopyFrom(eventArgs.Patch);
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
            catch (TimeoutException)
            {
                ShowErrorMessage("Device is not responding, try again in a moment");
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