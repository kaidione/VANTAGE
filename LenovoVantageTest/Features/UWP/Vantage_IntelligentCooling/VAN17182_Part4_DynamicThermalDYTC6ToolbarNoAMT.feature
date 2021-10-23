Feature: VAN17182_Part4_DynamicThermalDYTC6ToolbarNoAMT
	Auto_ITS_FullTestCase_DYTC6-Show active mode and link on Toolbar
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-17182
	Author ：fengya2

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep38_AC mode:set Better performance unplugs then plugs
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given DC Condition(Connect the Adapter)
	Given Waiting 5 seconds
	Given AC Condition(Connect the Adapter)
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given turn on narrator
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3803hover in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep39_AC mode:set Battery saver plugs then unplugs
	Given DC Condition(Connect the Adapter)
	Given Close Vantage
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given AC Condition(Connect the Adapter)
	Given Waiting 5 seconds
	Given DC Condition(Connect the Adapter)
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3903hover in 17182 under ITSScreenShotResult
	Given AC Condition(Connect the Adapter)
	Then  turn off narrator

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep44_AC mode:click IntelligentCooling link in tool bar
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link

@DYTC6NoAMTActiveModeAndLink @DYTC6MWS
Scenario: VAN17182_TestStep45_AC mode:Not install Vantage click IntelligentCooling link in tool bar
	Given Uninstall the lenovo vatage
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  Take Screen Shot 45notinstallvan in 17182 under ITSScreenShotResult
	Given Install Vantage

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep46_AC mode:Not connect network click IntelligentCooling link in tool bar
	When  The user connect or disconnect WiFi off lenovo
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link
	When The user connect or disconnect WiFi on lenovo

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep47_AC mode:connect network click IntelligentCooling link in tool bar
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep53_AC mode:update BatteryGauge plugin check ITS icon
	Given turn on narrator
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 53updatebatterygauge in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Then  Take Screen Shot 5302showicon in 17182 under ITSScreenShotResult
	Given Waiting 8 seconds
	Then  Take Screen Shot 5303hideicon in 17182 under ITSScreenShotResult
	Then  turn off narrator