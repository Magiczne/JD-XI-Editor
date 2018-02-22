using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Patches.Digital;

namespace JD_XI_Editor.Managers.Abstract
{
    internal interface IDigitalPatchManager : IPatchManager
    {
        /// <summary>
        ///     Dump common sysex frame
        /// </summary>
        void DumpCommon(Common common, int deviceId);

        /// <summary>
        ///     Dump partial
        /// </summary>
        void DumpPartial(Partial partial, DigitalPartial partialNumber, int deviceId);

        /// <summary>
        ///     Dump modifiers sysex frame
        /// </summary>
        void DumpModifiers(Modifiers modifiers, int deviceId);
    }
}