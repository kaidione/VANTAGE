@CheckLEBatteryChargeThresholdOneBattery
Feature: VAN7219_VFC206_BatteryChargeThresholdThinkPadRegressionTest
	Test Case： https://jira.tc.lenovo.com/browse/VFC-206
	Author： Jinxin Li

Background:
	Given Thinkpad machines
	Given Support Battery Charge Threshold

@CheckLEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep37_Battery Charge Threshold 37
	Given Machine is ThinkPad and enable Temproray mode
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When Turn off Battery Charge threshold
	When Turn On Battery Charge Threshold And Check Message
	When Turn off Battery Charge threshold

@CheckLEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep38_Battery Charge Threshold 38
	Given Machine is ThinkPad and enable Temproray mode
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When Turn off Battery Charge threshold
	When Click Battery Charge Threshold Button
	When Click Battery Charge Threshold Alert Here LinK
	Then Check Click Battery Charge Threshold Alert Here LinK Jump To Web Page

@CheckLEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep39_Battery Charge Threshold 39
	Given Machine is ThinkPad and enable Temproray mode
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When Turn off Battery Charge threshold
	When Click Battery Charge Threshold Button
	When Click Battery Charge Threshold Alert Here LinK
	Then Check Click Battery Charge Threshold Alert Here LinK Jump To Web Page
	When Click Battery Charge Threshold Back LinK
	Then Check Click Back LinK Go Back Battery Charge Threshold Alert Page

@CheckLEBatteryChargeThresholdOneBattery
Scenario: VFC206_TestStep41_Battery Charge Threshold 41
	Given Machine is ThinkPad and enable Temproray mode
	Given Change machine support temporary mode but it is disabled
	Given Go to My Device Settings page
	Given Into Battery Details page
	When There should not show question mark and the link
	Then Restore PI DLS mode Settings
	Then Delete Ini Settings File
	Given close lenovo vantage
	Given Launch Lenovo Vantage
	Given Click Device settings,enter Power page
	Given Click Battery Settings Link
	When Turn off Battery Charge threshold
	When Turn On And Check Battery Charge Threshold PopUp Display On Non Support Battery Temporary Mode system
	When Turn off Battery Charge threshold
	Given Machine is ThinkPad and enable Temproray mode
