Feature: VAN17171_DynamicThermalDYTC3CQL
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17171
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-1750
	Author ：Xiaoxiong Li

@DYTC3CQL  @ITSSmokeDYTC3CQL
Scenario:VAN17171_TestStep01_check message will be hidden and Intelligent Cooling toggle will be shown
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for DYTC3CQL
	Then Take Screen Shot 01 in 17171 under ITSScreenShotResult

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep02_There will be a message and the Intelligent Cooling toggle will be hidden
	Given Go to Power Page
	Given jump to power smart settings section
	Then Check Intelligent Cooling show for DYTC3CQLNOAPS
	Then Take Screen Shot 02 in 17171 under ITSScreenShotResult

@DYTC3CQLNotsupport
Scenario:VAN17171_TestStep03_check It doesn't show Legacy function UI in Power Smart Settings
	When Click the Power icon
	When Check Open Power page
	Then Take Screen Shot 03 in 17171 under ITSScreenShotResult

@DYTC3CQL
Scenario:VAN17171_TestStep04_check The legacy function doesn't display on Lenovo Vantage Toolbar
	Given Launch toolbar
	Then Take Screen Shot 04 in 17171 under ITSScreenShotResult

@DYTC3CQL
Scenario:VAN17171_TestStep05_check intelligent cooling toggle is on and no Performance and Cool & quiet mode display
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Check Intelligent Cooling hide for Perf&CQ

@DYTC3CQL
Scenario:VAN17171_TestStep06_check intelligent cooling toggle is off and the Performance and Cool & quiet mode will be shown
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Check Intelligent Cooling show for Perf&CQ

@DYTC3CQL
Scenario:VAN17171_TestStep07_check It will jump to Power Smart settings section
	Given Go to Power Page
	Then Take Screen Shot 0701 in 17171 under ITSScreenShotResult
	Given jump to power smart settings section
	Then Take Screen Shot 0702 in 17171 under ITSScreenShotResult

@DYTC3CQL
Scenario:VAN17171_TestStep08_check The Intelligent Cooling UI can be displayed normally and toggle status is on
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn On Toggle State

@DYTC3CQL
Scenario:VAN17171_TestStep09_check Intelligent Cooling UI can be displayed normally and toggle status is off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Go to Power Page
	Given jump to power smart settings section
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep10_check The Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep11_check The Intelligent Cooling mode is Cool&quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep12_check The Intelligent Cooling mode is performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch Performance Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep13_check The Intelligent Cooling mode is Cool&quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Go to Power Page
	Given jump to power smart settings section
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep16_change DPI check ITS UI
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch toggle off DYTC THREE CQL
	Given Change DPI to 100
	Given jump to power smart settings section
	Then Take Screen Shot 1601 in 17171 under ITSScreenShotResult
	Given Change DPI to 125
	Given jump to power smart settings section
	Then Take Screen Shot 1602 in 17171 under ITSScreenShotResult
	Given Change DPI to 150
	Given jump to power smart settings section
	Then Take Screen Shot 1603 in 17171 under ITSScreenShotResult
	Given Change DPI to 175
	Given jump to power smart settings section
	Then Take Screen Shot 1604 in 17171 under ITSScreenShotResult
	Given Change DPI to 150
	Given SetWindowSize
	Given jump to power smart settings section
	Then Take Screen Shot 1605 in 17171 under ITSScreenShotResult

@DYTC3CQL
Scenario:VAN17171_TestStep17_check ITS toggle On
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@DYTC3CQL
Scenario:VAN17171_TestStep18_check ITS toggle Off
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep21_check Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep22_check The Intelligent Cooling mode is Cool & quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep23_check Intelligent Cooling default mode is performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Turn on Intellgentcooling toggle
	Given Turn off Intellgentcooling toggle
	Then Switch Performance Mode Normal  

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep24_check Intelligent Cooling mode is Performance
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep25_check The Intelligent Cooling mode is Cool & quiet
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep27_Fast switching Intelligent Cooling mode Legacy Function work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@DYTC3CQL
Scenario:VAN17171_TestStep28_Fast switching Intelligent Cooling toggle Legacy Function work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling toggle

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep29_NOAPS Fast switching Intelligent Cooling mode Legacy Function work is OK
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Fast Switch IntelligentCooling Mode

@DYTC3CQL
Scenario:VAN17171_TestStep30_check The Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	When Enter sleep
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep31_check The Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	When Enter hibernate
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep33_check The Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	When Enter sleep
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep34_check The Intelligent Cooling toggle status can't be changed
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch coolquiet mode
	When Enter hibernate
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep35_reinstall the vantage Intelligent Cooling toggle status is off42
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep36_reinstall the vantage Intelligent Cooling toggle status is on43
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Turn On Toggle State

@DYTC3CQL
Scenario:VAN17171_TestStep37_reinstall the vantage The Intelligent Cooling mode is Performance44
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch Performance Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep38_reinstall the vantage Intelligent Cooling mode is Cool&quiet45
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch CoolQuiet Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep39_NOAPS reinstall the vantage Intelligent Cooling mode is Performance46
	Given Go to Power Page
	Given jump to power smart settings section
	Given Switch performance mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch Performance Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep40_reinstall the vantage Intelligent Cooling mode is Cool&quiet47
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Given Install Vantage
	Given Go to Power Page
	Given jump to power smart settings
	Then Switch CoolQuiet Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep41_check The Intelligent Cooling toggle status is on36
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn on Intellgentcooling toggle
	Then Turn On Toggle State

@DYTC3CQL
Scenario:VAN17171_TestStep42_check The Intelligent Cooling toggle status is off37
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Then Turn Off Toggle State Normal

@DYTC3CQL
Scenario:VAN17171_TestStep43_check The Intelligent Cooling mode is Performance38
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC3CQL
Scenario:VAN17171_TestStep44_check The Intelligent Cooling mode is Cool & quiet39
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep45_check The Intelligent Cooling mode is Performance40
	When The user connect or disconnect WiFi off lenovo
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch performance mode
	Then Switch Performance Mode Normal

@DYTC3CQLNOAPS
Scenario:VAN17171_TestStep46_check The Intelligent Cooling mode is Cool & quiet41
	Given Go to Power Page
	Given jump to power smart settings section
	Given Turn off Intellgentcooling toggle
	Given Switch coolquiet mode
	Then Switch CoolQuiet Mode Normal
	When The user connect or disconnect WiFi on lenovo



