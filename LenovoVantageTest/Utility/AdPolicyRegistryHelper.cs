using Microsoft.Win32;
using System;

namespace LenovoVantageTest.Utility
{
    public static class AdPolicyRegistryHelper
    {
        public static void SetAudioSmartSettingsAdPolicy(bool isEnabled)
        {
            int value = isEnabled ? 1 : 0;
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_adpolicy_audio_smart_settings, value, RegistryValueKind.DWord);
        }

        public static void DeleteAudioSmartSettings()
        {
            DeleteKey(Constants.vantage_adpolicy_audio_smart_settings);
        }

        public static void SetMicrophoneAdPolicy(bool isEnabled)
        {
            int value = isEnabled ? 1 : 0;
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_adpolicy_microphone, value, RegistryValueKind.DWord);
        }

        public static void SetStandbyAdPolicy(bool isEnabled)
        {
            int value = isEnabled ? 1 : 0;
            RegistryHelp.SetRegistryKeyValuePlus(Constants.vantage_adpolicy_power_standby_settings, value, RegistryValueKind.DWord);
        }

        public static void SetAdPolicy(string key, bool isEnabled)
        {
            int value = isEnabled ? 1 : 0;
            RegistryHelp.SetRegistryKeyValuePlus(key, value, RegistryValueKind.DWord);
        }

        public static void DeleteMicrophoneAdPolicy()
        {
            DeleteKey(Constants.vantage_adpolicy_microphone);
        }

        public static void DeleteKey(string key)
        {
            try
            {
                RegistryHelp.DeleteRegistryKeyValue(key);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message != "No value exists with that name.")
                    throw ex;
            }
        }
    }
}
