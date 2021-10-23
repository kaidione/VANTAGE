Feature: VAN19138_Part4_DynamicThermalDYTC6
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-19138
	Author ：fengya2

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep29_DC Mode:Slider Power Slider to Battery saver and check tips
	Given DC Condition(Connect the Adapter)
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	When hover toolbar
	Then Take Screen Shot VAN19138_TestStep29 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep30_DC Mode:Slider Power Slider to Better battery
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep31_DC Mode:Slider Power Slider to Better battery and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When hover toolbar
	Then Take Screen Shot VAN19138_TestStep31 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep32_DC Mode:Slider Power Slider to Better performance
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep33_DC Mode:Slider Power Slider to Better performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When hover toolbar
	Then Take Screen Shot VAN19138_TestStep33 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep34_DC Mode:Slider Power Slider to Best performance
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Ultra-performance mode

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep35_DC Mode:Slider Power Slider to Best performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then Take Screen Shot VAN19138_TestStep35 in 19138 under ITSScreenShotResult
	Then  turn off narrator

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep40_check metric data
	When Close Vantage
	Given AC Condition(Connect the Adapter)
	Then  turn off narrator
	Given launch toolbar
	Given delete eventlog
	When click IntelligentCooling link in tool bar
	Then check metric data

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep41_check heartbeat metric data
	When Close Vantage
    Given Click System Battery  
    Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given delete eventlog
	Given start heartbeat
	Then  read DYTC6 heartbeat eventlog
	
@DYTC6CMActiveStateUI  
Scenario: VAN19138_TestStep42_check metric data
	Then  turn off narrator
	Given launch toolbar
	Given delete eventlog
	When click IntelligentCooling link in tool bar
	Then check metric data

@DYTC6CMActiveStateUI   
Scenario: VAN19138_TestStep43_check heartbeat metric data
	When Close Vantage
    Given Click System Battery  
    Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given delete eventlog
	Given start heartbeat
	Then  read MCDYTC6 heartbeat eventlog
