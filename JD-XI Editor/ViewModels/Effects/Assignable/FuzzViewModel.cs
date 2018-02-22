using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class FuzzViewModel : Screen
    {
        /// <summary>
        ///     Fuzz parameters
        /// </summary>
        public FuzzParameters FuzzParameters { get; }

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of FuzzViewModel
        /// </summary>
        public FuzzViewModel(FuzzParameters parameters)
        {
            FuzzParameters = parameters;
        }
    }
}