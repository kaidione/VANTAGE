Feature: VAN18803_DynamicThermalDYTC6MWSUpdateIcon
	DYTC 6.0-Add active state for DYTC5.0/6.0 on BatteryGauge for ThinkPad models
	Test Case：https://jira.lenovonet.lenovo.local/browse/VAN-18803
	Author ：fengya2

@DYTC6MWSActiveStateUI  
Scenario: VAN18803_TestStep01_Drag slider bar to the far-right position
	Given Click System Battery  
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Then Take Screen Shot VAN18803_TestStep01 in 18803 under ITSScreenShotResult

@DYTC6MWSActiveStateUI  
Scenario: VAN18803_TestStep02_check the UP icon
	Given Click System Battery  
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Then Take Screen Shot VAN18803_TestStep02 in 18803 under ITSScreenShotResult

@DYTC6MWSActiveStateUI  
Scenario: VAN18803_TestStep03_the UP icon will keep showing 7s
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Given Waiting 1 seconds
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Given Waiting 8 seconds
	Then Take Screen Shot VAN18803_TestStep03 in 18803 under ITSScreenShotResult
