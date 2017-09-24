using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.Digital;

namespace JD_XI_Editor.ViewModels
{
    internal class DigitalPartialsEditorViewModel : Conductor<DigitalPartialViewModel>.Collection.OneActive
    {
        /// <inheritdoc />
        public DigitalPartialsEditorViewModel(Patch patch)
        {
            Items.Add(new DigitalPartialViewModel(patch.PartialOne, "Partial 1"));
            Items.Add(new DigitalPartialViewModel(patch.PartialTwo, "Partial 2"));
            Items.Add(new DigitalPartialViewModel(patch.PartialThree, "Partial 3"));
        }
    }
}