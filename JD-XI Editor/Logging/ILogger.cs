namespace JD_XI_Editor.Logging
{
    public interface ILogger
    {
        /// <summary>
        /// Log message
        /// </summary>
        /// <param name="level">Log level</param>
        /// <param name="message">Message</param>
        void Log(LogLevel level, string message);

        /// <summary>
        /// Log with <see cref="LogLevel.Info" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Info(string message);

        /// <summary>
        /// Log with <see cref="LogLevel.Error" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Error(string message);
    }
}