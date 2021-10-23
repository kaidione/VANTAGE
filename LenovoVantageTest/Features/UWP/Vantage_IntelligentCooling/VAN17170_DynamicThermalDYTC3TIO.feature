Feature: VAN17170_DynamicThermalDYTC3TIO
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17170
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1749
	Author: Xiaoxiong Li

@DYTC3TIO  @ITSSmokeDYTC3TIO
Scenario: VAN_17170_TestStep01_check The Intelligent Cooling toggle will be shown It will show below words
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling Show for DYTC3TIO
	Then Check Intelligent CoolingDesc Text for DYTC3TIO

@NOTSUPPORTDYTC3TIO
Scenario: VAN_17170_TestStep02_check It doesn't show Legacy function in Power Smart Settings
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling hide for DYTC3TIO
	Then Take Screen Shot 02 in 17170 under ITSScreenShotResult

@DYTC3TIO  @ITSSmokeDYTC3TIO
Scenario: VAN_17170_TestStep03_check The intelligent cooling toggle is on and no "Performance" and "Cool & quiet" mode display
	Given Go to Power Page
	Given turn on Intelligent Cooling
	Then Intelligent Cooling is on
	Then Check Intelligent Cooling hide for Perf&CQ

@DYTC3TIO  @ITSSmokeDYTC3TIO
Scenario: VAN_17170_TestStep04_check The intelligent cooling toggle is off and no "Performance" and "Cool & quiet" mode display
	Given Go to Power Page
	Given turn off Intelligent Cooling
	Then Check Intelligent Cooling hide for Perf&CQ

@DYTC3TIO
Scenario: VAN_17170_TestStep05_check It will jump to Power Smart settings section
	Given Go to Power Page
	Then Take Screen Shot 0501 in 17170 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0502 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep06_check The switch state is off, it will switch to on
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	Given turn on Intelligent Cooling
	Then Intelligent Cooling is on
	Given Go to Power Page
	Given jump to power smart settings section
	Then Intelligent Cooling is on

@DYTC3TIO
Scenario: VAN_17170_TestStep07_check The switch state is on, it will switch to off
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn on Intelligent Cooling
	Given turn off Intelligent Cooling
	Then Intelligent Cooling is off
	Given Go to Power Page
	Given jump to power smart settings section
	Then Intelligent Cooling is off

@DYTC3TIO
Scenario: VAN_17170_TestStep08_check The Intelligent Cooling toggle status is off18
	Given Change DPI to 150
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	Given Install Vantage
	Given Launch Vantage
	Given Go to Power Page
	Then Intelligent Cooling is off

@DYTC3TIO
Scenario: VAN_17170_TestStep09_check The Intelligent Cooling toggle status is on19
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn on Intelligent Cooling
	Given Install Vantage
	Given Launch Vantage
	Given Go to Power Page
	Then Intelligent Cooling is on

@DYTC3TIO
Scenario: VAN_17170_TestStep10_check The Intelligent Cooling UI can be displayed normally and the Intelligent Cooling toggle status is on08
	When  The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn on Intelligent Cooling
	Then Intelligent Cooling is on

@DYTC3TIO
Scenario: VAN_17170_TestStep11_check The Intelligent Cooling UI can be displayed normally and the Intelligent Cooling toggle status is off09
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	Then Intelligent Cooling is off

@DYTC3TIO
Scenario: VAN_17170_TestStep12_check The Intelligent Cooling UI can be displayed normally and toggle status is on10
	When  The user connect or disconnect WiFi on lenovo
	Given jump to power smart settings section
	Given Go to Power Page
	Given turn on Intelligent Cooling
	Given go to Audio page
	Given Go to Power Page
	Given jump to power smart settings section
	Then Intelligent Cooling is on
	Then Take Screen Shot 10 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep13_check The Intelligent Cooling UI can be displayed normally and toggle status is off11
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	Given go to Audio page
	Given Go to Power Page
	Given jump to power smart settings section
	Then Intelligent Cooling is off
	Then Take Screen Shot 11 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep14_check The Intelligent Cooling UI can be displayed normally and toggle ststus can't change12
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	When Enter sleep
	Then Intelligent Cooling is off
	Then Take Screen Shot 12 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep15_check The Intelligent Cooling UI can be displayed normally and toggle ststus can't change13
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	When Enter hibernate
	Then Intelligent Cooling is off
	Then Take Screen Shot 13 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep16_fast switch and check The Legacy Function work is OK15
	Given Go to Power Page
	Given jump to power smart settings section
	Given turn off Intelligent Cooling
	Then Fast Switch IntelligentCooling Mode

@DYTC3TIO
Scenario: VAN_17170_TestStep17_check The legacy function doesn't display on Lenovo Vantage Toolbar16
	Given launch toolbar
	Then Take Screen Shot 16 in 17170 under ITSScreenShotResult

@DYTC3TIO
Scenario: VAN_17170_TestStep18_check The Intelligent Cooling layout is reasonable and show full description17
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Then Take Screen Shot 1701 in 17170 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 1702 in 17170 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 1703 in 17170 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 1704 in 17170 under ITSScreenShotResult
	Given SetWindowSize
	Given jump to power smart settings section
	Then Take Screen Shot 1705 in 17170 under ITSScreenShotResult
	Given Change DPI to 150


