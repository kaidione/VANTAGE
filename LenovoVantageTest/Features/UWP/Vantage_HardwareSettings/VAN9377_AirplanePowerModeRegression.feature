@AirplaneModelIcon
Feature: VAN9377_VFC205_AirplanePowerMode_regression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-9377
	Author： DaQi Fang

@AirplaneModelIcon @AirplaneModelIconLE @SmokeAirplaneModelIcon
Scenario: VAN9377_TestStep01_Machine is supported the feature
	Given The machine support Airplane Power Mode feature
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then Receive response,the Airplane Power Mode can be shown in Power page

@AirplaneModelIcon @AirplaneModelIconLE
Scenario: VAN9377_TestStep02_The airplane model is on and the airplane icon below the Power status
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn on Airplane Mode
	Then Take Screen Shot 02ToolbarAirplaneModeIcon in 13280 under HSScreenShotResult

@AirplaneModelIcon @AirplaneModelIconLE
Scenario: VAN9377_TestStep03_The airplane model is off and the airplane icon disappear
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	Then Take Screen Shot 03ToolbarAirplaneModeIcon in 13280 under HSScreenShotResult

#@AirplaneModelACtoDC
#Scenario: VAN9377_TestStep04_Uncheck the checkbox AC 90w adapter <-> DC 90w adapter transition happens 3 times in 3 minutes Airplane Power Mode will not automatically turn on
#	Given Go to Devices Settings
#	Given Click Power Settings Link
#	When Turn off Airplane Mode
#	Given Uncheck the checkbox beside Enable auto-detection
#	When ACDC 20  Times "10.119.134.225" and button is "1018"
#	Then In Power page Enable Airplane Power Mode will not automatically turn on

@AirplaneModelIcon @AirplaneModelIconLE
Scenario: VAN9377_TestStep07_Uncheck the checkbox beside Enable auto-detection the airplane model is on and the  plane icon beside the battery gauge will appear
	Given Go to Devices Settings
	Given Click Power Settings Link
	Given Uncheck the checkbox beside Enable auto-detection
	When Turn on Airplane Mode
	Then Take Screen Shot 07ToolbarAirplaneModeIcon in 13280 under HSScreenShotResult

#@AirplaneModelACtoDC
#Scenario: VAN9377_TestStep08_Select the checkbox AC 90w adapter <-> DC 90w adapter transition happens 3 times in 3 minutes Airplane Power Mode will automatically turn on
#	Given Go to Devices Settings
#	Given Click Power Settings Link
#	When Turn off Airplane Mode
#	Given Select the checkbox beside Enable auto-detection
#	When ACDC 20 Times "10.119.134.225" and button is "1018"
#	Then A prompt message will appear 
#	Then Click the Yesbutton
#	Given Go to Devices Settings
#	Given Click Power Settings Link
#	Then In Power page Enable Airplane Power Mode will automatically turn on
#	Then Take Screen Shot 08ToolbarAirplaneModeIcon in 13280 under HSScreenShotResult
	
@AirplaneModelIcon @AirplaneModelIconLE
Scenario: VAN9377_TestStep16_Install and Launch Vantage turn on Airplane Power Mode then Uninstall Vantage Airplane power mode is off
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn on Airplane Mode
	Given Install Vantage
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then In Power page Enable Airplane Power Mode will not automatically turn on

#@AirplaneModelACtoDC
#Scenario: VAN9377_TestStep17_Install and Launch Vantage turn on Airplane Power Mode and auto-detection when uninstall loss of function
#	Given Go to Devices Settings
#	Given Click Power Settings Link
#	When Turn on Airplane Mode
#	Given Select the checkbox beside Enable auto-detection
#	Given Uninstall the lenovo vatage
#	Then Take Screen Shot 17ToolbarAirplaneModeIcon in 13280 under HSScreenShotResult
#	When ACDC 20 Times "10.119.134.225" and button is "1018"
#	Then No prompt message 
#
#@AirplaneModelACtoDC @AirplaneModelIconLE
#Scenario: VAN9377_TestStep18_Install and Launch Vantage turn on Airplane Power Mode and auto-detection when uninstall they all off
#	Given Install Vantage
#	Given Go to Devices Settings
#	Given Click Power Settings Link
#	Then In Power page Enable Airplane Power Mode will not automatically turn on
#	Then The checkbox should restore to un-checked

@AirplaneModelIcon @AirplaneModelIconLE
Scenario: VAN9377_TestStep19_sleep and hibernate is not change 
	Given Go to Devices Settings
	When Turn on Airplane Mode
	Given Select the checkbox beside Enable auto-detection
	When enter hibernate
	Given wait 1 seconds
	Then The Airplane Mode is on
	When enter sleep
	Given wait 1 seconds
	Then The Airplane Mode is on