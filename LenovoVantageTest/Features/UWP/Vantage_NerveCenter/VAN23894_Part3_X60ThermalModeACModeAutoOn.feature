Feature: VAN23894_Part3_X60ThermalModeACModeAutoOn
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23894
    Author： Xu Wei
    Automated Test Step：Quiet 49-72

Background: 
    Given Machine is Gaming
    Given AC Condition(Connect the Adapter)
    Given The Machine is X Series 'X60'
    Given The Machine support Specific function 'ThermalModeNew'
    When kill dota2 and wait 1 second 
    When kill Wow and wait 1 second

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep49_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep50_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Check the Auto adjust checkbox status
    When Launch the specifie game Dota2
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep51_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When Launch Vantage
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestSte52_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep53_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep54_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep55_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep56_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Check the Auto adjust checkbox status
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep57_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep58_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep59_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep60_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep61_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep62_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Check the Auto adjust checkbox status
    When Launch the specifie game GameWorldOfWarcraft
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep63_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep64_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep65_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep66_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep67_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep68_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Check the Auto adjust checkbox status
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep69_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep70_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep71_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOn
Scenario: VAN23894_TestStep72_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode
