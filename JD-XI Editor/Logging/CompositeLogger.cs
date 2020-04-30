using System.Collections.Generic;

namespace JD_XI_Editor.Logging
{
    public class CompositeLogger : BaseLogger
    {
        /// <summary>
        /// List of loggers
        /// </summary>
        public IList<ILogger> Loggers { get; } = new List<ILogger>();

        /// <inheritdoc cref="ILogger.Log" />
        public override void Log(LogLevel level, string message)
        {
            foreach (var logger in Loggers)
            {
                logger.Log(level, message);
            }
        }
    }
}