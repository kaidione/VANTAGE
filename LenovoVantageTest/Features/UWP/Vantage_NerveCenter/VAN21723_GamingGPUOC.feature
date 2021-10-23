Feature: VAN21723_GamingGPUOC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-21723
	Author： caopp2

Background:
	Given Machine is Gaming 
	When Install 'GPU' Driver
	Given Close Vantage
	Given Launch Vantage

@GamingCPUGPUOC @GamingSmokeNewCPUGPUOC
Scenario: VAN21723_TestStep01_Check the Advance OC Page
	Given The Machine support Specific function 'CPUGPUOverclockNew'
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	Then  CPU And GPU area should be shown in the Advanced OC page

@GamingGPUOC @GamingSmokeNewGPUOC
Scenario: VAN21723_TestStep02_Check the Advance OC Page
	Given The Machine support Specific function 'GPUOverclockNew' 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	Then  Only GPU area should be shown in the Advanced OC page

@GamingGPUOC
Scenario: VAN21723_TestStep03_Check GPU Area in the Advance OC Page
	Given The Machine support Specific function 'GPUOverclockNew' 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	Then  Only GPU Clock Offset showing in Advanced OC Page

@GamingGPUOC
Scenario: VAN21723_TestStep04_Check GPU Value in the Advance OC Page
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	When  click set to default link in the Overclock Advanced Settings page
	Then  GPU Clock Offset default value should be consistent with Spec definition

@GamingGPUOC
Scenario: VAN21723_TestStep05_check the GPU Core clock area in the Advance OC Page
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	Then  Check GPU Core Clock Area
	Then  Take Screen Shot VAN21723_TestStep05_GPUCoreArea in 21723 under GamingScreenShotResult

@GamingGPUOC
Scenario: VAN21723_TestStep06_check the GPU Core clock offset DescriptionTip in the Advance OC Page
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	When  Hover the GPU Clock Offset title
	Then  Take Screen Shot VAN21723_TestStep06_GPUClockOffsetDescription in 21723 under GamingScreenShotResult

@GamingGPUOC
Scenario: VAN21723_TestStep07_check the blocker on the  GPU Clock Offset slider bar far Left
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to far-left
	Then  Take Screen Shot VAN21723_TestStep07_GPUClockOffsetSliderBarFarLeft in 21723 under GamingScreenShotResult

@GamingGPUOC
Scenario: VAN21723_TestStep08_check the GPU Clock Offset value bar far left
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to far-left
	Then  The GPU Clock Offset value should be the minimize value that consistent with definition

@GamingGPUOC
Scenario: VAN21723_TestStep09_check the minus and plus icons in the value bar of  GPU Clock Offset  far left
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to far-left
	Then  The GPU Clock Offset minus icon should be gery and unclickable plus icon should not be grey and clickable

@GamingGPUOC
Scenario: VAN21723_TestStep10_check the blocker on the slider bar when drag to the right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to right
	Then  Take Screen Shot VAN21723_TestStep10_GPUClockOffsetBlockerLeft in 21723 under GamingScreenShotResult

@GamingGPUOC
Scenario: VAN21723_TestStep11_check the value bar when drag to the right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	When  click set to default link in the Overclock Advanced Settings page
	Then  GPU Clock Offset default value should be consistent with Spec definition
	When  Drag the blocker on the GPU Clock Offset slider bar to right
	Then  Take Screen Shot VAN21723_TestStep11_GPUClockOffsetValueBarLeft in 21723 under GamingScreenShotResult
	Then  The value bar should be the current value and the value should be greater than before dragging to right

@GamingGPUOC
Scenario: VAN21723_TestStep12_check the minus and plus icons in the value bar of GPU Clock Offset when drag to the right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	Then  GPU Clock Offset default value should be consistent with Spec definition
    Given Drag 'gpu_clock_offset_slider' on the Slider Bar to The 'Random Left'
	Given click X button in Advance OC dialog
	Given click Save button in the save change dialog
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
    Given Drag 'gpu_clock_offset_slider' on the Slider Bar to The 'Random Right'
	Then  Take Screen Shot VAN21723_TestStep12_GPUClockOffsetIconsLeft in 21723 under GamingScreenShotResult
	Then  Minus and plus icon should not be grey and clickable

@GamingGPUOC
Scenario: VAN21723_TestStep13_check the blocker on the  GPU Clock Offset slider bar far Right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to far-right
	Then  Take Screen Shot VAN21723_TestStep13_GPUClockOffsetSliderBarFarRight in 21723 under GamingScreenShotResult

@GamingGPUOC
Scenario: VAN21723_TestStep14_check the GPU Clock Offset value bar far right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to right
	Then  The GPU Clock Offset value should be the maximize value that consistent with definition

@GamingGPUOC
Scenario: VAN21723_TestStep15_check the minus and plus icons in the value bar of  GPU Clock Offset  far right
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog 
	When  click set to default link in the Overclock Advanced Settings page
	When  Drag the blocker on the GPU Clock Offset slider bar to far-right
	Then  The GPU Clock Offset plus icon should be gery and unclickable minus icon should not be grey and clickable

@GamingGPUOC
Scenario: VAN21723_TestStep16_check the value bar after clicking minus icons of  GPU Clock Offset 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Click minus icon of GPU Clock Offset

@GamingGPUOC
Scenario: VAN21723_TestStep17_check the blocker and value on the slider bar after clicking minus icons of  GPU Clock Offset 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Click minus icon of GPU Clock Offset
	Then  Take Screen Shot VAN21723_TestStep17_GPUClockOffsetBlockerAndValueAfterClickingMinusIcon in 21723 under GamingScreenShotResult
	Then  Value bar should minus one 

@GamingGPUOC
Scenario: VAN21723_TestStep18_check the value bar after clicking plus icons of  GPU Clock Offset 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Click plus icon of GPU Clock Offset

@GamingGPUOC
Scenario: VAN21723_TestStep19_check the blocker and value on the slider bar after clicking plus icons of  GPU Clock Offset 
	Given The Thermal Mode Setting popup is displaying
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When  click set to default link in the Overclock Advanced Settings page
	When  Click plus icon of GPU Clock Offset
	Then  Take Screen Shot VAN21723_TestStep19_GPUClockOffsetBlockerAndValueAfterClickingPlusIcon in 21723 under GamingScreenShotResult
	Then  Value bar should plus one 