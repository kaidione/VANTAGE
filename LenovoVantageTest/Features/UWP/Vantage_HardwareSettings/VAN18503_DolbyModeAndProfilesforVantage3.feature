Feature: VAN18503_DolbyModeAndProfilesforVantage3
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18503
	Author: Jinxin Li

Background:
	Given Stop Dolby Driver

@DolbySettings
Scenario: VAN18503_TestStep01 Check Dolby modes
	Given supported Dolby machine 
	And go to Audio section
	And Dolby audio is on
	When check the UI of Dolby mode
	Then some machine provide 5 options of Dolby modes: Dynamic, Movie, Music, Gaming, Voice

@DolbySettings
Scenario: VAN18503_TestStep02 Check Dolby Hidden
	Given supported Dolby machine 
	And go to Audio section
	Given Dolby audio is off
	Then The Dolby options will be hidden

@DolbySettings
Scenario: VAN18503_TestStep03 Check Dolby Show
	Given supported Dolby machine 
	And go to Audio section
	Given Dolby audio is on
	When check the UI of Dolby mode
	Then The Dolby options will show

@DolbySettings
Scenario: VAN18503_TestStep04 Check Dolby mode should not change
	Given supported Dolby machine 
	And go to Audio section
	Given Dolby audio is on
	When Get Current Dolby Mode Name
	When switch pages
	Then The Dolby mode should not change and should work normally
	#When reopen Vantage
	When ReLaunch Vantage
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally

@DolbySettings
Scenario: VAN18503_TestStep05 Check Dolby mode should not change
	Given supported Dolby machine 
	And go to Audio section
	When Get Current Dolby Mode Name
	When Enter sleep
	Then The Dolby mode should not change and should work normally
	When Enter hibernate
	Then The Dolby mode should not change and should work normally
