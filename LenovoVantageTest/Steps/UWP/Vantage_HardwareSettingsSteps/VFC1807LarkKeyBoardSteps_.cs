using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class LarkKeyBoardSteps
    {
        private InformationalWebDriver _webDriver;
        private HSInputPage _hSInputPage;

        public LarkKeyBoardSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Show ""(.*)"" under IntelligentKeyBoard")]
        public void ThenShowUnderIntelligentKeyBoard(string p0)
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_hSInputPage.InputLarkKeyBoardNote, "The larkkeyboardnote is not find");
            Assert.AreEqual(_hSInputPage.InputLarkKeyBoardNote.Text, p0, "The note is not the true");
        }

        [Then(@"Show Userdefined key function")]
        public void ThenShowUserdefinedKeyFunction()
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_hSInputPage.userDefinedKey_Title, "The user defined key function is not find");
        }

        [Then(@"not show ""(.*)""")]
        public void ThenNotShow(string p0)
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            switch (p0)
            {
                case "Touchpad link":
                    Assert.IsNull(_hSInputPage.Touchpadlink, "The Touchpad link is find");
                    break;
                case "Trackpoint link":
                    Assert.IsNull(_hSInputPage.Trackpointlink, "The Trackpoint link is find");
                    break;
                case "More":
                    string targetID = VantageConstContent.AutomationIDKeyMap["InputMoreLink"];
                    Assert.IsNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID, 2, false, 5), "The more is find");
                    break;
            }
        }

        [Then(@"Turn ""(.*)"" bluetooth")]
        public void ThenTurnBluetooth(string p0)
        {
            _hSInputPage = new HSInputPage(_webDriver.Session);
            _hSInputPage.SetBlueToothState(p0);
        }


    }
}
