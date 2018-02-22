using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect1;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class CompressorViewModel : Screen
    {
        /// <summary>
        ///     Compressor parameters
        /// </summary>
        public CompressorParameters CompressorParameters { get; }

        public CompressorViewModel(CompressorParameters parameters)
        {
            CompressorParameters = parameters;
        }
    }
}