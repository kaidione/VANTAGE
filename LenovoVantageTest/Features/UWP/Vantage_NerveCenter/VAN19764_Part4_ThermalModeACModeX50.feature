Feature: VAN19764_Part4_ThermalModeACModeX50ACTODC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19764
	Author： Jinxin Li
	Automated Test Step 121-150

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep121_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep122_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep123_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep124_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep125_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep126_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep127_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep128_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep129_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep130_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep131_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep132_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)
	
@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep133_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep134_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep135_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep136_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep137_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep138_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep139_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep140_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep141_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep142_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep143_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep144_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep145_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep146_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep147_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given DC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep148_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep149_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)
	When Stop the game

@ThermalModeACModeX50ACTODC
Scenario: VAN19764_TestStep150_Check From AC to DC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given DC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)
	When Stop the game
