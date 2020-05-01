using System.Windows;

namespace JD_XI_Editor.Views
{
    public partial class MainWindowView
    {
        public MainWindowView()
        {
            InitializeComponent();

            Closed += (sender, args) =>
            {
                foreach (Window window in Application.Current.Windows)
                {
                    window.Close();
                }
            };
        }
    }
}