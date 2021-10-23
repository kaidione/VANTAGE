Feature: VAN17182_Part3_DynamicThermalDYTC6ToolbarNoAMT
	Auto_ITS_FullTestCase_DYTC6-Show active mode and link on Toolbar
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-17182
	Author ：fengya2

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep15_AC mode:Slider Power Slider to Best performance
	Given Close Vantage
	Given AC Condition(Connect the Adapter)
	Given turn on narrator
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1501 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1502 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1503 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep16_AC mode:Slider Power Slider to Better performance
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1601 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1602 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1603 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep17_AC mode:Slider Power Slider to Better battery
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1701 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1702 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1703 in 17182 under ITSScreenShotResult
	Then  turn off narrator
	
@DYTC6NoAMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep18_DC mode:Slider Power Slider to Best performance
	Given DC Condition(Connect the Adapter)
	Given Close Vantage
	Given turn on narrator
	Given Click System Battery 
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1801 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1802 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1803 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep19_DC mode:Slider Power Slider to Better performance
	Given Close Vantage
	Given Click System Battery 
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1901 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1902 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1903 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep20_DC mode:Slider Power Slider to Better battery
	Given Close Vantage
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2001 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2002 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2003 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep21_DC mode:Slider Power Slider to Battery saver
	Given Close Vantage
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2101 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2102 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2103 in 17182 under ITSScreenShotResult
	Then turn off narrator

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep23_AC mode:disconnect network and check toolbar
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	When  The user connect or disconnect WiFi off lenovo
	Given launch toolbar
	Then  Take Screen Shot 2301 in 17182 under ITSScreenShotResult
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2302 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2303 in 17182 under ITSScreenShotResult
	When  The user connect or disconnect WiFi on lenovo

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep24_AC mode:connect network and check toolbar
	Given launch toolbar
	Given Close Vantage
	Then  Take Screen Shot 2401 in 17182 under ITSScreenShotResult
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2402 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2403 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep61_AC mode:unpin toolbar then pin toolbar
	When  unpin toolbar on Taskbar settings
	Given Waiting 2 seconds
	When  pin toolbar on Taskbar settings
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link
	Given turn on narrator
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 6101 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 6102 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 6103 in 17182 under ITSScreenShotResult
	Then  turn off narrator

	

