Feature: VAN27994_Part5_HS_VantageToolbarquickregressiontestfornewOS
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Yangyu
	Conmments: TestStep201-250

Background:
	Given Turn on or off the narrator 'on'

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep201_Check Airplane power mode is on
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Airplane power mode
	Given Close toolbar
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then The Airplane Mode Status is 'on' within Vantage

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep202_Check Airplane power mode is off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Airplane power mode
	Then the Airplane power mode status is 'off' within Toolbar

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep203_Check Airplane power mode is off tips
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Airplane power mode
	Then Take screen shot 203Ariplanepowermode_text_isoff in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep204_Check Airplane power mode is off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Airplane power mode
	Given Close Toolbar Background
	Given Go to Devices Settings
	Given Click Power Settings Link
	Then The Airplane Mode Status is 'off' within Vantage

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep205_Check Airplane power mode is on
	Given Close Toolbar Background
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	When Turn on Airplane Mode
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then the Airplane power mode status is 'on' within Toolbar

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep206_Check Airplane power mode is on
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Close Toolbar Background
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	Given Select the checkbox beside Enable auto-detection
	Given Turn 'on' Action Center for 'AirplaneMode'
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then the Airplane power mode status is 'on' within Toolbar

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep207_Check Airplane power mode is off
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Close Toolbar Background
	Given Go to Devices Settings
	Given Click Power Settings Link
	When Turn off Airplane Mode
	Given Select the checkbox beside Enable auto-detection
	Given Turn 'on' Action Center for 'AirplaneMode'
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then the Airplane power mode status is 'off' within Toolbar

@NOSAirplaneToolbaTthinkpad
Scenario: VAN27994_TestStep208_Check Airplane power mode
	Given Turn 'off' Action Center for 'AirplaneMode'
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Airplane power mode
	Given Uninstall the lenovo vatage
	Given Close Toolbar Background
	Given wait 180 seconds
	Given Install Vantage
	Given Launch Toolbar On NewOS
	Then The Airplane power mode status same as vantage
	Given Launch Toolbar On NewOS
	When Turn off the Airplane power mode
	Given Uninstall the lenovo vatage
	Given Close Toolbar Background
	Given wait 180 seconds
	Given Install Vantage
	Given Launch Toolbar On NewOS
	Then The Airplane power mode status same as vantage

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep209_Check the Conservation mode toggle display on statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When check the Conservation mode display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep210_Check The text display is "Conservation mode on"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Conservation mode button
	Then Take screen shot 210checkTipsConservationmode_On in 27994 under ToolbarScreenShotResult after 0 seconds
	When Turn off the Conservation mode
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Conservation mode button
	Then Take screen shot 210checkTipsConservationmode_Off in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep211_Check the Conservation mode button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep212_Check The text display is Conservation mode off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Conservation mode
	When Turn on the Conservation mode
	Then Take screen shot 212CheckTipConservationmode_On in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep213_Check the Conservation mode button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep214_Check the Conservation mode button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	Then The Conservation mode button display on statue
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Rapid charge from power page on Lenovo Vantgae
	Given Launch Toolbar On NewOS
	Then The Conservation mode button display off statue

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep215_Check The text display is Conservation mode off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	When Turn on the Rapid charge
	Then The Conservation mode button display off statue

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep216_Check The text display is Conservation mode off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Conservation mode
	Then The Conservation mode button display off statue

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep217_Check The text display is Conservation mode off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Conservation mode
	When Turn off the Conservation mode
	Then Take screen shot 217CheckTipConservationmode_Off in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep218_Check the Conservation mode toggle display off statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Conservation mode
	When check the Conservation mode display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Conservation mode button displays same as with Vantage

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep219_Check the Conservation button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn on Conservation mode from power page
	Given Launch Toolbar On NewOS
	Then The Conservation mode button display on statue

@NOSConservationModeToolbar
Scenario: VAN27994_TestStep220_Check the Conservation button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn off Conservation mode from power page
	Given Launch Toolbar On NewOS
	Then The Conservation mode button display off statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep221_Check the Rapid charge button displays same as with Vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When check the Rapid charge display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep222_Check The hover tips display is "Rapid charge"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Click batterydetails button on toolbar
	When Hover the mouse on the Rapid charge button
	Then Take Screen Shot 222CheckTiprapidcharge in 27994 under ToolbarScreenShotResult

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep223_Check the Rapid charge button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	Then The Rapid charge button display on statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep224_Check The text display is "Rapid charge on"
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	Then Take screen shot 224CheckTiprapidchargeOn in 27994 under ToolbarScreenShotResult after 0 seconds

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep225_Check the Rapid charge toggle display on statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	When check the Rapid charge display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep226_Check the Rapid charge button display off status from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Given turn on Conservation mode from power page
	Given Launch Toolbar On NewOS
	Then The Rapid charge button display off statue
	
@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep227_Check the Rapid charge button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge
	When Turn on the Conservation mode
	Then The Rapid charge button display off statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep228_Check the Rapid charge button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Rapid charge
	Then The Rapid charge button display off statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep229_Check The text display is Rapid charge off
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Rapid charge
	Then Take screen shot 229CheckTiprapidchargeOff in 27994 under ToolbarScreenShotResult after 0 seconds 

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep230_Check the Rapid charge toggle display off statue from vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Rapid charge
	When check the Rapid charge display
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	Then The Rapid charge button displays same as with Vantage

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep231_Check the Rapid charge button display on statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn on Rapid charge from power page on Lenovo Vantgae
	Given Launch Toolbar On NewOS
	Then The Rapid charge button display on statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep232_Check the Rapid charge button display off statue from toolbar
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Open the My Device Settings and into Power page
	Given Jump to Battery settings
	When turn off Rapid charge from power page on Lenovo Vantgae
	Given Launch Toolbar On NewOS
	Then The Rapid charge button display off statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep233 _Turn on Rapid charge and Uninstall vantage Check Rapid charge button display statue
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn on the Rapid charge	
	Given Close Toolbar Background
	Given Uninstall the lenovo vatage
	When wait 120 seconds
	Given Launch Toolbar On NewOS
	When wait 5 seconds
	Then The Rapid charge button display off statue

@NOSRapidChargeToolbar
Scenario: VAN27994_TestStep234_Turn off Rapid charge and Uninstall vantage Check Rapid charge button display statue
	Given Install Vantage
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	When Turn off the Rapid charge
	When check the Rapid charge display
	Given Close Toolbar Background
	Given Uninstall the lenovo vatage
	When wait 120 seconds
	Given Launch Toolbar On NewOS
	When wait 5 seconds
	Then The Rapid charge button display off statue
	Given Install Vantage
