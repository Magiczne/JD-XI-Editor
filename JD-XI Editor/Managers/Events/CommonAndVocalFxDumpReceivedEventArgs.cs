using JD_XI_Editor.Models.Patches.Program;

namespace JD_XI_Editor.Managers.Events
{
    internal class CommonAndVocalFxDumpReceivedEventArgs : PatchDumpReceivedEventArgs
    {
        public CommonAndVocalFxDumpReceivedEventArgs(CommonAndVocalEffectPatch patch)
        {
            Patch = patch;
        }

        /// <summary>
        ///     Patch object
        /// </summary>
        public CommonAndVocalEffectPatch Patch { get; }
    }
}