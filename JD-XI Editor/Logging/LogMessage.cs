using System;

namespace JD_XI_Editor.Logging
{
    internal class LogMessage
    {
        public DateTime Time { get; set; } = DateTime.Now; 

        public LogLevel Level { get; set; }

        public string Class { get; set; }

        public string Message { get; set; }
    }
}
