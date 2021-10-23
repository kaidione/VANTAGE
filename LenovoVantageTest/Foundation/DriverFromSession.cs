namespace LenovoVantageTest.Foundation
{
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Web;

    public class DriverFromSession
    {
        public static string GetBrowserDetail()
        {
            string browserdetail = string.Empty;

            HttpBrowserCapabilitiesBase capabilitiesBase;

            HttpBrowserCapabilities httpBrowser;

            return browserdetail;
        }
        public static Uri GetExecutorURLFromDriver(RemoteWebDriver driver)
        {
            var executorField = typeof(RemoteWebDriver)
                .GetField("executor",
                BindingFlags.NonPublic
                | BindingFlags.Instance);

            object executor = executorField.GetValue(driver);

            var internalExecutorField = executor.GetType()
                .GetField("internalExecutor",
                          BindingFlags.NonPublic
                          | BindingFlags.Instance);
            object internalExecutor = internalExecutorField.GetValue(executor);


            var remoteServerUriField = internalExecutor.GetType()
                .GetField("remoteServerUri",
                          BindingFlags.NonPublic
                          | BindingFlags.Instance);
            var remoteServerUri = remoteServerUriField.GetValue(internalExecutor) as Uri;

            return remoteServerUri;
        }
    }

    public class ReuseRemoteWebDriver : RemoteWebDriver
    {
        private String sessionId;

        public ReuseRemoteWebDriver(Uri remoteAddress, String sessionId)
            : base(remoteAddress, new DesiredCapabilities())
        {
            this.sessionId = sessionId;
            var sessionIdBase = this.GetType()
                .BaseType
                .GetField("sessionId",
                          BindingFlags.Instance
                          | BindingFlags.NonPublic);
            sessionIdBase.SetValue(this, new SessionId(sessionId));
        }

        protected override Response
            Execute(string driverCommandToExecute, Dictionary<string, object> parameters)
        {
            if (driverCommandToExecute == DriverCommand.NewSession)
            {
                var resp = new Response();
                resp.Status = OpenQA.Selenium.WebDriverResult.Success;
                resp.SessionId = this.sessionId;
                resp.Value = new Dictionary<string, object>();
                return resp;
            }
            var respBase = base.Execute(driverCommandToExecute, parameters);
            return respBase;
        }
    }
}
