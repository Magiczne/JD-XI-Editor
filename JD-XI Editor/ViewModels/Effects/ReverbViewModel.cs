using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Reverb;

namespace JD_XI_Editor.ViewModels.Effects
{
    internal class ReverbViewModel : Screen
    {
        /// <summary>
        ///     Reverb patch
        /// </summary>
        public Patch Patch { get; }

        /// <inheritdoc />
        /// <summary>
        ///     Create new instance of Reverb View Model
        /// </summary>
        public ReverbViewModel(Patch patch)
        {
            Patch = patch;
        }
    }
}