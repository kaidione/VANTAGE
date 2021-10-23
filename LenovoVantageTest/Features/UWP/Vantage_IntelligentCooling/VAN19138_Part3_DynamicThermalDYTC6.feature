Feature: VAN19138_Part3_DynamicThermalDYTC6
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-19138
	Author ：fengya2


@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep19_check tool bar DYTC6 UI
	Given launch toolbar
	Then Take Screen Shot VAN19138_TestStep19 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep20_click IntelligentCooling link in tool bar
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then There should have Power Smart settings Jump link

@DYTC6MWSActiveStateUI 
Scenario: VAN19138_TestStep21_Not install Vantage click IntelligentCooling link in tool bar
	Given Uninstall the lenovo vatage
	Given launch toolbar
	When  click IntelligentCooling link in tool bar
	Then Take Screen Shot VAN19138_TestStep21 in 19138 under ITSScreenShotResult
	Given Install Vantage

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep22_AC Mode:Slider Power Slider to Better Battery
	Given AC Condition(Connect the Adapter)
	When Close Vantage
	Given turn on narrator
	Given Click System Battery  
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Balanced mode
	
@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep23_AC Mode:Slider Power Slider to Better Battery and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When  hover toolbar
	Then Take Screen Shot VAN19138_TestStep23 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep24_AC Mode:Slider Power Slider to Better Performance
	When Close Vantage
	Given Click System Battery  
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Performance mode
	
@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep25_AC Mode:Slider Power Slider to Better Performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When hover toolbar
	Then Take Screen Shot VAN19138_TestStep25 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep26_TestStep Mode:Slider Power Slider to Best Performance
	When Close Vantage
	Given Click System Battery  
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given launch toolbar
	Then  check toolbar DYTC status Ultra-performance mode
	
@DYTC6MWSActiveStateUI  
Scenario: VAN19138_TestStep27_AC Mode:Slider Power Slider to Best Performance and check tips
	When Close Vantage
	Given Click System Battery  
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then Take Screen Shot VAN19138_TestStep27 in 19138 under ITSScreenShotResult

@DYTC6MWSActiveStateUI
Scenario: VAN19138_TestStep28_DC Mode:Slider Power Slider to Battery saver
	Given DC Condition(Connect the Adapter)
	When Close Vantage
	Given turn on narrator
	Given Click System Battery  
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Given launch toolbar
	Then check toolbar DYTC status Quiet mode



		


