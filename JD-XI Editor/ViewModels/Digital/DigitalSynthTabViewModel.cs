﻿using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Enums.Digital;
using JD_XI_Editor.Models.Patches.Digital;
using JD_XI_Editor.Serializing;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.ViewModels.Digital
{
    internal sealed class DigitalSynthTabViewModel : PatchTabViewModel
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of DigitalSynthTabViewModel
        /// </summary>
        public DigitalSynthTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator, DigitalSynth synth)
            : base(eventAggregator, dialogCoordinator, new DigitalPatchManager(synth))
        {
            //TODO: Take use of enum description
            DisplayName = synth == DigitalSynth.First ? "Digital Synth 1" : "Digital Synth 2";
            InitLogger(typeof(DigitalSynthTabViewModel));

            Patch = new Patch();
            Editor = new DigitalPartialsEditorViewModel(Patch);

            Patch.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var digitalPatchManager = (IDigitalPatchManager) PatchManager;

                    switch (args.PropertyName)
                    {
                        case nameof(Patch.Common):
                            digitalPatchManager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.Modifiers):
                            digitalPatchManager.DumpModifiers(Patch.Modifiers, SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialOne):
                            digitalPatchManager.DumpPartial(Patch.PartialOne, DigitalPartial.First,
                                SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialTwo):
                            digitalPatchManager.DumpPartial(Patch.PartialTwo, DigitalPartial.Second,
                                SelectedOutputDeviceId);
                            break;

                        case nameof(Patch.PartialThree):
                            digitalPatchManager.DumpPartial(Patch.PartialThree, DigitalPartial.Third,
                                SelectedOutputDeviceId);
                            break;
                    }

                    Logger.AutoSync($"{args.PropertyName} changed");
                }

                if (args.PropertyName == nameof(Modifiers))
                    NotifyOfPropertyChange(nameof(IsEnvelopeLoopSyncNoteEnabled));
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is DigitalPatchDumpReceivedEventArgs eventArgs)
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

        public DigitalPartialsEditorViewModel Editor { get; }

        /// <summary>
        ///     Is envelope loop sync note combo box enabled
        /// </summary>
        public bool IsEnvelopeLoopSyncNoteEnabled => Patch.Modifiers.EnvelopeLoopMode == EnvelopeLoopMode.TempoSync;

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