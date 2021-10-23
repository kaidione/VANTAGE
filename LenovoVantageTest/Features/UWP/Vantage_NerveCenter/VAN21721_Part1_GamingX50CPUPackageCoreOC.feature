Feature: VAN21721_Part1_GamingX50CPUPackageCoreOC
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21721
	Author： Yang Liu

Background:
	Given Machine is Gaming 
	 
@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep01_check the CPU area in the Advance OC page
	When Install 'GPU/CPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then check the CPU area in the Advance OC page

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep02_check the CPU Core clock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then check the CPU Core clock area

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep03_check the 1 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 1 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep04_check the 2 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 2 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep05_check the 3 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 3 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep06_check the 4 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 4 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep07_check the 5 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 5 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep08_check the 6 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 6 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep09_check the 7 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 7 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep10_check the 8 core ratio / Active Core Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the 8 Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep11_check the Core Voltage Offset and Cache Voltage Offset default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the Core Voltage Offset and Cache Voltage Offset default value in the CPU Overclock area should be same and consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep12_check the AVX Ration Offset default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the "AVX Ration Offset" default value in the CPU Overclock area should be consistent with Spec definition

@GamingX50CPUPackageCoreOC
Scenario: VAN21721_TestStep13_check the Cache Ratio default value in the CPU Overclock area
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then the "Cache Ratio" default value in the CPU Overclock area should be consistent with Spec definition
