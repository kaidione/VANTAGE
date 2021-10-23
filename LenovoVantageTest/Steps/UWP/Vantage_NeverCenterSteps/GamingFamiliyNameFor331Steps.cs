using Castle.Core.Internal;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Features.UWP.Vantage_NerveCenter
{
    [Binding]
    public class GamingFamiliyNameFor331Steps
    {
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;

        public GamingFamiliyNameFor331Steps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        public string machineinfo = string.Empty;

        [Given(@"get machine info")]
        public void GivenGetMachineInfo()
        {
            machineinfo = VantageCommonHelper.GetCurrentMachineType();
        }

        [When(@"check if (.*) or not")]
        public void WhenCheckIfYOrNot(string p0)
        {
            string machineValues;
            GamingMachineListPage.GamingMachineList.TryGetValue(p0, out machineValues);
            Assert.IsTrue(!machineValues.IsNullOrEmpty() && machineValues.Contains(machineinfo));
        }


        [When(@"check if this machine in gaming list")]
        public void WhenCheckIfThisMachineInGamingList()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            bool result = _gamingThermalModePages.MachineIsGaming(machineinfo);
            Assert.IsTrue(result);
        }

        [Then(@"check info consistent with vantage")]
        public void ThenCheckInfoConsistentWithVantage()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreEqual(machineinfo, _gamingThermalModePages.CheckMachineinfoConsistent());
            Assert.AreEqual(machineinfo, _gamingThermalModePages.CheckVantageConsitent());

        }

    }
}



