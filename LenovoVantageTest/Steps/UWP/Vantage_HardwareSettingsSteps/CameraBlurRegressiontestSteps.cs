using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class CameraBlurRegressiontestSteps
    {
        private InformationalWebDriver _webDriver;
        private string _exceptionMsg = string.Empty;
        private HSDispalyCameraPage _displayCameraPage;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private PreferenceSettingPage preferSettingPage;

        public CameraBlurRegressiontestSteps(InformationalWebDriver appDriver)

        {
            _webDriver = appDriver;
        }
        [Then(@"check Camereblur Featrue")]
        public void ThenCheckCamereblurFeatrue()
        {
            _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            var toggle = _displayCameraPage.CameraBlurCheckBox;
            var DESC = _displayCameraPage.CameraBlurCaption;
            Assert.IsTrue(toggle != null && DESC.Text.Contains("This feature blurs your background when you use the camera for any video call, or taking photos. You could choose different effect from below selections."));
        }

        [Then(@"check the three blur")]
        public void ThenCheckTheThreeBlur()
        {
            _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            var option1 = _displayCameraPage.blurModeRadio;
            var option2 = _displayCameraPage.comicModeRadio;
            var option3 = _displayCameraPage.sketchModeRadio;
            Assert.IsTrue(option1 != null && option2 != null && option3 != null);
        }

        [Given(@"openwincamera")]
        public void GivenOpenwincamera()
        {
            Process.Start("Microsoft.Windows.Camera:");
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [Given(@"closewincamera")]
        public void GivenClosewincamera()
        {
            Common.KillProcess("WindowsCamera", true);
        }

        [Given(@"stopcameradriver")]
        public void GivenStopcameradriver()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\devcon.exe");
            if (File.Exists(filePath))
            {
                _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
                string deviceID1 = _displayCameraPage.GetDeviceID("Integrated Camera");
                string deviceID2 = _displayCameraPage.GetDeviceID("Realtek DMFT - IR");
                string args1 = string.Format("\"{0}\" disable \"{1}\"", filePath, deviceID1);
                string args2 = string.Format("\"{0}\" disable \"{1}\"", filePath, deviceID2);
                CommandBase.RunCmd(args1);
                CommandBase.RunCmd(args2);
            }
        }

        [Given(@"startcameradirver")]
        public void GivenStartcameradirver()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestLib\\Data\\Tools\\devcon.exe");
            if (File.Exists(filePath))
            {
                _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
                string deviceID1 = _displayCameraPage.GetDeviceID("Integrated Camera");
                string deviceID2 = _displayCameraPage.GetDeviceID("Realtek DMFT - IR");
                string args1 = string.Format("\"{0}\" enable \"{1}\"", filePath, deviceID1);
                string args2 = string.Format("\"{0}\" enable \"{1}\"", filePath, deviceID2);
                CommandBase.RunCmd(args1);
                CommandBase.RunCmd(args2);
            }
        }


        [Then(@"Camera section Hidden")]
        public void ThenCameraSectionHidden()
        {
            _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsNull(_displayCameraPage.CameraLink);
        }

        [Given(@"Scroll the camera screen")]
        public void GivenScrollTheCameraScreen()
        {
            preferSettingPage = new PreferenceSettingPage(_webDriver.Session);
            preferSettingPage.ScrollScreen();
        }

    }
}
