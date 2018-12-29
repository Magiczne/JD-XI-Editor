using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal sealed class DrumKitPartialViewModel : Screen
    {
        public DrumKitPartialViewModel(Partial partial, string title)
        {
            DisplayName = title;
            Partial = partial;
        }

        #region Properties

        /// <summary>
        ///     Partial
        /// </summary>
        public Partial Partial { get; }

        #endregion
    }
}