Feature: VAN26008_Part3_GamingIntelligentSubModeChangeWhenGaming
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN26008
    Author： Xu Wei
    Automated Test Step：Quiet 25-36

Background: 
    Given Machine is Gaming
    Given AC Condition(Connect the Adapter)
    Given The Machine is X Series 'X60'
    Given The Machine support Specific function 'ThermalModeNew'
    When kill SOTTR and wait 1 second 
    When kill Wow and wait 1 second
    When kill steam and wait 1 second

@IntellegentSubMode
Scenario: VAN26008_TestStep25_IntelligentSubMode In Quiet Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep26_IntelligentSubMode In Performance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep27_IntelligentSubMode Back To Quiet Mode From Performance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep28_IntelligentSubMode In Quiet mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep29_IntelligentSubMode In Balance Mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 2 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep30_IntelligentSubMode Back To Quiet Mode From Balance mode When Game In White List Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game SOTTR
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep31_IntelligentSubMode In Quiet Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep32_IntelligentSubMode In Performance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep33_IntelligentSubMode Back To Quiet Mode From Performance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Performance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep34_IntelligentSubMode In Quiet mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep35_IntelligentSubMode In Balance Mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Then The Intelligent Sub Mode value is 1 And the Method is GetIntelligentSubMode

@IntellegentSubMode
Scenario: VAN26008_TestStep36_IntelligentSubMode Back To Quiet Mode From Balance mode When Common Game Is Running
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Given Auto adjust checkbox is ON
    When Launch the specifie game GameWorldOfWarcraft
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Balance Mode
    Given The Thermal Mode Setting popup is displaying
    Given The thermal mode is Quiet Mode
    Then The Intelligent Sub Mode value is 0 And the Method is GetIntelligentSubMode