Feature: VAN27943_FeatureTags
	Test Case：https://jira.tc.lenovo.com/browse/VAN-27943
	Author：Jinxin Li

Background: 
	Given Machine is Gaming
	Given Restart IMC service

@MacroKeySupported
Scenario: VAN27943_TestStep01 MacroKeySupported
	Given "Macro key" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Macrokey" is "true"

@MacroKeyUnSupported
Scenario: VAN27943_TestStep02 MacroKeyUnSupported
	Given "Macro key" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Macrokey" is "null"

@CPUOCUnSupported
Scenario: VAN27943_TestStep03 CPUOCUnSupported
	Given "CPU OC" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "null"

@CPUOCSupported
Scenario: VAN27943_TestStep04 CPUOCSupported
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "CPU OC" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "true"

@CPUOCSupported
Scenario: VAN27943_TestStep05 CPUOCSupported
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "CPU OC" is displayed
	Given Uninstall the "XTU" driver
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "true"

@CPUOCSupported
Scenario: VAN27943_TestStep06 CPUOCSupported
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "CPU OC" is displayed
	Given Uninstall the "XTU" driver
	Given Restart IMC service
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.CPUOverClock" is "true"

@RAMOCUnSupported
Scenario: VAN27943_TestStep07 RAMOCUnSupported
	Given "RAM OC" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "null"

@RAMOCSupportedDriverinstalled
Scenario: VAN27943_TestStep08 RAMOCSupportedDriverinstalled
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "RAM OC" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "true"

@RAMOCSupportedDriverinstalled
Scenario: VAN27943_TestStep09 RAMOCSupportedDriverinstalled
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "RAM OC" is displayed
	Given Uninstall the "XTU" driver
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "true"

@RAMOCSupportedDriverinstalled
Scenario: VAN27943_TestStep10 RAMOCSupportedDriverinstalled
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "RAM OC" is displayed
	Given Uninstall the "XTU" driver
	Given Restart IMC service
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.RAMOverClock" is "true"

@GPUOCUnSupported
Scenario: VAN27943_TestStep11 GPUOCUnSupported
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "GPU OC" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "null"

@GPUOCSupportedDriver
Scenario: VAN27943_TestStep12 GPUOCSupportedDriver
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Given "GPU OC" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "true"

@GPUOCSupportedDriver
Scenario: VAN27943_TestStep13 GPUOCSupportedDriver
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Given "GPU OC" is displayed
	Given 'GPU' Driver don't exist
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "true"

@GPUOCSupportedDriver
Scenario: VAN27943_TestStep14 GPUOCSupportedDriver
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Given "GPU OC" is displayed
	Given Delete 'System.Profile.Gaming.GPUOverClock' tag
	Given Restart IMC service
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.GPUOverClock" is "true"

@NetworkboostSupportedDriver
Scenario: VAN27943_TestStep15 NetworkboostSupportedDriver
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "Network boost" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.NetworkBoost" is "true"

@NetworkboostSupportedDriver
Scenario: VAN27943_TestStep16 NetworkboostSupportedDriver
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "Network boost" is displayed
    When Uninstall Lenovo Gaming NetFilter Device Driver
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.NetworkBoost" is "true"

@NetworkboostSupportedDriver
Scenario: VAN27943_TestStep17 NetworkboostSupportedDriver
	When Install Gaming driver
	Given Close Vantage
	Given Launch Vantage
	Given "Network boost" is displayed
	Given Delete 'System.Profile.Gaming.GPUOverClock' tag
	Given Restart IMC service
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.NetworkBoost" is "true"

@AutoCloseSupported
Scenario: VAN27943_TestStep18 AutoCloseSupported
	Given "Auto Close" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.AutoClose" is "true"

@HybridModeSupported
Scenario: VAN27943_TestStep19 HybridModeSupported
	Given The Machine support Specific function 'HybridMode'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "true"

@HybridModeUnSupported
Scenario: VAN27943_TestStep20 HybridModeUnSupported
	Given "Hybrid Mode" is not displayed	
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.HybridMode" is "null"

@OverDriveSupported
Scenario: VAN27943_TestStep21 OverDriveSupported
    Given Install Vantage
	Given The Machine support Specific function 'OverDrive'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "true"

@OverDriveUnSupported
Scenario: VAN27943_TestStep22 OverDriveUnSupported
	Given The Machine not support Specific function 'OverDrive'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.OverDrive" is "null"

@ThermalmodeUnSupported
Scenario: VAN27943_TestStep23 ThermalmodeUnSupported
	Given  "Thermal mode" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "null"
	
@Thermalmode2.0Supported
Scenario: VAN27943_TestStep24 Thermal mode 2.0(Y740) Supported
	Given "Thermal mode 2.0" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "2.0"
	
@Thermalmode3.0Supported
Scenario: VAN27943_TestStep25 Thermal mode 3.0(X50) Supported
	Given "Thermal mode 3.0" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "3.0"

@Thermalmode4.0Supported
Scenario: VAN27943_TestStep26 Thermal mode 4.0(X60) Supported
	Given "Thermal mode 4.0" is displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.ThermalMode" is "4.0"

@LightingUnSupported
Scenario: VAN27943_TestStep27 LightingUnSupported
	Given "Lighting" is not displayed
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "null"

@LightingNBSupported
Scenario: VAN27943_TestStep28 Lighting NB(Y550/Y560) Supported
    Then The Lighting section is display or not display in homepage 'display'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "notebook"

@LightingTowerSupported
Scenario: VAN27943_TestStep29 Lighting Tower with memory lights(T550) Supported
    Then The Lighting section is display or not display in homepage 'display'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"

@LightingDesktopMemory
Scenario: VAN27943_TestStep30 Lighting Tower with memory lights(T750) Supported
    Then The Lighting section is display or not display in homepage 'display'
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-memory"

@LightingTowerSupportedLEDDriver
Scenario: VAN27943_TestStep31 Lighting Tower without memory lights(C730) Supported
    When Uninstall Lenovo Gaming LED Driver
    Then The Lighting section is display or not display in homepage 'display'
    When Install Gaming driver
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"

@LightingTowerSupportedLEDDriver
Scenario: VAN27943_TestStep32 Lighting Tower without memory lights(C730) Supported
    When Install Gaming driver
    Then The Lighting section is display or not display in homepage 'display'
    When Uninstall Lenovo Gaming LED Driver
	Given Restart IMC service
	Then The Regedit Value of the Gaming Features tags and "System.Profile.Gaming.Lighting" is "desktop-tower"