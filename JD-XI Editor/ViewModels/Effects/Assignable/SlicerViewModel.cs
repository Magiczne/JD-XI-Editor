using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class SlicerViewModel : Screen
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of SlicerViewModel
        /// </summary>
        public SlicerViewModel(SlicerParameters parameters)
        {
            SlicerParameters = parameters;
        }

        /// <summary>
        ///     Slicer parameters
        /// </summary>
        public SlicerParameters SlicerParameters { get; }
    }
}