Feature: VAN24737_BatteryHealthQuickRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-24737
	Author：Pengjie Chen
	Updater:DaQi Fang

@CheckBatteryHealth
Scenario: VAN24737_TestStep01_Check The Battery Health Feature Title Is "Battery Health"
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Health Title Display '$.PowerPage.BatteryHealthTitleText'

@CheckBatteryHealth
Scenario: VAN24737_TestStep02_Check The Battery Health Feature Description Text
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Health Description Text '$.PowerPage.BatteryHealthDescriptionText'

@CheckBatteryHealthNoBattery
Scenario: VAN24737_TestStep03_No Battery Installed No Battery Health Feature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Battery Health Feature Should Hidden

@CheckBatteryHealth @SmokeCheckBatteryHealth
Scenario: VAN24737_TestStep04_Go to Other Pages and Back to Power Page UI Should Display Correctly
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given Click Dashboard Link
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Health Should Display Correctly

@CheckBatteryHealth
Scenario: VAN24737_TestStep05_Close Vantage and Reopen Vantage Power Page UI Should Display Correctly
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Health Should Display Correctly

@CheckBatteryHealth
Scenario: VAN24737_TestStep06_Resize Vantage Window UI Should Display Correctly
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Vantage Maxmize Button
	Then Check Battery Health Should Display Correctly
	Then Take Screen Shot VAN24737_Step06 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep07_Performance Test Check Battery Health Feature Show Time
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to My Device Settings page
	When wait 3 seconds
	Given Click Battery Settings Link
	Then Check Battery Health Should Display Correctly
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to My Device Settings page
	When wait 2 seconds
	Given Click Battery Settings Link
	Then Check Battery Health Should Display Correctly

@CheckBatteryHealth
Scenario: VAN24737_TestStep08_Check The UI of Battery Health Level
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check The Title Battery Health Status Is '$.PowerPage.BatteryHealthStatusText'
	Then Display Five Stars
	Then Take Screen Shot VAN24737_Step08 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep09_The Battery Is In The 7th Level All The Five Stars are Green
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check The Title Battery Health Status Is '$.PowerPage.BatteryHealthStatusText'
	Then All The Five Stars are Green
	Then Take Screen Shot VAN24737_Step09 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep17_Check The UI of Battery Capacity
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check The Title Battery Capacity Is '$.PowerPage.BatteryCapacityTitleText'
	Then Check Question Mark On Battery Capacity Right
	Then Show Circle Under The Battery Capacity
	Then Take Screen Shot VAN24737_Step17 in 24737 under SettingsScreenShotResult
	Then Show '$.PowerPage.BatteryCapacityTipLine1Text' Under The Circle
	Then Show '$.PowerPage.BatteryCapacityTipLine2Text' Under The Circle

@CheckBatteryHealth
Scenario: VAN24737_TestStep18_Click Question Mark and Check Question Mark Tip Show Text
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTipText'

@CheckBatteryHealth
Scenario: VAN24737_TestStep23_Full Charge Capacity Is More Than Designed Capacity
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Show Circle Under The Battery Capacity
	Then Take Screen Shot VAN24737_Step23 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep24_Check The Capacity Tip
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Show '$.PowerPage.BatteryCapacityTipLine1Text' Under The Circle
	Then Show '$.PowerPage.BatteryCapacityTipLine2Text' Under The Circle

@CheckBatteryHealth
Scenario: VAN24737_TestStep25_Check The UI Of Battery Temperature
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Battery Temperature Title Is '$.PowerPage.BatteryTemperatureTitleText'
	Then Display Temperature Icon and Current Temperature
	Then Take Screen Shot VAN24737_Step25 in 24737 under SettingsScreenShotResult
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescriptionText'
	
@CheckBatteryHealth
Scenario: VAN24737_TestStep26_Description13degC
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given Set Battery Health "Reset"
	Given wait 5 seconds
	Given Set Battery Health "13degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription13Text'
	Then Take Screen Shot VAN24737_Step26 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep27_Description25degC
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given Set Battery Health "25degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescriptionText'
	Then Take Screen Shot VAN24737_Step27 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep28_Description40degC
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given Set Battery Health "40degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription40Text'
	Then Take Screen Shot VAN24737_Step28 in 24737 under SettingsScreenShotResult

@CheckBatteryHealth
Scenario: VAN24737_TestStep29_Description51degC
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given Set Battery Health "51degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription51Text'
	Then Take Screen Shot VAN24737_Step29 in 24737 under SettingsScreenShotResult