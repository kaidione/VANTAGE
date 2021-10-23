using HTTPAnalyzer;
using HTTPAnalyzerStd;
using System;
using System.Collections.Concurrent;

namespace HttpAnalyzerHelper
{
    public class HttpAnalyzerAgent
    {
        HTTPAnalyzerStandAloneClass analyzerAgent;
        string urlToMonitor;
        BlockingCollection<string> trafficListCaptured;

        public HttpAnalyzerAgent(string urlToMonitor, bool isVisible)
        {
            analyzerAgent = new HTTPAnalyzerStandAloneClass();
            analyzerAgent.Visible = isVisible;
            this.urlToMonitor = urlToMonitor;
            analyzerAgent.AttachAllSessions();
            analyzerAgent.OnNewEntry += handleOnNewEntryEvent;
            trafficListCaptured = new BlockingCollection<string>();
        }
        public HttpAnalyzerAgent(string processName, string urlToMonitor, bool isVisible)
        {
            analyzerAgent = new HTTPAnalyzerStandAloneClass();
            analyzerAgent.Visible = isVisible;
            this.urlToMonitor = urlToMonitor;
            analyzerAgent.AttachProcessByName(processName);
            analyzerAgent.OnNewEntry += handleOnNewEntryEvent;
            trafficListCaptured = new BlockingCollection<string>();
        }

        public HTTPAnalyzerStandAloneClass AnalyzerAgent
        {
            get
            {
                return analyzerAgent;
            }

            set
            {
                analyzerAgent = value;
            }
        }

        public BlockingCollection<string> TrafficListCaptured
        {
            get
            {
                return trafficListCaptured;
            }

            set
            {
                trafficListCaptured = value;
            }
        }

        public void Start()
        {
            analyzerAgent.Start();
        }

        public void Stop()
        {
            analyzerAgent.Stop();
        }

        public void Clear()
        {
            analyzerAgent.Clear();
        }

        private void handleOnNewEntryEvent(ILogEntry Entry, ref bool DiscardIt)
        {
            if (Entry.URL.Contains(urlToMonitor) && !DBNull.Value.Equals(Entry.Request.PostData))
            {
                trafficListCaptured.Add(System.Text.Encoding.Default.GetString((byte[])Entry.Request.PostData));
            }
        }

        ~HttpAnalyzerAgent()
        {
            Stop();
        }
    }
}