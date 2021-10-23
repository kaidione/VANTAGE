Feature: VFC196_SuppressKeyboardNoise
	Test Case： https://jira.tc.lenovo.com/browse/VFC-196
	Author： Haiye Li

@SuppressKeyboardNoise
Scenario: VFC196_TestStep01_Check title toggle question
	Given go to Audio section
	Given Go to Microphone Panel
	Given voice recognition is unselect
	Then  check title is Suppress Keyboard Noise with an icon in front and a toggle, question mark on the right

@SuppressKeyboardNoise
Scenario: VFC196_TestStep02_Check question text
	Given go to Audio section
	Given Go to Microphone Panel
	Given voice recognition is unselect
	When click the question mark
	Then  it will show a KeystrokeSuppression textbox to introduce the feature
	"""
	Toggle this on to optimize the MIC audio by suppressing keyboard noise.
	"""

@SuppressKeyboardNoise
Scenario: VFC196_TestStep03_Check the toggle is on
	Given go to Audio section
	Given Go to Microphone Panel
	Given voice recognition is unselect
	When  turn on the toggle
	Then  the feature in Realtek Audio Console is on
	Then  the toggle is on 
	
@SuppressKeyboardNoise
Scenario: VFC196_TestStep04_Check toggle is off
	Given go to Audio section
	Given Go to Microphone Panel
	Given voice recognition is unselect
	When  turn off the toggle
	Then  the feature in Realtek Audio Console is off
	Then  the toggle is off

@SuppressKeyboardNoise
Scenario: VFC196_TestStep05_Check the toggle and the UI should not change and the feature should work normally
	Given go to Audio section
	Given Go to Microphone Panel
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

