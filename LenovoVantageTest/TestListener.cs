namespace LenovoVantageTest
{
    using TechTalk.SpecFlow.Tracing;
    public class TestListener : ITraceListener
    {
        private const string DisableTraceVariable = "DISABLE_SPECFLOW_TRACE_OUTPUT";

        private readonly ITraceListener listener;

        public void WriteTestOutput(string message)
        {
            if (listener != null)
                listener.WriteTestOutput(message);
        }

        public void WriteToolOutput(string message)
        {
            if (listener != null)
                listener.WriteToolOutput(message);
        }
    }
}
