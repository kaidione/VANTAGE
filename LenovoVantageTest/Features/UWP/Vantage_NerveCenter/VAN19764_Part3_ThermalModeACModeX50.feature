Feature: VAN19764_Part3_ThermalModeACModeX50ACTODC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19764
	Author： Jinxin Li
	Automated Test Step 91-120

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep91_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep92_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep93_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep94_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep95_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep96_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep97_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep98_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep99_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep100_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep101_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep102_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep103_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep104_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep105_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep106_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep107_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep108_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep109_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep110_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep111_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep112_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep113_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep114_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep115_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep116_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep117_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	When Stop the game
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep118_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep119_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep120_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)
