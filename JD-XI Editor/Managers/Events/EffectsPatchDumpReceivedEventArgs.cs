using JD_XI_Editor.Models.Patches.Program.Effects;

namespace JD_XI_Editor.Managers.Events
{
    internal class EffectsPatchDumpReceivedEventArgs : PatchDumpReceivedEventArgs
    {
        public EffectsPatchDumpReceivedEventArgs(Patch patch)
        {
            Patch = patch;
        }

        /// <summary>
        ///     Patch object
        /// </summary>
        public Patch Patch { get; }
    }
}