using JD_XI_Editor.Models.Analog;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class AnalogSynthTabViewModel : TabViewModel
    {
        #region Properties

        /// <summary>
        /// Patch model
        /// </summary>
        public AnalogPatch Patch { get; }

        #endregion

        /// <summary>
        /// Creates new instance of AnalogSynthTabViewModel
        /// </summary>
        public AnalogSynthTabViewModel()
        {
            DisplayName = "Analog Synth";

            Patch = new AnalogPatch();
        }
    }
}