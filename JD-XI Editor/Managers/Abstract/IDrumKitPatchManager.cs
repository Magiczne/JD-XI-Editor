using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.Models.Patches.DrumKit.Partial;

namespace JD_XI_Editor.Managers.Abstract
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
        void DumpPartial(Partial partial, int deviceId);
    }
}