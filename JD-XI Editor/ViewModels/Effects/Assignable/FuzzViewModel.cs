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

        public FuzzViewModel(FuzzParameters parameters)
        {
            FuzzParameters = parameters;
        }
    }
}