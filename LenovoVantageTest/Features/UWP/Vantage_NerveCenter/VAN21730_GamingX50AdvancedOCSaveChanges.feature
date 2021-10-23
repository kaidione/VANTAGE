Feature: VAN21730_GamingX50AdvancedOCSaveChanges
	Test Case： https://jira.tc.lenovo.com/browse/VAN-21730
	Author： Yang Liu

Background:
	Given Machine is Gaming 
	When check if T750 or not
	Given driver is installed
	Given CPU name and contains the 'K/HK/KF' characters
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	When click set to default link in the Overclock Advanced Settings page

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep01_check Advance OC dialog
	Given click X button in Advance OC dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep02_check the all parameters in the Advance OC dialog
	Given all parameters are not changed
	Given click X button in Advance OC dialog
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then all parameters should be consistent with the before that the Advance OC dialog is closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep03_Save change dialog should be shown
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Then Save change dialog should be shown

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep04_check the Save change dialog
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click the other areas
	Then Save change dialog should be shown

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep05_check the Save change dialog
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click X button in the save change dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be shown

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep06_check the all parameters should not be changed in the Advance OC dialog
	Given all parameters have been changed
	Given all parameters are not changed
	Given click X button in Advance OC dialog
	Given click X button in the save change dialog
	Then all parameters should be consistent with the before that the Advance OC dialog is closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep07_Save change dialog and Advance OC dialog should be closed
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click Don't Save link button in the save change dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep08_all parameters should be consistent with the before changed
	Given all parameters are not changed
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click Don't Save link button in the save change dialog
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then all parameters should be consistent with the before that the Advance OC dialog is closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep09_check the Save change dialog
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click Save button in the save change dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep10_all parameters should be consistent with the before changed
	Given all parameters have been changed
	Given all parameters are not changed
	Given click X button in Advance OC dialog
	Given click Save button in the save change dialog
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Then all parameters should be consistent with the before that the Advance OC dialog is closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep11_check the Advanced OC dialog
	Given all parameters have been changed
	Given click X button in Advance OC dialog
	Given click Save button in the save change dialog
	Given click the Thermal mode area
	Given click the Advance OC button in the Thermal mode settings page
	Given click the proceed button in the Warning dialog
	Given click X button in Advance OC dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be closed

@GamingX50AdvancedOCSaveChanges
Scenario: VAN21730_TestStep12_check the Advanced OC dialog
	Given all parameters have been changed
	When click set to default link in the Overclock Advanced Settings page
	Given click X button in Advance OC dialog
	Then Save change dialog should not be shown
	Then the Advance OC dialog should be closed