using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class PhaserViewModel : Screen
    {
        /// <summary>
        ///     Phaser parameters
        /// </summary>
        public PhaserParameters PhaserParameters { get; }

        public PhaserViewModel(PhaserParameters parameters)
        {
            PhaserParameters = parameters;
        }
    }
}