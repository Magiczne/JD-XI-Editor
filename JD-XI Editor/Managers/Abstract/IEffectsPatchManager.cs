﻿using JD_XI_Editor.Managers.Enums;
using JD_XI_Editor.Models.Patches;
using JD_XI_Editor.Models.Patches.Program.Abstract;
using JD_XI_Editor.Models.Patches.Program.Effects;

namespace JD_XI_Editor.Managers.Abstract
{
    internal interface IEffectsPatchManager : IPatchManager
    {
        /// <summary>
        ///     Dump data to device
        /// </summary>
        /// <param name="patch">Effect model</param>
        /// <param name="effect">Effect type</param>
        /// <param name="deviceId">Output device id</param>
        void DumpEffect<TBasicData, TParameters>(EffectPatch<TBasicData, TParameters> patch, Effect effect, int deviceId) 
            where TBasicData : IPatchPart
            where TParameters : EffectParameters;
    }
}