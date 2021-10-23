Feature: VAN19764_Part2_ThermalModeACModeX50
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19764
	Author： Jinxin Li
	Automated Test Step 61-90

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)

@ThermalModeACModeX50
Scenario: VAN19764_TestStep61_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep62_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep63_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep64_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep65_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep66_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep67_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep68_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep69_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep70_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep71_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep72_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep73_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep74_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep75_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep76_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep77_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep78_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep79_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep80_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep81_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep82_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep83_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep84_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep85_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep86_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX50
Scenario: VAN19764_TestStep87_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeACModeX50
Scenario: VAN19764_TestStep88_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX50
Scenario: VAN19764_TestStep89_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX50
Scenario: VAN19764_TestStep90_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetThermalMode