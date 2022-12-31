using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;

namespace JD_XI_Editor.ViewModels.Program
{
    internal sealed class CommonAndVocalFxTabViewModel : PatchTabViewModel
    {
        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of CommonAndVocalFxTabViewModel
        /// </summary>
        public CommonAndVocalFxTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
            : base(eventAggregator, dialogCoordinator, new ProgramCommonAndVocalEffectsManager())
        {
            DisplayName = "Program Common & VocalFX";
            InitLogger(typeof(CommonAndVocalFxTabViewModel));

            Patch = new CommonAndVocalEffectPatch();

            Patch.Common.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager) PatchManager;

                    if (args.PropertyName == nameof(Patch.Common.AutoNote))
                    {
                        manager.SetAutoNote(Patch.Common.AutoNote, SelectedOutputDeviceId);
                        Logger.AutoSync($"Common.{args.PropertyName} changed");
                    }
                    else
                    {
                        manager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
                        Logger.AutoSync($"Common.{args.PropertyName} changed - dumping common");
                    }
                }
            };

            Patch.VocalEffect.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager) PatchManager;
                    manager.DumpVocalEffects(Patch.VocalEffect, SelectedOutputDeviceId);

                    Logger.AutoSync($"VocalEffect.{args.PropertyName} changed");
                }
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is CommonAndVocalFxDumpReceivedEventArgs eventArgs)
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

        /// <summary>
        ///     Common and vocal fx patch
        /// </summary>
        public CommonAndVocalEffectPatch Patch { get; }

        /// <inheritdoc />
        public override void LoadPatch()
        {
            var result = Serializer.Deserialize<CommonAndVocalEffectPatch>();

            if (result.Success)
            {
                Patch.CopyFrom(result.Patch);
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
    }
}