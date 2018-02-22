namespace JD_XI_Editor.Models.Patches
{
    internal interface IPatch
    {
        /// <summary>
        ///     Reset data to initial patch
        /// </summary>
        void Reset();

        /// <summary>
        ///     Get bytes of the patch
        /// </summary>
        /// <returns>Bytes</returns>
        byte[] GetBytes();
    }
}