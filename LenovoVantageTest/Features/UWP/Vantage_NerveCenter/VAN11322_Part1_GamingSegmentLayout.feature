Feature: VAN11322_Part1_GamingSegmentLayout
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-11322
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming

@GamingCapacity @GamingSmokeSystemStatusBar
Scenario: VAN11322_TestStep01_Check system status banner is displayed in homepage 
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity @GamingSmokeSystemStatusBar
Scenario: VAN11322_TestStep02_Check GPU CPU RAM hard disk information and INFO link be shown in the system status banner
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep03_Check system status banner is displayed in homepage 
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep04_Check GPU CPU RAM hard disk information and INFO link be shown in the system status banner
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep05_Check system status banner is displayed in homepage 
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep06_Check GPU CPU RAM hard disk information and INFO link be shown in the system status banner
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep07_Check system status banner is displayed in homepage 
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity
Scenario: VAN11322_TestStep08_Check GPU CPU RAM hard disk information and INFO link be shown in the system status banner
	Then The system status banner is shown or hidden in homepage 'shown'

@GamingCapacity_Think
Scenario: VAN11322_TestStep09_Check system status banner is not displayed in the commercial device
	Given Machine is non-Gaming
	Then The system status banner is shown or hidden in homepage 'hidden'

@GamingCapacity_SMB
Scenario: VAN11322_TestStep10_Check system status banner is not displayed in the SMB device
	Given Machine is non-Gaming
	Then The system status banner is shown or hidden in homepage 'hidden'

@GamingCapacity_Ideapad
Scenario: VAN11322_TestStep11_Check system status banner is not displayed in the comsumer device
	Given Machine is non-Gaming
	Then The system status banner is shown or hidden in homepage 'hidden'