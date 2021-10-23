Feature: VAN21724_Part2_X50HomepageOClabel
	Test Case: https://jira.tc.lenovo.com/browse/VAN-21724
	Author: Jinxin Li
	
Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)

@X50HomepageGetOCValues
Scenario: VAN21724_TestStep02_unchecked Performance not display OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is unchecked
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display not OC values

@X50HomepageGetOCValues
Scenario: VAN21724_TestStep04_unchecked Quiet not display OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is unchecked
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display not OC values
	 
@X50HomepageGetOCValues
Scenario: VAN21724_TestStep06_unchecked Balance not display OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is unchecked
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display not OC values

@X50HomepageGetOCValues
Scenario: VAN21724_TestStep08_checked Performance Display OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display yes OC values

@X50HomepageGetOCValues
Scenario: VAN21724_TestStep10_checked Quiet Not OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display not OC values

@X50HomepageGetOCValues
Scenario: VAN21724_TestStep12_checked Balance Not OC values
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	Given Support Xtu
	When Check the OC values in the tools
	Then It will display not OC values