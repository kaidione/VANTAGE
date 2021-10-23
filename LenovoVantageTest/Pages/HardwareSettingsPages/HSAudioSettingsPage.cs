using CoreAudioApi;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TangramTest.Utility;

namespace LenovoVantageTest.Pages
{
    public class HSAudioSettingsPage : SettingsBase
    {
        public WindowsDriver<WindowsElement> session;

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        public string OptimizeMicrophoneCaptionContext = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.OptimizeMicrophoneCaptionContext").ToString();

        //Audio Smart settings
        public WindowsElement AudioSmartSettingsJumpLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='jumptoSetting-audio']");
        public WindowsElement HSDolbyAudioSection => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-dolby-li']");
        public WindowsElement AudioAutomaticDolbyCheckBox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-automatic-dolby_checkbox']");
        public WindowsElement HSRadioDolbyModeMusic => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='radioDolbyModeMusic']", 5);//base.GetElement(session, "AutomationId", "radioDolbyModeMusic");
        public WindowsElement HSRadioDolbyModeMovie => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='radioDolbyModeMovie']", 5);//base.GetElement(session, "XPath", "//*[@AutomationId='radioDolbyModeMovie']");
        public WindowsElement HSRadioDolbyModeDynamic => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='radioDolbyModeDynamic']", 5);//base.GetElement(session, "XPath", "//*[@AutomationId='radioDolbyModeDynamic']");
        public WindowsElement HSRadioDolbyModeGames => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioDolbyModeGames']");
        public WindowsElement HSRadioDolbyModeVoip => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioDolbyModeVoip']");
        public WindowsElement HSDolbyModeRadioGroup => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dolby-mode-radio-group']");
        public WindowsElement HSDolbyDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-automatic-dolby-caption']");
        public WindowsElement AudiosmartSettingsCollapseCardTitle => base.FindElementByTimes(session, "AutomationId", "audio-smart-settings-collapse-card-title", timeOut: 5);
        public WindowsElement AutomaticVoipCheckBox => base.FindElementByTimes(session, "AutomationId", "audio-voip_checkbox");//audio-voip_checkbox audio-voip_checkbox
        public WindowsElement EntertainmentCheckbox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='entertainmentCheckbox_checkbox']");
        public WindowsElement VoipRightIcon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-voip-tooltip_right_icon']");
        public WindowsElement VoipRightToolTip => base.FindElementByTimes(session, "AutomationId", "voipTooltip");
        public WindowsElement EntertainmentRightIcon => base.FindElementByTimes(session, "AutomationId", "entertainmentRightIcon");
        public WindowsElement EntertainmentToolTip => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='entertainmentTooltip']");
        public WindowsElement ECourseCheckbox => VantageCommonHelper.FindElementByXPath(session, "//*[@AutomationId='audio-eCourse_checkbox']", 5);
        public WindowsElement ECourseTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-eCourse-title']");
        public WindowsElement ECourseSection => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-eCourse-li']");
        public WindowsElement ECourseDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-eCourse-caption']");
        public WindowsElement VantageMinizeElement => FindElementByTimes(session, "XPath", VantageMinizeId);
        public WindowsElement VantageMaxizeElement => FindElementByTimes(session, "XPath", VantageMaxizeId);
        public WindowsElement CbthresholdLael => FindElementByTimes(session, "XPath", "//*[@AutomationId='cbthreshold-secondary-battery_checkbox-label']");
        public WindowsElement OptimizeMicrophoneCaption => FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-microphone-optimize-caption']");
        public WindowsElement MicrophoenCheckbox => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneCheckBoxId);
        public WindowsElement MicrophoneTitle => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneTitle);
        public WindowsElement MicrophoneSldierBar => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneVolumeSlider);
        public WindowsElement MicrophoneVolumeTitle => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneVolume);
        public WindowsElement MicrophoneVolumeSilent => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneVolumesilent);
        public WindowsElement MicrophoneVolumeLound => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneVolumelound);
        public WindowsElement JumpMicrophoneLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='jumptoSetting-microphone']", 20);
        public WindowsElement MicrophoneAecQuestionMark => base.FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneAECTooltip, 20);
        public WindowsElement MicrophoneAecCheckbox => base.FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneAECCheckBoxId);
        public WindowsElement MicrophoneAecTitle => base.FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneAECTitle);
        public WindowsElement MicrophoneAecTooltip => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneAECIntroduce);
        public WindowsElement MicroPhoneMultipleVoices => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneMultipleVoices);
        public WindowsElement MicroPhoneOnlyMyVoice => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneOnlyMyVoice);
        public WindowsElement MicroPhoneNormal => VantageCommonHelper.FindElementByXPath(session, VantageConstContent.MicroPhoneNormal, 5);//FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneNormal);
        public WindowsElement MicroPhoneVoiceRecognition => FindElementByTimes(session, "XPath", VantageConstContent.MicroPhoneVoiceRecognition);
        public WindowsElement KeystrokeSuppressionCheckBoxEle => VantageCommonHelper.FindElementByXPath(session, VantageConstContent.KeystrokeSuppressionCheckBoxXpath, 5);// GetElement(session, "XPath", VantageConstContent.KeystrokeSuppressionCheckBoxXpath);
        public WindowsElement KeystrokeSuppressionMaskEle => FindElementByTimes(session, "XPath", VantageConstContent.KeystrokeSuppressionMask);
        public WindowsElement KeystrokeTooltipToolTipEle => FindElementByTimes(session, "XPath", VantageConstContent.KeystrokeTooltipToolTip);
        public WindowsElement AcousticEchoCancellationToggle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='audio-microphone-acousticEcho_checkbox']");
        public WindowsElement AudioAutomaticDolbyQuesttion => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioAutomaticDolbyQuesttion"));
        public WindowsElement AudioAutomaticDolbyQuesttiontext => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioAutomaticDolbyQuesttiontext"));
        public WindowsElement MicroPhoneOptimizationTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.MicroPhoneOptimizationTitle"));
        public WindowsElement KeystrokeTooltiptitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.KeystrokeTooltiptitle"));
        public WindowsElement KeystrokeSuppressionCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.KeystrokeSuppressionCheckBox"));
        public WindowsElement KeystrokeSuppressionQuesttion => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.KeystrokeSuppressionQuesttion"));
        //Automatic Audio Optimization For VoIP
        public WindowsElement AutomaticAudioOptimizationForVoIPTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AutomaticAudioOptimizationForVoIPTitle"));
        public WindowsElement AutomaticAudioOptimizationForVoIPToggle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AutomaticAudioOptimizationForVoIPToggle"));
        public WindowsElement AutomaticAudioOptimizationForVoIPQuestionMark => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AutomaticAudioOptimizationForVoIPQuestionMark"));
        public WindowsElement AutomaticAudioOptimizationForVoIPTip => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AutomaticAudioOptimizationForVoIPTip"));
        public WindowsElement AudioMicrophoneOptimizeTitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioMicrophoneOptimizeTitle"));
        public WindowsElement AudioMicrophoneOptimizeCaption => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioMicrophoneOptimizeCaption"));
        public WindowsElement RadioMicrophoneVoiceRecognition => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneVoiceRecognition"));
        public WindowsElement RadioMicrophoneOnlyMyVoice => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneOnlyMyVoice"));
        public WindowsElement RadioMicrophoneNormal => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneNormal"));
        public WindowsElement RadioMicrophoneMultipleVoices => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneMultipleVoices"));
        public WindowsElement RadioMicrophoneVoiceRecognitionLabel => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneVoiceRecognitionLabel"));
        public WindowsElement RadioMicrophoneOnlyMyVoiceLabel => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneOnlyMyVoiceLabel"));
        public WindowsElement RadioMicrophoneNormalLabel => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneNormalLabel"));
        public WindowsElement RadioMicrophoneMultipleVoicesLabel => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.RadioMicrophoneMultipleVoicesLabel"));
        public WindowsElement AudioMicrophoneSuppressCheckbox => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioMicrophoneSuppressCheckbox"));
        public WindowsElement AudioMicrophoneAcousticEchoCheckbox => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioMicrophoneAcousticEchoCheckbox"));
        public WindowsElement MicrophoneEffectslink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicrophoneEffectslink"));
        public WindowsElement AdvancedMicrophoneEffects => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneEffects"));
        public WindowsElement AdvancedMicrophoneDescription => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneDescription"));
        public WindowsElement MicrophoneForMeetingstitle => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicrophoneForMeetingstitle"));
        public WindowsElement AdvancedMicrophoneQuickDescription => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescription"));
        public WindowsElement AdvancedMicrophoneQuickDescriptions => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptions"));
        public WindowsElement AdvancedMicrophoneEffectsHere => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneEffectsHere"));
        public WindowsElement AdvancedMicrophoneEffectsHeres => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneEffectsHeres"));
        public WindowsElement GoToWindowsPrivacySettings => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.GoToWindowsPrivacySettings"));
        public WindowsElement ForteMediainstallbutton => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.ForteMediainstallbutton"));
        public WindowsElement MicrophoneForMettingsLink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicrophoneForMettingsLink"));
        public WindowsElement ConferenceMode => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.ConferenceMode"));
        public WindowsElement MicrophoneSection => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicrophoneSection"), timeOut: 5);
        public WindowsElement MicrophoneFeatureTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AudioMicrophoneTitle"), 10);
        public WindowsElement SMBGoToWindowsPrivacySettings => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBGoToWindowsPrivacySettings"));
        public WindowsElement SMBMicrophoneEffectslink => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBMicrophoneEffectslink"));
        public WindowsElement SMBAdvancedMicrophoneQuickDescription => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBAdvancedMicrophoneQuickDescription"));
        public WindowsElement SMBAdvancedMicrophoneQuickDescriptions => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBAdvancedMicrophoneQuickDescriptions"));
        public WindowsElement SMBAdvancedMicrophoneDescription => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBAdvancedMicrophoneDescription"));
        public WindowsElement SMBAdvancedMicrophoneEffectsHere => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBAdvancedMicrophoneEffectsHere"));
        public WindowsElement SMBAdvancedMicrophoneEffectsHeres => FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMBAdvancedMicrophoneEffectsHeres"));
        public string AdvancedMicrophoneEffectsText => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneEffectsText");
        public string MicrophoneForMeetingstitletext => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicrophoneForMeetingstitletext");
        public string AdvancedMicrophoneDescriptionText => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneDescriptionText");
        public string AdvancedMicrophoneQuickDescriptionText => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionText");
        public string MicriophoneClickHere => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicriophoneClickHere");
        public string AdvancedMicrophoneQuickDescriptionTexts => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionTexts");
        // Smart Microphone Settings Elements
        public string SMSPrivateMode => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMSPrivateMode");
        public string SMSShardMode => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMSShardMode");
        public string SMSEnvMode => GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.SMSEnvMode");


        public UIAutomationControl contrl = new UIAutomationControl();

        private string realtekPath = @"C:\Program Files\Realtek\Audio\HDA\RAVCpl64.exe";

        public HSAudioSettingsPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public bool SupportMachine()
        {
            return (!GetCmdOutput("1", "Vantage will NOT show Dolby Settings"));
        }

        public bool SupportVoip()
        {

            return (GetCmdOutput("1", "VOIP feature supported: True"));
        }

        public bool SupportEntertainment()
        {

            return (GetCmdOutput("1", "entertainment feature Supported: True"));
        }

        public bool SupportDynamicMode()
        {
            return (!GetCmdOutput("1", "not support Dynamic mode"));
        }

        public bool SupportECourseMode()
        {
            return (GetCmdOutput("1", "ECourse feature supported: True"));
        }

        public static string MultiMediaToolPath()
        {
            string MultiMediaToolFilepath = string.Empty;
            if (Environment.Is64BitOperatingSystem)
            {
                MultiMediaToolFilepath = Path.Combine(VantageConstContent.DataPath, @"Data\Tools\MultimediaTool\x64\MultimediaDriverTool.exe");
            }
            else
            {
                MultiMediaToolFilepath = Path.Combine(VantageConstContent.DataPath, @"Data\Tools\MultimediaTool\x86\MultimediaDriverTool.exe");
            }
            return MultiMediaToolFilepath;
        }

        public static bool GetCmdOutput(string number, string supportflag)
        {
            if (string.IsNullOrEmpty(MultiMediaToolPath()))
            {
                return false;
            }
            bool SupportedOrNot = false;
            Process proc = new Process();
            proc.StartInfo.FileName = MultiMediaToolPath();
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.CreateNoWindow = false;
            proc.Start();
            Thread.Sleep(3000);
            proc.StandardInput.WriteLine(number);
            proc.StandardInput.WriteLine("{enter}");
            proc.StandardInput.WriteLine("q");
            proc.StandardInput.AutoFlush = true;
            StreamReader reader = proc.StandardOutput;
            while (!reader.EndOfStream)
            {
                string OutputResult = reader.ReadLine();
                if (OutputResult.Contains(supportflag))
                {
                    SupportedOrNot = true;
                }
            }
            proc.Close();
            return SupportedOrNot;
        }

        public bool SupportDolbyDynamic()
        {
            if (VantageCommonHelper.GetSupportedMode("1", "Current Dolby is DCH version") || VantageCommonHelper.GetSupportedMode("1", "Dynamic"))
            {
                return true;
            }
            return false;
        }

        public bool CompareToggle()
        {
            bool MuteState = false;
            bool MuteOne = CheckMuteState(MicrophoenCheckbox);
            MicrophoenCheckbox.Click();
            bool MuteTwo = CheckMuteState(MicrophoenCheckbox);
            MicrophoenCheckbox.Click();
            bool MuteThree = CheckMuteState(MicrophoenCheckbox);

            if (MuteOne && MuteTwo && MuteThree)
            {
                MuteState = true;
            }
            return MuteState;
        }

        public bool CheckMuteState(WindowsElement windowsElement)
        {
            bool muteTag = false;

            ToggleState toggleState = VantageCommonHelper.GetToggleStatus(windowsElement);
            var muteState = GetMicStatus();

            if (toggleState == ToggleState.On && muteState == "Unmute")
            {
                muteTag = true;
            }
            if (toggleState == ToggleState.Off && muteState == "Mute")
            {
                muteTag = true;
            }
            return muteTag;
        }

        private string GetMicStatus()
        {
            string _mutesatus = "unknow";
            try
            {
                MMDeviceEnumerator DevEnum = new MMDeviceEnumerator();
                MMDevice device_mic = DevEnum.GetDefaultAudioEndpoint(EDataFlow.eCapture, ERole.eMultimedia);
                if (device_mic.AudioEndpointVolume.Mute == true)
                {
                    _mutesatus = "Mute";
                }
                else
                {
                    _mutesatus = "Unmute";
                }

                bool xxx = device_mic.AudioEndpointVolume.Mute;
            }
            catch (Exception e)
            {
                Console.Write("GetMicStatus Exception:" + e);
            }
            return _mutesatus;
        }

        public bool PlayMode(string Mode)
        {
            string modeFilePath = string.Empty;
            try
            {
                switch (Mode)
                {
                    case "music":
                        modeFilePath = VantageConstContent.DolbyMusicPath;
                        break;
                    case "movie":
                        modeFilePath = VantageConstContent.DolbyMoviePath;
                        break;
                    case "game":
                        modeFilePath = VantageConstContent.DolbyGamePath;
                        VantageCommonHelper.OpenCmdRunCommand(modeFilePath);
                        return true;
                    case "music top":
                        RunCmd(VantageConstContent.DolbyMusicPath);
                        SetWindowsTopShow("Groove Music");
                        Thread.Sleep(6000);
                        return true;
                    case "movie top":
                        RunCmd(VantageConstContent.DolbyMoviePath);
                        SetWindowsTopShow("Movies & TV");
                        Thread.Sleep(6000);
                        return true;
                    case "task manager top":
                        Process.Start("Taskmgr");
                        Thread.Sleep(2000);
                        IntPtr intPtr = UnManagedAPI.FindWindow("TaskManagerWindow", "Task Manager");
                        UnManagedAPI.SetWindowPos(intPtr, UnManagedAPI.HWND_TOPMOST, 0, 0, 0, 0, UnManagedAPI.SWP_NOSIZE);
                        return true;
                }
                RunCmd(modeFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public void OpenFileViaApp(string file, string appFile = "cmd.exe")
        {
            if (!File.Exists(appFile))
            {
                appFile = "cmd.exe";
            }
            Process process = new Process();
            process.StartInfo.FileName = appFile;
            process.StartInfo.Arguments = file;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            process.Close();
            Thread.Sleep(2000);
        }

        public void SetWindowsTopShow(string windowsName, string className = "ApplicationFrameWindow", bool isProcess = false, string handleProcessName = null)
        {
            IntPtr intPtr = IntPtr.Zero;
            if (isProcess)
            {
                Process[] p = Process.GetProcessesByName(handleProcessName);
                if (p.Length > 0)
                {
                    intPtr = p[0].MainWindowHandle;
                }
            }
            else
            {
                intPtr = UnManagedAPI.FindWindow(className, windowsName);
            }
            UnManagedAPI.SetWindowPos(intPtr, UnManagedAPI.HWND_TOPMOST, Screen.PrimaryScreen.Bounds.Width - 300, Screen.PrimaryScreen.Bounds.Height / 2, 0, 0, UnManagedAPI.SWP_NOSIZE);
            UnManagedAPI.SetWindowsActivatedViaClick(intPtr);
            Thread.Sleep(500);
            UnManagedAPI.SetWindowsActivatedViaClick(intPtr);
        }

        public void VanatageMinisize()
        {
            VantageMinizeElement?.Click();
            VantageMaxizeElement?.Click();
        }

        public bool GotoAudioPage()
        {
            try
            {
                GotoMySettingsAudioPage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public bool ClickElement(WindowsElement windowsElement)
        {
            try
            {
                windowsElement.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }



        public void Wait(int p0)
        {
            Thread.Sleep(p0 * 1000);
        }

        public bool TurnElementState(WindowsElement element, ToggleState toggleState)
        {
            try
            {
                Thread.Sleep(TimeSpan.FromSeconds(3));
                if (GetCheckBoxStatus(element) != toggleState)
                {
                    element.Click();
                }
                if (GetCheckBoxStatus(element) == toggleState)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return false;
        }

        public bool SelectDolbyMode(WindowsElement windowsElement)
        {
            try
            {
                if (GetCheckBoxStatus(windowsElement) != ToggleState.On)
                {
                    windowsElement.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
            return true;
        }

        public WindowsElement GetCurrentDolbyModeElement()
        {
            if (GetCheckBoxStatus(HSRadioDolbyModeVoip) == ToggleState.On)
            {
                return HSRadioDolbyModeVoip;
            }
            if (GetCheckBoxStatus(HSRadioDolbyModeMusic) == ToggleState.On)
            {
                return HSRadioDolbyModeMusic;
            }
            if (GetCheckBoxStatus(HSRadioDolbyModeDynamic) == ToggleState.On)
            {
                return HSRadioDolbyModeDynamic;
            }
            if (GetCheckBoxStatus(HSRadioDolbyModeGames) == ToggleState.On)
            {
                return HSRadioDolbyModeGames;
            }
            if (GetCheckBoxStatus(HSRadioDolbyModeMovie) == ToggleState.On)
            {
                return HSRadioDolbyModeMovie;
            }
            return null;
        }

        public ToggleState GetCurrentDolbyMode()
        {
            try
            {
                return GetCheckBoxStatus(HSRadioDolbyModeVoip);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ToggleState.Indeterminate;
        }

        public ToggleState GetCurrentDynamicMode()
        {
            try
            {
                return GetCheckBoxStatus(HSRadioDolbyModeDynamic);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ToggleState.Indeterminate;
        }

        public bool OpenRAVCpl64()
        {
            try
            {
                Common.KillProcess("RAVCpl64", true);
                Process p = new Process();
                if (!File.Exists(realtekPath))
                {
                    return false;
                }
                p.StartInfo.FileName = realtekPath;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                AutomationElement realtekTabElement = contrl.FindElement("Realtek HD Audio Manager", "", "Microphone Array", 1);
                int index = 10;
                while (realtekTabElement == null && index > 0)
                {
                    realtekTabElement = contrl.FindElement("Realtek HD Audio Manager", "", "Microphone Array", 1);
                    if (realtekTabElement == null)
                    {
                        realtekTabElement = contrl.FindElement("Realtek HD Audio Manager", "", "麦克风阵列", 1);
                    }
                    index--;
                }
                var position = realtekTabElement.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void ReopenVantage()
        {
            session.LaunchApp();
        }

        public void DisableMicrophoneDriver(string state)
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:sound");
            Thread.Sleep(2000);
            if (state == "on")
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicDriverLinkOn"));
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(2000);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(2000);
                SendKeys.SendWait("{Enter}");
                Thread.Sleep(2000);
                VantageCommonHelper.FindElementByIdAndMouseClick(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicDriverCheckOnButton"));
                KillProcess("SystemSettings");
            }
            else
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicDriverLink"));
                Thread.Sleep(2000);
                AutomationElement toggle = VantageCommonHelper.FindElementByIdIsEnabled(GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.AudioPage.MicDriverCheckBox"));
                UIAutomationControl control = new UIAutomationControl();
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.On);
                KillProcess("SystemSettings");
            }

        }
    }
}
