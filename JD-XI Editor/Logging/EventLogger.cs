using Caliburn.Micro;
using System;
using JD_XI_Editor.Bootstrap;

namespace JD_XI_Editor.Logging
{
    public class EventLogger : BaseLogger
    {
        /// <summary>
        /// Event aggregator instance
        /// </summary>
        private readonly IEventAggregator _aggregator;

        public EventLogger(Type type) : base(type)
        {
            _aggregator = Bootstrapper.ContainerInstance.GetInstance<IEventAggregator>();
        }

        /// <inheritdoc cref="ILogger.Log" />
        public override async void Log(LogLevel level, string message)
        {
            await _aggregator.PublishOnBackgroundThreadAsync(new LogMessage
            {
                Class = Type,
                Level = level,
                Message = message
            });
        }

        /// <summary>
        /// Get logger instance for specified class
        /// </summary>
        public static EventLogger GetForClass(Type type) => new EventLogger(type);
    }
}