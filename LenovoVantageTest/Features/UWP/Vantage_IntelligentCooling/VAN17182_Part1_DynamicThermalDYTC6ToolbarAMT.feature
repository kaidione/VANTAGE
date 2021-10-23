Feature: VAN17182_Part1_DynamicThermalDYTC6ToolbarAMT
	Auto_ITS_FullTestCase_DYTC6-Show active mode and link on Toolbar
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-17182
	Author ：fengya2

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep01_AC mode:Slider Power to Best performance
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given enable AMT
	Given Turn on or off the narrator 'on'
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0101 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0102 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0103 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep02_AC mode:Slider Power to Better performance
	Given enable AMT
	Given Close Vantage
	Given Turn on or off the narrator 'on'
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0201 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0202 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0203 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep03_AC mode:Slider Power to Better battery
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Battery mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0301 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0302 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0303 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep04_DC mode:Slider Power to Best performance
	Given DC Condition(Connect the Adapter)
	Given Close Vantage
	Given enable AMT
	Given Turn on or off the narrator 'on'
	Given Click System Battery 
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0401 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0402 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0403 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep05_DC mode:Slider Power to Better performance
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0501 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0502 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0503 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep06_DC mode:Slider Power to Better battery
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Battery mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0601 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0602 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0603 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep07_DC mode:Slider Power to Battery saver
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Battery mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0701 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0702 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0703 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep08_AC mode:Slider Power to Best performance
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given disable AMT
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0801 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0802 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0803 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep09_AC mode:Slider Power to Better performance
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 0901 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0902 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0903 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep10_AC mode:Slider Power to Better battery
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1001 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1002 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1003 in 17182 under ITSScreenShotResult
	Given Click System Battery 
	Given Turn on or off the narrator 'off'

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep11_DC mode:Slider Power to Best performance
	Given DC Condition(Connect the Adapter)
	Given Close Vantage
	Given disable AMT
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1101 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1102 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1103 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep12_DC mode:Slider Power to Better performance
	Given Turn on or off the narrator 'on'
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1201 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1202 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1203 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep13_DC mode:Slider Power to Better battery
	Given Close Vantage
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1301 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1302 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1303 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink_DC
Scenario: VAN17182_TestStep14_DC mode:Slider Power to Battery saver
	Given Close Vantage
	Given disable AMT
	Given launch toolbar
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 1401 in 17182 under ITSScreenShotResult
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1402 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1403 in 17182 under ITSScreenShotResult
	Given Turn on or off the narrator 'off'

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep22_AC mode:The machine doesn't support DYTC6 and Intelligent Cooling
	Given check AMT supportAmt

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep25_AC mode:reopen toolbar 
	Given AC Condition(Connect the Adapter)
	Given Close Vantage
	Given Turn on or off the narrator 'on'
	Given launch toolbar
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2501 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2502 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2503 in 17182 under ITSScreenShotResult

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep26_AC mode:unpin toolbar then pin toolbar
	When  unpin toolbar on Taskbar settings
	Given Waiting 2 seconds
	When  pin toolbar on Taskbar settings
	Then  Take Screen Shot 26showicon in 17182 under ITSScreenShotResult
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then  There should have Power Smart settings Jump link
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2601 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2602 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2603 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep27:pin toobar within vantage
	Given launch toolbar
	Given Close Vantage
	When  click IntelligentCooling link in tool bar
	Given Close Toolbar Background
	When  Launch the Lenovo Vantage Toolbar
	Then  Take Screen Shot 27showicon in 17182 under ITSScreenShotResult
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 2701 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2702 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2703 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep29_AC mode:change DPI then check toolbar
	Given adjusts window size
	Given Change DPI to 100%
	Given launch toolbar
	Then  Take Screen Shot 2901 in 17182 under ITSScreenShotResult
	Given Change DPI to 150%

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep30_AC mode:restart ITS service then check toolbar
	When  restart ITSservice
	Given Close Vantage
	Given Waiting 180 seconds
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3001 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 3002 in 17182 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 3003 in 17182 under ITSScreenShotResult

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep31_AC mode:stop ITS service then check toolbar
	Given Stop ITS service
	Given Close Vantage
	Given launch toolbar
	Then  ITS not exist in toolbar
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3101 in 17182 under ITSScreenShotResult
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 3102 in 17182 under ITSScreenShotResult
	Given start ITSService
	Given Waiting 180 seconds
	Given Turn on or off the narrator 'off'

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep34:set Best performance unplugs then plugs
	Given enable AMT
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Given DC Condition(Connect the Adapter)
	Given AC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Turn on or off the narrator 'on'
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3403hover in 17182 under ITSScreenShotResult
	Given Click System Battery 

@DYTC6AMTActiveModeAndLink
Scenario: VAN17182_TestStep35:set better battery plugs then unplugs
	Given Close Vantage
	Given DC Condition(Connect the Adapter)
	Given Click System Battery 
	Given AC Condition(Connect the Adapter)
	Given DC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Auto Battery mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3503hover in 17182 under ITSScreenShotResult
	Given Click System Battery 
	Given AC Condition(Connect the Adapter)

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep36:set Better performance unplugs then plugs
	Given disable AMT
	Given Close Vantage
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Click System Battery 
	Given DC Condition(Connect the Adapter)
	Given AC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3603hover in 17182 under ITSScreenShotResult
	Given Click System Battery 

@DYTC6NoAMTActiveModeAndLink
Scenario: VAN17182_TestStep37_AC mode:set Battery saver plugs then unplugs
	Given DC Condition(Connect the Adapter)
	Given Close Vantage
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given AC Condition(Connect the Adapter)
	Given DC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	Given Click System Battery 
	When  hover toolbar
	Then  Take Screen Shot 3703hover in 17182 under ITSScreenShotResult
	Given Click System Battery 
	Given AC Condition(Connect the Adapter)
	Given Turn on or off the narrator 'off'

