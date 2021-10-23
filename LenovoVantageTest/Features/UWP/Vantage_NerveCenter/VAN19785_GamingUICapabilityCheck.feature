Feature: VAN19785_GamingUICapabilityCheck
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-19785
	Author： Xuwei & Chen Pengjie
	Automated Test Step 1-12

Background: 
	Given Machine is Gaming

@GamingUICapabilityLegion @GamingSmokeLegionUI
Scenario: VAN19785_TestStep01_Y Logo Should Be Shown In Legion 
	Given The machine support 'Y' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'
	Then Take Screen Shot VAN19785_TestStep01_Y_Logo in 19785 under GamingScreenShotResult

@GamingUICapabilityLegion @GamingSmokeLegionUI
Scenario: VAN19785_TestStep02_Legion Edge Header Should Be Shown In Legion 
	Given The machine support 'Y' Logo
	Then The 'Legion' Header Should Be Shown or Hidden 'shown'

@GamingUICapabilityLegion @GamingSmokeLegionUI
Scenario: VAN19785_TestStep03_Legion Edge Section Should Be Shown In Legion
	Given The machine support 'Y' Logo
	Then The 'Legion' Should Be Shown or Hidden 'shown' in the Right Section

@GamingUICapabilityLegion	 @GamingSmokeLegionUI
Scenario: VAN19785_TestStep04_Legion Edge Image Should Be Shown In Legion 
	Given The machine support 'Y' Logo
	When Click Help icon
	Then The 'Legion' Should Be Shown or Hidden 'shown' in Help page
	Then Take Screen Shot VAN19785_TestStep04_Help in 19785 under GamingScreenShotResult

@GamingUICapabilityIdeapadGAMING @GamingSmokeLiteNBUI
Scenario: VAN19785_TestStep05_L Logo Should Be Shown In Lite Notebook
	Given The machine support 'L' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'
	Then Take Screen Shot VAN19785_TestStep05_L_Logo in 19785 under GamingScreenShotResult

@GamingUICapabilityIdeapadGAMING @GamingSmokeLiteNBUI
Scenario: VAN19785_TestStep06_IdeapadGAMING Header Should Be Shown In Lite Notebook
	Given The machine support 'L' Logo
	Then The 'IdeapadGAMING' Header Should Be Shown or Hidden 'shown'

@GamingUICapabilityIdeapadGAMING @GamingSmokeLiteNBUI
Scenario: VAN19785_TestStep07_IdeapadGAMING Section Should Be Shown In Lite Notebook
	Given The machine support 'L' Logo
	Then The 'IdeapadGAMING' Should Be Shown or Hidden 'shown' in the Right Section

@GamingUICapabilityIdeapadGAMING @GamingSmokeLiteNBUI
Scenario: VAN19785_TestStep08_IdeapadGAMING Image Should Be Shown In Lite Notebook
	Given The machine support 'L' Logo
	When Click Help icon
	Then The 'IdeapadGAMING' Should Be Shown or Hidden 'shown' in Help page
	Then Take Screen Shot VAN19785_TestStep08_Help in 19785 under GamingScreenShotResult

@GamingUICapabilityIdeaCentreGAMING @GamingSmokeLiteDTUI
Scenario: VAN19785_TestStep09_L Logo Should Be Shown In Lite Desktop
	Given The machine support 'L' Logo
	Then Gaming Logo Should Be Shown or Hidden 'shown'
	Then Take Screen Shot VAN19785_TestStep09_L_Logo in 19785 under GamingScreenShotResult

@GamingUICapabilityIdeaCentreGAMING @GamingSmokeLiteDTUI
Scenario: VAN19785_TestStep10_IdeaCentreGAMING Header Should Be Shown In Lite Desktop
	Given The machine support 'L' Logo
	Then The 'IdeaCentreGAMING' Header Should Be Shown or Hidden 'shown'

@GamingUICapabilityIdeaCentreGAMING @GamingSmokeLiteDTUI
Scenario: VAN19785_TestStep11_IdeaCentreGAMING Section Should Be Shown In Lite Desktop
	Given The machine support 'L' Logo
	Then The 'IdeaCentreGAMING' Should Be Shown or Hidden 'shown' in the Right Section

@GamingUICapabilityIdeaCentreGAMING @GamingSmokeLiteDTUI
Scenario: VAN19785_TestStep12_IdeaCentreGAMING Image Should Be Shown In Lite Desktop
	Given The machine support 'L' Logo
	When Click Help icon
	Then The 'IdeapCentreGAMING' Should Be Shown or Hidden 'shown' in Help page
	Then Take Screen Shot VAN19785_TestStep12_Help in 19785 under GamingScreenShotResult