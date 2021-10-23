Feature: VAN10418_GamingHelpPage
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10418
	Author ：Xiao Yunyan

Background:
	Given Machine is Gaming 

@GamingHelp
Scenario: VAN10418_TestStep01_Help Page Should Be Opened
	When Click Help icon
	Then Help Page Should Be Opened

@GamingHelp
Scenario: VAN10418_TestStep02_Gaming Features Introductions Should be Shown
	When Click Help icon
	Then Gaming Features Introductions Should be Shown

@GamingHelp
Scenario: VAN10418_TestStep03_Help Page Should Be Closed
	When Click Help icon
	Then Help Page Should Be Opened
	When Click The Other Area
	Then Help Page Should Be Closed And Homepage Should Be Shown

@GamingHelp
Scenario: VAN10418_TestStep04_Help Page Should Be Closed And Homepage Should Be Shown
	When Click Help icon 
	Then Help Page Should Be Opened
	When Click the Close Button
	Then Help Page Should Be Closed And Homepage Should Be Shown

