using System;

namespace JD_XI_Editor.Logging
{
    public abstract class BaseLogger : ILogger
    {
        /// <summary>
        /// Type
        /// </summary>
        protected readonly string Type;

        protected BaseLogger(Type type) => Type = type.Name;

        /// <inheritdoc cref="ILogger.Log" />
        public abstract void Log(LogLevel level, string message);

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