Feature: VFC202_VantageAudio
	Test Case： https://jira.tc.lenovo.com/browse/VFC-202
	Author： HaiYe Li

@DolbyAudioSetting
Scenario: VFC202-Step01 Check Dolby UI
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Then the title is Automatic Dolby Audio Settings there is a toggle off by default there is a question mark beside the toggle

@DolbyAudioSetting
Scenario: VFC202-Step02 Check Dolby Mode
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	When Take Screen Shot VFC02_mode IN 202 under HSScreenShotResult for DolbySettings
	When open Dolby Atmos Speaker System
	When wait 5 seconds
	When Take Screen Shot VFC02_Sysmode IN 202 under HSScreenShotResult for DolbySettings

@DolbyAudioSettingNoDolbySudio
Scenario: VFC202-Step03 Check title and options will show normally, but no toggle and question mark
	Given go to Audio section
	When Click Audio Smart Settings Link
	Then Dolby options not hidden
	Then  no toggle and question mark

@DolbyAudioSetting
Scenario: VFC202-Step04 Check question mark text
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	When Click question mark Link
	Then Check question mark text

@DolbyAudioSetting
Scenario: VFC202-Step05 Check open Dolby Audio app/Dolby Atmos Speaker System app, the Dolby mode should automatically switch to the appropriate mode 
	Given supported Dolby machine 
	And  go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is on
	When open Dolby Atmos Speaker System
	When Play game
	When Take Screen Shot VFC05_onGame IN 202 under HSScreenShotResult for DolbySettings
	When Play music
	When Take Screen Shot VFC05_onMusic IN 202 under HSScreenShotResult for DolbySettings
	When Play movie
	When Take Screen Shot VFC05_onMovie IN 202 under HSScreenShotResult for DolbySettings

@DolbyAudioSetting
Scenario: VFC202-Step06 Check open Dolby Atmos Speaker System app/Dolby Audio app, the Dolby mode should not switch 
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off
	When open Dolby Atmos Speaker System
	When Play game
	When Take Screen Shot VFC06_offGame IN 202 under HSScreenShotResult for DolbySettings
	When Play music
	When Take Screen Shot VFC06_offMusic IN 202 under HSScreenShotResult for DolbySettings
	When Play movie
	When Take Screen Shot VFC06_offMovie IN 202 under HSScreenShotResult for DolbySettings

@DolbyAudioSetting
Scenario: VFC202-Step07 Check open Dolby Atmos Speaker System app/Dolby Audio app, the Dolby mode should be the same with Vantage
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off
	When switch pages
	When open Dolby Atmos Speaker System
	When Take Screen Shot VFC202_Audio IN 202 under HSScreenShotResult for DolbySettings

@DolbyAudioSetting
Scenario: VFC202-Step08 Check Dolby options should be hidden
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off
	When wait 2 seconds
	Given Dolby audio is on
	Then  The Dolby options will be hidden

@DolbyAudioSetting
Scenario: VFC202-Step09 Check the UI should not change and the feature should work normall
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	When Get Current Dolby Mode Name
	When switch pages
	When Click Audio Smart Settings Link
	Then The Dolby mode should not change and should work normally
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to audio section
	When Click Audio Smart Settings Link
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally
	When Minimize vantage conservation mode
	Then The Dolby mode should not change and should work normally
	When resize Vantage
	Then The Dolby mode should not change and should work normally

@DolbyAudioSetting
Scenario: VFC202-Step10 Check the toggle is off
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is on
	Given Uninstall the lenovo vatage
	Given Install Vantage
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off

@DolbyAudioSetting
Scenario: VFC202-Step11 Check the toggle is off
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off
	Given Uninstall the lenovo vatage
	Given Install Vantage
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off

@DolbyAudioSetting
Scenario: VFC202-Step12 Check The UI should show completely in 2 seconds when launch LE
	Given supported Dolby machine 
	And go to Audio section
	When Click Audio Smart Settings Link
	Given Dolby audio is off
	Then The UI should show completely in 2 seconds