using System;

namespace Terraform.Core.Logging
{
    /// <summary>
    /// Static logging class.
    /// </summary>
    public static partial class Log
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static ILog log;

        /// <summary>
        /// Set logger.
        /// </summary>
        /// <param name="log"> New logger. </param>
        public static void SetLogger(ILog log)
        {
            Log.log = log;
        }

        public static void Debug(string message)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.Debug(message);
        }

        public static void DebugFormat(string message, params object[] parameters)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.DebugFormat(message, parameters);
        }

        public static void Info(string message)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.Info(message);
        }

        public static void InfoFormat(string message, params object[] parameters)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.InfoFormat(message, parameters);
        }

        public static void Warn(string message)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.Warn(message);
        }

        public static void WarnFormat(string message, params object[] parameters)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.WarnFormat(message, parameters);
        }

        public static void Error(string message)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.Error(message);
        }

        public static void ErrorFormat(string message, params object[] parameters)
        {
            if (Log.log == null)
            {
                throw new InvalidOperationException("Logger not set in static class");
            }

            log.ErrorFormat(message, parameters);
        }
    }
}
