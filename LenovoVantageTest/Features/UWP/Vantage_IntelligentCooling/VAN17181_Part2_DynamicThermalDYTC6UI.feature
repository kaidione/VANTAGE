Feature: VAN17181_Part2_DynamicThermalDYTC6UI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17181
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1744
	Author: Huajie

@DYTC6AMTUI   @ITSSmokeDYTC6AMT
Scenario: VAN17181_TestStep01_check DYTC6UI follow UI Spec
	Given enable AMT 
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6AMT

@DYTC6AMTUI  @ITSSmokeDYTC6AMT
Scenario: VAN17181_TestStep02_check DYTC6UI follow UI Spec
	Given disable AMT
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6AMT

@DYTC6AMTUI
Scenario: VAN17181_TestStep04_click more info and check description
	Given enable AMT 
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6AMT_enabled_More
	Given disable AMT 
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6AMT_disabled_More

@DYTC6AMTUI
Scenario: VAN17181_TestStep05_click less info and check UI
	Given enable AMT 
	Given Go to Power Page
	Given jump to power smart settings section
	Given click less info for ITS
	Then Check Intelligent CoolingDesc Text for DYTC6AMT_enabled_Less
	Given disable AMT 
	Given Go to Power Page
	Given jump to power smart settings section
	Given click less info for ITS
	Then Check Intelligent CoolingDesc Text for DYTC6AMT_disabled_Less

@DYTC6AMTUI
Scenario: VAN17181_TestStep09_check jump link function
	Given Go to Power Page
	Then Take Screen Shot 0901UI in 17181 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0902UI in 17181 under ITSScreenShotResult

@DYTC6AMTUI
Scenario: VAN17181_TestStep11_offline and check UI
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT
	When  The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT

@DYTC6AMTUIS3S4
Scenario: VAN17181_TestStep12_S3S4 and check UI
	When  The user connect or disconnect WiFi on lenovo
	Given Go to Power Page
	When Enter sleep
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT
	When Enter hibernate
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT

@DYTC6AMTUI
Scenario: VAN17181_TestStep13_change DPI Check Intelligent Cooling UI 
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 1301 in 17181 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 1302 in 17181 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 1303 in 17181 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 1304 in 17181 under ITSScreenShotResult
	Given Change DPI to 150

@DYTC6AMTUI
Scenario: VAN17181_TestStep14_restart ITS service and check UI show normally 
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6AMT
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6AMT

@DYTC6AMTUI
Scenario: VAN17181_TestStep15_stop ITS service and check UI hide
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6AMT
	Given Stop ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC6AMT
	Given Start ITS Service

@DYTC6AMTUI
Scenario: VAN17181_TestStep20_check registry when enable AMT AC and Better performance
	Given Start ITS Service
	Given Close Vantage
	Given AC Condition(Connect the Adapter)
	Given enable AMT
	Given Click System Battery
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When wait 2 seconds
	Then DYTC6AMT enabled registry is correct with AC and better performance

@DYTC6AMTUI
Scenario: VAN17181_TestStep21_check registry when disable AMT DC and Better performance
	Given DC Condition(Connect the Adapter)
	Given disable AMT
	Given Close Vantage
	Given Click System Battery
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When wait 2 seconds
	Then DYTC6AMT disabled registry is correct with DC and better performance
	Given AC Condition(Connect the Adapter)
