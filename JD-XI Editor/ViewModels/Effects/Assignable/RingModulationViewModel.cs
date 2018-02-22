using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class RingModulationViewModel : Screen
    {
        /// <summary>
        ///     Ring modulation parameters
        /// </summary>
        public RingModulationParameters RingModulationParameters { get; }

        public RingModulationViewModel(RingModulationParameters parameters)
        {
            RingModulationParameters = parameters;
        }
    }
}