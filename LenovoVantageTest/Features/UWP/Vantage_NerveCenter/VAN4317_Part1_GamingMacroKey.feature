Feature: VAN4317_Part1_GamingMacroKey
	Test Case： https://jira.tc.lenovo.com/browse/VAN-4317
	Author: Yang Liu

Background: 
	When Disable the CapsLK lock
	When Kill explorer by processName
	Given Machine is Gaming

@GamingMacroKey @GamingSmokeMacrokeyNumpad
Scenario: VAN4317_TestStep01_Check the macro key sub page show
	When Click the macrokey icon in the System tools area
	Then It will enter the macro key subpage

@GamingMacroKey @GamingSmokeMacrokeyNumpad
Scenario: VAN4317_TestStep02_Check 10 keys can be set as macro key for 17 keyboard layout, only number 0 and M1 are selected for the first time to launch the macro key subpage
	When Click the macrokey icon in the System tools area
	Then Take Screen Shot TestStep02 in 4317 under GamingScreenShotResult
	Then For 17 keyboard layout, they are 10 keys can be set as macro key
	Then As for the first time to launch this subpage, only number 0 and M1 are selected

@GamingMacroKey
Scenario: VAN4317_TestStep03_Check the macro key subpage display nornamlly
	When Click the macrokey icon in the System tools area
	When Drag and drop the macro key subpage window
	Then It will enter the macro key subpage

@GamingMacroKeyS3
Scenario: VAN4317_TestStep04_Enter S3 for a while and resume, Check the macro key subpage display nornamlly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	When Enter sleep
	When The user connect or disconnect WiFi on lenovo
	Then Take Screen Shot TestStep04 in 4317 under GamingScreenShotResult
	Then It will enter the macro key subpage

@GamingMacroKeyS4
Scenario: VAN4317_TestStep05_Enter S4 for a while and resume, Check the macro key subpage display nornamlly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	When Enter hibernate
	When Take Screen Shot TestStep05 in 4317 under GamingScreenShotResult
	Then It will enter the macro key subpage

@GamingMacroKey
Scenario: VAN4317_TestStep06_Check "abcdefg" will be output whenever "3" is pressed.
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "abcdefg"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "abcdefg" will be output whenever "3" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep07_Check the Macro key only works in game
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "asdf1234"
	Given Click the STOP RECORDING button 
	When Set to "Enabled Only When Gaming" option
	Then "3" will be output whenever "3" is pressed
	When Launch the specifie game GameWorldOfWarcraft
	Then "asdf1234" will be output whenever "3" is pressed
	When Stop the specified app GameWorldOfWarcraft

@GamingMacroKey
Scenario: VAN4317_TestStep08_Check "3" will be output whenever "3" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "abcd1234"
	Given Click the STOP RECORDING button 
	When Set to "Off" option
	Then "3" will be output whenever "3" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep09_Check the macrokey subpage display is consistent with the keys entered
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep09_1 in 4317 under GamingScreenShotResult
	When Scroll the screen in macrokey subpage
	Then Take Screen Shot TestStep09_2 in 4317 under GamingScreenShotResult

@GamingMacroKey
Scenario: VAN4317_TestStep10_Check the macrokey subpage display is consistent with the keys entered
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "^{+}%{+}{ESC}{+}"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep10_1 in 4317 under GamingScreenShotResult
	When Scroll the screen in macrokey subpage
	Then Take Screen Shot TestStep10_2 in 4317 under GamingScreenShotResult
	Given Click the START RECORDING button
	Given Type in "{+}{UP}{RIGHT}{DOWN}{LEFT}"
	Given Click the STOP RECORDING button 
	Then Take Screen Shot TestStep10_3 in 4317 under GamingScreenShotResult

@GamingMacroKey
Scenario: VAN4317_TestStep11_Check that the binding number 3 is consistent with SPEC before recording, during recording and end record
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Then Check that the binding number "3" is consistent with SPEC before recording
	Given Click the START RECORDING button
	Given Type in "asdfg"
	Then Take Screen Shot TestStep11 in 4317 under GamingScreenShotResult
	Given Click the STOP RECORDING button 
	Then Check that the binding number "3" is consistent with SPEC end record

@GamingMacroKey
Scenario: VAN4317_TestStep12_Check "123abc~!@" will be output whenever "0" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 0
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "123abc~!@" will be output whenever "0" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep13_Check "456defg#$%456defg#$%" will be output whenever "1" is pressed twice
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 1
	Given Click the START RECORDING button
	Given Type in "456defg#${%}"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "456defg#$%456defg#$%" will be output whenever "11" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep14_Check "7890HIGH^&*" will be output whenever "2" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 2
	Given Click the START RECORDING button
	Given Type in "7890HIGH{^}&*"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "7890HIGH^&*" will be output whenever "2" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep15_Check "1122I J K L M N" will be output whenever "3" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "1122I J K L M"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "1122I J K L M" will be output whenever "3" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep16_Check "opqr()-+" will be output whenever "4" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 4
	Given Click the START RECORDING button
	Given Type in "opqr{(}{)}-{+}"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "opqr()-+" will be output whenever "4" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep17_Check "STUV'-=/" will be output whenever "5" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 5
	Given Click the START RECORDING button
	Given Type in "STUV'-=/"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "STUV'-=/" will be output whenever "5" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep18_Check "012345~!@#$" will be output whenever "6" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 6
	Given Click the START RECORDING button
	Given Type in "012345{~}!@#$"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "012345~!@#$" will be output whenever "6" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep21_Check the Vantage window will be closed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 9
	Given Click the START RECORDING button
	Given Type in "%{F4}"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then Press the number "9"
	Then The Vantage window will be closed

@GamingMacroKey
Scenario: VAN4317_TestStep23_Check "123abc~!@123abc~!@123abc~!@" will be output whenever "0" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 0
	Given Click the START RECORDING button
	Given Type in "123abc{~}!@"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	When Click the "Repeat time" drop-down arrow and select "Repeat 3 times"
	Then "123abc~!@123abc~!@123abc~!@" will be output whenever "0" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep24_Check the number of characters output is consistent with the setting
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 1
	Given Click the START RECORDING button
	Given Type in "zxcvb"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	When Click the "Repeat time" drop-down arrow and select "Repeat 2 times"
	Then "zxcvbzxcvb" will be output whenever "1" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep25_Check display effect under keep or ignore interval times option
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 2
	Given Click the START RECORDING button
	Given Type in "1234qwer" with interval "1" seconds
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then Check if "1234qwer" will be output in "10" seconds whenever "2" is pressed and "Keep Delay" is selected
	When Click the "Delay status" drop-down arrow and select "Ignore Delay"
	Then Check if "1234qwer" will be output in "2.5" seconds whenever "2" is pressed and "Ignore Delay" is selected

@GamingMacroKey
Scenario: VAN4317_TestStep26_Check whether macro keys can be recorded properly
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 0
	Given Click the START RECORDING button
	Given Type in "123"
	Given Click the STOP RECORDING button
	Given Select the number 1
	Given Click the START RECORDING button
	Given Type in "qwe"
	Given Click the STOP RECORDING button
	Given Select the number 2
	Given Click the START RECORDING button
	Given Type in "asd"
	Given Click the STOP RECORDING button
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "zxc"
	Given Click the STOP RECORDING button
	Given Select the number 4
	Given Click the START RECORDING button
	Given Type in "456"
	Given Click the STOP RECORDING button
	Given Select the number 5
	Given Click the START RECORDING button
	Given Type in "rty"
	Given Click the STOP RECORDING button
	Given Select the number 6
	Given Click the START RECORDING button
	Given Type in "fgh"
	Given Click the STOP RECORDING button
	Given Select the number 7
	Given Click the START RECORDING button
	Given Type in "vbn"
	Given Click the STOP RECORDING button
	Given Select the number 8
	Given Click the START RECORDING button
	Given Type in "789"
	Given Click the STOP RECORDING button
	Given Select the number 9
	Given Click the START RECORDING button
	Given Type in "uio"
	Given Click the STOP RECORDING button
	When Set to "Always Enable" option
	Then "123qweasdzxc456rtyfghvbn789uio" will be output whenever "0123456789" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep27_Check "11111abcde~!@#$" will be output whenever "123" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 1
	Given Click the START RECORDING button
	Given Type in "11111"
	Given Click the STOP RECORDING button 
	Given Select the number 2
	Given Click the START RECORDING button
	Given Type in "abcde"
	Given Click the STOP RECORDING button 
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "{~}!@#$"
	Given Click the STOP RECORDING button 
	When Set to "Always Enable" option
	Then "11111abcde~!@#$" will be output whenever "123" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep28_Check if there will pop-up the clear window and the characters recorded under number 5 are cleared
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 5
	Given Click the START RECORDING button
	Given Type in "AAAAAbbbb"
	Given Click the STOP RECORDING button 
	Given Click the CLEAR button under the macro key subpage.
	Then Check if there will pop-up the clear window
	Then Check that the characters recorded under number are cleared

@GamingMacroKey
Scenario: VAN4317_TestStep29_Check "ABCDEFG" will be output whenever "3" is pressed
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "abcdefg"
	Given Click the STOP RECORDING button
	When Set to "Always Enable" option	
	When If Disabled Enable The CapsLK Lock
	Then "ABCDEFG" will be output whenever "3" is pressed
	When Disable the CapsLK lock

@GamingMacroKey
Scenario: VAN4317_TestStep32_Check that "Time Out For Recording" window will pop up, recording stopped and 123456 will not be saved
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "123456"
	Given Waiting 10 seconds
	Then Pop up the Time Out For Recording window
	Then Go back to empty state after clicking OK

@GamingMacroKey
Scenario: VAN4317_TestStep33_Check Show time out dialog if no input for 20s, and go back to empty state after clicking OK or "x" button, the dialog box matches the UI SPEC design
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Waiting 20 seconds
	Then Show time out dialog if no input for 20s
	Then Take Screen Shot TestStep33 in 4317 under GamingScreenShotResult
	Then Go back to empty state after clicking OK for 20s dialog

@GamingMacroKey
Scenario: VAN4317_TestStep34_Check if no key is pressed, click stop recording to cancel
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Click the STOP RECORDING button
	Then The recording is canceled

@GamingMacroKey
Scenario: VAN4317_TestStep35_Check whether scrollbars appear in the subpage interface
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "qwertyuiopasdf"
	Given Click the STOP RECORDING button
	When Click the "Repeat time" drop-down arrow
	Then Take Screen Shot TestStep35_TimeoutDialog35 in 4317 under GamingScreenShotResult

@GamingMacroKey
Scenario: VAN4317_TestStep36_Check if key action reaches 40, the dialog shows, clicking OK or x to finish recording, the dialog box matches the UI SPEC design
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	Given Type in "1234567890qwertyuiop"
	Then The Maximum Input Reached dialog shows when key action reaches 40
	Then Take Screen Shot TestStep_36 in 4317 under GamingScreenShotResult
	Then clicking OK in Maximum Input Reached dialog to finish recording

@GamingMacroKey
Scenario: VAN4317_TestStep37_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 4
	Given Click the START RECORDING button
	Given Type in "123abc"
	When Click the macrokey icon in the System tools area
	Given Select the number 4
	Then The recording is canceled

@GamingMacroKey
Scenario: VAN4317_TestStep38_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 5
	Given Click the START RECORDING button
	Given Type in "2222aaaa"
	When Minimized vantage
	Then The recording is canceled

@GamingMacroKey
Scenario: VAN4317_TestStep39_Check the delete icons shows when hovering the row, when hovering on the delete icon a hovertip will show，clicking the icon and both rows of pressing and releasing will be deleted
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 5
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	Given Click the STOP RECORDING button
	When Hovering the c row
	Then Take Screen Shot TestStep39_1 in 4317 under GamingScreenShotResult
	When Hovering on the delete icon
	Then Take Screen Shot TestStep39_1 in 4317 under GamingScreenShotResult
	Then clicking the icon and both rows of pressing and releasing will be deleted

@GamingMacroKeyS3
Scenario: VAN4317_TestStep40_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 6
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	When Enter sleep
	Then The recording is canceled

@GamingMacroKeyS4
Scenario: VAN4317_TestStep41_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 6
	Given Click the START RECORDING button
	Given Type in "abcdefghigk"
	Given Click The Macro Key Title
	When Enter hibernate
	Then The recording is canceled

@GamingMacroKey
Scenario: VAN4317_TestStep43_Check recording stopped and don't save anything
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 8
	Given Click the START RECORDING button
	Given Type in "111111"
	Given Close Vantage
	Given Launch Vantage for MacroKey
	When Click the macrokey icon in the System tools area
	Given Select the number 8
	Then The recording is canceled

@GamingMacroKey
Scenario: VAN4317_TestStep44_Check the macro key no response
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 6
	Given Click the START RECORDING button
	Given Type in "qwerty"
	Given Click the STOP RECORDING button
	When Set to "Always Enable" option	
	When Stop the IMC service in the task manager
	Then "6" will be output whenever "6" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep45_Check the macro key no response
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Select the number 7
	Given Click the START RECORDING button
	Given Type in "asdfgh"
	Given Click the STOP RECORDING button
	When Set to "Always Enable" option	
	When Stop the IMC service in the task manager
	Then "7" will be output whenever "7" is pressed

@GamingMacroKey
Scenario: VAN4317_TestStep46_Check the macro key page should be shown and recording will not be stopped
	Given Machine is Gaming
	When Click the macrokey icon in the System tools area
	Given Click the START RECORDING button
	When Click start Vantage
	Then The macro key page should be shown and recording will not be stopped
