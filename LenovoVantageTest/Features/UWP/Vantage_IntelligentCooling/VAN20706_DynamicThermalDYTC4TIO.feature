Feature: VAN20706_DynamicThermalDYTC4TIO
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-20706
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1748
	Author ：Yang Liu

@DYTC4TIO  @ITSSmokeDYTC4TIO
Scenario:VAN20706_TestStep01_check the Performance and Coolquiet mode will be hide
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Check Intelligent Cooling hide for Perf&CQ
	Then Check Intelligent CoolingDesc Text for DYTC4TIO

@DYTC4TIO  @ITSSmokeDYTC4TIO
Scenario:VAN20706_TestStep02_check the Performance and Coolquiet mode will be show
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for Perf&CQ
	Then Check Intelligent Cooling show for DYTC4TIO
	Then Check Intelligent CoolingDesc Text for DYTC4TIO

@DYTC4TIO
Scenario:VAN20706_TestStep03_check jump link function
	Given Go to Power Page
	Then Take Screen Shot 0301 in 20706 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0302 in 20706 under ITSScreenShotResult

@DYTC4TIO_Unsupport
Scenario:VAN20706_TestStep04_unsupport machine check it does not show Intelligent Cooling UI in Power Smart Settings
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling hide for DYTC4TIO

@DYTC4TIO
Scenario:VAN20706_TestStep05_check it does not show Intelligent Cooling UI in toolbar
	Given launch toolbar
	Then Take Screen Shot 05 in 20706 under ITSScreenShotResult

@DYTC4TIO
Scenario:VAN20706_TestStep06_check the Intelligent Cooling UI should display reasonable
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 0601 in 20706 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 0602 in 20706 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 0603 in 20706 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 0604 in 20706 under ITSScreenShotResult
	Given Change DPI to 200
	Given jump to power smart settings section
	Then Take Screen Shot 0605 in 20706 under ITSScreenShotResult
	Given Change DPI to 225
	Given jump to power smart settings section
	Then Take Screen Shot 0606 in 20706 under ITSScreenShotResult
	Given Change DPI to 250
	Given jump to power smart settings section
	Then Take Screen Shot 0607 in 20706 under ITSScreenShotResult
	Given Change DPI to 300
	Given jump to power smart settings section
	Then Take Screen Shot 0608 in 20706 under ITSScreenShotResult
	Given Change DPI to recommend

@DYTC4TIO
Scenario:VAN20706_TestStep07_check the Intelligent Cooling UI should be hidden
	Given Change DPI to recommend
	Given Stop ITS Service
	Given Go to Power Page
	Given wait 2 seconds
	Then Check Intelligent Cooling hide for DYTC4TIO
	Given Start ITS Service

@DYTC4TIO
Scenario:VAN20706_TestStep09_check the Intelligent Cooling UI should be hidden
	Given Start ITS Service
	Given Go to Power Page
	Given move thinkpad plugin
	Given Go to Power Page
	Given wait 5 seconds
	Then Check Intelligent Cooling hide for DYTC4TIO
	Given recover thinkpad plugin

@DYTC4TIO
Scenario:VAN20706_TestStep12_check the Intelligent Cooling toggle status is on
	Given recover thinkpad plugin
	Given wait 5 seconds
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep13_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@DYTC4TIO
Scenario:VAN20706_TestStep14_check the Intelligent Cooling default mode is Performance when toggle is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep15_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep16_check the Intelligent Cooling mode is Coolquiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep17_check the ITS work is OK when fast switching Intelligent Cooling mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@DYTC4TIO
Scenario:VAN20706_TestStep18_check the ITS work is OK when fast switching Intelligent Cooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling toggle

@DYTC4TIO
Scenario:VAN20706_TestStep19_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@DYTC4TIO
Scenario:VAN20706_TestStep20_check the Intelligent Cooling toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep21_check the Intelligent Cooling mode is performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep22_check the Intelligent Cooling mode is coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC4TIOS3S4
Scenario:VAN20706_TestStep31_check the Intelligent Cooling mode cannot be changed and the Intelligent Cooling toggle status cannot be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	When Enter sleep
	Then Turn Off Toggle State Normal
	Then Switch Performance Mode Normal

@DYTC4TIOS3S4
Scenario:VAN20706_TestStep32_check the Intelligent Cooling mode cannot be changed and the Intelligent Cooling toggle status cannot be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	When Enter hibernate
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep34_check the Intelligent Cooling toggle status is on 23
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep35_check the Intelligent Cooling toggle status is off 24
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@DYTC4TIO
Scenario:VAN20706_TestStep36_check the Intelligent Cooling mode is Performance 25
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep37_check the Intelligent Cooling mode is Coolquiet 26
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo

@DYTC4TIO
Scenario:VAN20706_TestStep38_Reconnect Network
	When The user connect or disconnect WiFi on lenovo

@DYTC4TIO
Scenario:VAN20706_TestStep27_check the Intelligent Cooling toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep28_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@DYTC4TIO
Scenario:VAN20706_TestStep29_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep30_check the Intelligent Cooling mode is Coolquiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep23_check the Intelligent Cooling toggle status is off 34
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal

@DYTC4TIO
Scenario:VAN20706_TestStep24_check the Intelligent Cooling toggle status is on 35
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn On Toggle State

@DYTC4TIO
Scenario:VAN20706_TestStep25_check the Intelligent Cooling mode is Performance 36
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch Performance Mode Normal

@DYTC4TIO
Scenario:VAN20706_TestStep26_check the Intelligent Cooling mode is Coolquiet 37
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch CoolQuiet Mode Normal
