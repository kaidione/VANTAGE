Feature: VAN29525_ToastMessageForSealedBatteryWarranty
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29525
	Author： DaQi Fang

@SealedBatteryToast
Scenario: VAN29525_TestStep01
	Given Close Vantage
	Given Clear Action Center All Value
	Given Set Time to "sealedbatterytime"
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "1" toast
	Then Check SealedBattery Toast "1"
	Then Take Screen Shot  VAN29525Step01 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	
@SealedBatteryToast
Scenario: VAN29525_TestStep03
	Given Close Vantage
	Given Clear Action Center All Value
	Given Set Time to "sealedbatterytime"
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "1" toast
	Then Check SealedBattery Toast "1"
	Then Take Screen Shot  VAN29525Step03 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "1" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep04
	Given Close Vantage
	Given Clear Action Center All Value
	Given Set Time to "sealedbatterytime"
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "1" toast
	Then Check SealedBattery Toast "1"
	Then Take Screen Shot  VAN29525Step04 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "1" will be hidden
	Then Take Screen Shot  VAN29525Step04_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep05
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "2" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Second" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "2" toast
	Then Check SealedBattery Toast "2"
	Then Take Screen Shot  VAN29525Step05 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button

@SealedBatteryToast
Scenario: VAN29525_TestStep06
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "2" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Second" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "2" toast
	Then Check SealedBattery Toast "2"
	Then Take Screen Shot  VAN29525Step06 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "2" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep07
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "2" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Second" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "2" toast
	Then Check SealedBattery Toast "2"
	Then Take Screen Shot  VAN29525Step07 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "2" will be hidden
	Then Take Screen Shot  VAN29525Step07_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep08
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "3" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Third" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "3" toast
	Then Check SealedBattery Toast "3"
	Then Take Screen Shot  VAN29525Step08 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button

@SealedBatteryToast
Scenario: VAN29525_TestStep09
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "3" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Third" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "3" toast
	Then Check SealedBattery Toast "3"
	Then Take Screen Shot  VAN29525Step09 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "3" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep10
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "3" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Third" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "3" toast
	Then Check SealedBattery Toast "3"
	Then Take Screen Shot  VAN29525Step10 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "3" will be hidden
	Then Take Screen Shot  VAN29525Step10_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep11
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "4" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fourth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "4" toast
	Then Check SealedBattery Toast "4"
	Then Take Screen Shot  VAN29525Step11 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button

@SealedBatteryToast
Scenario: VAN29525_TestStep12
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "4" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fourth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "4" toast
	Then Check SealedBattery Toast "4"
	Then Take Screen Shot  VAN29525Step12 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "4" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep13
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "4" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fourth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "4" toast
	Then Check SealedBattery Toast "4"
	Then Take Screen Shot  VAN29525Step13 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "4" will be hidden
	Then Take Screen Shot  VAN29525Step13_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep14
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "5" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fifth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "5" toast
	Then Check SealedBattery Toast "5"
	Then Take Screen Shot  VAN29525Step14 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button

@SealedBatteryToast
Scenario: VAN29525_TestStep15
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "5" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fifth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "5" toast
	Then Check SealedBattery Toast "5"
	Then Take Screen Shot  VAN29525Step15 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "5" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep16
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "5" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Fifth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "5" toast
	Then Check SealedBattery Toast "5"
	Then Take Screen Shot  VAN29525Step16 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "5" will be hidden
	Then Take Screen Shot  VAN29525Step16_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep17
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "6" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Sixth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "6" toast
	Then Check SealedBattery Toast "6"
	Then Take Screen Shot  VAN29525Step17 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button

@SealedBatteryToast
Scenario: VAN29525_TestStep18
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "6" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Sixth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "6" toast
	Then Check SealedBattery Toast "6"
	Then Take Screen Shot  VAN29525Step18 in 29525 under ScreenShotResult
	Given Click SealedBattery toast "6" Learn More
	Then There is PowerPage

@SealedBatteryToast
Scenario: VAN29525_TestStep19
	Given Set Time to "sealedbatterytime"
	Given Set SealedBattery Toast "6" Time and Id
	Given Clear Action Center All Value
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Del "%USERPROFILE%\\AppData\\Local\\Lenovo\\ImController\\PluginData\\GenericMessagingPlugin\\db" folder
	Given Restart IMC Service
	Given Set SealedBattery "Sixth" toast time
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "6" toast
	Then Check SealedBattery Toast "6"
	Then Take Screen Shot  VAN29525Step19 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button
	Then SealedBattery Toast "6" will be hidden
	Then Take Screen Shot  VAN29525Step19_01 in 29525 under ScreenShotResult

@SealedBatteryToast
Scenario: VAN29525_TestStep20
	Given Close Vantage
	Given SealedBattery Toast "SN" is null
	Given Del SealedBattery toast data from the registry
	Given Set Time to "sealedbatterytime"
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "SNNULL" message

@SealedBatteryToast
Scenario: VAN29525_TestStep21
	Given Close Vantage
	Given SealedBattery Toast "upgrade" is null
	Given Del SealedBattery toast data from the registry
	Given Set Time to "sealedbatterytime"
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "Upgrade" message

@SealedBatteryToast
Scenario: VAN29525_TestStep22
	Given Close Vantage
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Set SealedBattery Toast "SOH" Data "70"
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "SOH" message

@SealedBatteryToast
Scenario: VAN29525_TestStep23
	Given Close Vantage
	Given Set SealedBattery toast Mock Data
	Given Set SealedBattery Toast "7" Time and Id
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "All" message

@SealedBatteryToast
Scenario: VAN29525_TestStep24
	Given Close Vantage
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Set SealedBattery toast Date More than 18 month
	Given Set Time to "sealedbatterytime"
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "Moremonth" message

@SealedBatteryToast
Scenario: VAN29525_TestStep25
	Given Uninstall the lenovo vatage
	Given Set Time to "sealedbatterytime"
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given wait 10 seconds
	Then Check SealedBattery toast "Uninstall" message
	Then The SealedBattery toast will not show

@SealedBatteryToast
Scenario: VAN29525_TestStep26	
	Given Install the Lenovo Vantage
	Given Close Vantage
	Given Set Time to "sealedbatterytime"
	Given Del SealedBattery toast data from the registry
	Given Set SealedBattery toast Mock Data
	Given Del "C:\\ProgramData\\Lenovo\\Modern\\Logs" folder
	Given Restart SealedBattery toast TaskScheduler
	Given Wait "1" toast
	Then Check SealedBattery Toast "1"
	Then Take Screen Shot  VAN29525Step01 in 29525 under ScreenShotResult
	Then Click SealedBattery toast close button