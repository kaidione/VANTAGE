Feature: VAN27994_Part6_HS_VantageToolbarquickregressiontestfornewOS
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-27994
	Author： Yangyu
	Conmments: TestStep251-300

Background:
	Given Turn on or off the narrator 'on'

@NOSToolbarLink
Scenario: VAN27994_TestStep254_Check Comments & feedback display
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then There is No 'Comments & feedback' Link

@NOSToolbarLink
Scenario: VAN27994_TestStep255_Check Comments & feedback display
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Comments & feedback blank' Link
	Then The Comments feedback Doesn't Display

@NOSToolbarPriorityThinkpad
Scenario: VAN27994_TestStep258_Check the priority and order of thinkpad
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then Toolbar priority and order of the settings button is correct
	Then Take Screen Shot PriorityOrderofIconsOnThinkpad in 27994 under ToolbarScreenShotResult

@NOSToolbarPriorityIdeapad
Scenario: VAN27994_TestStep259_Check the priority and order of ideapad
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then Toolbar priority and order of the settings button is correct
	Then Take Screen Shot PriorityOrderofIconsOnIdeapad in 27994 under ToolbarScreenShotResult

@NOSToolbarLink
Scenario: VAN27994_TestStep260_Check the device capability and shows the settings matrix accordingly
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then Take Screen Shot CheckIconShowaccordingtoCapability in 27994 under ToolbarScreenShotResult

@NOSToolbarLink
Scenario: VAN27994_TestStep261_Check maximum number of the settings is 10
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Then Take Screen Shot CheckOnelineShow5buttons in 27994 under ToolbarScreenShotResult

@NOSToolbarLink
Scenario: VAN27994_TestStep262_Check via Go to Lenovo Vantage link jump to Dashboard page
	Given Close Vantage
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Then The Current page display correct 'DashBoard'

@NOSToolbarLink
Scenario: VAN27994_TestStep264_Check via All Settings link jump to Power page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'All Settings' Link
	Then The Current page display correct 'Power'

@NOSToolbarLink
Scenario: VAN27994_TestStep265_Check via Battery details link jump to Battery details page
	Given Toolbar has been pin to Taskbar
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Battery details' Link

@NOSToolbarLink
Scenario: VAN27994_TestStep267_Check via Wi-Fi security link jump to Wi-Fi security page
	Given enable microphone total access
	Given enable camera total access
	Given Turn off Location Permission for Vantage
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Wi-Fi security' Link
	Then The Current page display correct 'Wi-Fi security'

@NOSToolbarLink
Scenario: VAN27994_TestStep268_Check via Microphone link jump to Audio page
	Given disable microphone total access
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Microphone' Link
	Then The Current page display correct 'Audio'

@NOSToolbarLink
Scenario: VAN27994_TestStep269_Check via Camera link jump to Camera display page
	Given disable camera total access
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Camera' Link
	Then The Current page display correct 'Camera & display'

@NOSToolbarLink
Scenario: VAN27994_TestStep270_Check click toolbar link jump to windows store page
	Given disable microphone total access
	Given disable camera total access
	Given Uninstall the lenovo vatage
	Given Toolbar has been pin to Taskbar
	Given Close Toolbar Background
	When Kill WinStore.App by processName
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Microphone' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	Given Close Toolbar Background
	When Kill WinStore.App by processName
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Camera' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	When Kill WinStore.App by processName
	Given Close Toolbar Background
	Given Launch Toolbar On NewOS
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	When Kill WinStore.App by processName

@NOSToolbarCPUMemory
Scenario: VAN27994_TestStep275_Check Toolbar and CPU Memory
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple clicks icons within Toolbar
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple clicks icons within Toolbar
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	
@NOSToolbarCPUMemory
Scenario: VAN27994_TestStep276_Check Toolbar and CPU Memory
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple launch and close Toolbar
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type	
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple launch and close Toolbar
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type	
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@NOSToolbarCPUMemory
Scenario: VAN27994_TestStep277_Check Toolbar and CPU Memory
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Waiting 43200 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@NOSToolbarCPUMemory
Scenario: VAN27994_TestStep278_Check Toolbar and CPU Memory 
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Waiting 300 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@NOSToolbarCPUMemorySleepHibernate
Scenario: VAN27994_TestStep279_Check Toolbar and CPU Memory 
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	When Enter sleep
	Given Launch Winappdriver
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@NOSToolbarCPUMemorySleepHibernate
Scenario: VAN27994_TestStep280_Check Toolbar and CPU Memory 
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	When Enter hibernate
	Given Launch Winappdriver
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@NOSToolbarCPUMemory
Scenario: VAN27994_TestStep282_Check Toolbar no error log on event view
	Given Toolbar has been pin to Taskbar
	Given close lenovo vantage
	Given Launch Toolbar On NewOS
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions