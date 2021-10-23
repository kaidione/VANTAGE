Feature: VAN29462_BatterySettingsTopPosition
	Test Case： https://jira.tc.lenovo.com/browse/VAN-29462
	Author：Haiye Li

@BatterySettingsTopPositionIdea
Scenario: VAN29462_TestStep01_Check The UI appearance of the Battery settings
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Battery settings' feature
	Then Take Screen Shot TestStep01_BatterySettingsDisplayOnTheTop in 29462 under HSScreenShotResult

@BatterySettingsTopPositionIdea
Scenario: VAN29462_TestStep02_Check the UI appearance of the Lenovo Vantage toolbar on top of Energy Star
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Battery settings' feature
	Given Go To Lenovo Vantage ToolBar Panel
	When  Scroll the screen 80 in homepage
	Then Take Screen Shot TestStep02_BatterySettingsDisplayOnTheEneryStartTop in 29462 under HSScreenShotResult

@BatterySettingsTopPositionIdea
Scenario: VAN29462_TestStep03_Check The order should be: Battery settings-> Power Smart settings -> Power settings -> Lenovo Vantage toolbar -> Energy Star 
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Battery settings' feature

@BatterySettingsTopPositionIdea
Scenario: VAN29462_TestStep04_Check the jump to link order should be: Battery settings-> Power Smart settings -> Power settings -> Lenovo Vantage toolbar
	Given Go to My Device Settings page
	Then The Order Of Jump To link with 'Battery Settings' feature

@BatterySettingsTopPositionNoPowerSmartSetingsIdea
Scenario: VAN29462_TestStep05_Check The order should be: Battery settings-> Power settings -> Lenovo Vantage toolbar -> Energy Star when no Power Smart settings
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Non Power Smart settings' feature

@BatterySettingsTopPositionIdea
Scenario: VAN29462_TestStep06_ Click the supported sections link in "Jump to settings
	Given Go to My Device Settings page
	Given Jump to Battery settings
	Then Take Screen Shot TestStep06_JumpToBatterySettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to power smart settings section
	Then Take Screen Shot TestStep06_JumpToPowerSmarSettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to Power settings
	Then Take Screen Shot TestStep06_JumpToPowerSettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to Other settings
	Then Take Screen Shot TestStep06_JumpToLenovoVantageToolbarSection in 29462 under HSScreenShotResult

@BatterySettingsTopPositionThink
Scenario: VAN29462_TestStep07_Check The Battery settings is located at the top of Power page
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Standby settings' feature
	Then Take Screen Shot TestStep07_BatterySettingsDisplayOnTheTop in 29462 under HSScreenShotResult

@BatterySettingsTopPositionThink
Scenario: VAN29462_TestStep08_Check The UI appearance of the Battery settings
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Standby settings' feature
	Given Go To Lenovo Vantage ToolBar Panel
	When  Scroll the screen 5 in homepage
	Then Take Screen Shot TestStep08_BatterySettingsDisplayOnTheEneryStartTop in 29462 under HSScreenShotResult

@BatterySettingsTopPositionThink
Scenario: VAN29462_TestStep09_Check The order should be: Battery settings-> Power Smart settings -> Standby settings -> Power settings -> Lenovo Vantage toolbar -> Energy Star
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Standby settings' feature

@BatterySettingsTopPositionNoBatteryThink
Scenario: VAN29462_TestStep10_Check the order should be: Power Smart settings -> Standby settings -> Power settings -> Lenovo Vantage toolbar -> Energy Star with no battery settings
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Non Battery settings' feature

@BatterySettingsTopPositionThink
Scenario: VAN29462_TestStep11_Check The order should be: Battery settings-> Power Smart settings -> Standby settings -> Power settings -> Lenovo Vantage toolbar with standby feature
	Given Go to My Device Settings page
	Then The Order Of Jump To link with 'Standby settings' feature

@BatterySettingsTopPositionThink
Scenario: VAN29462_TestStep12_Check The UI appearance of the Battery settings by clicking the jumplink
	Given Go to My Device Settings page
	Given Jump to Battery settings
	Then Take Screen Shot TestStep12_JumpToBatterySettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to power smart settings section
	Then Take Screen Shot TestStep12_JumpToPowerSmarSettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	When Go to Smart Standby section
	Then Take Screen Shot TestStep12_JumpToSmarStandbySection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to Power settings
	Then Take Screen Shot TestStep12_JumpToPowerSettingsSection in 29462 under HSScreenShotResult
	Given Go to My Device Settings page
	Given Jump to Other settings
	Then Take Screen Shot TestStep12_JumpToLenovoVantageToolbarSection in 29462 under HSScreenShotResult

@BatterySettingsTopPositionNoSmartStandbyThink
Scenario: VAN29462_TestStep13_Check The order should be: Battery settings -> Power Smart settings -> Power settings -> Lenovo Vantage toolbar -> Energy Star without smart standby
	Given Go to My Device Settings page
	Then Check the Order Of Power Page with 'Battery settings' feature


