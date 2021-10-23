Feature: VAN11322_Part3_GamingSegmentLayout
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-11322
	Author： Pengjie Chen

@GamingCapacity @GamingSmokeLegionEdgeSection
Scenario: VAN11322_TestStep23_Check legion edge banner is displayed in homepage 
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity @GamingSmokeLegionEdgeSection
Scenario: VAN11322_TestStep24_Check CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock be shown in the legion edge banner
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep25_Check legion edge banner is displayed in homepage 
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep26_Check CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock be shown in the legion edge banner
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep27_Check legion edge banner is displayed in homepage 
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep28_Check CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock be shown in the legion edge banner
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep29_Check legion edge banner is displayed in homepage 
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep30_Check CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock be shown in the legion edge banner
	Given Machine is Gaming
	Then The legion edge banner is shown or hidden in homepage 'shown'

@GamingCapacity_Think
Scenario: VAN11322_TestStep31_Check legion edge banner is not displayed in the commercial device
	Given Machine is non-Gaming
	Then The legion edge banner is shown or hidden in homepage 'hidden'

@GamingCapacity_SMB
Scenario: VAN11322_TestStep32_Check legion edge banner is not displayed in the SMB device
	Given Machine is non-Gaming
	Then The legion edge banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Ideapad
Scenario: VAN11322_TestStep33_Check legion edge banner is not displayed in the comsumer device
	Given Machine is non-Gaming
	Then The legion edge banner is shown or hidden in homepage 'hidden'