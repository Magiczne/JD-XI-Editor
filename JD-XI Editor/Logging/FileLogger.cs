using System;
using System.IO;

namespace JD_XI_Editor.Logging
{
    public class FileLogger : BaseLogger
    {
        /// <summary>
        /// Absolute path to directory with logs
        /// </summary>
        private readonly string _logPath;

        protected FileLogger(Type type) : base(type)
        {
            _logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            if (!Directory.Exists(_logPath))
            {
                Directory.CreateDirectory(_logPath);
            }
        }

        /// <inheritdoc cref="ILogger.Log" />
        public override void Log(LogLevel level, string message)
        {
            var now = DateTime.Now;
            var filePath = Path.Combine(_logPath, $"{now:yyyy-MM-dd}.txt");

            using (var writer = File.AppendText(filePath))
            {
                writer.WriteLine($"{now:g} [{Type}][{level}] {message}");
            }
        }

        /// <summary>
        /// Get logger instance for specified class
        /// </summary>
        public static FileLogger GetForClass(Type type) => new FileLogger(type);
    }
}
