@VFC1996_Standby
Feature: VFC-1996_StandbyAdPolicy
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1996

@VFC1996_Standby
Scenario: VFC1996_TestStep01_Standby Not show Standby Section after to turn on the toggle and IT changes AdPolicy to enabled
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Select Auto Mode
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should not be visible
	And Check the standby registry value is OFF

@VFC1996_Standby
Scenario: VFC1996_TestStep02_Standby Show Standby Section after IT admin change the AdPolicy to disabled
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Select Auto Mode
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Standby adpolicy is disabled
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should be visible
	And the Smart standby toggle should be OFF

@VFC1996_Standby
Scenario: VFC1996_TestStep03_Standby Show Standby Section with Automatic mode selected after IT admin change the AdPolicy to disabled
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Select Auto Mode
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Standby adpolicy is disabled
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should be visible
	And the Smart standby toggle should be ON
	And the Automatic Mode should be selected

@VFC1996_Standby
Scenario: VFC1996_TestStep04_Standby Show Standby Section after IT admin change the AdPolicy to disabled and not change the toggle state
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Select Auto Mode
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Standby adpolicy is disabled
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	And the standby section should be visible
	And the Smart standby toggle should be ON
	And the Automatic Mode should be selected
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	And the standby section should be visible
	And the Smart standby toggle should be ON
	And the Automatic Mode should be selected

@VFC1996_Standby
Scenario: VFC1996_Standby_Step05 Show Standby Section with manual mode and toggle on selected after IT admin change the AdPolicy to disabled
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Select Manual Mode
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Standby adpolicy is disabled
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	And Turn ON Smart standby toggle
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should be visible
	And the Smart standby toggle should be ON
	And Check if Manual Mode is in selected state

@VFC1996_Standby
Scenario: VFC1996_Standby_Step06 Show Standby Section with manual mode selected after IT admin change the AdPolicy to disabled
	Given Machine Support Smart Standby 2.0
	And Standby adpolicy is disabled
	And Go to Power Page
	And Turn ON Smart standby toggle
	When Standby adpolicy is enabled
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should not be visible
	And Check the standby registry value is OFF

@VFC1996_Standby
Scenario: VFC1996_TestStep07_Standby Not show Standby Section after to turn off the toggle and IT changes AdPolicy to enabled
	Given Machine Support Smart Standby 2.0
	And Go to Power Page
	And Turn OFF Smart standby toggle
	And Standby adpolicy is enabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should not be visible
	And Check the standby registry value is OFF

@VFC1996_Standby
Scenario: VFC1996_TestStep08_Standby Shows Standby Section with toggle off when AdPolicy is disabled
	Given Machine Support Smart Standby 2.0
	And Standby adpolicy is disabled
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	When Turn ON Smart standby toggle
	And Turn OFF Smart standby toggle
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should be visible
	And the Smart standby toggle should be OFF

@VFC1996_Standby
Scenario: VFC1996_TestStep09_Standby Show Standby Section with toggle ON when IT admin changes AdPolicy to Not Configured
	Given Machine Support Smart Standby 2.0
	And Standby adpolicy is not configured
	When Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	When Turn OFF Smart standby toggle
	And Turn ON Smart standby toggle
	And Close Vantage
	And ReLaunch Lenovo Vantage
	And Go to Power Page
	Then the standby section should be visible
	And the Smart standby toggle should be ON