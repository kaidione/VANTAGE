Feature: VAN17179_DynamicThermalDYTC5Toolbar
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17179
	Author ：Xiaoxiong Li

@DYTC5toolbar
Scenario:VAN17179_TestStep01_AC best performance_ hover toolbar tips_ Performance mode
	Given AC Condition(Connect the Adapter)
	Given turn on narrator
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 01 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep02_AC better performance_ hover toolbar tips_ Balanced mode
	Given turn on narrator
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 02 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep03_AC better battery hover toolbar tips_ Quiet mode
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 03 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep04_DC best performance hover toolbar tips_ Performance mode
	Given DC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 04 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep05_DC better performance hover toolbar tips_ Balanced mode
	Given Click System Battery 
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 05 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep06_DC better battery hover toolbar tips_ Quiet mode
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 06 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep07_DC battery saver hover toolbar tips_ Quiet mode
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	When  hover toolbar
	Then  Take Screen Shot 07 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep08_AC Best performance check toolbar ITS icons_ red icon 
	Given AC Condition(Connect the Adapter)
	Given Click System Battery
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0801 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0802 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep09_AC Better performance check toolbar ITS icons_ green icon
	Given AC Condition(Connect the Adapter)	
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 0901 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 0902 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep10_AC Better battery check toolbar ITS icons_ blue icon
	Given Click System Battery 
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1001 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1002 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep11_DC Best performance check toolbar ITS icons_ red icon
	Given DC Condition(Connect the Adapter)	
	Given Click System Battery 
	Given Set DC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1101 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1102 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep12_DC Better performance check toolbar ITS icons_ green icon
	Given DC Condition(Connect the Adapter)
	Given Click System Battery 
	Given Set DC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1201 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1202 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep13_DC Better battery check toolbar ITS icons_ blue icon
	Given Click System Battery 
	Given Set DC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1301 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1302 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep14_DC Battery saver check toolbar ITS icons_ blue icon
	Given Click System Battery 
	Given Set DC Mode Power Slider is battery saver mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1401 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1402 in 17179 under ITSScreenShotResult
	Given AC Condition(Connect the Adapter)

@DYTC5toolbar
Scenario:VAN17179_TestStep15_fast switch power slider and check function
	Given AC Condition(Connect the Adapter)
	Given Click System Battery 
	Given fast switch 10 times windows power slider on AC mode
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1501 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1502 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 1503 in 17179 under ITSScreenShotResult	Then  Take Screen Shot 1503 in 17179 under ITSScreenShotResult

@DYTC5toolbar_Notsupport
Scenario:VAN17179_TestStep16_doesn't support machine check function
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 1601 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1602 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 1603 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep19_pin toolbar and check ITS icon and info on Toolbar
	When unpin toolbar on Taskbar settings
	When pin toolbar on Taskbar settings
	Then  Take Screen Shot 1901 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 1902 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep20_pin toolbar by power page and check ITS icon and info on Toolbar
	When unpin toolbar on Taskbar settings
	Given Go to Power Page
	Given "open" pintoolbar toggle in powerpage
	Then  Take Screen Shot 2001 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2002 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep21_check toolbar ITS function when wifi off
	When  The user connect or disconnect WiFi off lenovo
	Given Click System Battery 
	Given Set AC Mode Power Slider is best performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2101 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2102 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 2103 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep22_check toolbar ITS function when wifi off and on
	When  The user connect or disconnect WiFi on lenovo
	Given Click System Battery 
	Given Set AC Mode Power Slider is better performance mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2201 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2202 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 2203 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep25_restart ITS service and check if ITS icon shows
	When  The user connect or disconnect WiFi on lenovo
	Given Restart ITS Service
	Then  Take Screen Shot 2501 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2502 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 2502 in 17179 under ITSScreenShotResult

@DYTC5toolbar
Scenario:VAN17179_TestStep26_stop ITS service and check if ITS icon shows
	Given Stop ITS Service
	Given Set AC Mode Power Slider is better battery mode for Thinkpad DYTC Six
	Then  Take Screen Shot 2601 in 17179 under ITSScreenShotResult
	Given Waiting 7 seconds
	Then  Take Screen Shot 2602 in 17179 under ITSScreenShotResult
	When  hover toolbar
	Then  Take Screen Shot 2603 in 17179 under ITSScreenShotResult
	Given Start ITS Service
	Given turn off narrator
