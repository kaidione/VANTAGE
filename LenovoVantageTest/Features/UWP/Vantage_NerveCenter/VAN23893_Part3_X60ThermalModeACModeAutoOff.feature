Feature: VAN23893_Part3_X60ThermalModeACModeAutoOff
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-23893
    Author： Xu Wei
    Automated Test Step：Quiet 49-72

Background: 
    Given Machine is Gaming
    Given AC Condition(Connect the Adapter)
    Given The Machine is X Series 'X60'
    Given The Machine support Specific function 'ThermalModeNew'
    When kill dota2 and wait 1 second 
    When kill Wow and wait 1 second

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep49_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep50_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Check the Auto adjust checkbox status
    When Launch the specifie game Dota2
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep51_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestSte52_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep53_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep54_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep55_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep56_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Check the Auto adjust checkbox status
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep57_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep58_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep59_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep60_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game Dota2
    When kill dota2 and wait 1 second 
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep61_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup 

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep62_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Check the Auto adjust checkbox status
    When Launch the specifie game GameWorldOfWarcraft
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep63_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep64_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep65_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep66_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep67_Check Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    When Check Thermal mode in the Thermal Mode Setting popup
    Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep68_Check Auto Adjust Checkbox Status In Thermal Mode Setting popup
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Check the Auto adjust checkbox status
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    When Check Thermal mode in the Thermal Mode Setting popup
    Then Auto adjust checkbox status should not be changed

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep69_Check Thermal Mode In Homepage
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Given Click X button in Thermal Mode Setting popup
    Then Then The thermal mode is Quiet Mode in homepage

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep70_Check Smart Fan Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Gaming mode value is 1 And the Method is GetSmartFanMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep71_Check Thermal Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Gaming mode value is 1 And the Method is GetThermalMode

@ThermalModeACModeX60AutoOff
Scenario: VAN23893_TestStep72_Check Intellignet Sub Mode In WMI
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is OFF
    When Launch the specifie game GameWorldOfWarcraft
    When kill Wow and wait 1 second
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode