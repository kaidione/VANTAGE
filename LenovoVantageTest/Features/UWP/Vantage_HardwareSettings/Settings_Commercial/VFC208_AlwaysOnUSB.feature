Feature: VFC208_AlwaysOnUSB
	Test Case： https://jira.tc.lenovo.com/browse/VFC-208
	Author： HaiYe Li

@CheckNOAlwaysOnUSB
Scenario: VFV208_TestStep01_Check 500W Gen 3 Machine No Display Elements
	Given Go to My Device Settings page
	Then Check Power Settings No Always On USB Feature

@CheckAlwaysOnUSB
Scenario: VFV208_TestStep02_Check Power Settings Display Always On USB Elements
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Display Always On USB Elements
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBDescriptionText'

@CheckAlwaysOnUSB
Scenario: VFV208_TestStep03_Check checkbox shows under the description(Enable USB charging from laptop battery when computer is off)
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then Check Power Settings Always On USB Section Display '$.PowerPage.AlwaysUSBCheckboxText'

@CheckAlwaysOnUSB
Scenario: VFV208_TestStep04_Check the checkbox is greyed out
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn On Always On USB toggle
	Then  The Checkbox is greyout
	
@CheckAlwaysOnUSB
Scenario: VFV208_TestStep05_Check the checkbox can be checked
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Given Turn Off Always On USB toggle
	Then The Checkbox is nogreyout
	
@CheckAlwaysOnUSB
Scenario: VFV208_TestStep11_Check the UI should show completely in 2 seconds
	Given Go to My Device Settings page
	Given Click Power Settings Link
	Then The AlwaysOnUSBUI should show completely in 2 seconds