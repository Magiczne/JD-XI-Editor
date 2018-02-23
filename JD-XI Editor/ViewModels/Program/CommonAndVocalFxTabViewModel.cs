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
        private readonly CommonAndVocalEffectPatch _patch;

        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of CommonAndVocalFxTabViewModel
        /// </summary>
        /// <param name="eventAggregator"></param>
        public CommonAndVocalFxTabViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator, new ProgramCommonAndVocalEffectsManager())
        {
            DisplayName = "Program Common & VocalFX";
            _patch = new CommonAndVocalEffectPatch();

            _patch.Common.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager)PatchManager;
                    manager.DumpCommon(_patch.Common, SelectedOutputDeviceId);
                }
            };

            _patch.VocalEffect.PropertyChanged += (sender, args) =>
            {
                if (AutoSync && SelectedOutputDeviceId != -1)
                {
                    var manager = (IProgramCommonAndVocalEffectsManager)PatchManager;
                    manager.DumpVocalEffects(_patch.VocalEffect, SelectedOutputDeviceId);
                }
            };
        }

        /// <inheritdoc />
        public override void Dump()
        {
            throw new System.NotImplementedException();
        }

        /// <inheritdoc />
        public override void InitPatch()
        {
            _patch.Reset();
        }
    }
}