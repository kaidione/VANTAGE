Feature: VAN26007_GamingGPUOCVRAM
	Test Case： https://jira.tc.lenovo.com/browse/VAN-26007
	Author： Jinxin Li

@GamingGPUOCVRAM @GamingSmokeVRAMOC
Scenario: VAN26007_TestStep01_Clock Offset and VRAM Clock Offset items should be shown
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Then CPU Clock Offset and VRAM Clock Offset Items Should be Shown in the Advanced OC Page

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep02_The VRAM Clock Offset Default Value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then VRAM Clock Offset '200 MHz' should be consistent with Spec definition

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep03_Check VRAM Clock Offset area items should be shown
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Then Take Screen Shot 03 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep04_Clock Vram Tips shown
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Hover the mouse on the 'vram_clock_offset_item' In the Vantage
	Then VRAM Clock Offset description tip should be shown the VRAM Clock Offset area

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep05_Clock Drag To the Far Left
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Far Left'
	Then Take Screen Shot 05 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep06_Clock Drag To the Far Left Check Value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Far Left'
	Then The 'vram_clock_offsetlevel0' Slider value should be the '0' value

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep07_Clock Drag To the Far Left Check UI
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Far Left'
	Then '+' icon should be gery and unclickable for 'vram_clock_offset_plus_icon_clickable'
	Then '-' icon should not be grey and clickable for 'vram_clock_offset_minus_icon_unclickable'

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep08_Clock Drag To the Far Right
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Random Right'
	Then Take Screen Shot 08 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep09_Clock Drag To the Far Left Check Value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Random Right'
	Then Should be greater than before Dragging

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep10_Clock Drag To the Far Right Check UI
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Random Right'
	Then Vram Slider Minus and Plus icon should not be grey and clickable

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep11_Clock Drag To the Far Right Check UI
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The Far 'Far Right'
	Then Take Screen Shot 11 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep12_Clock Drag To the Far Right Check Value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The Far 'Far Right'
	Then The 'vram_clock_offset_slider' Slider value should be the '300' value

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep13_Clock Drag To the Far Right Check UI
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The Far 'Far Right'
	Then '+' icon should be gery and unclickable for 'vram_clock_offset_plus_icon_unclickable'
	Then '-' icon should not be grey and clickable for 'vram_clock_offset_minus_icon_clickable'

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep14_Clock Drag To the Far Right Check UI
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The Far 'Random Left'
	Then Take Screen Shot 14 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep15_Clock Drag To the Far Right Click the minus icon
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The 'Random Left'
	Then Should be smaller than before Dragging

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep16_Clock Drag To the Far left
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given Drag 'vram_clock_offset_slider' on the Slider Bar to The Far 'Random Left'
	Then '+' icon should not be grey and clickable for 'vram_clock_offset_plus_icon_clickable'
	Then '-' icon should not be grey and clickable for 'vram_clock_offset_minus_icon_clickable'

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep17_Click Minus to check value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Click Minus icon to check value
	Then Should be smaller than before Dragging

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep18_Click Minus to check value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Click Minus icon to check value
	Then Take Screen Shot 18 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep19_Click Plus to check value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Click Plus icon to check value
	Then Should be greater than before Dragging

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep20_Click Plus to check value
	Given click the Thermal mode area
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	When Get the Slider Bar value
	Given Click Plus icon to check value
	Then Take Screen Shot 20 in 26007 under GamingScreenShotResult

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep21_Click Plus to check value
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The Enable Overclocking Checkbox is Checked
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then The 'memory offset' values in the tool should be '200'

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep22_Click Plus to check value
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The Enable Overclocking Checkbox is UnChecked
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Then The 'memory offset' values in the tool should be '0'

@GamingGPUOCVRAM
Scenario: VAN26007_TestStep23_Click Plus to check value
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The Enable Overclocking Checkbox is Checked
	Given Advanced link button shown
	Given click the Advance OC button in the Thermal mode settings page
	Given Warning dialog is displaying
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page
	Given Click 'vram_clock_offset_minus_icon_clickable' on the Slider Bar to The '50' To Set Slider Value '150'
	Given Click the X button
	Given Click the Save button
	Then The 'memory offset' values in the tool should be '150'
