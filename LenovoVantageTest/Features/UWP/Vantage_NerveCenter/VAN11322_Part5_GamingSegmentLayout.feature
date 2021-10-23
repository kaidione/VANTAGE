Feature: VAN11322_Part5_GamingSegmentLayout
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-11322
	Author： Pengjie Chen

@GamingCapacity_C730 @GamingSmokeQuickSettingSectionDT
Scenario: VAN11322_TestStep43_Check Quick settings card is displayed in homepage 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_C730
Scenario: VAN11322_TestStep44_Check Thermal Mode Rapid Charge WiFi Security Dolby is displayed in Quick settings card 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_C730
Scenario: VAN11322_TestStep45_Check Quick settings card is displayed in homepage 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_C730
Scenario: VAN11322_TestStep46_Check Thermal Mode Rapid Charge WiFi Security Dolby is displayed in Quick settings card 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_Y740 @GamingSmokeQuickSettingSectionNB
Scenario: VAN11322_TestStep47_Check Thermal Mode Rapid Charge WiFi Security Dolby is displayed in Quick settings card 
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_Y540
Scenario: VAN11322_TestStep48_Check Thermal Mode Rapid Charge WiFi Security Dolby is displayed in Quick settings card 
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_Y730
Scenario: VAN11322_TestStep49_Check Thermal Mode Rapid Charge WiFi Security Dolby is displayed in Quick settings card 
	Given Machine is Gaming
	Given The Machine is X Series 'X30'
	Then The Quick settings card is shown or hidden in homepage 'shown'

@GamingCapacity_Think
Scenario: VAN11322_TestStep50_Check Quick settings card is not displayed in the commercial device
	Given Machine is non-Gaming
	Then The Quick settings card is shown or hidden in homepage 'hidden'

@GamingCapacity_SMB
Scenario: VAN11322_TestStep51_Check Quick settings card is not displayed in the SMB device
	Given Machine is non-Gaming
	Then The Quick settings card is shown or hidden in homepage 'hidden'

@GamingCapacity_Ideapad
Scenario: VAN11322_TestStep52_Check Quick settings card is not displayed in the comsumer device
	Given Machine is non-Gaming
	Then The Quick settings card is shown or hidden in homepage 'hidden'