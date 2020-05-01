using JD_XI_Editor.ViewModels;

namespace JD_XI_Editor.Views
{
    public partial class DebugWindowView
    {
        public DebugWindowView()
        {
            InitializeComponent();

            Closed += (sender, args) =>
            {
                DebugWindowViewModel.IsShown = false;
            };

            Activated += (sender, args) =>
            {
                DebugWindowViewModel.IsShown = true;
            };
        }
    }
}
