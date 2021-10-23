Feature: VAN10210_Part8_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Penejie Chen
	Conmments: TestStep281-320

@ToolbarLink
Scenario: VAN10210_TestStep281_Check via Battery details link jump to Battery details page
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Battery details' Link

@ToolbarLink
Scenario: VAN10210_TestStep283
	Given enable microphone total access
	Given enable camera total access

@ToolbarLink
Scenario: VAN10210_TestStep283_Check via Wi-Fi security link jump to Wi-Fi security page
	Given Turn off Location Permission for Vantage
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Wi-Fi security' Link
	Then The Current page display correct 'Wi-Fi security'

@ToolbarLink
Scenario: VAN10210_TestStep284_Check via Microphone link jump to Audio page
	Given disable microphone total access
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Microphone' Link
	Then The Current page display correct 'Audio'

@ToolbarLink
Scenario: VAN10210_TestStep285_Check via Camera link jump to Camera display page
	Given disable camera total access
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Camera' Link
	Then The Current page display correct 'Camera & display'

@ToolbarLink
Scenario: VAN10210_TestStep286_Check click toolbar link jump to windows store page
	Given Uninstall the lenovo vatage
	Given Pin toolbar to taskbar
	When Kill WinStore.App by processName
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Microphone' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	When Kill WinStore.App by processName
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Camera' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	When Kill WinStore.App by processName
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Go to Lenovo Vantage' Link
	Given Type in "{TAB}"
	Given Type in "{Enter}"
	Given Waiting 2 seconds
	Then The Current page display correct 'Store'
	When Kill WinStore.App by processName

@ToolbarLink @ToolbarCPUMemory
Scenario: VAN10210_TestStep287
	Given turn on the Allow access to the camera toggle on this device
	Given turn on the Allow apps to access your camera
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given turn on the Allow desktop apps to access your camera
	Given turn on the Allow access to the microphone toggle on this device
	Given turn on the Allow apps to access your microphone
	Given turn on Lenovo Vantage permission for Microphonefrom system settings
	Given turn on the Allow desktop apps to access your microphone

@ToolbarLink
Scenario: VAN10210_TestStep287_Check Toolbar right menu
	Given Pin toolbar to taskbar
	Given Launch toolbar
	Given Launch Vantage from Toolbar Via 'Toolbar right menu' Link
	Then Take Screen Shot TestStep287 in 10210 under ToolbarScreenShotResult

@ToolbarCPUMemory
Scenario: VAN10210_TestStep300_Check Toolbar and CPU Memory
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep300_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep300_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple clicks icons within Toolbar
	#Then Take screen shot TestStep300_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple clicks icons within Toolbar
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	
@ToolbarCPUMemory
Scenario: VAN10210_TestStep301_Check Toolbar and CPU Memory
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep301_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep301_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple launch and close Toolbar
	Given Launch toolbar do not wait
	#Then Take screen shot TestStep301_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type	
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	Given Multiple launch and close Toolbar
	Given Launch toolbar do not wait
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type	
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

#@ToolbarCPUMemory
Scenario: VAN10210_TestStep302_Check Toolbar and CPU Memory
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep302_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep302_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	#Given Launch toolbar
	Given Waiting 43200 seconds
	#Then Take screen shot TestStep302_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@ToolbarCPUMemory
Scenario: VAN10210_TestStep303_Check Toolbar and CPU Memory 
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep303_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep303_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	#Given Launch toolbar
	Given Waiting 300 seconds
	#Then Take screen shot TestStep303_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@ToolbarCPUMemory
Scenario: VAN10210_TestStep304_Check Toolbar and CPU Memory 
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep304_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep304_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	When Enter sleep
	#Then Take screen shot TestStep304_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep304_04 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@ToolbarCPUMemory
Scenario: VAN10210_TestStep305_Check Toolbar and CPU Memory 
	Given Pin toolbar to taskbar
	#When Play task manager top
	Given close lenovo vantage
	#Then Take Screen Shot TestStep305_01 in 10210 under ToolbarScreenShotResult
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep305_02 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions
	When Enter hibernate
	#When Enter hibernate via thread way
	#Then Take screen shot TestStep305_03 in 10210 under ToolbarScreenShotResult after 0 seconds
	#Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Given Launch toolbar do not wait
	#Then Take Screen Shot TestStep305_04 in 10210 under ToolbarScreenShotResult
	Then Write log 'Check Toolbar and CPU Memory' to report for 'ToolbarCPUMemory' type
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions

@ToolbarCPUMemory
Scenario: VAN10210_TestStep307_Check Toolbar no error log on event view
	Given Pin toolbar to taskbar
	Given close lenovo vantage
	Given Launch toolbar do not wait
	Then Write log 'Check Toolbar do not throw exceptions' to report for 'ToolbarEventError' type
	Then The Toolbar do not throw exceptions