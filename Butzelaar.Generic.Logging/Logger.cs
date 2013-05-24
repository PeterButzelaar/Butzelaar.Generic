﻿using Butzelaar.Generic.Logging.Enumeration;
using log4net;
using System;
using System.Diagnostics;
using System.Reflection;

namespace Butzelaar.Generic.Logging
{
    /// <summary>
    /// Wrapper class for the log4net framework
    /// </summary>
    public static class Logger
    {
        #region Log

        /// <summary>
        /// Writes debug information
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        public static void Log(Level level, string message)
        {
            Log(level, message, null);
        }

        /// <summary>
        /// Writes debug information
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        public static void Log(Level level, string message, string details)
        {
            Log(level, message, details, null);
        }

        /// <summary>
        /// Writes debug information
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="details">The details.</param>
        /// <param name="ex">The exception.</param>
        public static void Log(Level level, string message, string details, Exception ex)
        {
            var logger = GetCallingAssemblyName();

            SetDetailsProperty(details);
            SetStackTraceProperty();
            var loggerObject = LogManager.GetLogger(logger);
            var logMethod = GetLogMethodFromLevel(loggerObject, level);

            logMethod(message, ex);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Gets the name of the calling assembly.
        /// </summary>
        /// <returns>
        /// The name of the calling assembly
        /// </returns>
        internal static string GetCallingAssemblyName()
        {
            return Assembly.GetCallingAssembly().GetName().Name;
        }

        /// <summary>
        /// Sets the details property.
        /// </summary>
        /// <param name="details">The details.</param>
        internal static void SetDetailsProperty(string details)
        {
            GlobalContext.Properties["details"] = details ?? string.Empty;
        }

        /// <summary>
        /// Sets the stack trace property.
        /// </summary>
        internal static void SetStackTraceProperty()
        {
            GlobalContext.Properties["StackTrace"] = new StackTrace();
        }

        /// <summary>
        /// Gets the log method from level.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="level">The level.</param>
        /// <returns>
        /// The method used for logging
        /// </returns>
        internal static Action<object, Exception> GetLogMethodFromLevel(ILog logger, Level level)
        {
            switch (level)
            {
                case Level.Debug: return logger.Debug;
                case Level.Info: return logger.Info;
                case Level.Warning: return logger.Warn;
                case Level.Error: return logger.Error;
                case Level.Fatal: return logger.Fatal;
            }

            throw new ArgumentException(String.Format("Level specified not valid: {0}", level.ToString()));
        }

        #endregion
    }
}
