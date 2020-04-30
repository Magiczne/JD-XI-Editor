namespace JD_XI_Editor.Logging
{
    public abstract class BaseLogger : ILogger
    {
        /// <inheritdoc cref="ILogger.Log" />
        public abstract void Log(LogLevel level, string message);

        /// <inheritdoc cref="ILogger.Info" />
        public void Info(string message) => Log(LogLevel.Info, message);

        /// <inheritdoc cref="ILogger.Error" />
        public void Error(string message) => Log(LogLevel.Error, message);
    }
}