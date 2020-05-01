using JD_XI_Editor.Models.Patches.Analog;

namespace JD_XI_Editor.Managers.Events
{
    internal class AnalogPatchDumpReceivedEventArgs : PatchDumpReceivedEventArgs
    {
        public AnalogPatchDumpReceivedEventArgs(Patch patch)
        {
            Patch = patch;
        }

        /// <summary>
        ///     Patch object
        /// </summary>
        public Patch Patch { get; }
    }
}
