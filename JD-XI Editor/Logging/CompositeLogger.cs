using System.Collections.Generic;

namespace JD_XI_Editor.Logging
{
    public class CompositeLogger : ILogger
    {
        /// <summary>
        /// List of loggers
        /// </summary>
        public IList<ILogger> Loggers { get; } = new List<ILogger>();

        /// <inheritdoc cref="ILogger.Log" />
        public void Log(LogLevel level, string message)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(level, message);
            }
        }

        /// <inheritdoc cref="ILogger.AutoSync" />
        public void AutoSync(string message) => Log(LogLevel.AutoSync, message);

        /// <inheritdoc cref="ILogger.DataDump" />
        public void DataDump(string message) => Log(LogLevel.DataDump, message);

        /// <inheritdoc cref="ILogger.Info" />
        public void Info(string message) => Log(LogLevel.Info, message);

        /// <inheritdoc cref="ILogger.Error" />
        public void Error(string message) => Log(LogLevel.Error, message);

        /// <inheritdoc cref="ILogger.Send" />
        public void Send(string message) => Log(LogLevel.Send, message);

        /// <inheritdoc cref="ILogger.Receive" />
        public void Receive(string message) => Log(LogLevel.Receive, message);
    }
}