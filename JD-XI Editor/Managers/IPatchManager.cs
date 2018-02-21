using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Managers
{
    internal interface IPatchManager
    {
        /// <summary>
        ///     Dump data to device
        /// </summary>
        void Dump(IPatch patch, int deviceId);
    }
}