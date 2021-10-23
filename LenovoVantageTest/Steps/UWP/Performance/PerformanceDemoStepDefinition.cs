namespace LenovoVantageTest.Steps.UWP.Performance
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using System;
    using System.Diagnostics;
    using System.IO;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class PerformanceDemoStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;

        public double elapsed;

        public PerformanceDemoStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Get Load Hero Banner '(.*)' time")]
        public void GivenGetLoadHeroBannerTime(string p0)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.heroBanner.Displayed);

            stopwatch.Stop();
            elapsed = stopwatch.Elapsed.TotalSeconds;
        }

        [Given(@"Get the Download Speed demo")]
        public void GivenGetTheDownloadSpeedDemo()
        {
            Process proc = null;
            string batDir = string.Format(@"D:\TestNetworkBoost");
            proc = new Process();
            proc.StartInfo.WorkingDirectory = batDir;
            proc.StartInfo.FileName = "download.bat";
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
            proc.WaitForExit(1000);
            //proc.WaitForExit();
            KillProccess("wget.exe");
            KillProccess("cmd.exe");

            string outlogfilename = "output.log";
            string filenamepath = batDir + "\\" + outlogfilename;
            Console.WriteLine(filenamepath);

            if (File.Exists(filenamepath))
            {
                /// <param name="filenamepath">txt等文件的路径</param>
                /// <param name="strIndex">索引的字符串，定位到某一行</param>               
                string[] lines = System.IO.File.ReadAllLines(filenamepath);
                File.WriteAllLines(filenamepath, lines);
            }

        }
        public void KillProccess(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            try
            {
                foreach (Process process in processes)
                {
                    process.Kill();
                    process.WaitForExit();
                    process.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("not find process", ex);
            }
        }
    }
}
