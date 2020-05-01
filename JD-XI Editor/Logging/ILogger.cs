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
        /// Log with <see cref="LogLevel.AutoSync" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void AutoSync(string message);

        /// <summary>
        /// Log with <see cref="LogLevel.DataDump" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void DataDump(string message);

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

        /// <summary>
        /// Log with <see cref="LogLevel.Send" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Send(string message);

        /// <summary>
        /// Log with <see cref="LogLevel.Receive" /> level.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void Receive(string message);
    }
}