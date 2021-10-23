Feature: VAN15463_Part2_HSIdeaBacklight_Metrics
	Test Case： https://jira.tc.lenovo.com/browse/VAN-15463
	JIRA Task: https://jira.tc.lenovo.com/browse/HAIDIAN-494
	Author： Yang Liu
	Update: Yingying Li

#@IdeaBacklight @Debug
Scenario: VAN15463_Part2_A_BeforeTest
    Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture 

#@IdeaBacklight @Debug
Scenario: VAN15463_Part2_TestStep25_Check the keyboard backlight toggle should send metrics data with on
	Given Maxmize Vantage
	Given Go to My Device Settings page
	Given Go to input page
	When Turn off the toggle of keyboard backlight feature
	Given clear data
	When Clikck the toggle of keyboard backlight feature
	Then the metric data is as expected with Test VAN15463 and Name ItemValueOn and Timeout 20

#@IdeaBacklight @Debug
Scenario: VAN15463_Part2_TestStep27_Check the keyboard backlight toggle should send metrics data with on
	Given Maxmize Vantage
	Given Go to My Device Settings page
	Given Go to input page
	When Turn on the toggle of keyboard backlight feature
	Given clear data
	When Clikck the toggle of keyboard backlight feature
	Then the metric data is as expected with Test VAN15463 and Name ItemValueOff and Timeout 20

#@IdeaBacklight @Debug
Scenario: VAN15463_Part2_Z_Resandbox
	Given Stop Capture