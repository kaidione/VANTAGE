@ITSToolbarCase
Feature:VAN28156_ITS3ToolbarTestcaseNewOS
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28156
	Author： Jinxin Li

Background: 
	When Current Machine OS is "more" than "21354"

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep01 Check Intelligent Cooling is on status On NewOS
	Given Launch Toolbar On NewOS
	Given change ITS mode to Auto via Toolbar
	Then ITS Auto is selected in Toolbar

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep02 Check IconClear On NewOS
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 02UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep03 Check Tip Location On NewOS
	Given Launch Toolbar On NewOS
	Given switch ITS Mode 	
	Given change ITS mode to Auto via Toolbar
	Then Take screen shot 03UI in 28156 under ITSScreenShotResult after 0 seconds

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep04 Check Tip Text On NewOS
	Given Launch Toolbar On NewOS
	Given switch ITS Mode 	
	Given change ITS mode to Auto via Toolbar
	Then Take screen shot 04UI in 28156 under ITSScreenShotResult after 0 seconds

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep05 Check Power Page ITS Mode On NewOS
	Given Go to Power Page
	Then vantage ITS mode is on 

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep06 Turn off Intelligent Cooling check toolbar ITS Mode
	Given Go to Power Page
	Given turn off Intelligent Cooling
	Given Launch Toolbar On NewOS	
	Then ITS Perf is selected in Toolbar

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep07 Select Performance On NewOS
	Given Launch Toolbar On NewOS	
	Given switch ITS Mode 
	Given change ITS mode to Perf via Toolbar
	Then ITS Perf is selected in Toolbar
	Then Take Screen Shot 07UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep08 Check Performance icon On NewOS
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 08UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep09 Check Performance Tips On NewOS
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given change ITS mode to Perf via Toolbar
	Then Take screen shot 09UI in 28156 under ITSScreenShotResult after 0 seconds

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep10 Check Power Page Performance Mode On NewOS
	Given Launch Toolbar On NewOS	
	Given switch ITS Mode 
	Given change ITS mode to Perf via Toolbar
	Given Go to Power Page
	Then Performance is on in vantage

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep11 Check toolbar ITS mode
	Given Go to Power Page
	Given turn off Intelligent Cooling
	Given click Cool & quiet 
	Given Launch Toolbar On NewOS
	Then ITS C&Q is selected in Toolbar
	Then Take Screen Shot 11UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep12_check toolbar ITS mode
	Given Launch Toolbar On NewOS
	Then ITS C&Q is selected in Toolbar
	Then Take Screen Shot 12UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep13_check icon clear
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 13UI in 28156 under ITSScreenShotResult

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep14_check Tip Text
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given change ITS mode to C&Q via Toolbar
	Then Take screen shot 14UI in 28156 under ITSScreenShotResult after 0 seconds

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep15_check vantage ITS mode
	Given Go to Power Page
	Then  Cool & quiet is on in vantage

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep16_turn on Intelligent cooling check toolbar mode
	Given Go to Power Page
	Given turn on Intelligent Cooling
	Given Launch Toolbar On NewOS
	Then ITS Auto is selected in Toolbar

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep18_select Intelligent cooling check eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to Auto via Toolbar
	When wait 5 seconds
	Then Check "Intelligent_Cooling" Eventlog for "ITS3"

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep19_select Performance check eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to Perf via Toolbar
	When wait 5 seconds
	Then Check "Performance" Eventlog for "ITS3"

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep20_select Cool & quiet check eventlog
	Given Launch Toolbar On NewOS
	Given switch ITS Mode
	Given delete eventlog
	Given change ITS mode to C&Q via Toolbar
	When wait 5 seconds
	Then Check "Cool_Quiet" Eventlog for "ITS3"

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep21 ITS3 heartbeat eventlog On NewOS
	Given delete eventlog
	Given Adjust The System Time To 1 Days Later
	When wait 60 seconds
	Then Read "ITS3" Heartbeat Eventlog
	Given Adjust The System Time To -1 Days Later

@ITS3ToolbarNewOS
Scenario:VAN28156_TestStep22_change DPI check Button icon display clear reasonable
	Given Change DPI to 100
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2201UI in 28156 under ITSScreenShotResult
	Given Change DPI to 125
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2202UI in 28156 under ITSScreenShotResult
	Given Change DPI to 150
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2203UI in 28156 under ITSScreenShotResult
	Given Change DPI to 175
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2204UI in 28156 under ITSScreenShotResult
	Given Change DPI to 100

@ITS3ToolbarNewOS
Scenario: VAN28156_TestStep23_change resolution check Button icon display
	Given change resolution 1920 to 1080
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2301UI in 28156 under ITSScreenShotResult
	Given change resolution 1600 to 1900
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2302UI in 28156 under ITSScreenShotResult
	Given change resolution 1280 to 1024
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2303UI in 28156 under ITSScreenShotResult
	Given change resolution 1280 to 720
	Given Launch Toolbar On NewOS
	Then Take Screen Shot 2304UI in 28156 under ITSScreenShotResult
	Given change resolution 1920 to 1080
	Given Close toolbar

@ITS3ToolbarNewOS
Scenario: VAN28156_TestStep24_check toolbar tips of Intelligent cooling mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to Auto via Toolbar
	Given Hover ITS icon in toolbar ON NewOS
	Then Take screen shot 24UI in 28156 under ITSScreenShotResult after 0 seconds
	Given Close toolbar

@ITS3ToolbarNewOS
Scenario: VAN28156_TestStep25_check toolbar tips of Performance mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to Perf via Toolbar
	Given Hover ITS icon in toolbar ON NewOS
	Then Take screen shot 25UI in 28156 under ITSScreenShotResult after 0 seconds
	Given Close toolbar

@ITS3ToolbarNewOS
Scenario: VAN28156_TestStep26_check toolbar tips of Cool&quiet mode
	Given Launch Toolbar On NewOS
	Given change ITS mode to C&Q via Toolbar
	Given Hover ITS icon in toolbar ON NewOS
	Then Take screen shot 26UI in 28156 under ITSScreenShotResult after 0 seconds
	Given Close toolbar
