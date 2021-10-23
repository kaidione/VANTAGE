Feature: VAN17182_Part2_DynamicThermalDYTC6ToolbarAMT
	Auto_ITS_FullTestCase_DYTC6-Show active mode and link on Toolbar
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-17182
	Author ：fengya2

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep40_AC mode:install vantage and click IC link in toobar
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given enable AMT
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep41_AC mode:uninstall vantage and click IC link in toobar
	Given Uninstall the lenovo vatage
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  Take Screen Shot 41notinstallvan in 17182 under ITSScreenShotResult
	Given Install Vantage

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep42_AC mode:install vantage and click IC link in toobar
	Given disable AMT
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep43_AC mode:uninstall vantage and click IC link in toobar
	Given Uninstall the lenovo vatage
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  Take Screen Shot 43notinstallvan in 17182 under ITSScreenShotResult
	Given Install Vantage

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep54_AC mode:unpin toolbar then pin toolbar
	Given  Turn on or off the narrator 'on'
	When  unpin toolbar on Taskbar settings
	Given Waiting 2 seconds
	When  pin toolbar on Taskbar settings
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 5401 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5402 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 5403 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep55_AC mode:unpin toolbar then switch slider bar
	When  unpin toolbar on Taskbar settings
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5501 in 17182 under ITSScreenShotResult
	When  pin toolbar on Taskbar settings

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep56_AC mode:AC adapter icon should be replaced by ITS icon
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5601 in 17182 under ITSScreenShotResult
	
@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep57_AC mode:The AC adapter icon should be displayed
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5701 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 5702 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep58_AC mode:the Airplane power mode icon should be replaced by ITS icon
	Given Close Vantage
	Given Launch toolbar
	Given Turn on airplane power mode from toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5801 in 17182 under ITSScreenShotResult
	
@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep59_AC mode:The Airplane icon should be displayed
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Then  Take Screen Shot 5901 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 5902 in 17182 under ITSScreenShotResult
	Given Launch toolbar
	Given Turn off airplane power mode from toolbar

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep60_AC mode:all link,mode,icon,hover tips should display correctly
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 6001 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 6002 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 6003 in 17182 under ITSScreenShotResult
	Given  Turn on or off the narrator 'off'

