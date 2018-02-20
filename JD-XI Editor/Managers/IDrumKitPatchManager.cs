using JD_XI_Editor.Models.Patches.DrumKit;

namespace JD_XI_Editor.Managers
{
    internal interface IDrumKitPatchManager : IPatchManager
    {
        /// <summary>
        ///     Dump common sysex frame
        /// </summary>
        void DumpCommon(Common common, int deviceId);

        /// <summary>
        ///     Dump partial sysex frame
        /// </summary>
        void DumpPartial(Patch patch, string key, int deviceId);
    }
}