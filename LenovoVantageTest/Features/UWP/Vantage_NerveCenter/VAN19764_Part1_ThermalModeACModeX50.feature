Feature: VAN19764_Part1_ThermalModeACModeX50
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19764
	Author： Jinxin Li
	Automated Test Step 31-60

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
 
@ThermalModeACModeX50
Scenario: VAN19764_TestStep31_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep32_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep33_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep34_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep35_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep36_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep38_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep39_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep40_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep41_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep42_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep43_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep44_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep45_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep46_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep47_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep48_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep49_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep50_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep51_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep52_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep53_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep54_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep55_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep56_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep57_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep58_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep59_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep60_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetThermalMode
