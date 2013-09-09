using System;
using System.Diagnostics;
using System.Reflection;
using Butzelaar.Generic.Logging.Enumeration;
using log4net;

namespace Butzelaar.Generic.Logging
{
    /// <summary>
    ///     Wrapper class for the log4net framework
    /// </summary>
    public static class Logger
    {
        #region Log

        /// <summary>
        /// Writes debug information
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="ex">The exception.</param>
        public static void Log(Level level, string message, string details = null, Exception ex = null)
        {
            var logger = GetEntryAssemblyName();
            var loggerObject = LogManager.GetLogger(logger);
            var logMethod = GetLogMethodFromLevel(loggerObject, level);

            SetDetailsProperty(details);
            SetStackTraceProperty();
            
            logMethod(message, ex);
        }

        #endregion

        #region Helpers

        /// <summary>
        ///     Gets the name of the entry assembly.
        /// </summary>
        /// <returns>
        ///     The name of the calling assembly
        /// </returns>
        private static string GetEntryAssemblyName()
        {
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();

            return assembly.GetName().Name;
        }

        /// <summary>
        ///     Sets the details property.
        /// </summary>
        /// <param name="details">The details.</param>
        private static void SetDetailsProperty(string details)
        {
            ThreadContext.Properties["details"] = details ?? string.Empty;
        }

        /// <summary>
        ///     Sets the stack trace property.
        /// </summary>
        private static void SetStackTraceProperty()
        {
            ThreadContext.Properties["StackTrace"] = new StackTrace();
        }

        /// <summary>
        ///     Gets the log method from level.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="level">The level.</param>
        /// <returns>
        ///     The method used for logging
        /// </returns>
        private static Action<object, Exception> GetLogMethodFromLevel(ILog logger, Level level)
        {
            switch (level)
            {
                case Level.Debug:
                    return logger.Debug;
                case Level.Info:
                    return logger.Info;
                case Level.Warning:
                    return logger.Warn;
                case Level.Error:
                    return logger.Error;
                case Level.Fatal:
                    return logger.Fatal;
            }

            throw new ArgumentException(String.Format("Level specified not valid: {0}", level));
        }

        #endregion
    }
}