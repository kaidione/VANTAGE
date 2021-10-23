Feature: VAN19765_Part2_ThermalModeDCModeX50
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19765
	Author： Jinxin Li
	Automated Test Step 61-90

Background:
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep61_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep62_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep63_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep64_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep65_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep66_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep67_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep68_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep69_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep70_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep71_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep72_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep73_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep74_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep75_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep76_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep77_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep78_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep79_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep80_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep81_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep82_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep83_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep84_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep85_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep86_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep87_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep88_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep89_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep90_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetThermalMode