
Feature: VAN19765_Part4_ThermalModeDCModeX50DCTOAC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19765
	Author： Jinxin Li
	Automated Test Step 121-150

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep121_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep122_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep123_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep124_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep125_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep126_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep127_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep128_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep129_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep130_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep131_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep132_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	
@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep133_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep134_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep135_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is Off
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep136_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep137_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep138_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep139_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep140_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Given wait 2 seconds
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep141_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep142_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep143_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep144_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep145_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep146_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	When Stop the game

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep147_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	When Stop the game

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep148_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep149_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep150_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetThermalMode
