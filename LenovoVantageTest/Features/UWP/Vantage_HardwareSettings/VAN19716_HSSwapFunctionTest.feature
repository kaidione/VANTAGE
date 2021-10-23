Feature: VAN19716_HSSwapFunctionTest

Auto test case: https://jira.tc.lenovo.com/browse/VAN-21036

For manual testcase: https://jira.tc.lenovo.com/browse/VAN-19716

JIRA task: https://jira.tc.lenovo.com/browse/HAIDIAN-473

Autor：Yingying Li

@IdeaPadNotSupportSwap18
Scenario: VAN19716_TestStep01_Fn and Ctrl key swap feature Not show
	Given IdeaPad machines
	Given Go to input page
	Then Check Fn and Ctrl key swap feature Not show

@ThinkePadNotSupportSwap06
Scenario: VAN19716_TestStep02_Fn and Ctrl key swap feature Not show
	Given Thinkpad machines
	Given Go to input page
	Then Check Fn and Ctrl key swap feature Not show

@ThinkePadSupportSwap @SmokeThinkePadSupportSwap
Scenario: VAN19716_TestStep03_Fn and Ctrl key swap feature Should show
	Given Thinkpad machines
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check Fn and Ctrl key swap feature Should show
	Then Take Screen Shot Step03_FnCtrlSwap in 21426 under HSScreenShotResult

@ThinkePadSupportSwap 
Scenario: VAN19716_TestStep04_Fn and Ctrl key swap feature Should show and check details
	Given Thinkpad machines
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check Fn and Ctrl key swap feature Should show
	Then Take Screen Shot Step04_FnCtrlSwap in 21426 under HSScreenShotResult

@ThinkePadSupportSwap
Scenario: VAN19716_TestStep05_The default state of the toggle for Swap feature is off
	Given Thinkpad machines
	Given Install Vantage
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then The default state of the toggle is off

@ThinkePadSupportSwap
Scenario: VAN19716_TestStep11_The state of the toggle for Swap feature will keep on
	Given Thinkpad machines
	Given Go to input page
	Given Turn on the the toggle for Swap feature
	Given Install Vantage
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is on

@ThinkePadSupportSwap
Scenario: VAN19716_TestStep12_The state of the toggle for Swap feature will keep off
	Given Thinkpad machines
	Given Go to input page
	Given Turn off the the toggle for Swap feature
	Given Install Vantage
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is off

@ThinkePadSupportSwapSleep
Scenario: VAN19716_TestStep14_The default state of the toggle for Swap feature is off
	Given Thinkpad machines
	Given Go to input page
	Given Turn off the the toggle for Swap feature
	When Enter sleep
	When wait 5 seconds
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is off
	When Enter hibernate
	When wait 5 seconds
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is off

@ThinkePadSupportSwap
Scenario: VAN19716_TestStep15_The Fn and Ctrl key swap toggle status will not change when relunch vantage
	Given Thinkpad machines
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Given Turn on the the toggle for Swap feature
	Given Turn off the the toggle for Swap feature
	Then Check the state of the toggle for Swap feature is off
	When Press Win and D to Switch Page
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is off
	Given close lenovo vantage
	Given ReLaunch Lenovo Vantage
	Given Go to input page
	Given Go to Fn and Ctrl key swap section
	Then Check the state of the toggle for Swap feature is off