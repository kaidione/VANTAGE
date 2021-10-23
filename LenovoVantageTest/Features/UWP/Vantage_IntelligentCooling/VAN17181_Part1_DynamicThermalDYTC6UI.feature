Feature: VAN17181_Part1_DynamicThermalDYTC6UI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17181
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1744
	Author: Huajie

@DYTC6NOAMTUI  @ITSSmokeDYTC6NOAMT
Scenario: VAN17181_TestStep03_check DYTC6UI follow UI Spec
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT

@DYTC6NOAMTUI  @ITSSmokeDYTC6NOAMT
Scenario: VAN17181_TestStep04_click more info and check description
	Given Go to Power Page
	Given jump to power smart settings section
	Given click more info
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT_More

@DYTC6NOAMTUI
Scenario: VAN17181_TestStep05_click less info and check UI
	Given Go to Power Page
	Given jump to power smart settings section
	Given click less info for ITS
	Then Check Intelligent CoolingDesc Text for DYTC6NOAMT_Less

@DYTC6NOAMTUI
Scenario: VAN17181_TestStep09_check jump link function
	Given Go to Power Page
	Then Take Screen Shot 0901UI in 17181 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0902UI in 17181 under ITSScreenShotResult

@DYTC6NOAMTUI_Unsupport
Scenario: VAN17181_TestStep10_unsupport machine check DYTC6NOAMT UI hide
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling hide for DYTC6NOAMT

@DYTC6NOAMTUI
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

@DYTC6NOAMTUIS3S4
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

@DYTC6NOAMTUI
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

@DYTC6NOAMTUI
Scenario: VAN17181_TestStep14_restart ITS service and check UI show normally 
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT

@DYTC6NOAMTUI
Scenario: VAN17181_TestStep15_stop ITS service and check UI hide
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC6NOAMT
	Given Stop ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling hide for DYTC6NOAMT
	Given Start ITS Service

