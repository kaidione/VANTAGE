using LenovoVantageTest;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

[Binding]
public class CameraAndCameraPrivacyRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSQuickSettingsPage _hsQuickSettingsPage;
    private HSDispalyCameraPage _displayCameraPage;
    private string _currentBrihtnessValue;
    private string _currentContrastValue;
    private string _currentAutoExposureValue;
    private string _amCapBrihtnessValue;
    private string _amCapContrastValue;
    private string _amCapAutoExposureValue;

    public CameraAndCameraPrivacyRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Given(@"Click Camera Link")]
    public void GivenClickCameraLink()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraLink);
        _hsQuickSettingsPage.CameraLink.Click();
    }

    [Given(@"Show a Question Mark")]
    public void GivenShowAQuestionMark()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyQuestionMark);
    }

    [Given(@"Click Question Mark")]
    public void GivenClickQuestionMark()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyQuestionMark);
        _hsQuickSettingsPage.CameraPrivacyQuestionMark.Click();
    }

    [Given(@"Click Camera Privacy Mode Question Mark")]
    public void GivenClickCameraPrivacyModeQuestionMark()
    {
        _displayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_displayCameraPage.CameraPrivacyModeToolTipRightIcon, "Element 'Camera Privacy Mode Tool Tip Right Icon' Is Not Found");
        _displayCameraPage.CameraPrivacyModeToolTipRightIcon.Click();
    }

    [Then(@"Check tooltip display '(.*)'")]
    public void ThenCheckTooltipDisplay(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyQuestionMarkToolTip);
        Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.CameraPrivacyQuestionMarkToolTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
    }

    [Given(@"Turn (.*) Camera Privacy")]
    public void WhenTurnCameraPrivacy(String Status)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.ToLower().Equals("on"))
        {
            if (_hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraPrivacyToggle) == ToggleState.Off)
            {
                _hsQuickSettingsPage.CameraPrivacyToggle.Click();
            }
            Assert.AreEqual(ToggleState.On, _hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraPrivacyToggle));
        }
        if (Status.ToLower().Equals("off"))
        {
            if (_hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraPrivacyToggle) == ToggleState.On)
            {
                _hsQuickSettingsPage.CameraPrivacyToggle.Click();
            }
            Assert.AreEqual(ToggleState.Off, _hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraPrivacyToggle));
        }
    }

    [Given(@"Click Dashboard Link")]
    public void GivenClickDashboardLink()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.dashboardLink);
        _hsQuickSettingsPage.dashboardLink.Click();
    }

    [Then(@"Quick settings camera privacy status is '(.*)'")]
    public void ThenQuickSettingsCameraPrivacyStatusIs(string status)
    {
        if (status.ToLower().Equals("off"))
        {
            if (VantageConstContent.VantageTypePlan == VantageType.LE)
            {
                _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle);
            }
            else
            {
                _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                Assert.IsNotNull(_hsQuickSettingsPage.cameraOffButton);
            }
        }
    }

    [Given(@"Set Brightness")]
    public void GivenSetBrightness()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightnessSlider);
        if (CameraBrightnessSlider != null)
        {
            Actions moveSlider = new Actions(_webDriver.Session);
            IAction action = moveSlider.DragAndDropToOffset(_hsQuickSettingsPage.CameraBrightnessSlider, -100, 0).Build();
            action.Perform();
        }
    }

    [Given(@"Set Contrast")]
    public void GivenSetContrast()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrastSlider);
        if (CameraContrastSlider != null)
        {
            Actions moveSlider = new Actions(_webDriver.Session);
            IAction action = moveSlider.DragAndDropToOffset(_hsQuickSettingsPage.CameraContrastSlider, -100, 0).Build();
            action.Perform();
        }
    }

    [Given(@"Set Auto Exposure")]
    public void GivenSetAutoExposure()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposureSlider);
        if (CameraAutoExposureSlider != null)
        {
            VantageCommonHelper.DragSlider(_webDriver.Session, _hsQuickSettingsPage.CameraAutoExposureSlider, 100);
        }
    }

    [Given(@"Turn (.*) Auto Exposure")]
    public void GivenTurnAutoExposure(String Status)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.ToLower().Equals("on"))
        {
            if (_hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraAutoExposureBtn) == ToggleState.Off)
            {
                _hsQuickSettingsPage.CameraAutoExposureBtn.Click();
            }
            Assert.AreEqual(ToggleState.On, _hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraAutoExposureBtn));
        }
        if (Status.ToLower().Equals("off"))
        {
            if (_hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraAutoExposureBtn) == ToggleState.On)
            {
                _hsQuickSettingsPage.CameraAutoExposureBtn.Click();
            }
            Assert.AreEqual(ToggleState.Off, _hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraAutoExposureBtn));
        }
    }

    [When(@"Click the Reset button")]
    public void WhenClickTheResetButton()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraResetBtn);
        _hsQuickSettingsPage.CameraResetBtn.Click();
    }

    [Then(@"The Auto Exposure toogle become 'on' and restore to default value")]
    public void ThenCheckResetValue()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.AreEqual(_hsQuickSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.CameraAutoExposureBtn), ToggleState.On);
        Assert.IsNull(_hsQuickSettingsPage.CameraAutoExposureSlider);

    }

    [Then(@"Camera Link should be hidden")]
    public void ThenCameraLinkShouldBeHidden()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(_hsQuickSettingsPage.CameraLink);
    }

    [Then(@"The Camera section should be hidden")]
    public void ThenTheCameraSectionShouldBeHidden()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyToggle);
    }

    //Only run Agent07
    [Given(@"Disable Device 'Integrated Camera' and 'Integrated IR Camera'")]
    public void GivenDisableCameraDevice()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\devcon.exe");
        if (File.Exists(filePath))
        {
            string args = string.Format("{0} disable \"{1}\"", filePath, DeviceIDKeyMap["IntegratedCameraDeviceID"]);
            CommandBase.RunCmd(args);
        }
    }

    //Only run Agent07
    [Given(@"Enable Device 'Integrated Camera' and 'Integrated IR Camera'")]
    public void GivenEnableCameraDevice()
    {
        string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\devcon.exe");
        if (File.Exists(filePath))
        {
            string args = string.Format("{0} enable \"{1}\"", filePath, DeviceIDKeyMap["IntegratedCameraDeviceID"]);
            CommandBase.RunCmd(args);
        }
    }

    [Given(@"Open the Windows Camera")]
    public void GivenOpenTheWindowsCamera()
    {
        Process.Start("microsoft.windows.camera:");
    }

    [Then(@"The Camera privacy mode is ""(.*)""")]
    public void ThenTheCameraPrivacyModeIs(string onOrOff)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        switch (onOrOff)
        {
            case "on":
                Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), "The Camera Privacy is off");
                break;
            case "off":
                Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), "The Camera Privacy is on");
                break;
        }
    }

    [Then(@"There shows the description '(.*)'")]
    public void ThenThereShowsTheDescription(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyModeCaption);
        Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.CameraPrivacyModeCaption).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
    }

    [Then(@"All the title and slider will show")]
    public void ThenAllTheTitleAndSliderWillShow()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightness, "The brightness title is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightnessSlider, "The brightness slider is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrast, "The cameracontrast title is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrastSlider, "The cameracontrast slider is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposure, "The cameraAutoExposure title is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposureBtn, "The CameraAutoExposureBtn is not find");
    }

    [Then(@"The AutoExposure slider is ""(.*)""")]
    public void ThenTheAutoExposureSliderIs(string p0)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (p0 == "show")
        {
            Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposureSlider, "The CameraAutoExposureSlider is not find");
        }
        else if (p0 == "hidden")
        {
            Assert.IsNull(_hsQuickSettingsPage.CameraAutoExposureSlider, "The CameraAutoExposureSlider is find");
        }
    }

    [Given(@"Get camera current message")]
    public void GivenGetCameraCurrentMessage()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _currentBrihtnessValue = _hsQuickSettingsPage.CameraBrightnessSlider.GetAttribute("RangeValue.Value").ToString();
        _currentContrastValue = _hsQuickSettingsPage.CameraContrastSlider.GetAttribute("RangeValue.Value").ToString();
        _currentAutoExposureValue = _hsQuickSettingsPage.CameraAutoExposureSlider.GetAttribute("RangeValue.Value").ToString();
    }

    [Then(@"Get All value in AMCap")]
    public void ThenGetAllValueInAMCap()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _amCapBrihtnessValue = _hsQuickSettingsPage.GetValueFromAMCap("1009", "null");
        Thread.Sleep(5000);
        _amCapContrastValue = _hsQuickSettingsPage.GetValueFromAMCap("1010", "null");
        Thread.Sleep(5000);
        _amCapAutoExposureValue = _hsQuickSettingsPage.GetValueFromAMCap("1028", "auto");
    }

    [Then(@"The Vantage value is same with amcap")]
    public void ThenTheVantageValueIsSameWithAmcap()
    {
        Assert.AreEqual(_currentBrihtnessValue, _amCapBrihtnessValue, "The value of brithness is not same");
        Assert.AreEqual(_currentContrastValue, _amCapContrastValue, "The value of contrast is not same");
        Assert.AreEqual(_currentAutoExposureValue, _amCapAutoExposureValue, "The value of autoexposure is not same");
    }

    [Then(@"""(.*)"" value is same with AMCap")]
    public void ThenValueIsSameWithAMCap(string tp)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        switch (tp)
        {
            case "brightness":
                _amCapBrihtnessValue = _hsQuickSettingsPage.GetValueFromAMCap("1009", "null");
                Assert.AreEqual(_currentBrihtnessValue, _amCapBrihtnessValue, "The value of brithness is not same");
                break;
            case "contrast":
                _amCapContrastValue = _hsQuickSettingsPage.GetValueFromAMCap("1010", "null");
                Assert.AreEqual(_currentContrastValue, _amCapContrastValue, "The value of contrast is not same");
                break;
            case "autoexposure":
                _amCapAutoExposureValue = _hsQuickSettingsPage.GetValueFromAMCap("1028", "auto");
                Assert.AreEqual(_currentAutoExposureValue, _amCapAutoExposureValue, "The value of autoexposure is not same");
                break;
        }
    }

    [Then(@"The Camera Privacy mode will be ""(.*)""")]
    public void ThenTheCameraPrivacyModeWillBe(string tp)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        switch (tp)
        {
            case "hidden":
                Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyModeTitle, "The CameraPrivacyModeTitle is find");
                Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyModeCaption, "The CameraPrivacyModeCaption is find");
                Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyToggle, "The CameraPrivacyToggle is find");
                break;
            case "show":
                Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyModeTitle, "The CameraPrivacyModeTitle is not find");
                Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyModeCaption, "The CameraPrivacyModeCaption is not find");
                Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyToggle, "The CameraPrivacyToggle is not find");
                break;
        }
    }

    [Then(@"The slider will be ""(.*)""")]
    public void ThenTheSliderWillBe(string tp)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        switch (tp)
        {
            case "greyout":
                Assert.IsFalse(_hsQuickSettingsPage.CameraBrightnessSlider.Enabled, "The CameraBrightnessSlider is not greyout");
                Assert.IsFalse(_hsQuickSettingsPage.CameraContrastSlider.Enabled, "The CameraContrastSlider is not greyout");
                Assert.IsFalse(_hsQuickSettingsPage.CameraAutoExposureBtn.Enabled, "The CameraAutoExposureBtn is not greyout");
                break;
            case "nogreyout":
                Assert.IsTrue(_hsQuickSettingsPage.CameraBrightnessSlider.Enabled, "The CameraBrightnessSlider is  greyout");
                Assert.IsTrue(_hsQuickSettingsPage.CameraContrastSlider.Enabled, "The CameraContrastSlider is  greyout");
                Assert.IsTrue(_hsQuickSettingsPage.CameraAutoExposureBtn.Enabled, "The CameraAutoExposureBtn is  greyout");
                break;
        }
    }

    [Then(@"Device Settigs Camera Access Url will be ""(.*)""")]
    public void ThenDeviceSettigsCameraAccessUrlWillBe(string tp)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        switch (tp)
        {
            case "show":
                Assert.IsNotNull(_hsQuickSettingsPage.DeviceSettingsCameraAccessUrl, "The cameraaccessurl is not find");
                Assert.AreEqual(_hsQuickSettingsPage.DeviceSettingsCameraAccessUrl.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.DisplayAndCamera.DeviceSettingsCameraAccessUrlText").ToString());
                break;
            case "hidden":
                Assert.IsNull(_hsQuickSettingsPage.DeviceSettingsCameraAccessUrl, "The cameraaccessurl is  find");
                break;
        }
    }

    [Then(@"Camera privacy mode toggle is on")]
    public void ThenCameraPrivacyModeToggleIsOn()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle));
    }

    [Then(@"The value is same than before")]
    public void ThenTheValueIsSameThanBefore()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.AreEqual(_currentBrihtnessValue, _hsQuickSettingsPage.CameraBrightnessSlider.GetAttribute("RangeValue.Value").ToString(), "The CameraBrightnessSlider value is not same");
        Assert.AreEqual(_currentContrastValue, _hsQuickSettingsPage.CameraContrastSlider.GetAttribute("RangeValue.Value").ToString(), "The CameraContrastSlider value is not same");
        Assert.AreEqual(_currentAutoExposureValue, _hsQuickSettingsPage.CameraAutoExposureSlider.GetAttribute("RangeValue.Value").ToString(), "The CameraAutoExposureSlider value is not same");
    }

    [Then(@"The Ui show normally")]
    public void ThenTheUiShowNormally()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightnessSlider, "The CameraBrightnessSlider is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrastSlider, "The CameraContrastSlider is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposureSlider, "The CameraAutoExposureSlider is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraResetBtn, "The CameraResetBtn is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposureBtn, "The CameraAutoExposureBtn is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightness, "The CameraBrightness is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrast, "The CameraContrast is not find");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraAutoExposure, "The CameraAutoExposure is not find");
    }

    [Then(@"Check Camera Is In Use")]
    public void ThenCheckCameraIsInUse()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraIsInUseName, "Element 'Camera Is In Use' Is Not Found");
    }

    [Then(@"Check Camera and Camera Privacy UI Elements")]
    public void ThenCheckCameraAndCameraPrivacyUIElements()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyQuestionMark, "Element 'Camera Privacy QuestionMark' Is Not Found");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraPrivacyToggle, "Element 'Camera Privacy Toggle' Is Not Found");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraBrightnessSlider, "Element 'Camera Brightness Slider' Is Not Found");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraContrastSlider, "Element 'Camera Contrast Slider' Is Not Found");
        Assert.IsNotNull(_hsQuickSettingsPage.CameraResetBtn, "Element 'Camera Reset Btn' Is Not Found");
    }

    [Then(@"The Camera Preview should be hidden")]
    public void ThenTheCameraPreviewShouldBeHidden()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(VantageCommonHelper.FindElementByIdIsEnabled(VantageConstContent.CameraTitle), "Element 'Camera title' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraResetBtn, "Element 'Camera Reset Btn' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyQuestionMark, "Element 'Camera Privacy QuestionMark' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraBrightnessSlider, "Element 'Camera Brightness Slider' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraContrastSlider, "Element 'Camera Contrast Slider' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraAutoExposureBtn, "The CameraAutoExposureBtn is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraPreview, "Element 'Camera Preview Slider' Is Found");
    }

    [Given(@"Click Go To Settings links")]
    public void GivenClickGoToSettingsLinks()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DeviceSettingsCameraAccessUrl, "DeviceSettingsCameraAccessUrl is not find");
        _hsQuickSettingsPage.DeviceSettingsCameraAccessUrl.Click();
        AutomationElement cameraBtn = VantageCommonHelper.FindElementByIdIsEnabled("SystemSettings_CapabilityAccess_Camera_SystemGlobal_Group_GroupTitleTextBlock");
        Assert.IsNotNull(cameraBtn, "The cameraBtn is not find");
    }

    [Then(@"The Camera section should not be find")]
    public void ThenTheCameraSectionShouldNotBeFind()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyModeTitle, "The CameraPrivacyModeTitle is find");
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyModeCaption, "The CameraPrivacyModeCaption is find");
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyToggle, "The CameraPrivacyToggle is find");
        Assert.IsNull(_hsQuickSettingsPage.CameraResetBtn, "Element 'Camera Reset Btn' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraPrivacyQuestionMark, "Element 'Camera Privacy QuestionMark' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraBrightnessSlider, "Element 'Camera Brightness Slider' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraContrastSlider, "Element 'Camera Contrast Slider' Is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraAutoExposureBtn, "The CameraAutoExposureBtn is Found");
        Assert.IsNull(_hsQuickSettingsPage.CameraAutoExposureSlider, "The CameraAutoExposureSlider is Found");
    }
}
