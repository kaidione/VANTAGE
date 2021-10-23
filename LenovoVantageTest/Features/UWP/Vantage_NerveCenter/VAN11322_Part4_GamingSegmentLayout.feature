Feature: VAN11322_Part4_GamingSegmentLayout
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-11322
	Author： Pengjie Chen

@GamingCapacity_DT @GamingSmokeLightingSectionDT
Scenario: VAN11322_TestStep34_Check Lighting banner is displayed in homepage 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Lighting banner is shown or hidden in homepage 'shown'

@GamingCapacity_DT
Scenario: VAN11322_TestStep35_Check Lighting be shown in the Lighting banner
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Lighting banner is shown or hidden in homepage 'shown'

@GamingCapacity_DT
Scenario: VAN11322_TestStep36_Check Lighting be shown in the Lighting banner
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Lighting banner is shown or hidden in homepage 'shown'

@GamingCapacity_DT
Scenario: VAN11322_TestStep37_Check Lighting be shown in the Lighting banner
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Lighting banner is shown or hidden in homepage 'shown'

@GamingCapacity_Y740 @GamingSmokeNoLightingSectionNB
Scenario: VAN11322_TestStep38_Check Lighting be shown in the Lighting banner
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The Lighting banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Y540
Scenario: VAN11322_TestStep39_Check Lighting be shown in the Lighting banner
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The Lighting banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Think
Scenario: VAN11322_TestStep40_Check Lighting banner is not displayed in the commercial device
	Given Machine is non-Gaming
	Then The Lighting banner is shown or hidden in homepage 'hidden'

@GamingCapacity_SMB
Scenario: VAN11322_TestStep41_Check Lighting banner is not displayed in the SMB device
	Given Machine is non-Gaming
	Then The Lighting banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Ideapad
Scenario: VAN11322_TestStep42_Check Lighting banner is not displayed in the comsumer device
	Given Machine is non-Gaming
	Then The Lighting banner is shown or hidden in homepage 'hidden'