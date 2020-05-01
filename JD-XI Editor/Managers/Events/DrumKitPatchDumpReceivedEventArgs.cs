using JD_XI_Editor.Models.Patches.DrumKit;

namespace JD_XI_Editor.Managers.Events
{
    internal class DrumKitPatchDumpReceivedEventArgs : PatchDumpReceivedEventArgs
    {
        public DrumKitPatchDumpReceivedEventArgs(Patch patch)
        {
            Patch = patch;
        }

        /// <summary>
        ///     Patch object
        /// </summary>
        public Patch Patch { get; }
    }
}