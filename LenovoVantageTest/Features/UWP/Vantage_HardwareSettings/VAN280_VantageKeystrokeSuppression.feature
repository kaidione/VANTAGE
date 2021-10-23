Feature: VAN280_VantageKeystrokeSuppression
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-280
	Author： Jinxin Li

@MicrophoneKeystroke
Scenario: VAN280_TestStep01_KeystrokeSuppression 01
	Given machines not support keyboard suppress
	Given voice recognition is unselect
	When  check the UI
	Then  there is no such a feature

@MicrophoneKeystroke @SmokeSmokeMicrophoneToggle
Scenario: VAN280_TestStep02_KeystrokeSuppression 02
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  check the UI
	Then  there is a toggle and a question mark

@MicrophoneKeystroke
Scenario: VAN280_TestStep03_KeystrokeSuppression 03
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  click the question mark
	Then  it will show a KeystrokeSuppression textbox to introduce the feature
	"""
	Toggle this on to optimize the MIC audio by suppressing keyboard noise.
	"""

@MicrophoneKeystrokeRealtek
Scenario: VAN280_TestStep04_KeystrokeSuppression 04
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  make a connection		
	When  turn on the toggle
	Then  the feature in Realtek Audio Console is on
	Then  the toggle is on

@MicrophoneKeystrokeRealtek
Scenario: VAN280_TestStep05_KeystrokeSuppression 05
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  make a connection		
	When  turn off the toggle
	Then  the feature in Realtek Audio Console is off
	Then  the toggle is off

@MicrophoneKeystroke
Scenario: VAN280_TestStep06_KeystrokeSuppression 06
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When Get kssuppress toggle state
	When Switch vantage page KeystrokeSuppression
	Then  the toggle should not change and the feature should work normally
	When Get kssuppress toggle state
	When Relaungh vantage page KeystrokeSuppression
	Then  the toggle should not change and the feature should work normally
	When Get kssuppress toggle state
	When Minimize vantage page KeystrokeSuppression
	Then  the toggle should not change and the feature should work normally

@MicrophoneKeystroke
Scenario: VAN280_TestStep07_KeystrokeSuppression 07
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When Get kssuppress toggle state
	When enter sleep
	Then the toggle should not change and the feature should work normally
	When Get kssuppress toggle state
	When enter hibernate
	Then the toggle should not change and the feature should work normally

#@MicrophoneKeystroke
Scenario: VAN280_TestStep09_KeystrokeSuppression 09
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  check performance test
	Then  The UI should show in 2 seconds

#@MicrophoneKeystroke
Scenario: VAN280_TestStep10_KeystrokeSuppression 10
	Given machines support keyboard suppress
	Given go to keyboard suppress
	Given voice recognition is unselect
	When  check metrics data test
	Then  The toggle button should send metrics data normally