using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial.Wmt;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal sealed class WmtViewModel : Screen
    {
        public WmtViewModel(Wmt wmt, string title)
        {
            DisplayName = title;
            Wmt = wmt;
        }

        #region Properties

        /// <summary>
        ///     Wmt
        /// </summary>
        public Wmt Wmt { get; }

        #endregion
    }
}