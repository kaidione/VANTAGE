Feature: VAN17159_IntelligentCoolingITS2IdeaPad
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17159
	Author ：Yang Liu

@ITS2UI  @ITSSmokeITS2
Scenario:VAN17159_TestStep01_check the Performance and Coolquiet mode will be hide
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Check Intelligent Cooling hide for Perf&CQ
	Then Check Intelligent CoolingDesc Text for ITS2

@ITS2UI  @ITSSmokeITS2
Scenario:VAN17159_TestStep02_check the Performance and Coolquiet mode will be show
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for Perf&CQ
	Then Check Intelligent Cooling show for ITS2
	Then Check Intelligent CoolingDesc Text for ITS2

@ITS2UI
Scenario:VAN17159_TestStep03_check jump link function
	Given Go to Power Page
	Then Take Screen Shot 0301 in 17159 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0302 in 17159 under ITSScreenShotResult

@ITS2UI_Unsupport
Scenario:VAN17159_TestStep04_unsupport machine check it does not show Intelligent Cooling UI in Power Smart Settings
	When Click the Power icon
	When Check Open Power page
	Then Check Intelligent Cooling hide for ITS2

@ITS2UI
Scenario:VAN17159_TestStep05_check it does not show Intelligent Cooling UI in toolbar
	Given launch toolbar
	Then Take Screen Shot 05 in 17159 under ITSScreenShotResult

@ITS2UI
Scenario:VAN17159_TestStep06_check the Intelligent Cooling UI should display reasonable
	Given Go to Power Page
	Given jump to power smart settings section
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 0601 in 17159 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 0602 in 17159 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 0603 in 17159 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 0604 in 17159 under ITSScreenShotResult
	Given Change DPI to recommend

@ITS2UI
Scenario:VAN17159_TestStep07_check the Intelligent Cooling UI should be hidden
	Given Change DPI to recommend
	Given Stop ITS Service
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS2
	Given Start ITS Service

@ITS2UI
Scenario:VAN17159_TestStep09_check the Intelligent Cooling UI should be hidden
	Given Start ITS Service
	Given Go to Power Page
	Given move thinkpad plugin
	Given Go to Power Page
	Then Check Intelligent Cooling hide for ITS2
	Given recover thinkpad plugin

@ITS2UI
Scenario:VAN17159_TestStep12_check the Intelligent Cooling toggle status is on
	Given recover thinkpad plugin
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@ITS2UI
Scenario:VAN17159_TestStep13_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@ITS2UI
Scenario:VAN17159_TestStep14_check the Intelligent Cooling default mode is Performance when toggle is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Switch Performance Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep15_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep16_check the Intelligent Cooling mode is Coolquiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep17_check the ITS work is OK when fast switching Intelligent Cooling mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@ITS2UI
Scenario:VAN17159_TestStep18_check the ITS work is OK when fast switching Intelligent Cooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling toggle

@ITS2UI
Scenario:VAN17159_TestStep19_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@ITS2UI
Scenario:VAN17159_TestStep20_check the Intelligent Cooling toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS2UI
Scenario:VAN17159_TestStep21_check the Intelligent Cooling mode is performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep22_check the Intelligent Cooling mode is coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Restart ITS Service
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@ITS2UIS3S4
Scenario:VAN17159_TestStep23_check the Intelligent Cooling mode cannot be changed and the Intelligent Cooling toggle status cannot be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	When Enter sleep
	Then Turn Off Toggle State Normal
	Then Switch Performance Mode Normal

@ITS2UIS3S4
Scenario:VAN17159_TestStep24_check the Intelligent Cooling mode cannot be changed and the Intelligent Cooling toggle status cannot be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	When Enter hibernate
	Then Turn On Toggle State

@ITS2UI
Scenario:VAN17159_TestStep35_check the Intelligent Cooling toggle status is on 26
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State
	When The user connect or disconnect WiFi on lenovo

@ITS2UI
Scenario:VAN17159_TestStep36_check the Intelligent Cooling toggle status is off 27
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal
	When The user connect or disconnect WiFi on lenovo

@ITS2UI
Scenario:VAN17159_TestStep37_check the Intelligent Cooling mode is Performance 28
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal
	When The user connect or disconnect WiFi on lenovo

@ITS2UI
Scenario:VAN17159_TestStep38_check the Intelligent Cooling mode is Coolquiet 29
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo

@ITS2UI
Scenario:VAN17159_TestStep30_check the Intelligent Cooling toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@ITS2UI
Scenario:VAN17159_TestStep31_check the Intelligent Cooling toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@ITS2UI
Scenario:VAN17159_TestStep32_check the Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep33_check the Intelligent Cooling mode is Coolquiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep26_check the Intelligent Cooling toggle status is off 35
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal

@ITS2UI
Scenario:VAN17159_TestStep27_check the Intelligent Cooling toggle status is on 36
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn On Toggle State

@ITS2UI
Scenario:VAN17159_TestStep28_check the Intelligent Cooling mode is Performance 37
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch Performance Mode Normal

@ITS2UI
Scenario:VAN17159_TestStep29_check the Intelligent Cooling mode is Coolquiet 38
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch CoolQuiet Mode Normal
