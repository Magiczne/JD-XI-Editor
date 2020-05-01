using System;
using Caliburn.Micro;
using JD_XI_Editor.Exceptions;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Managers.Events;
using JD_XI_Editor.ViewModels.Abstract;
using MahApps.Metro.Controls.Dialogs;
using Sanford.Multimedia.Midi;
using EffectPatch = JD_XI_Editor.Models.Patches.Program.Effects.Patch;


namespace JD_XI_Editor.ViewModels.Effects
{
    /// <inheritdoc />
    /// <summary>
    ///     Creates new instance of AnalogSynthTabViewModel
    /// </summary>
    internal sealed class EffectsTabViewModel : PatchTabViewModel
    {
        /// <summary>
        ///     Effect patch data
        /// </summary>
        private readonly EffectPatch _patch;

        public EffectsTabViewModel(IEventAggregator eventAggregator, IDialogCoordinator dialogCoordinator)
            : base(eventAggregator, dialogCoordinator, new EffectsPatchManager())
        {
            DisplayName = "Effects";
            InitLogger(typeof(EffectsTabViewModel));

            _patch = new EffectPatch();
            Effect1 = new Effect1ViewModel(_patch.Effect1);
            Effect2 = new Effect2ViewModel(_patch.Effect2);
            Delay = new DelayViewModel(_patch.Delay);
            Reverb = new ReverbViewModel(_patch.Reverb);

            _patch.Effect1.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(_patch.Effect1, Effect.Effect1, SelectedOutputDeviceId);

                    Logger.AutoSync($"Effect1.{args.PropertyName} changed");
                }
            };

            _patch.Effect2.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(_patch.Effect2, Effect.Effect2, SelectedOutputDeviceId);

                    Logger.AutoSync($"Effect2.{args.PropertyName} changed");
                }
            };

            _patch.Delay.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(_patch.Delay, Effect.Delay, SelectedOutputDeviceId);

                    Logger.AutoSync($"Delay.{args.PropertyName} changed");
                }
            };

            _patch.Reverb.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var effectsPatchManager = (IEffectsPatchManager) PatchManager;
                    effectsPatchManager.DumpEffect(_patch.Reverb, Effect.Reverb, SelectedOutputDeviceId);

                    Logger.AutoSync($"Reverb.{args.PropertyName} changed");
                }
            };

            PatchManager.DataDumpReceived += (sender, args) =>
            {
                if (args is EffectsPatchDumpReceivedEventArgs eventArgs)
                {
                    AutoSync = false;

                    _patch.CopyFrom(eventArgs.Patch);
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
        ///     Effect 1 View Model
        /// </summary>
        public Effect1ViewModel Effect1 { get; }

        /// <summary>
        ///     Effect 2 View Model
        /// </summary>
        public Effect2ViewModel Effect2 { get; }

        /// <summary>
        ///     Delay View Model
        /// </summary>
        public DelayViewModel Delay { get; }

        /// <summary>
        ///     Reverb View Model
        /// </summary>
        public ReverbViewModel Reverb { get; }

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
                    PatchManager.Dump(_patch, SelectedOutputDeviceId);
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
            _patch.Reset();
            Logger.Info("Loaded init patch");
        }
    }
}