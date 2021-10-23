Feature: VAN10210_Part6_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep201-240

Background:
	Given Turn on or off the narrator 'on'

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep201_Check the Battery charge threshold button display off statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Battery charge threshold
	Then The Battery charge threshold button display off statue
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep202_Check The text display is Battery charge threshold off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Battery charge threshold
	Then Take screen shot TestStep202 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep203_Check the Battery charge threshold toggle display off statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Battery charge threshold
	When check the Battery charge threshold display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Battery charge threshold button displays same as with Vantage

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep204_Check the Battery charge threshold button display off statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Battery charge threshold from power page on Lenovo Vantage
	When Launch toolbar
	Then The Battery charge threshold button display off statue
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep207_Check the Battery charge threshold button display on statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Battery charge threshold from power page on Lenovo Vantage
	When Launch toolbar
	Then The Battery charge threshold button display on statue
	When Close toolbar

@BatteryChargeToolbarThinkpad
Scenario: VAN10210_TestStep208_Check the Battery charge threshold button display off statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Battery charge threshold from power page on Lenovo Vantage
	When Launch toolbar
	Then The Battery charge threshold button display off statue
	When Close toolbar

#@ToolbarBadBattery @Debug
#Scenario: VAN10210_TestStep209_Check the machine no battery Toolbar display
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	Then Take Screen Shot TestStep209 in 10210 under ToolbarScreenShotResult

#@ToolbarNoBatteryThink @Debug
#Scenario: VAN10210_TestStep210_Check the machine no battery Toolbar display
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	Then Take Screen Shot TestStep210 in 10210 under ToolbarScreenShotResult

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep211_Check the Airplane power mode button displays same as with Vantage
	Given Pin toolbar to taskbar
	#Given turn on narrator
	When Launch toolbar
	When check the Airplane power mode display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Power settings
	Then The Airplane power mode button displays same as with Vantage

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep212_Check The hover tips display is "Airplane power mode"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Hover the mouse on the Airplane power mode button
	Then Take Screen Shot TestStep212 in 10210 under ToolbarScreenShotResult
	When Close toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep213_Check the Airplane power mode button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Airplane power mode
	Then The Airplane power mode button display on statue
	When Close toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep214_Check The text display is "Airplane power mode on"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Airplane power mode
	Then Take screen shot TestStep214 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep215_Check Airplane power mode is on
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Airplane power mode
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then The Airplane Mode Status is 'on' within Vantage

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep216_Check Airplane power mode is off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Airplane power mode
	Then the Airplane power mode status is 'off' within Toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep217_Check Airplane power mode is off tips
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Airplane power mode
	Then Take screen shot TestStep217 in 10210 under ToolbarScreenShotResult after 0 seconds

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep218_Check Airplane power mode is off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Airplane power mode
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then The Airplane Mode Status is 'off' within Vantage

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep219_Check Airplane power mode is on
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	When Turn on Airplane Mode
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then the Airplane power mode status is 'on' within Toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep220_Check Airplane power mode is on
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	Given Select the checkbox beside Enable auto-detection
	Given Turn 'on' Action Center for 'AirplaneMode'
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then the Airplane power mode status is 'on' within Toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep221_Check Airplane power mode is off
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	Given Select the checkbox beside Enable auto-detection
	Given Turn 'on' Action Center for 'AirplaneMode'
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Pin toolbar to taskbar
	When Launch toolbar
	Then the Airplane power mode status is 'off' within Toolbar

@AirplaneToolbaTthinkpad
Scenario: VAN10210_TestStep222_Check Airplane power mode
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Airplane power mode
	Given Uninstall the lenovo vatage
	Given wait 180 seconds
	Given Install Vantage
	When Launch toolbar
	Then The Airplane power mode status same as vantage
	When Launch toolbar
	When Turn off the Airplane power mode
	Given Uninstall the lenovo vatage
	Given wait 180 seconds
	Given Install Vantage
	When Launch toolbar
	Then The Airplane power mode status same as vantage

@ConservationModeToolbar
Scenario: VAN10210_TestStep223_Check the Conservation mode toggle display on statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When check the Conservation mode display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@ConservationModeToolbar
Scenario: VAN10210_TestStep224_Check The text display is "Conservation mode on"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	When Hover the mouse on the Conservation mode button
	Then Take screen shot TestStep224on in 10210 under ToolbarScreenShotResult after 0 seconds
	When Turn off the Conservation mode
	When Hover the mouse on the Conservation mode button
	Then Take screen shot TestStep224off in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep225_Check the Conservation mode button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep226_Check The text display is Conservation mode off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	Then Take screen shot TestStep226 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep227_Check the Conservation mode button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@ConservationModeToolbar
Scenario: VAN10210_TestStep228_Check the Conservation mode button display off statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Rapid charge from power page on Lenovo Vantgae
	When Launch toolbar
	Then The Conservation mode button display off statue
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep229_Check The text display is Conservation mode off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	When Turn on the Rapid charge
	Then The Conservation mode button display off statue
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep230_Check The text display is Conservation mode off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Conservation mode
	Then The Conservation mode button display off statue
	When Close toolbar
@ConservationModeToolbar
Scenario: VAN10210_TestStep231_Check The text display is Conservation mode off
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Conservation mode
	Then Take screen shot TestStep229 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep232_Check the Conservation mode toggle display off statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Conservation mode
	When check the Conservation mode display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@ConservationModeToolbar
Scenario: VAN10210_TestStep233_Check the Conservation button display on statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn on Conservation mode from power page
	When Launch toolbar
	Then The Conservation mode button display on statue
	When Close toolbar

@ConservationModeToolbar
Scenario: VAN10210_TestStep234_Check the Conservation button display off statue from toolbar
	Given Pin toolbar to taskbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn off Conservation mode from power page
	When Launch toolbar
	Then The Conservation mode button display off statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep235_Check the Rapid charge button displays same as with Vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When check the Rapid charge display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@RapidChargeToolbar
Scenario: VAN10210_TestStep236_Check The hover tips display is "Rapid charge"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Hover the mouse on the Rapid charge button
	Then Take Screen Shot TestStep234 in 10210 under ToolbarScreenShotResult
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep237_Check the Rapid charge button display on statue from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	Then The Rapid charge button display on statue
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep238_Check The text display is "Rapid charge on"
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	Then Take screen shot TestStep236 in 10210 under ToolbarScreenShotResult after 0 seconds
	When Close toolbar

@RapidChargeToolbar
Scenario: VAN10210_TestStep239_Check the Rapid charge toggle display on statue from vantage
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	When check the Rapid charge display
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@RapidChargeToolbar
Scenario: VAN10210_TestStep240_Check the Rapid charge button display off status from toolbar
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	When Close toolbar
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn on Conservation mode from power page
	When Launch toolbar
	Then The Rapid charge button display off statue
	When Close toolbar