Feature: VAN18509_VantageApplicationbasedDolbySettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18509
	Author：Jinxin Li

Background:
	Given Stop Dolby Driver

@DolbySettings @SmokeDolbySettings
Scenario: VAN18509_TestStep01_Dolby_Settings Check UI
	Given supported Dolby machine 
	And go to Audio section
	When check the UI of Automatic Dolby Audio Settings
	Then the header is Automatically optimize audio for entertainment. a checkbox in front. a question mark on the right

@DolbySettings
Scenario: VAN18509_TestStep02_Dolby_Settings Check Uwp Model
	Given supported Dolby machine 
	And go to Audio section
	When check the UI of Automatic Dolby Audio Settings
	Then open Dolby Audio app and check the options. The options in Vantage should be the same with Dolby Audio app. support 5 modes:Dynamic/Movie/Music/Game/Voice support 4 modes: Movie/Music/Game/Voice

@NotSupportDolbySettings
Scenario: VAN18509_TestStep03_Dolby_Settings Check Mask
	Given not supported Dolby machine 
	And go to Audio section
	When check the UI of Automatic Dolby Audio Settings
	Then no checkbox and question mark 

@DolbySettings @SmokeDolbySettings
Scenario: VAN18509_TestStep04_Dolby_Settings Check tips
	Given supported Dolby machine 
	And go to Audio section
	When click the entertainment question mark
	Then it will show a textbox to introduce the feature for entertainmenttooltip
	"""
	When this option is selected, Dolby audio automatically adjusts the mode according to the app you are using:<br>• If you are using apps such as iTunes, it changes to the Music mode.<br>• If you are using apps such as Youtube, it changes to the Movie mode.<br>• If you are using gaming apps, it changes to the Gaming mode accordingly.
	"""

@DolbySettings
Scenario: VAN18509_TestStep05_Dolby_Settings Change Mode
	Given go to Audio section
	Given Check the entertainment checkbox
	When open Dolby Atmos Speaker System
	When Play game
	When Take Screen Shot VAN18509_Game IN 18509 under HSScreenShotResult for DolbySettings
	When Play music
	When Take Screen Shot VAN18509_Music IN 18509 under HSScreenShotResult for DolbySettings
	When make a voice connection via Lync or use Voice Recorder
	When Take Screen Shot VAN18509_Voice IN 18509 under HSScreenShotResult for DolbySettings
	When Play movie
	When Take Screen Shot VAN18509_Movie IN 18509 under HSScreenShotResult for DolbySettings

@DolbySettings
Scenario: VAN18509_TestStep06_Dolby_Settings Uncheck 
	Given go to Audio section
	Given uncheck the entertainment checkbox
	When wait 5 seconds
	When Play music
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally
	When Play movie
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally
	When Play game
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally
	When make a voice connection via Lync or use Voice Recorder
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally

@DolbySettings
Scenario: VAN18509_TestStep08_Check Dolby options
	Given go to Audio section
	Given uncheck the entertainment checkbox
	When wait 2 seconds
	Given Check the entertainment checkbox
	Then Dolby options not hidden

@DolbySettings
Scenario: VAN18509_TestStep09 Work Normally
	Given supported Dolby machine 
	And go to Audio section
	When Get Current Dolby Mode Name
	When switch pages
	Then The Dolby mode should not change and should work normally
	#When reopen Vantage
	When ReLaunch Vantage
	When Get Current Dolby Mode Name
	Then The Dolby mode should not change and should work normally
	When Minimize vantage conservation mode
	Then The Dolby mode should not change and should work normally
	When resize Vantage
	Then The Dolby mode should not change and should work normally

@DolbySettings
Scenario: VAN18509_TestStep10 checkbox status
	Given supported Dolby machine 
	And go to Audio section
	Given Check the entertainment checkbox
	Given Install Vantage
	Given supported Dolby machine 
	And go to Audio section
	Then The entertainment checkbox is unchecked

@DolbySettings
Scenario: VAN18509_TestStep11 checkbox status
	Given supported Dolby machine 
	And go to Audio section
	Given uncheck the entertainment checkbox
	Given Install Vantage
	Given supported Dolby machine
	And go to Audio section
	Then The entertainment checkbox is unchecked

#@DolbySettings
Scenario: VAN18509_TestStep12 check performance 
	Given supported Dolby machine 
	And go to Audio section
	Then The entertainment checkbox is unchecked
	Then The UI should show completely in 2 seconds

#@DolbySettings
Scenario: VAN18509_TestStep13 Check Metrics
    Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture 
	Given supported Dolby machine 
	And go to Audio section
	Given Check the entertainment checkbox
	Given clear data
	Given uncheck the entertainment checkbox
	Then the metric data is as expected with Test VAN18509 and Name Dolby.OptimizeCheckout.Off and Timeout 20
	Then The entertainment checkbox is unchecked
	Given Stop Capture