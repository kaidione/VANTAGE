Feature: VAN19138_Part1_DynamicThermalDYTC5
	DYTC 6.0-Add active state for DYTC5.0/6.0 on BatteryGauge for ThinkPad models
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-19138
	Author ：fengya2


@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep01_check tool bar DYTC5 UI
	Given launch toolbar
	Then  Take Screen Shot 01 in 19138 under ITSScreenShotResult

@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep02_click IntelligentCooling link in tool bar
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then There should have Power Smart settings Jump link

@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep04_AC Mode:Slider Power Slider to Better Battery
	Given turn on narrator
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Quiet mode
	
@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep05_AC Mode:Slider Power Slider to Better Battery and check tips
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 05 in 19138 under ITSScreenShotResult
	Given launch toolbar

@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep06_AC Mode:Slider Power Slider to Better Performance
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	
@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep07_AC Mode:Slider Power Slider to Better Performance and check tips
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When hover toolbar
	Then  Take Screen Shot 07 in 19138 under ITSScreenShotResult
	Given launch toolbar

@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep08_TestStep Mode:Slider Power Slider to Best Performance
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	
@DYTC5ActiveStateUI  
Scenario: VAN19138_TestStep09_AC Mode:Slider Power Slider to Best Performance and check tips
	When Close Vantage
	Given Click System Battery
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 09 in 19138 under ITSScreenShotResult
	Given launch toolbar