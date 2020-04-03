using System;
using System.Diagnostics;

namespace IXMWEBv2.Utils
{
    public static class Logger
    {
        /// <summary>
        /// Method to verify an error message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Error(string message, string module)
        {
            WriteEntry(message, "ERROR", module);
        }

        /// <summary>
        /// Method to verify and error exception
        /// </summary>
        /// <param name="exception"></param>
        /// <param name="message"></param>
        public static void Error(Exception exception, string message)
        {
            //WriteEntry(message, "ERROR", message);
            WriteEntry(exception.Message, "ERROR", message);
            WriteEntry(exception.StackTrace, "ERROR", message);

            // Adding Assert Inconclusive
            //Assert.Inconclusive(exception.StackTrace);
        }

        /// <summary>
        /// Method to verify a warning message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Warning(string message, string module = null)
        {
            WriteEntry(message, "WARNING", module);
        }

        /// <summary>
        /// Method to verify an info message
        /// </summary>
        /// <param name="message"></param>
        /// <param name="module"></param>
        public static void Info(string message, string module = null)
        {
            WriteEntry(message, "INFO", module);
        }

        public static void TestStartInfo(string testName, string className)
        {
            Trace.WriteLine(string.Format("{0} ========== Starting Test Execution for Method: '{1}' from Class:'{2}'.",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                testName,
                className));
        }

        public static void TestCompleteInfo(string testName, string testResult)
        {
            Trace.WriteLine(string.Format("{0} ========== Ending Test Execution for Method: '{1}' with Result: '{2}'.",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                testName,
                testResult.ToUpper()));
            Trace.WriteLine(Environment.NewLine);
        }

        private static void WriteEntry(string message, string type, string module)
        {
            Trace.WriteLine(
                    string.Format("{0} {1} {2} {3}",
                                  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                                  type,
                                  module,
                                  message));
        }
    }
}