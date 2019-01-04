using Caliburn.Micro;
using JD_XI_Editor.Models.Patches.DrumKit.Partial;

namespace JD_XI_Editor.ViewModels.Drums
{
    internal class WmtEditorViewModel : Conductor<WmtViewModel>.Collection.OneActive
    {
        public WmtEditorViewModel(Partial partial)
        {
            //TODO: WMT as array
            Items.Add(new WmtViewModel(partial.Wmt1, "WMT1"));
            Items.Add(new WmtViewModel(partial.Wmt2, "WMT2"));
            Items.Add(new WmtViewModel(partial.Wmt3, "WMT3"));
            Items.Add(new WmtViewModel(partial.Wmt4, "WMT4"));
        }
    }
}