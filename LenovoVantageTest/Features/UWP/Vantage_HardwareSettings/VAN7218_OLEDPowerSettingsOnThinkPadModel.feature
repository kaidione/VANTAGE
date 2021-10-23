Feature: VAN7218_VFC207_OLEDPowerSettingsOnThinkPadModel
	Test Case： https://jira.tc.lenovo.com/browse/VAN-7218
	Author: Jinxin Li

@CheckOLEDPowerSettings @SmokeCheckOLEDPowerSettings
Scenario: VAN7218_TestStep01_Check title display 'OLED Power Settings'
	Given Go to display page
	Given Click DisplayLink
	Then Check OLED Title Display '$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsTitleText'

@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep02_Check description display text
	Given Go to display page
	Given Click DisplayLink
	Then Check description1 Text Display '$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsdescription1Text'
	Then Check description2 Text Display '$.MyDeviceSettings.DisplayAndCamera.OLEDPowerSettingsdescription2Text'

@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep03_Check 'TASKBAR DIMMER' and 'Menu List' Exists
	Given Go to display page
	Given Click DisplayLink
	Then Check Display 'TASKBAR DIMMER' Title
	Then Check 'TASKBAR DIMMER Menu List' Exists

@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep04_Check 'BACKGROUND DIMMER' and 'Menu List' Exists
	Given Go to display page
	Given Click DisplayLink
	Then Check Display 'BACKGROUND DIMMER' Title
	Then Check 'BACKGROUND DIMMER Menu List' Exists

@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep05_Check 'DISPLAY DIMMER' and 'Menu List' Exists
	Given Go to display page
	Given Click DisplayLink
	Then Check Display 'DISPLAY DIMMER' Title
	Then Check 'DISPLAY DIMMER Menu List' Exists

@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep06_Check 'TASKBAR DIMMER''BACKGROUND DIMMER''DISPLAY DIMMER' Menu List Value
	Given Go to display page
	Given Click DisplayLink
	Then Check 'TASKBAR DIMMER Menu List' Value
	Then Check 'BACKGROUND DIMMER Menu List' Value
	Then Check 'DISPLAY DIMMER Menu List' Value
	
@CheckOLEDPowerSettings
Scenario: VAN7218_TestStep07_Check no need to show the tooltips for this feature
	Given Go to display page
	Given Click DisplayLink
	Then Take Screen Shot VAN7218_Step07 in 7218 under SettingsScreenShotResult



