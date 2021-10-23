using System;
using System.IO;
using winformUI.Common;

namespace LogServer
{
    public enum LogType
    {
        All,
        Information,
        Debug,
        Success,
        Failure,
        Warning,
        Error
    }

    public class Logger
    {

        #region Instance
        public static object logLock;

        public static Logger instance;

        public static string logFileName;
        public Logger() { }

        /// <summary>
        /// Logger instance
        /// </summary>
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logger();
                    logLock = new object();
                    logFileName = Guid.NewGuid() + ".log";
                }
                return instance;
            }
        }
        #endregion

        /// <summary>
        /// Write log to log file
        /// </summary>
        /// <param name="logContent">Log content</param>
        /// <param name="logType">Log type</param>
        public void WriteLog(string logContent, LogType logType = LogType.Information, string fileName = null)
        {
            try
            {

                if (!Directory.Exists(CommonConstStr.LogFilePath))
                {
                    Directory.CreateDirectory(CommonConstStr.LogDirectory);
                }

                string dataString = DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(CommonConstStr.LogFilePath + "\\Log\\" + dataString))
                {
                    Directory.CreateDirectory(CommonConstStr.LogFilePath + "\\Log\\" + dataString);
                }

                string[] logText = new string[] { DateTime.Now.ToString("hh:mm:ss") + ": " + logType.ToString() + ": " + logContent };
                string logStr = string.Empty;
                foreach (string log in logText)
                {
                    logStr += log + "\r\n";
                }
                if (!string.IsNullOrEmpty(fileName))
                {
                    fileName = fileName + "_" + logFileName;
                }
                else
                {
                    fileName = logFileName;
                }
                Console.WriteLine(logText[0]);
                lock (logLock)
                {
                    File.AppendAllText(CommonConstStr.LogFilePath + "\\Log\\" + dataString + "\\" + fileName, logStr);
                }
            }
            catch (Exception) { }
        }

        /// <summary>
        /// Write exception to log file
        /// </summary>
        /// <param name="exception">Exception</param>
        public void WriteException(Exception exception, string specialText = null)
        {
            if (exception != null)
            {
                Type exceptionType = exception.GetType();
                string text = string.Empty;
                if (!string.IsNullOrEmpty(specialText))
                {
                    text = text + specialText + Environment.NewLine;
                }
                text = "Exception: " + exceptionType.Name + Environment.NewLine;
                text += "               " + "Message: " + exception.Message + Environment.NewLine;
                text += "               " + "Source: " + exception.Source + Environment.NewLine;
                text += "               " + "StackTrace: " + exception.StackTrace + Environment.NewLine;
                WriteLog(text, LogType.Error);
            }
        }
    }
}

