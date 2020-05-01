using JD_XI_Editor.Models.Patches.Digital;

namespace JD_XI_Editor.Managers.Events
{
    internal class DigitalPatchDumpReceivedEventArgs : PatchDumpReceivedEventArgs
    {
        public DigitalPatchDumpReceivedEventArgs(Patch patch)
        {
            Patch = patch;
        }

        /// <summary>
        ///     Patch object
        /// </summary>
        public Patch Patch { get; }
    }
}