Feature: VAN19765_Part1_ThermalModeDCModeX50
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19765
	Author： Jinxin Li
	Automated Test Step 31-60

Background:
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep31_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep32_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep33_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep34_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep35_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep36_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep37_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep38_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep39_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep40_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep41_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep42_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep43_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep44_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep45_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep46_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep47_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given wait 2 seconds
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep48_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep49_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep50_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep51_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep52_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep53_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep54_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep55_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep56_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep57_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep58_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep59_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep60_Check Thermal Mode Setting popup
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is OFF
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Then The Gaming mode value is 1 And the Method is GetThermalMode
