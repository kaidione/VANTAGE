Feature: VAN13723_SmartStandbyV2FeatureTest
	Test Case： https://jira.tc.lenovo.com/browse/VAN-13723
	Author: Jingting Jia 

@SmartStandby @SmokeSmartStandby
Scenario: VAN13723_TestStep01_Smart Standby Check Feature Description
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	Then Check the Smart Standby Version Two feature description
	#Given Change DPI to 175

@SmartStandby
Scenario: VAN13723_TestStep04_Smart Standby Check feature QuestionMark Description
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Click Smart Standby Version Two Question Mark
	Then Check the Smart Standby Version Two Question tip description

@SmartStandby
Scenario: VAN13723_TestStep05_Smart Standby Check Auto/Manual Radio Mode
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	Then Check the Smart Standby Version Two Computer Schedule Title
	Then Check the Smart Standby Version Two Computer Schedule Manual Options
	Then Check the Smart Standby Version Two Computer Schedule Auto Options

@SmartStandby
Scenario: VAN13723_TestStep07_Smart Standby Check Manual Time/Schedule with regedit
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Days
	Then Check the Smart Standby Version Two Computer Manual Schedule Time
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days

@SmartStandby
Scenario: VAN13723_TestStep08_Smart Standby Check Manual Title text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	Then Check the Smart Standby Version Two Computer Manual Schedule Title

@SmartStandby
Scenario: VAN13723_TestStep09_Smart Standby Check CLICK TO CHANGE LINK
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	Then Check the Smart Standby Version Two Computer Manual Schedule Change Link

@SmartStandby
Scenario:VAN13723_TestStep10_Smart Standby Check Start/End/Schedule DropDown Section
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Start Section
	Then Check the Smart Standby Version Two Computer Manual Schedule End Section
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Section

@SmartStandby
Scenario: VAN13723_TestStep11_Smart Standby Check COLLAPSE link
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Collapse link

@SmartStandby
Scenario: VAN13723_TestStep12_Smart Standby Change the Start/End/Schedule value correctly
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	Then Check the Smart Standby Version Two Computer Manual Schedule Days
	Then Check the Smart Standby Version Two Computer Manual Schedule Time
	Then Check the Smart Standby Start Time
	Then Check the Smart Standby End Time
	Then Check the Smart Standby Schedule Days

@SmartStandby
Scenario: VAN13723_TestStep13_Smart Standby More Then 20 Hours Check
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Get the current Smart Standby Schedule
	When Set a More Than 20 Hours Smart Standby Schedule "2.0"
	Then There is a more than 20 Hours tip
	Given Click Device settings,enter Power page
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one

@SmartStandby
Scenario: VAN13723_TestStep14_Smart Standby User uncheck any day
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Get the current Smart Standby Schedule
	When Uncheck any day
	Then There is a any day tip
	Given Click Device settings,enter Power page
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one

@SmartStandby
Scenario: VAN13723_TestStep15_Smart Standby Start/End/Schedule hidden after user click "Collapse" link
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Click the Collapse link
	Then Check if there has the Smart Standby Version Two Computer Manual Schedule Section

@SmartStandby
Scenario: VAN13723_TestStep16_Smart Standby Cilck "Click to change" link again the value should keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Get the current Smart Standby Schedule
	When Click the Collapse link
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one

@SmartStandby
Scenario: VAN13723_TestStep17_Smart Standby Turn off Smart Standby toggle all element in grey-out state
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn off Smart Standby Version Two toggle
	Then Take Screen Shot 17 in 13723 under HSScreenShotResult

@SmartStandby
Scenario: VAN13723_TestStep18_Smart Standby Turn on Smart Standby toggle again all the value will keep the preivous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Get the current Smart Standby Schedule
	When Turn off Smart Standby Version Two toggle
	When Turn on Smart Standby Version Two toggle
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one

@SmartStandby
Scenario: VAN13723_TestStep19_Smart Standby Turn on Smart Standby toggle again Auto radio button will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Turn off Smart Standby Version Two toggle
	When Turn on Smart Standby Version Two toggle
	#Then Check if Manual Mode is in selected state
	Then Check if Automatic Mode is in unselected state

@SmartStandby
Scenario: VAN13723_TestStep20_Smart Standby Check usage and applied active time link text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	Then Check Graph link

@SmartStandby
Scenario: VAN13723_TestStep21_Smart Standby Check Activity and Active time windows
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click Graph link
	Then Check the Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep22_Smart Standby Check two chart title text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click Graph link
	Then Check the Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep23_Smart Standby Click "Close" and "X" to close the pupped-up windows
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click Graph link
	When Close the Usage Graph
	Then There is no Usage Graph
	When Click Graph link
	When CloseX the Usage Graph
	Then There is no Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep24_Smart Standby Check the active chart under manual mode
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	Then Take Screen Shot 24Old in 13723 under HSScreenShotResult
	When Click Graph link
	Then Take Screen Shot 24New in 13723 under HSScreenShotResult
	When Close the Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep25_Smart Standby Check the active chart under manual mode after change value
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Click the Collapse link
	When Click Smart Standby Version Two Question Mark
	Then Take Screen Shot 25Old in 13723 under HSScreenShotResult
	When Click Graph link
	Then Take Screen Shot 25New in 13723 under HSScreenShotResult
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep26_TestStep31_Smart Standby 8301200200500 Usage Data Chart follow SPEC
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When There is not enough data in Machine
	When User use the machine during 830121417 under 2631 step
	When Restart the Smart Standby Schedule Task
	When Select Auto Mode
	When Click Graph link
	When Take Screen Shot 2631UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 2631ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	Then Check if the SmartActiveHours Match the _smartActiveHours830 SPEC
	Then The 2631UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 2631UsageSPEC IN 13723 under HSScreenShotResult And Write log to report 
	Then The 2631ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 2631ActiveSPEC IN 13723 under HSScreenShotResult And Write log to report 

@SmartStandbyTask86
Scenario: VAN13723_TestStep27_TestStep32_Smart Standby 10121322 Usage Data Chart follow SPEC
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When There is not enough data in Machine
	When User use the machine during 10121322 under 2732 step
	When Restart the Smart Standby Schedule Task
	When Select Auto Mode
	When Click Graph link
	When Take Screen Shot 2732UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 2732ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	Then Check if the SmartActiveHours Match the _smartActiveHours10 SPEC
	Then The 2732UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 2732UsageSPEC IN 13723 under HSScreenShotResult And Write log to report 
	Then The 2732ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 2732ActiveSPEC IN 13723 under HSScreenShotResult And Write log to report 

@SmartStandbyTask86
Scenario: VAN13723_TestStep28_TestStep33_Smart Standby 9121318 Usage Data Chart follow SPEC
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When There is not enough data in Machine
	When User use the machine during 9121318 under 2833 step
	When Restart the Smart Standby Schedule Task
	When Select Auto Mode
	When Click Graph link
	When Take Screen Shot 2833UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 2833ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	Then Check if the SmartActiveHours Match the _smartActiveHours9 SPEC
	Then The 2833UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 2833UsageSPEC IN 13723 under HSScreenShotResult And Write log to report 
	Then The 2833ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 2833ActiveSPEC IN 13723 under HSScreenShotResult And Write log to report 

@SmartStandbyTask86
Scenario: VAN13723_TestStep29_Smart Standby Check Not enough Data tip text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Auto Mode
	When There is not enough data in Machine
	When Restart the Smart Standby Schedule Task
	When Click Graph link
	Then Check the Not Enough Usage data Tip
	When Close the Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep30_Smart Standby Check auto mode tip text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Auto Mode
	Then Check Auto mode tip
	Then Check there is no Manual Mode section

@SmartStandbyTask86
Scenario: VAN13723_TestStep31_Smart Standby 8301200200500 Usage Data Chart follow SPEC
	When Only Print 'Please check TestStep26'

@SmartStandbyTask86
Scenario: VAN13723_TestStep32_Smart Standby 10121322 Usage Data Chart follow SPEC
	When Only Print 'Please check TestStep27'

@SmartStandbyTask86
Scenario: VAN13723_TestStep33_Smart Standby 9121318 Usage Data Chart follow SPEC
	When Only Print 'Please check TestStep28'

@SmartStandbyTask86
Scenario: VAN13723_TestStep37_Smart Standby Switch back form Manual chart will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Auto Mode
	When There is not enough data in Machine
	When User use the machine during 10121322 under 2732 step
	When Restart the Smart Standby Schedule Task
	When Click Graph link
	When Take Screen Shot 37UsagePrevious IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 37ActivePrevious IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	When Select Manual Mode
	When Select Auto Mode
	When Click Graph link
	When Take Screen Shot 37UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 37ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	Then Check if the SmartActiveHours Match the previous value
	Then The 37UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 37UsagePrevious IN 13723 under HSScreenShotResult And Write log to report 
	Then The 37ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 37ActivePrevious IN 13723 under HSScreenShotResult And Write log to report 
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep38_Smart Standby turn on againe chart/mode will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Auto Mode
	When There is not enough data in Machine
	When User use the machine during 10121322 under 2732 step
	When Restart the Smart Standby Schedule Task
	When Click Graph link
	When Take Screen Shot 38UsagePrevious IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 38ActivePrevious IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	When Turn off Smart Standby Version Two toggle 
	When Turn on Smart Standby Version Two toggle
	Then Automatic mode is in ON state
	When Click Graph link
	When Take Screen Shot 38UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 38ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	Then Check if the SmartActiveHours Match the previous value
	Then The 38UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 38UsagePrevious IN 13723 under HSScreenShotResult And Write log to report 
	Then The 38ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 38ActivePrevious IN 13723 under HSScreenShotResult And Write log to report 
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep39_Smart Standby Check Not enough Data and Chart
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When There is not enough data in Machine
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 0
	When Select Auto Mode
	When Click Graph link
	Then Take Screen Shot 39BlankChart in 13723 under HSScreenShotResult
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep40_Smart Standby Check Not enough Data tip text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When There is not enough data in Machine
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 0
	When Select Auto Mode
	When Click Graph link
	Then Check the Not Enough Usage data Tip
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep41_Smart Standby Check there is no Not enough Data tip Chart
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When There is not enough data in Machine
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 0
	When Select Auto Mode
	When User use the machine during 10121322 under 2732 step
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 1
	When Click Graph link
	Then Take Screen Shot 41NotBlankChart in 13723 under HSScreenShotResult
	When Close the Usage Graph

@SmartStandbyTask86
Scenario: VAN13723_TestStep42_Smart Standby Check  there is no Not enough Data tip text
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When There is not enough data in Machine
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 0
	When Select Auto Mode
	When User use the machine during 10121322 under 2732 step
	When Restart the Smart Standby Schedule Task
	When Get the related Regedit value before we closed Vantage
	Then Check if the DateSufficient value is 1
	When Click Graph link
	Then There is no Not Engouth Date Tip
	When Close the Usage Graph

@SmartStandby
Scenario: VAN13723_TestStep43_Smart Standby Select Manual mode again check the value will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Get the current Smart Standby Schedule
	When Select Auto Mode
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one

@SmartStandbyReinstall
Scenario: VAN13723_TestStep45_Smart Standby Reinstall Vantage check the value will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Get the current Smart Standby Schedule
	When Select Auto Mode
	When Get the related Regedit value before we closed Vantage
	When Click Graph link
	When Take Screen Shot 45UsagePrevious IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 45ActivePrevious IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	Given Uninstall the lenovo vatage
	Given Install Vantage
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	Then Check the Mode ManualTime ManualSchedule AutoTime Keep the previous one
	When Click Graph link
	When Take Screen Shot 45UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 45ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	Then Check if the SmartActiveHours Match the previous value
	Then The 45UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 45UsagePrevious IN 13723 under HSScreenShotResult And Write log to report 
	Then The 45ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 45ActivePrevious IN 13723 under HSScreenShotResult And Write log to report 
	When Close the Usage Graph
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one
	
@SmartStandby
Scenario: VAN13723_TestStep46_Smart Standby Restart Vantage check the value will keep the previous one
	Given Machine Support Smart Standby 2.0
	And Click Device settings,enter Power page
	When Go to Smart Standby section
	When Turn on Smart Standby Version Two toggle
	When Select Manual Mode
	When Click the Change Drop Down link
	When Set a new Smart Standby Schedule "2.0" and "save"
	When Get the current Smart Standby Schedule
	When Select Auto Mode
	When Get the related Regedit value before we closed Vantage
	When Click Graph link
	When Take Screen Shot 46UsagePrevious IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 46ActivePrevious IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	When Get the SmartActiveHours Regedit Value
	When Close the Usage Graph
	When ReLaunch Vantage
	Given Go to My Device Settings page
	When Go to Smart Standby section
	Then Check the Mode ManualTime ManualSchedule AutoTime Keep the previous one
	When Click Graph link
	When Take Screen Shot 46UsageCurrent IN 13723 under HSScreenShotResult for usageComputer-chartContainer
	When Take Screen Shot 46ActiveCurrent IN 13723 under HSScreenShotResult for appliedActiveTime-chartContainer
	Then Check if the SmartActiveHours Match the previous value
	Then The 46UsageCurrent IN 13723 under HSScreenShotResult keep the same with the 46UsagePrevious IN 13723 under HSScreenShotResult And Write log to report 
	Then The 46ActiveCurrent IN 13723 under HSScreenShotResult keep the same with the 46ActivePrevious IN 13723 under HSScreenShotResult And Write log to report 
	When Close the Usage Graph
	When Select Manual Mode
	When Click the Change Drop Down link
	Then Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one
	Then Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one
	
