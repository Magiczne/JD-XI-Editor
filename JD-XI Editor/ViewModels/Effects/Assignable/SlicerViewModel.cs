using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class SlicerViewModel : Screen
    {
        /// <summary>
        ///     Slicer parameters
        /// </summary>
        public SlicerParameters SlicerParameters { get; }

        public SlicerViewModel(SlicerParameters parameters)
        {
            SlicerParameters = parameters;
        }
    }
}