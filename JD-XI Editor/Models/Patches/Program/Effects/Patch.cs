namespace JD_XI_Editor.Models.Patches.Program.Effects
{
    internal class Patch : IPatch
    {
        /// <inheritdoc />
        public void Reset()
        {
            Effect1.Reset();
            Effect2.Reset();
            Delay.Reset();
            Reverb.Reset();
        }

        #region Properties

        /// <summary>
        ///     Effect 1
        /// </summary>
        public Effect1.Patch Effect1 { get; set; }

        /// <summary>
        ///     Effect 2
        /// </summary>
        public Effect2.Patch Effect2 { get; set; }

        /// <summary>
        ///     Delay patch
        /// </summary>
        public Delay.Patch Delay { get; set; }

        /// <summary>
        ///     Reverb patch
        /// </summary>
        public Reverb.Patch Reverb { get; set; }

        #endregion
    }
}