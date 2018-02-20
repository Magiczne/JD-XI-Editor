using System.Diagnostics;
using System.Windows.Documents;

namespace JD_XI_Editor.Controls
{
    internal class ExternalHyperlink : Hyperlink
    {
        protected override void OnClick()
        {
            base.OnClick();

            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = NavigateUri.AbsoluteUri
                }
            }.Start();
        }
    }
}