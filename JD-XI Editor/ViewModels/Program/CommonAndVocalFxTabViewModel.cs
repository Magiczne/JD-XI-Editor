using System;
using Caliburn.Micro;
using JD_XI_Editor.Managers;
using JD_XI_Editor.Managers.Abstract;
using JD_XI_Editor.Models.Patches.Program;
using JD_XI_Editor.ViewModels.Abstract;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels.Program
{
    internal sealed class CommonAndVocalFxTabViewModel : PatchTabViewModel
    {
        /// <summary>
        ///     Common and vocal fx patch
        /// </summary>
        public CommonAndVocalEffectPatch Patch { get; }

        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of CommonAndVocalFxTabViewModel
        /// </summary>
        /// <param name="eventAggregator"></param>
        public CommonAndVocalFxTabViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator, new ProgramCommonAndVocalEffectsManager())
        {
            DisplayName = "Program Common & VocalFX";
            Patch = new CommonAndVocalEffectPatch();

            Patch.Common.PropertyChanged += (sender, args) =>
            {
                if (!(AutoSync && SelectedOutputDeviceId != -1)) return;

                var manager = (IProgramCommonAndVocalEffectsManager)PatchManager;

                if (args.PropertyName == nameof(Patch.Common.AutoNote))
                {
                    manager.SetAutoNote(Patch.Common.AutoNote, SelectedOutputDeviceId);
                }
                else
                {
                    manager.DumpCommon(Patch.Common, SelectedOutputDeviceId);
                }
            };

            Patch.VocalEffect.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager)PatchManager;
                    manager.DumpVocalEffects(Patch.VocalEffect, SelectedOutputDeviceId);
                }
            };
        }

        /// <inheritdoc />
        public override void Dump()
        {
            if (SelectedOutputDeviceId != -1)
            {
                PatchManager.Dump(Patch, SelectedOutputDeviceId);
            }
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            Patch.Reset();
        }
    }
}