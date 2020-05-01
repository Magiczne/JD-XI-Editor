using System.Reflection;
using Caliburn.Micro;

namespace JD_XI_Editor.ViewModels
{
    internal sealed class HomeTabViewModel : Screen
    {
        public string Version { get; set; }

        public HomeTabViewModel()
        {
            DisplayName = "Home";

            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Version = $"{version.Major}.{version.Minor}.{version.Build}";
        }
    }
}