using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class FlangerViewModel : Screen
    {
        /// <summary>
        ///     Flanger parameters
        /// </summary>
        public FlangerParameters FlangerParameters { get; }

        public FlangerViewModel(FlangerParameters parameters)
        {
            FlangerParameters = parameters;
        }
    }
}