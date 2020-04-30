using System.Threading;
using System.Threading.Tasks;
using Caliburn.Micro;
using JD_XI_Editor.Logging;

namespace JD_XI_Editor.ViewModels
{
    internal class DebugWindowViewModel : Screen, IHandle<LogMessage>
    {
        public BindableCollection<LogMessage> Messages { get; set; } = new BindableCollection<LogMessage>();

        public DebugWindowViewModel(IEventAggregator eventAggregator)
        {
            eventAggregator.SubscribeOnBackgroundThread(this);
        }

        public Task HandleAsync(LogMessage message, CancellationToken cancellationToken)
        {
            Messages.Add(message);

            return Task.CompletedTask;
        }
    }
}