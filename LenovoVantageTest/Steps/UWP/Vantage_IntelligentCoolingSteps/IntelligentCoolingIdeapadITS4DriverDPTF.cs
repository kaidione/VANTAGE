using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class IntelligentCoolingIdeapadITS4DriverDPTF
    {
        public string _ITSRegistryValuePath = "hklm\\SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION\\Data";
        public string _ITSYMCRegistryPath = "hklm\\SOFTWARE\\Lenovo\\MoccaMode\\Mode";
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();


        public IntelligentCoolingIdeapadITS4DriverDPTF(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"current mode is (.*)")]
        public void ThenCurrentModeIs(string p)
        {
            var mode = IntelligentCoolingBaseHelper.GetCurrentModeFromBIOS();
            if (mode == p)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("current mode is " + mode);
            }
        }

        [Then(@"current mode not is (.*)")]
        public void ThenCurrentModeNotIsSTD(string p)
        {
            var mode = IntelligentCoolingBaseHelper.GetCurrentModeFromBIOS();
            if (mode != p)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("current mode is " + mode);
            }
        }



    }
}
