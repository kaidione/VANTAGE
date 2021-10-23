Feature: VAN26008_Part1_GamingIntelligentSubModeChangeWhenGaming
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN26008
    Author： Xu Wei
    Automated Test Step：Balance 1-12

Background: 
    Given Machine is Gaming
    Given AC Condition(Connect the Adapter)
    Given The Machine is X Series 'X60'
    Given The Machine support Specific function 'ThermalModeNew'
    When kill SOTTR and wait 1 second 
    When kill Wow and wait 1 second

@IntellegentSubMode
Scenario: VAN26008_TestStep1_IntelligentSubMode In Balance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep2_IntelligentSubMode In Performance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep3_IntelligentSubMode Back To Balance Mode From Performance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep4_IntelligentSubMode In Balance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep5_IntelligentSubMode In Quiet Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep6_IntelligentSubMode Back To Balance Mode From Quiet mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep7_IntelligentSubMode In Balance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep8_IntelligentSubMode In Performance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep9_IntelligentSubMode Back To Balance Mode From Performance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep10_IntelligentSubMode In Balance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep11_IntelligentSubMode In Quiet Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep12_IntelligentSubMode Back To Balance Mode From Quiet mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode