Feature: VAN26008_Part2_GamingIntelligentSubModeChangeWhenGaming
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN26008
    Author： Xu Wei
    Automated Test Step：Performance 13-24

Background: 
    Given Machine is Gaming
    Given AC Condition(Connect the Adapter)
    Given The Machine is X Series 'X60'
    Given The Machine support Specific function 'ThermalModeNew'
    When kill SOTTR and wait 1 second 
    When kill Wow and wait 1 second

@IntellegentSubMode
Scenario: VAN26008_TestStep13_IntelligentSubMode In Performance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep14_IntelligentSubMode In Balance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep15_IntelligentSubMode Back To Performance Mode From Balance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep16_IntelligentSubMode In Performance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep17_IntelligentSubMode In Quiet Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep18_IntelligentSubMode Back To Performance Mode From Quiet mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep19_IntelligentSubMode In Performance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep20_IntelligentSubMode In Balance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep21_IntelligentSubMode Back To Performance Mode From Balance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep22_IntelligentSubMode In Performance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep23_IntelligentSubMode In Quiet Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep24_IntelligentSubMode Back To Performance Mode From Quiet mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode