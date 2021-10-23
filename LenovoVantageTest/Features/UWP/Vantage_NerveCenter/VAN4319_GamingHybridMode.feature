Feature: VAN4319_GamingHybridMode
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4319
	Author ：Xiao Yunyan

Background:
	Given Machine is Gaming 

@GamingHybridModeX40  @GamingSmokeHibridModeOff
Scenario: VAN4319_TestStep01_Default State Is OFF
    Given The Machine is X Series 'X40'
	Then The hybrid mode toggle status is on or off within homepage 'off'
	Then The number of graphics card in Device Manager is '1'

@GamingHybridModeX50  @GamingSmokeHibridModeOn
Scenario: VAN4319_TestStep02_Default State Is ON
    Given The Machine is X Series 'X50'
	Then The hybrid mode toggle status is on or off within homepage 'on'
	Then The number of graphics card in Device Manager is '2'

@GamingHybridModeOff @GamingSmokeHibridModeOff
Scenario: VAN4319_TestStep03_Restart Window Display
	Given The Machine support Specific function 'HybridMode'
	When Click the hybrid mode 'off' toggle
	Then The Restart Window Display
	Then The system can display normally

@GamingHybridModeRestartNeed
Scenario: VAN4319_TestStep04_Hybrid Mode Will Be Disable
	Given The Machine support Specific function 'HybridMode'
	When Click the hybrid mode 'off' toggle
	When Enter hibernate
	Then The hybrid mode toggle status is on or off within homepage 'on'
	When Click the hybrid mode 'on' toggle
	Then The Restart Window Display
	When Enter hibernate
	Then The hybrid mode toggle status is on or off within homepage 'off'
	Then The number of graphics card in Device Manager is '1'
	Then The system can display normally

@GamingHybridModeOffS3
Scenario: VAN4319_TestStep05_Toggle Status Will Not Be Changed After Sleep
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'off'
	When Click the hybrid mode 'off' toggle
	When Enter sleep
	Then The hybrid mode toggle status is on or off within homepage 'off'
	Then The system can display normally

@GamingHybridModeRestartNeed
Scenario: VAN4319_TestStep06_Toggle Status Will Be Changed After Hibernate
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'off'
	When Click the hybrid mode 'off' toggle
	When Enter hibernate
	Then The hybrid mode toggle status is on or off within homepage 'on'
	Then The system can display normally

@GamingHybridModeOn
Scenario: VAN4319_TestStep08_Click OK Button In The Restart Window
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'on'
	When Click the hybrid mode 'on' toggle
	Then The Restart Window Display
	When Click the OK button in the Restart Window
	Then The hybrid mode toggle status is on or off within homepage 'on'
	Then The system can display normally

@GamingHybridModeOn
Scenario: VAN4319_TestStep09_Click X button In The Restart Window
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'on'
	When Click the hybrid mode 'on' toggle
	Then The Restart Window Display
	When Click the X button in the Restart Window
	Then The Restart Window Will be Closed
	Then The system can display normally

@GamingHybridModeOn
Scenario: VAN4319_TestStep10_Click X button In The Restart Window And Toggle Status Will Not Be Changed
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'on'
	When Click the hybrid mode 'on' toggle
	Then The Restart Window Display
	When Click the X button in the Restart Window
	Then The hybrid mode toggle status is on or off within homepage 'on'

@GamingHybridModeRestartNeed
Scenario: VAN4319_TestStep11_Click X button In The Restart Window And Hibernate
	Given The Machine support Specific function 'HybridMode'
	Then The hybrid mode toggle status is on or off within homepage 'on'
	When Click the hybrid mode 'on' toggle
	Then The Restart Window Display
	When Click the X button in the Restart Window
	When Enter hibernate
	Then The hybrid mode toggle status is on or off within homepage 'off'	