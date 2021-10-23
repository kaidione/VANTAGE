Feature: VAN19765_Part3_ThermalModeDCModeX50DCTOAC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/broThermalModeACModeX50ACTODCwse/VAN-19765
	Author： Jinxin Li
	Automated Test Step 91-120

Background:
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep91_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep92_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep93_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep94_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep95_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep96_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep97_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep98_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep99_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep100_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep101_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep102_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep103_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep104_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep105_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep106_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep107_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep108_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep109_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep110_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep111_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep112_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep113_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep114_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep115_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep116_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep117_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When check the Enable OverClocking checkbox status
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep118_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep119_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep120_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetThermalMode