Feature: VAN21721_Part2_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep14_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 1 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep14_1ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep15_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 2 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep15_2ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep16_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 3 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep16_3ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep17_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 4 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep17_4ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep18_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 5 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep18_5ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep19_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 6 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep19_6ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep20_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 7 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep20_7ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep21_Core Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover 8 Core Ratio/Active Core(s) Ratio title
	Then Take Screen Shot VAN21721_TestStep21_8ActiveCoreRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep22_Core Voltage offset decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover "Core Voltage offset" title
	Then Take Screen Shot VAN21721_TestStep22_CoreVoltageOffsetDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep23_AVX Ratio offset decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover "AVX Ratio offset" title
	Then Take Screen Shot VAN21721_TestStep23_AVXRatioOffsetDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep24_Cache Ratio decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover "Cache Ratio" title
	Then Take Screen Shot VAN21721_TestStep24_CacheRatioDescriptionTip in 21721 under GamingScreenShotResult

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep25_Cache Voltage offset decription tip should be shown in the Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When Hover "Cache Voltage offset" title
	Then Take Screen Shot VAN21721_TestStep25_CacheVoltageOffsetDescriptionTip in 21721 under GamingScreenShotResult
