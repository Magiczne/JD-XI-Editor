using System;
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
        /// <param name="eventAggregator"></param>
        /// <param name="dialogCoordinator"></param>
        public CommonAndVocalFxTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
            : base(eventAggregator, dialogCoordinator, new ProgramCommonAndVocalEffectsManager())
        {
            DisplayName = "Program Common & VocalFX";
            Patch = new CommonAndVocalEffectPatch();

            Patch.Common.PropertyChanged += (sender, args) =>
            {
                if (!(AutoSync && SelectedOutputDeviceId != -1)) return;

                var manager = (IProgramCommonAndVocalEffectsManager) PatchManager;

                if (args.PropertyName == nameof(Patch.Common.AutoNote))
                    manager.SetAutoNote(Patch.Common.AutoNote, SelectedOutputDeviceId);
                else
                    manager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
            };

            Patch.VocalEffect.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager) PatchManager;
                    manager.DumpVocalEffects(Patch.VocalEffect, SelectedOutputDeviceId);
                }
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is CommonAndVocalFxDumpReceivedEventArgs eventArgs)
                    Patch.CopyFrom(eventArgs.Patch);
            };
        }

        /// <summary>
        ///     Common and vocal fx patch
        /// </summary>
        public CommonAndVocalEffectPatch Patch { get; }

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
    }
}