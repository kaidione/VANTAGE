using System;

namespace LenovoVantageTest.LogHelper
{
    public enum LogType { Information, Warning, Failure, Error }
    class Logger
    {
        static Logger _instance;
        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Logger();
                }
                return _instance;
            }
        }
        public void WriteLog(string _message, LogType _logType = LogType.Warning)
        {
            Console.WriteLine($"{_logType.ToString()}:{_message}");
        }
    }
}
