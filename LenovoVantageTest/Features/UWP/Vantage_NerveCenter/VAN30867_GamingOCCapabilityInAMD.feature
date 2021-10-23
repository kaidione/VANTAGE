Feature: VAN30867_OCCapabilityinAMD
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30867
	Author: Xuwei
	Test Steps: 1-6

Background: 
	Given Machine is Gaming
	Then The Graphics Card vendor value is 2 And the Method is GetGPUVendor
	Then The OC value is 2 And the Method is IsSupportCpuOC

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep01_Check OC description in Thermal Mode Settings popup
	When Install 'AMDGPU/CPU' Driver
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The 'Enable CPU Overclocking in Performance Mode.' Description 'Displaying'
	Then The ADVANCED link button is at the right of Enable OverClocking description

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep02_Check OC description in Thermal Mode Settings popup
	When Install 'AMDGPU/CPU' Driver
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then check the CPU Core clock area
	Then GPU Clock Offset should not be shown in Advanced OC Page

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep03_Check OC description in Thermal Mode Settings popup
	Given 'AMDGPU' Driver don't exist
	When Install 'CPU' Driver
	Given The Thermal Mode Setting popup is displaying
	Then The 'Enable CPU Overclocking in Performance Mode.' Description 'Displaying'
	Then The ADVANCED link button is at the right of Enable OverClocking description

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep04_Check OC description in Thermal Mode Settings popup
	Given 'AMDGPU' Driver don't exist
	When Install 'CPU' Driver
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then check the CPU Core clock area
	Then GPU Clock Offset should not be shown in Advanced OC Page

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep05_Check OC description in Thermal Mode Settings popup
	When Install 'AMDGPU' Driver
	Given 'CPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The ADVANCED link button should shown or hidden in Performance Mode 'hidden'
	When OverClocking checkbox not display
	Then The 'Install CPU driver to use the Overclocking function.' Description 'Displaying'
	Then The GO INSTALL Link Shloud be 'Shown'

@X50OCCapabilityInAMD
Scenario: VAN30867_TestStep06_Check OC description in Thermal Mode Settings popup
	Given 'AMDGPU' Driver don't exist
	Given 'CPU' Driver don't exist
	Given Close Vantage
	Given Launch Vantage
	Given The Thermal Mode Setting popup is displaying
	Then The ADVANCED link button should shown or hidden in Performance Mode 'hidden'
	When OverClocking checkbox not display
	Then The 'Install CPU driver to use the Overclocking function.' Description 'Displaying'
	Then The GO INSTALL Link Shloud be 'Shown'
