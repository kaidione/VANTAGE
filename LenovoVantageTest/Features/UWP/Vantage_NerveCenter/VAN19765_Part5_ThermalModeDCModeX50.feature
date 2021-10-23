Feature: VAN19765_Part5_ThermalModeDCModeX50DCTOAC
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19765
	Author： Jinxin Li
	Automated Test Step 151-180

Background: 
	Given Machine is Gaming
	Given DC Condition(Connect the Adapter)

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep151_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep152_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep153_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep154_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep155_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep156_Check From DC To AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep157_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep158_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Given wait 2 seconds
	Then Then The thermal mode is Performance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep159_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep160_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	Given AC Condition(Connect the Adapter)
	Given wait 2 seconds
	Then The Gaming mode value is 3 And the Method is GetThermalMode

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep161_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep162_Check Auto switch On
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	When check the Enable OverClocking checkbox status
	Given AC Condition(Connect the Adapter)
	Then Enable OverClocking checkbox status should not be changed
	
@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep163_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep164_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode
	Given AC Condition(Connect the Adapter)

@ThermalModeDCModeX50DCTOAC
Scenario: VAN19765_TestStep165_Check From DC to AC
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is On
	When Launch the specifie game GameWorldOfWarcraft
	When Stop the game
	Given AC Condition(Connect the Adapter)
	Then The Gaming mode value is 2 And the Method is GetThermalMode

#Manual
@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep166_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep167_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Performance Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX60
Scenario: VAN19765_TestStep167_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	When Check the Auto adjust checkbox status
	Given The thermal mode is Performance Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep168_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Then Take Screen Shot ADasboardIcon_TestStep168 in 19764 under GamingScreenShotResult

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep169_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then The Gaming mode value is 3 And the Method is GetSmartFanMode

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep170_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep171_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Given The thermal mode is Balance Mode
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep172_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Balance Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX60
Scenario: VAN19765_TestStep172_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	When Check the Auto adjust checkbox status
	Given The thermal mode is Balance Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep173_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Balance Mode in homepage
	Then Take Screen Shot ASnowflakeIcon_TestStep173 in 19764 under GamingScreenShotResult

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep174_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then The Gaming mode value is 2 And the Method is GetSmartFanMode

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep175_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then The Gaming mode value is 2 And the Method is GetThermalMode

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep176_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given wait 5 seconds
	Given The thermal mode is Quiet Mode
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeDCModeX50
Scenario: VAN19765_TestStep177_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When check the Enable OverClocking checkbox status
	Given The thermal mode is Quiet Mode
	Then Enable OverClocking checkbox status should not be changed

@ThermalModeDCModeX60
Scenario: VAN19765_TestStep177_New_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	When Check the Auto adjust checkbox status
	Given wait 5 seconds
	Given The thermal mode is Quiet Mode
	Then Auto adjust checkbox status should not be changed

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep178_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
    Given wait 5 seconds
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Then The thermal mode is Quiet Mode in homepage
	Then Take Screen Shot ALeafBatteryIcon_TestStep178 in 19764 under GamingScreenShotResult

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep179_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given wait 5 seconds
	Given The thermal mode is Quiet Mode
	Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeDCModeX50 @ThermalModeDCModeX60
Scenario: VAN19765_TestStep180_Check Can Changed Mode
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given wait 5 seconds
	Given The thermal mode is Quiet Mode
	Then The Gaming mode value is 1 And the Method is GetThermalMode
	Given AC Condition(Connect the Adapter)
