using Caliburn.Micro;
using JD_XI_Editor.Models.Enums.Effects.Flanger;
using JD_XI_Editor.Models.Patches.Program.Effects.Effect2;

namespace JD_XI_Editor.ViewModels.Effects.Assignable
{
    internal class FlangerViewModel : Screen
    {
        /// <summary>
        ///     Flanger parameters
        /// </summary>
        public FlangerParameters FlangerParameters { get; }

        /// <summary>
        ///     Is Rate Mode Selected
        /// </summary>
        public bool IsRateModeSelected => FlangerParameters.Mode == Mode.Rate;

        /// <inheritdoc />
        /// <summary>
        ///     Creates new instance of FlangerViewModel
        /// </summary>
        public FlangerViewModel(FlangerParameters parameters)
        {
            FlangerParameters = parameters;

            FlangerParameters.PropertyChanged += (sender, args) =>
            {
                NotifyOfPropertyChange(nameof(IsRateModeSelected));
            };
        }
    }
}