using JD_XI_Editor.Models.Patches;

namespace JD_XI_Editor.Managers.Abstract
{
    internal interface IProgramCommonAndVocalEffectsManager : IPatchManager
    {
        /// <summary>
        ///     Dump common program data to device
        /// </summary>
        void DumpCommon(IPatchPart common, int deviceId);

        /// <summary>
        ///     Dump vocal effects program data to device
        /// </summary>
        void DumpVocalEffects(IPatchPart vocalEffects, int deviceId);
    }
}