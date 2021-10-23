Feature: VAN25984_Part1_HardWareInfoAMD
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25984
	Author： Chen Pengjie

Background: 
	Given Machine is Gaming

@HWInfoAMD @GamingSmokeHWInfo
Scenario: VAN25984_Part1_TestStep01_GPU CPU VRAM and HardDisk information should be shown
	Then The GPU CPU VRAM and HardDisk information should be shown or hidden in homepage 'shown'

@HWInfoAMD
Scenario: VAN25984_Part1_TestStep03_GPU CPU VRAM and HardDisk information should be shown
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCOFF 
Scenario: VAN25984_Part1_TestStep06_Check GPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep06 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep07_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep07 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCOFF 
Scenario: VAN25984_Part1_TestStep08_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep08 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep09_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep09 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep11_Check VARM columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep11 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep12_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep12 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep20_Check GPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep20 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep21_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep21 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep22_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep22 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep23_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep23 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep25_Check VARM columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep25 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep26_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep26 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep34_Check GPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep34 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep35_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep35 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep36_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep36 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep37_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep37 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep39_Check VARM columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep39 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCOFF
Scenario: VAN25984_Part1_TestStep40_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep40 in VAN25984 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value