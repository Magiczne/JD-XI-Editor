using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Managers
{
    internal interface IPatchManager
    {
        /// <summary>
        ///     Dump data to device
        /// </summary>
        /// <param name="patch">Patch model</param>
        /// <param name="deviceId">Output device id</param>
        void Dump(IPatch patch, int deviceId);
    }
}