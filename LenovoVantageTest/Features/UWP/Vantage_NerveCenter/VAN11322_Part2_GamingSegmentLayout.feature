Feature: VAN11322_Part2_GamingSegmentLayout
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-11322
	Author： Pengjie Chen

@GamingCapacity_NB @GamingSmokeSystemToolSectionNB
Scenario: VAN11322_An App Must Ready Legion Accessory Central App Must Install
	Given Legion Accessory Central App Install or Uninstall 'install'
	
@GamingCapacity_DT @GamingSmokeSystemToolSectionDT
Scenario: VAN11322_TestStep12_Check system tools banner is displayed in homepage 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_DT 
Scenario: VAN11322_TestStep13_Check system update power media hardwarescan macrokey legionaccessorycentral be shown in the system tools banner
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'DT'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_Y740
Scenario: VAN11322_TestStep14_Check system tools banner is displayed in homepage 
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_Y740
Scenario: VAN11322_TestStep15_Check system update power media hardwarescan macrokey legionaccessorycentral be shown in the system tools banner
	Given The Machine is X Series 'X40'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_Y540
Scenario: VAN11322_TestStep16_Check system tools banner is displayed in homepage
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_Y540
Scenario: VAN11322_TestStep17_Check system update power media hardwarescan macrokey legionaccessorycentral be shown in the system tools banner
	Given Machine is Gaming
	Given The Machine is X Series 'X40'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_NB @GamingSmokeSystemToolSectionNB
Scenario: VAN11322_TestStep18_Check system tools banner is displayed in homepage 
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'NB'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_NB
Scenario: VAN11322_TestStep19_Check system update power media hardwarescan macrokey legionaccessorycentral be shown in the system tools banner
	Given Machine is Gaming
	Given The Machine Type is DT or NB 'NB'
	Then The system tools banner is shown or hidden in homepage 'shown'

@GamingCapacity_Think
Scenario: VAN11322_TestStep20_Check system tools banner is not displayed in the commercial device
	Given Machine is non-Gaming
	Then The system tools banner is shown or hidden in homepage 'hidden'

@GamingCapacity_SMB
Scenario: VAN11322_TestStep21_Check system tools banner is not displayed in the SMB device
	Given Machine is non-Gaming
	Then The system tools banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Ideapad
Scenario: VAN11322_TestStep22_Check system tools banner is not displayed in the comsumer device
	Given Machine is non-Gaming
	Then The system tools banner is shown or hidden in homepage 'hidden'