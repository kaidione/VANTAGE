Feature: VAN10210_Part9_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Penejie Chen
	Conmments: AC DC

Background:
	Given Turn on or off the narrator 'on'

@IdeaToolbarRapidChargeACDC
Scenario: VAN10210_TestStep021_Check Rapid charge icon and show
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	Given Turn on or off the narrator 'off'
	Given AC Condition(Connect the Adapter)
	When Launch toolbar
	Then Take Screen Shot TestStep21 in 10210 under HSScreenShotResult

@IdeaToolbarRapidChargeACDC
Scenario: VAN10210_TestStep022_Check Rapid charge icon and show
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Rapid charge
	Given Turn on or off the narrator 'off'
	When User make the machine from AC to DC
	When Launch toolbar
	Then Take Screen Shot TestStep22 in 10210 under HSScreenShotResult

@IdeaToolbarRapidChargeACDC
Scenario: VAN10210_TestStep023_Check Rapid charge icon and show
	Given Pin toolbar to taskbar
	Given AC Condition(Connect the Adapter)
	When Launch toolbar
	When Turn off the Rapid charge
	Given Turn on or off the narrator 'off'
	When Launch toolbar
	Then Take Screen Shot TestStep23 in 10210 under HSScreenShotResult

@IdeaToolbarConservationModeACDC  
Scenario: VAN10210_TestStep024_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	Given AC Condition(Connect the Adapter)
	Given Turn on or off the narrator 'off'
	When Launch toolbar
	Then Take Screen Shot TestStep24 in 10210 under HSScreenShotResult

@IdeaToolbarConservationModeACDC  
Scenario: VAN10210_TestStep025_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn on the Conservation mode
	When User make the machine from AC to DC
	Given Turn on or off the narrator 'off'
	When Launch toolbar
	Then Take Screen Shot TestStep25 in 10210 under HSScreenShotResult

@IdeaToolbarConservationModeACDC  
Scenario: VAN10210_TestStep026_Check Conservation mode icon and show
	Given Machine support the conservation mode
	Given AC Condition(Connect the Adapter)
	Given Pin toolbar to taskbar
	When Launch toolbar
	When Turn off the Conservation mode
	Given Turn on or off the narrator 'off'
	When Launch toolbar
	Then Take Screen Shot TestStep26 in 10210 under HSScreenShotResult

##@ToolbarBatteryACDC
#Scenario: VAN10210_TestStep032_Check the battery guage color displays as green
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Turn off the Conservation mode and Battery charge threshold
#	When The battery is more than 25% via ACDC
#	Then Take Screen Shot TestStep32 in 10210 under HSScreenShotResult
#
##@ToolbarBatteryACDC
#Scenario: VAN10210_TestStep033_Check the battery guage color displays as yellow
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Turn off the Conservation mode and Battery charge threshold
#	When The battery is from 15% to 24% via ACDC
#	Then Take Screen Shot TestStep33 in 10210 under HSScreenShotResult
#
##@ToolbarBatteryACDC
#Scenario: VAN10210_TestStep034_Check the battery guage color displays as red
#	Given Pin toolbar to taskbar
#	When Launch toolbar
#	When Turn off the Conservation mode and Battery charge threshold
#	When the battery is lower than 15% via ACDC
#	Then Take Screen Shot TestStep34 in 10210 under HSScreenShotResult
