using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Managers
{
    internal interface IDigitalPatchManager : IPatchManager
    {
        /// <summary>
        ///     Dump common sysex frame
        /// </summary>
        void DumpCommon(IPatch patch, int deviceId);

        /// <summary>
        ///     Dump partial 1 sysex frame
        /// </summary>
        void DumpPartialOne(IPatch patch, int deviceId);

        /// <summary>
        ///     Dump partial 2 sysex frame
        /// </summary>
        void DumpPartialTwo(IPatch patch, int deviceId);

        /// <summary>
        ///     Dump partial 3 sysex frame
        /// </summary>
        void DumpPartialThree(IPatch patch, int deviceId);

        /// <summary>
        ///     Dump modifiers sysex frame
        /// </summary>
        void DumpModifiers(IPatch patch, int deviceId);
    }
}