using System.Collections.Generic;
using System.ComponentModel;

namespace JD_XI_Editor.Models.Patches
{
    internal interface IPatchPart : INotifyPropertyChanged
    {
        /// <summary>
        ///     Expected Dump Length
        /// </summary>
        int DumpLength { get; }

        /// <summary>
        ///     Reset data to initial path
        /// </summary>
        void Reset();

        /// <summary>
        ///     Copy data from another patch part
        /// </summary> 
        void CopyFrom(IPatchPart part);

        /// <summary>
        ///     Copy data from sysex dump
        /// </summary>
        void CopyFrom(byte[] data);

        /// <summary>
        ///     Get bytes of the part
        /// </summary>
        /// <returns>Bytes</returns>
        byte[] GetBytes();
    }
}