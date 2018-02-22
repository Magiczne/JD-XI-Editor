using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class CompressorViewModel : Screen
    {
        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of CompressorViewModel
        /// </summary>
        public CompressorViewModel(CompressorParameters parameters)
        {
            CompressorParameters = parameters;
        }

        /// <summary>
        ///     Compressor parameters
        /// </summary>
        public CompressorParameters CompressorParameters { get; }
    }
}