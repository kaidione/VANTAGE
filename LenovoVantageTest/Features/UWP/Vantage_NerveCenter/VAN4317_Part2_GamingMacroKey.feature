Feature: VAN4317_Part2_GamingMacroKey
	Test Case： https://jira.tc.lenovo.com/browse/VAN-4317
	Author: Yang Liu

Background: 
	When Disable the CapsLK lock
	When Kill explorer by processName

@GamingMacroKey15InchKeyboardLayout 
Scenario: VAN4317_TestStep49_Check the macro key sub page show for 15 keyboard layout
	Given Machine is Gaming
	Given Launch Vantage for MacroKey
	When Click the macrokey icon in the System tools area
	Then It will enter the macro key subpage

@GamingMacroKey15InchKeyboardLayout @GamingSmokeMacrokeyMkey
Scenario: VAN4317_TestStep50_Check 10 keys can be set as macro key for 17 keyboard layout, only number 0 and M1 are selected for the first time to launch the macro key subpage
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Then Take Screen Shot TestStep50 in 4317 under GamingScreenShotResult
	Then For 17 keyboard layout, they are 10 keys can be set as macro key
	Then As for the first time to launch this subpage, only number 0 and M1 are selected

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep51_Check the macro key subpage display nornamlly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	When Drag and drop the macro key subpage window
	Then It will enter the macro key subpage

@GamingMacroKey15InchKeyboardLayoutS3
Scenario: VAN4317_TestStep52_Enter S3 for a while and resume, Check the macro key subpage display nornamlly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	When Enter sleep
	Then Take Screen Shot TestStep52 in 4317 under GamingScreenShotResult
	Then It will enter the macro key subpage

@GamingMacroKey15InchKeyboardLayoutS4
Scenario: VAN4317_TestStep53_Enter S4 for a while and resume, Check the macro key subpage display nornamlly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	When Enter hibernate
	Then Take Screen Shot TestStep53 in 4317 under GamingScreenShotResult
	Then It will enter the macro key subpage

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep54_Check the macrokey subpage display is consistent with the keys entered
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep54_1 in 4317 under GamingScreenShotResult
	When Scroll the screen in macrokey subpage
	Then Take Screen Shot TestStep54_2 in 4317 under GamingScreenShotResult

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep55_Check the macrokey subpage display is consistent with the keys entered
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "^{+}%{+}{ESC}{+}"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep55_1 in 4317 under GamingScreenShotResult
	When Scroll the screen in macrokey subpage
	Then Take Screen Shot TestStep55_2 in 4317 under GamingScreenShotResult
	Given Click the START RECORDING button
	Given Type in "{+}{UP}{RIGHT}{DOWN}{LEFT}"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep55_3 in 4317 under GamingScreenShotResult

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep56_Check that the binding number 3 is consistent with SPEC before recording, during recording and end record
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Then Check that the binding number "M2" is consistent with SPEC before recording
	Given Click the START RECORDING button
	Given Type in "asdfg"
	Then Take Screen Shot TestStep56 in 4317 under GamingScreenShotResult
	Given Click the STOP RECORDING button 
	Then Check that the binding number "M2" is consistent with SPEC end record

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep57_Check "123abc~!@" will be output whenever "M1" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	Then "123abc~!@" will be output whenever "M1" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep58_Check "7890HIGH^&*" will be output whenever "M2" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "7890HIGH{^}&*"
	Given Click the STOP RECORDING button 
	Then "7890HIGH^&*" will be output whenever "M2" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep59_Check "STUV'-=/" will be output whenever "M1" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "STUV'-=/"
	Given Click the STOP RECORDING button 
	Then "STUV'-=/" will be output whenever "M1" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep60_Check "012345~!@#$" will be output whenever "M2" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "012345{~}!@#$"
	Given Click the STOP RECORDING button 
	Then "012345~!@#$" will be output whenever "M2" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep63_Check the Vantage window will be closed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "%{F4}"
	Given Click the STOP RECORDING button 
	Then Press the number "M1"
	Then The Vantage window will be closed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep65_Check "123abc~!@123abc~!@123abc~!@" will be output whenever "M1" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	When Click the "Repeat time" drop-down arrow and select "Repeat 3 times"
	Then "123abc~!@123abc~!@123abc~!@" will be output whenever "M1" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep66_Check the number of characters output is consistent with the setting
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "zxcvb"
	Given Click the STOP RECORDING button 
	When Click the "Repeat time" drop-down arrow and select "Repeat 2 times"
	Then "zxcvbzxcvb" will be output whenever "M1" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep67_Check display effect under keep or ignore interval times option
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "1234qwer" with interval "1" seconds
	Given Click the STOP RECORDING button 
	Then Check if "1234qwer" will be output in "10" seconds whenever "M2" is pressed and "Keep Delay" is selected
	When Click the "Delay status" drop-down arrow and select "Ignore Delay"
	Then Check if "1234qwer" will be output in "2.5" seconds whenever "M2" is pressed and "Ignore Delay" is selected

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep68_Check if there will pop-up the clear window and the characters recorded under numpad M1 are cleared
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "AAAAAbbbb"
	Given Click the STOP RECORDING button 
	Given Click the CLEAR button under the macro key subpage.
	Then Check if there will pop-up the clear window
	Then Check that the characters recorded under number are cleared

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep69_Check "ABCDEFG" will be output whenever "M2" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "abcdefg"
	Given Click the STOP RECORDING button
	When If Disabled Enable The CapsLK Lock
	Then "ABCDEFG" will be output whenever "M2" is pressed
	When Disable the CapsLK lock

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep71_Check that "Time Out For Recording" window will pop up, recording stopped and 123456 will not be saved
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "123456"
	Given Waiting 10 seconds
	Then Pop up the Time Out For Recording window
	Then Go back to empty state after clicking OK

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep72_Check Show time out dialog if no input for 20s, and go back to empty state after clicking OK or "x" button, the dialog box matches the UI SPEC design
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Waiting 20 seconds
	Then Show time out dialog if no input for 20s
    Then Take Screen Shot TestStep72 in 4317 under GamingScreenShotResult
	Then Go back to empty state after clicking OK for 20s dialog

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep73_Check if no key is pressed, click stop recording to cancel
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Click the STOP RECORDING button
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep74_Check whether scrollbars appear in the subpage interface
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "qwertyuiopasdf"
	Given Click the STOP RECORDING button
	When Click the "Repeat time" drop-down arrow
	When Take Screen Shot TestStep74 in 4317 under GamingScreenShotResult

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep75_Check if key action reaches 40, the dialog shows, clicking OK or x to finish recording, the dialog box matches the UI SPEC design
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "1234567890qwertyuiop"
	Then The Maximum Input Reached dialog shows when key action reaches 40
	Then Take Screen Shot TestStep75 in 4317 under GamingScreenShotResult
	Then clicking OK in Maximum Input Reached dialog to finish recording

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep76_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "123abc"
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep77_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "2222aaaa"
	When Minimized vantage
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep78_Check the delete icons shows when hovering the row, when hovering on the delete icon a hovertip will show，clicking the icon and both rows of pressing and releasing will be deleted
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	Given Click the STOP RECORDING button
	When Hovering the c row
	Then Take Screen Shot TestStep78_1 in 4317 under GamingScreenShotResult
	When Hovering on the delete icon
	Then Take Screen Shot TestStep78_2 in 4317 under GamingScreenShotResult
	Then clicking the icon and both rows of pressing and releasing will be deleted

@GamingMacroKey15InchKeyboardLayoutS3
Scenario: VAN4317_TestStep79_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	When Enter sleep
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayoutS4
Scenario: VAN4317_TestStep80_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	Given Click The Macro Key Title
	When Enter hibernate
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep82_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "111111"
	Given Close Vantage
	Given Launch Vantage for MacroKey
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Then The recording is canceled

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep83_Check the macro key no response
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "qwerty"
	Given Click the STOP RECORDING button
	When Stop the IMC service in the task manager
	Then "" will be output whenever "M2" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep84_Check the macro key no response
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "asdfgh"
	Given Click the STOP RECORDING button
	When Stop the IMC service in the task manager
	Then "" will be output whenever "M1" is pressed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep85_Check the macro key page should be shown and recording will not be stopped
	Given Machine is Gaming
	Given Pin Lenovo Vantage To Start
	Given Launch Vantage
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	When Click start Vantage
	Then The macro key page should be shown and recording will not be stopped

@GamingNoMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep86_Check the Macro key section will not be displayed because it only supports Y740 sample
	Given Machine is Gaming
	Given Judge gaming machine not support macro key
	Given Open Vantage to the home page
	Then The Macro key section will not be displayed

@GamingMacroKey15InchKeyboardLayout
Scenario: VAN4317_TestStep88_Check the speed of deleting is normally
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number M1
	Given Click the START RECORDING button
	Given Type in "1234567890qwertyuiop"
	Then clicking OK in Maximum Input Reached dialog to finish recording
	Given Select the number M2
	Given Click the START RECORDING button
	Given Type in "1234567890qwertyuiop"
	Then clicking OK in Maximum Input Reached dialog to finish recording
	Then the speed of deleting is normally
