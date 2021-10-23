Feature: VAN25332_GamingTagDetectionInCoreAddIn
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25332
	Author： Yang Liu

@GamingTagDetectionNonGaming
Scenario: VAN25332_TestStep01_Check Gaming tag should not be found
	Given Uninstall the lenovo vatage
	Given Uninstall Lenovo Vantage Service
	#Given Delete The Gaming Tag
	#Given Install Vantage
	#Then The Gaming Mode Value not Is Or Not 1,2,100,101 And The Method Is GetProductInfo
	Given Machine is non-Gaming

@GamingTagDetectionNonGaming
Scenario: VAN25332_TestStep02_Check the GamingPlugins should not be found
	Given Uninstall the lenovo vatage
	Given Uninstall Lenovo Vantage Service
	#Given Delete The Gaming Tag
	#Given Install Vantage
	#Then The Gaming Mode Value not Is Or Not 1,2,100,101 And The Method Is GetProductInfo
	Then The GamingPlugins Should Not Be Found

@GamingTagDetection
Scenario: VAN25332_TestStep03_Check Gaming tag should be found
	Given Uninstall the lenovo vatage
	Given Uninstall Lenovo Vantage Service
	Given Delete The Gaming Tag
	Given Install Vantage
    Then The Gaming Mode Value is Is Or Not 1,2,100,101 And The Method Is GetProductInfo
    Given Machine is Gaming

@GamingTagDetection
Scenario: VAN25332_TestStep04_Check the GamingPlugins should be found
	Given Uninstall the lenovo vatage
	Given Uninstall Lenovo Vantage Service
	Given Delete The Gaming Tag
	Given Install Vantage
    Then The Gaming Mode Value is Is Or Not 1,2,100,101 And The Method Is GetProductInfo
	Then The GamingPlugins Should Be Found

@GamingTagDetectionY760SAMD
Scenario: VAN25332_TestStep05_Check data should be 100
    Then The Gaming mode value is 100 And the Method is GetProductInfo

@GamingTagDetectionY760SAMD
Scenario: VAN25332_TestStep06_Check Y logo should be shown 
    Then The Gaming mode value is 100 And the Method is GetProductInfo
	Given The machine support 'Y' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'

@GamingTagDetectionY760SAMD
Scenario: VAN25332_TestStep07_Check Header name should be Legion
    Then The Gaming mode value is 100 And the Method is GetProductInfo
	Then The 'Legion' Header Should Be Shown or Hidden 'shown'

@GamingTagDetectionY760SAMD
Scenario: VAN25332_TestStep08_Check Legion Edge on the right section should be shown
    Given Machine is Gaming
	Given The Machine Type is DT or NB 'NB'
    Then The Gaming mode value is 100 And the Method is GetProductInfo
	Then The 'Legion' Should Be Shown or Hidden 'shown' in the Right Section

@GamingTagDetectionY760SAMD
Scenario: VAN25332_TestStep09_Check Legion Edge in the open help popup should be shown
    Then The Gaming mode value is 100 And the Method is GetProductInfo
	Then The 'Legion' Should Be Shown or Hidden 'shown' in Help page

@GamingTagDetectionL360
Scenario: VAN25332_TestStep10_Check data should be 101
    Then The Gaming mode value is 101 And the Method is GetProductInfo

@GamingTagDetectionL360
Scenario: VAN25332_TestStep11_Check L logo should be shown 
    Then The Gaming mode value is 101 And the Method is GetProductInfo
	Given The machine support 'L' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'

@GamingTagDetectionL360
Scenario: VAN25332_TestStep12_Check Header name should be IdeapadGAMING
    Then The Gaming mode value is 101 And the Method is GetProductInfo
	Then The 'IdeapadGAMING' Header Should Be Shown or Hidden 'shown'

@GamingTagDetectionL360
Scenario: VAN25332_TestStep13_Check IdeapadGAMING should be shown
    Then The Gaming mode value is 101 And the Method is GetProductInfo
	Then The 'IdeapadGAMING' Should Be Shown or Hidden 'shown' in the Right Section

@GamingTagDetectionL360
Scenario: VAN25332_TestStep14_Check IdeapadGAMING should be shown
    Then The Gaming mode value is 101 And the Method is GetProductInfo
	Then The 'IdeapadGAMING' Should Be Shown or Hidden 'shown' in Help page

@GamingTagDetectionT560
Scenario: VAN25332_TestStep15_Check data should be 1
    Then The Gaming mode value is 1 And the Method is GetProductInfo

@GamingTagDetectionT560
Scenario: VAN25332_TestStep16_Check Y logo should be shown 
    Then The Gaming mode value is 1 And the Method is GetProductInfo
	Given The machine support 'Y' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'

@GamingTagDetectionT560
Scenario: VAN25332_TestStep17_Check Header name should be Legion
    Then The Gaming mode value is 1 And the Method is GetProductInfo
	Then The 'Legion' Header Should Be Shown or Hidden 'shown'

@GamingTagDetectionT560
Scenario: VAN25332_TestStep18_Check Legion Edge should be shown
    Then The Gaming mode value is 1 And the Method is GetProductInfo
	Then The 'Legion' Should Be Shown or Hidden 'shown' in the Right Section

@GamingTagDetectionT560
Scenario: VAN25332_TestStep19_Check Legion Edge should be shown
    Then The Gaming mode value is 1 And the Method is GetProductInfo
	Then The 'Legion' Should Be Shown or Hidden 'shown' in Help page

@GamingTagDetectionT560G
Scenario: VAN25332_TestStep20_Check data should be 2
    Then The Gaming mode value is 2 And the Method is GetProductInfo

@GamingTagDetectionT560G
Scenario: VAN25332_TestStep21_Check L logo should be shown 
    Then The Gaming mode value is 2 And the Method is GetProductInfo
	Given The machine support 'L' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'

@GamingTagDetectionT560G
Scenario: VAN25332_TestStep22_Check Header name should be IdeaCentreGAMING
    Then The Gaming mode value is 2 And the Method is GetProductInfo
	Then The 'IdeaCentreGAMING' Header Should Be Shown or Hidden 'shown'

@GamingTagDetectionT560G
Scenario: VAN25332_TestStep23_Check IdeaCentreGAMING should be shown
    Then The Gaming mode value is 2 And the Method is GetProductInfo
	Then The 'IdeaCentreGAMING' Should Be Shown or Hidden 'shown' in the Right Section

@GamingTagDetectionT560G
Scenario: VAN25332_TestStep24_Check IdeaCentreGAMING should be shown
    Then The Gaming mode value is 2 And the Method is GetProductInfo
	Then The 'IdeaCentreGAMING' Should Be Shown or Hidden 'shown' in Help page
