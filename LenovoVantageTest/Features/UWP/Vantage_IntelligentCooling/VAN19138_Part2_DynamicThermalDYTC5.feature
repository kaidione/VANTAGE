Feature: VAN19138_Part2_DynamicThermalDYTC5
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-19138
	Author ：fengya2

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep10_DC Mode:Slider Power Slider to Battery saver
	Given DC Condition(Connect the Adapter)
	Given turn on narrator
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then check toolbar DYTC status Quiet mode

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep11_DC Mode:Slider Power Slider to Battery saver and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 11 in 19138 under ITSScreenShotResult
	Given launch toolbar

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep12_DC Mode:Slider Power Slider to Better battery
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep13_DC Mode:Slider Power Slider to Better battery and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When hover toolbar
	Then  Take Screen Shot 13 in 19138 under ITSScreenShotResult
	Given launch toolbar

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep14_DC Mode:Slider Power Slider to Better performance
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep15_DC Mode:Slider Power Slider to Better performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When hover toolbar
	Then  Take Screen Shot 15 in 19138 under ITSScreenShotResult
	Given launch toolbar

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep16_DC Mode:Slider Power Slider to Best performance
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep17_DC Mode:Slider Power Slider to Best performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 17 in 19138 under ITSScreenShotResult
	Then  turn off narrator

@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep38_check metric data
	Given AC Condition(Connect the Adapter)
	Then  turn off narrator
	Given launch toolbar
	Given delete eventlog
	When click IntelligentCooling link in tool bar
	Then check metric data

@DYTC5ActiveStateUI
Scenario: VAN19138_TestStep39_check heartbeat metric data
	When Close Vantage
    Given Click System Battery  
    Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given delete eventlog
	Given start heartbeat
	Then  read DYTC5 heartbeat eventlog