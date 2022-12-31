using System;
using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects;
using PropertyChanged;

namespace JD_XI_Editor.Models.Patches.Program.Abstract
{
    internal abstract class EffectPatch<TBasicData, TParameters> 
        : PropertyChangedBase, IPatch 
        where TBasicData : IPatchPart
        where TParameters : EffectParameters
    {
        /// <inheritdoc />
        public void Reset()
        {
            Basic.Reset();
            Parameters.Reset();
        }

        /// <inheritdoc />
        public void CopyFrom(IPatch patch)
        {
            if (patch is EffectPatch<TBasicData, TParameters> ep)
            {
                Basic.CopyFrom(ep.Basic);
                Parameters.CopyFrom(ep.Parameters);
            }
            else
            {
                throw new NotSupportedException("Copying from that type is not supported");
            }
        }

        /// <summary>
        ///     Copy data from sysex dump
        /// </summary>
        public abstract void CopyFrom(byte[] data);

        /// <inheritdoc />
        public abstract byte[] GetBytes();

        #region Properties

        /// <summary>
        ///     Expected Dump Length
        /// </summary>
        public abstract int DumpLength { get; }

        /// <summary>
        ///     Basic Data
        /// </summary>
        [DoNotNotify]
        public TBasicData Basic { get; set; }

        /// <summary>
        ///     Delay parameters
        /// </summary>
        [DoNotNotify]
        public TParameters Parameters { get; set; }

        #endregion
    }
}