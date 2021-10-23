	Feature: VAN16948_GamingOverDriveTest
	Test Case：https://jira.tc.lenovo.com/browse/VAN-16948
	Author ：tian xiang

Background:
	Given Machine is Gaming 

@GamingNotsupportOverDriveTestLess144 @GamingSmokeNOOD
Scenario:VAN16948_TestStep01_Over drive toggle should not be shown in the Legion edge section
	Given The Machine not support Specific function 'OverDrive'
	Given Refresh rate < 144Hz
	Then Over drive toggle should not be shown in the Legion edge section

@GamingNotsupportOverDriveTestLess144
Scenario:VAN16948_TestStep02_Over drive capability value is 0
	Given The Machine not support Specific function 'OverDrive'
	Given Refresh rate < 144Hz
	Then Over drive capability value is 0

@GamingNotsupportOverDriveTestMore144 
Scenario:VAN16948_TestStep03_Over drive toggle should not be shown in the Legion edge section
	Given The Machine not support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive toggle should not be shown in the Legion edge section

@GamingNotsupportOverDriveTestMore144
Scenario:VAN16948_TestStep04_Over drive capability value is 0
	Given The Machine not support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive capability value is 0

@GamingsupportOverDriveTestNoshown
Scenario:VAN16948_TestStep05_Over drive toggle should not be shown in the Legion edge section
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate < 144Hz
	Then Over drive toggle should not be shown in the Legion edge section

@GamingsupportOverDriveTestNoshown
Scenario:VAN16948_TestStep06_Over drive capability value is 0
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate < 144Hz
	Then Over drive capability value is 0

@GamingsupportOverDriveTestShown @GamingSmokeOD
Scenario:VAN16948_TestStep07_Over drive toggle should be shown in the Legion edge section
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive toggle should be shown in the Legion edge section

@GamingsupportOverDriveTestShown @GamingSmokeOD
Scenario:VAN16948_TestStep08_Over drive capability value is 1
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive capability value is 1

@GamingsupportOverDriveTestShown
Scenario:VAN16948_TestStep09_Over drive toggle position should be behind Hybrid mode in the Legion edge section
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive toggle position should be behind Hybrid mode in the Legion edge section

@GamingsupportOverDriveTestShown
Scenario:VAN16948_TestStep10_AOver drive toggle position should be behind Hybrid mode in the Legion edge section
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Then Over drive toggle status should be consistent with the Bios

@GamingsupportOverDriveTestShown
Scenario:VAN16948_TestStep11_Over drive value that GetODStatus should be 1
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Given Over Drive toggle status is on
	Then Over drive value should be 1

@GamingsupportOverDriveTestShown
Scenario:VAN16948_TestStep12_Over drive toggle status should be off
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Given Over Drive toggle status is on
	Given click Over Drive toggle_on
	Then Over drive toggle status should be off

@GamingsupportOverDriveTestShown
Scenario:VAN16948_TestStep13_Over drive value that GetODStatus should be 0
	Given The Machine support Specific function 'OverDrive'
	Given Refresh rate >= 144Hz
	Given Over Drive toggle status is on
	Given set Over Drive toggle status to off
	Then Over drive value should be 0