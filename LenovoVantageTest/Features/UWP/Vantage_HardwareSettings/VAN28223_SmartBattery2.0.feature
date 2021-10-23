Feature: VAN28223_SmartBattery2
	Test Case： https://jira.tc.lenovo.com/browse/VAN-28223
	Author： DaQi Fang

@SmartBattery2.0NotSupport
Scenario: VAN28223_TestStep01
	Given Go to Power Page
	Given Click Battery Settings Link
	Then Not show SmartBattery

@SmartBattery2.0
Scenario: VAN28223_TestStep02
	Given Go to Power Page
	Given Click Battery Settings Link
	Given "Close" the Battery Settings Table
	Then Not show SmartBattery 
	Given "Open" the Battery Settings Table
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode

@SmartBattery2.0
Scenario: VAN28223_TestStep03
	Given Go to Power Page
	Given Click Battery Settings Link
	#Battery Settings
	Then Check Battery Health Title Display '$.PowerPage.BatteryHealthTitleText'
	Then Check Battery Health Description Text '$.PowerPage.BatteryHealthDescriptionText'

@SmartBattery2.0
Scenario: VAN28223_TestStep04
	Given Go to Power Page
	Then Check SmartBattery Two mode
	Then Take Screen Shot VAN28223_Step04 in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep05
	Given Go to Power Page
	Given Click Battery Settings Link
	Then Check Battery Capacity mode
	Then Take Screen Shot VAN28223_Step05 in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep06
	Given Go to Power Page
	Given Click Battery Settings Link
	Then Check Battery Temperature mode
	Then Take Screen Shot VAN28223_Step06 in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep07
	Given Close Vantage
	Given Set Battery Health "Reset"
	Given wait 5 seconds
	Given Set Battery Health "tip7s"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTipTip7Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step07_battery_color_should_be_red in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep08
	Given Close Vantage
	Given Set Battery Health "tip8"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTipTip8Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step08_battery_color_should_be_red  in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep09_Description13degC
	Given Close Vantage
	Given Set Battery Health "13degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription13Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step09_battery_temperature_should_be_yellow in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep10_Description25degC
	Given Close Vantage
	Given Set Battery Health "25degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescriptionText'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step10_battery_temperature_should_be_green in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep11_Description40degC
	Given Close Vantage
	Given Set Battery Health "40degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription40Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step11_battery_temperature_should_be_pink in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep12_Description51degC
	Given Close Vantage
	Given Set Battery Health "51degC"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Current Temperature Status '$.PowerPage.BatteryTemperatureDescription51Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step12_battery_temperature_should_be_red in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep13
	Given Close Vantage
	Given Set Battery Health "50%"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTip50%Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step13_battery_color_should_be_green in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep14
	Given Close Vantage
	Given Set Battery Health "30%"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTip30%Text'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step14_battery_color_should_be_yellow in 28223 under SettingsScreenShotResult

@SmartBattery2.0Manual
Scenario: VAN28223_TestStep15
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	When Click Question Mark On Battery Capacity
	Then Check Question Mark Tip Show Text '$.PowerPage.BatteryCapacityQuestionMarkTipFCCText'
	Then The batterycolor and batterytempture image is existed
	Then Take Screen Shot VAN28223_Step15_battery_color_should_be_grayout&yellow_mark in 28223 under SettingsScreenShotResult

@SmartBattery2.0Manual
Scenario: VAN28223_TestStep16
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check Temperature Tip Show Text '$.PowerPage.BatteryTemperatureDescriptionFCCText'
	Then Take Screen Shot VAN28223_Step16_battery_temperature_should_be_grayout&yellow_mark in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep17
	Given Close Vantage
	Given Set Battery Health "Reset"
	Given wait 5 seconds
	Given Set Battery Health "50%"
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode
	Given Go to dashboad page
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode
	Then Take Screen Shot VAN28223_Step17_check_overlap_truncate in 28223 under SettingsScreenShotResult

@SmartBattery2.0
Scenario: VAN28223_TestStep18
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode
	Given Close Vantage
	Given Launch Vantage
	Given Go to My Device Settings page
	Given Click Battery Settings Link
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode
	Then Take Screen Shot VAN28223_Step18_check_overlap_truncate in 28223 under SettingsScreenShotResult

@SmartBattery2.0GammingMachine
Scenario: VAN28223_TestStep19
	Given Machine is Gaming
	When Click power icon in the system tools
	Given Click Battery Settings Link
	Then Check SmartBattery Two mode
	Then Check Battery Capacity mode
	Then Check Battery Temperature mode
	Then Take Screen Shot VAN28223_Step19_check_gamming_mode in 28223 under SettingsScreenShotResult