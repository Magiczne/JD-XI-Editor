using System.ComponentModel;

namespace JD_XI_Editor.Models.Patches
{
    internal interface IPatchPart : INotifyPropertyChanged
    {
        /// <summary>
        ///     Reset data to initial path
        /// </summary>
        void Reset();

        /// <summary>
        ///     Get bytes of the part
        /// </summary>
        /// <returns>Bytes</returns>
        byte[] GetBytes();
    }
}