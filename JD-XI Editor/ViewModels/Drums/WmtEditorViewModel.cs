using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal class WmtEditorViewModel : Conductor<WmtViewModel>.Collection.OneActive
    {
        public WmtEditorViewModel(Partial partial)
        {
            for (var i = 0; i < partial.Wmts.Length; i++)
                Items.Add(new WmtViewModel(partial.Wmts[i], $"WMT {i + 1}"));
        }
    }
}