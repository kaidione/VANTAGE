namespace LenovoVantageTest.Utility
{
    using Lenovo.Modern.Contracts.Keyboard;
    using Lenovo.Modern.Plugins.IdeaNotebookPlugin;
    using System;
    using System.Collections.Generic;

    public class IdeaPluginHelper
    {
        public KeyboardSettingsResponse keyboardSetting;

        public KeyboardSettingsResponse GetBacklightStatus()
        {
            IdeaNotebookAgent agent = IdeaNotebookAgent.GetInstance();
            keyboardSetting = agent.GetBacklightStatus();
            return keyboardSetting;
        }

        public string getKeyboardBacklightDriverValue()
        {
            string keyboardBacklightDriverValue = keyboardSetting.List.Items[1].value;
            return keyboardBacklightDriverValue;
        }

        public string getKeyboardBacklightDriverLevel()
        {
            string keyboardBacklightDriverLevel = keyboardSetting.List.Items[0].value;
            return keyboardBacklightDriverLevel;
        }

        public static void SetKeyboardBacklightLevelOff()
        {
            IdeaNotebookAgent agent = IdeaNotebookAgent.GetInstance();
            CommonResponse response = agent.SetBacklightStatus(new KeyboardSettingsRequest()
            {
                List = new SettingList()
                {
                    Items = new List<Setting>()
                    {
                        new Setting()
                        {
                            key = KeyboardContractConstants.Get.ValueKeyboardBacklightStatus,
                            value = BacklightLevelType.Off.ToString(),
                            enabled = XMLBoolean.True,
                        }
                    }
                }
            });
            Console.WriteLine(response.ErrorCode.Equals(ErrorCodeType.Success.ToString())
                ? "Set Keyboard backlight OFF success\n"
                : "Set Keyboard backlight OFF fail\n");
        }

        public static void SetKeyboardBacklightLevel1()
        {
            IdeaNotebookAgent agent = IdeaNotebookAgent.GetInstance();
            CommonResponse response = agent.SetBacklightStatus(new KeyboardSettingsRequest()
            {
                List = new SettingList()
                {
                    Items = new List<Setting>()
                    {
                        new Setting()
                        {
                            key = KeyboardContractConstants.Get.ValueKeyboardBacklightStatus,
                            value = BacklightLevelType.Level_1.ToString(),
                            enabled = XMLBoolean.True,
                        }
                    }
                }
            });
            Console.WriteLine(response.ErrorCode.Equals(ErrorCodeType.Success.ToString())
                ? "Set Keyboard backlight LOW/ON success\n"
                : "Set Keyboard backlight LOW/ON fail\n");
        }

        public static void SetKeyboardBacklightLevel2()
        {
            IdeaNotebookAgent agent = IdeaNotebookAgent.GetInstance();
            CommonResponse response = agent.SetBacklightStatus(new KeyboardSettingsRequest()
            {
                List = new SettingList()
                {
                    Items = new List<Setting>()
                    {
                        new Setting()
                        {
                            key = KeyboardContractConstants.Get.ValueKeyboardBacklightStatus,
                            value = BacklightLevelType.Level_2.ToString(),
                            enabled = XMLBoolean.True,
                        }
                    }
                }
            });
            Console.WriteLine(response.ErrorCode.Equals(ErrorCodeType.Success.ToString())
                ? "Set Keyboard backlight HIGH success\n"
                : "Set Keyboard backlight HIGH fail\n");
        }

        public static void SetKeyboardBacklightLevelAuto()
        {
            IdeaNotebookAgent agent = IdeaNotebookAgent.GetInstance();
            CommonResponse response = agent.SetBacklightStatus(new KeyboardSettingsRequest()
            {
                List = new SettingList()
                {
                    Items = new List<Setting>()
                    {
                        new Setting()
                        {
                            key = KeyboardContractConstants.Get.ValueKeyboardBacklightStatus,
                            value = BacklightLevelType.Auto.ToString(),
                            enabled = XMLBoolean.True,
                        }
                    }
                }
            });
            Console.WriteLine(response.ErrorCode.Equals(ErrorCodeType.Success.ToString())
                ? "Set Keyboard backlight AUTO success\n"
                : "Set Keyboard backlight AUTO fail\n");
        }

    }
}
