using System;

namespace JD_XI_Editor.Logging
{
    public class LoggerFactory
    {
        public static CompositeLogger FullSet(Type type)
        {
            return new CompositeLogger
            {
                Loggers =
                {
                    EventLogger.GetForClass(type),
                    FileLogger.GetForClass(type)
                }
            };
        }
    }
}