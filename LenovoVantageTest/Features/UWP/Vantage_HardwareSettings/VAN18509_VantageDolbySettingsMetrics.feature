Feature: VAN18509_VantageDolbySettingsMetrics
	Test Case： https://jira.tc.lenovo.com/browse/VAN-18509
	Author： Jinxin Li

#@DolbySettings
Scenario: VAN18509_DolbySettings_A_BeforeTest
    Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture

#@DolbySettings
Scenario: VAN18509_DolbySettings_send metrics data with on
	And go to Audio section
	Given Check the entertainment checkbox
	Given clear data
	Given uncheck the entertainment checkbox
	Then the metric data is contains with Test VAN18509 and Name Dolby.OptimizeCheckout.Off and Timeout 20

#@DolbySettings
Scenario: VAN18509_DolbySettings_Z_Resandbox
	Given Stop Capture