Feature: SettingsSmokeTest
	Author： Haiye Li

@SmokeNoInputAccessories
Scenario: SmokeTest_TestStep01_Check device detail input and accessories not show on the menu
	Given Go to Power Page
	Then  input and accessories not show on the menu

@SmokeNoBatteryCharge
Scenario: SmokeTest_TestStep02_Check There should no Battery Charge Threshold Section
	Given Click Device settings,enter Power page
	Then  There should no Battery Charge Threshold Section

@SmokeNoSmartStandby
Scenario: SmokeTest_TestStep03_Check Section Smart Standby Section elements will be hide
	And Click Device settings,enter Power page
	Then Section Smart Standby Section elements will be hide


