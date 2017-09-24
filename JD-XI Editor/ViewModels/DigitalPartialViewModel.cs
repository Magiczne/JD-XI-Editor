using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Digital;

// ReSharper disable InvertIf

namespace JD_XI_Editor.ViewModels
{
    internal sealed class DigitalPartialViewModel : Screen
    {
        /// <summary>
        ///     Partial
        /// </summary>
        private Partial _partial;

        /// <inheritdoc />
        public DigitalPartialViewModel(Partial partial, string title)
        {
            DisplayName = title;
            Partial = partial;
        }

        /// <summary>
        ///     Partial
        /// </summary>
        public Partial Partial
        {
            get => _partial;
            private set
            {
                if (value != _partial)
                {
                    _partial = value;
                    NotifyOfPropertyChange(nameof(Partial));
                }
            }
        }
    }
}