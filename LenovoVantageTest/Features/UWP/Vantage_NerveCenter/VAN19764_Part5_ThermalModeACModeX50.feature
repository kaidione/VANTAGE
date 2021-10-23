Feature: VAN19764_Part5_ThermalModeACModeX50ACTODC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19764
	Author： Jinxin Li
	Automated Test Step 151-180

Background: 
	When Run Server On '10.119.137.45' User make from DC to AC Use Server '1010' id

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep151_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep152_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep153_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep154_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep155_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep156_Check From AC To DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep157_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep158_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep159_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep160_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep161_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep162_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)
	
@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep163_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep164_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep165_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

#Manual
@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep166_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep167_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Performance Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX60 
Scenario: VAN19764_TestStep167_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When Check the Auto adjust checkbox status
	Given The thermal mode is Performance Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep168_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage
	Then Take Screen Shot ADasboardIcon_TestStep168 in 19764 under GamingScreenShotResult

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep169_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep170_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep171_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Given The thermal mode is Balance Mode
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep172_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Balance Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX60
Scenario: VAN19764_TestStep172_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When Check the Auto adjust checkbox status
	Given The thermal mode is Balance Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep173_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Then Take Screen Shot ASnowflakeIcon_TestStep173 in 19764 under GamingScreenShotResult

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep174_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep175_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep176_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep177_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Quiet Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX60
Scenario: VAN19764_TestStep177_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When Check the Auto adjust checkbox status
	Given The thermal mode is Quiet Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep178_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Then Take Screen Shot ALeafBatteryIcon_TestStep178 in 19764 under GamingScreenShotResult

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep179_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX50 @ThermalModeACModeX60
Scenario: VAN19764_TestStep180_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Then The Gaming mode value is 1 And the Method is GetThermalMode
