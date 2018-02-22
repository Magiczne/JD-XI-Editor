using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class BitCrusherViewModel : Screen
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of BitCrusherViewModel
        /// </summary>
        public BitCrusherViewModel(BitCrusherParameters parameters)
        {
            BitCrusherParameters = parameters;
        }

        /// <summary>
        ///     Bit Crusher parameters
        /// </summary>
        public BitCrusherParameters BitCrusherParameters { get; }
    }
}