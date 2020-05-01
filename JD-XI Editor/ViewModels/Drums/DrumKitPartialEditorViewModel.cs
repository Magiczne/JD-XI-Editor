using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit;
using JD_XI_Editor.Utils.Enums;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal class DrumKitPartialEditorViewModel : Conductor<DrumKitPartialViewModel>.Collection.OneActive
    {
        public DrumKitPartialEditorViewModel(Patch patch)
        {
            foreach (var partial in patch.Partials)
            {
                Items.Add(new DrumKitPartialViewModel(partial.Value, partial.Key.Description()));
            }
        }
    }
}