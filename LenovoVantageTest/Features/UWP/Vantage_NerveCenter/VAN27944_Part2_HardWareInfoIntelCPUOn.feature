Feature: VAN27944_Part2_HardWareInfoIntelCPUOn
	Test Case： https://jira.tc.lenovo.com/browse/VAN-27944
	Author： Yang Liu
	Test Steps:8-14,22-28,36-42

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Then The OC value is 1 And the Method is GetBIOSOCMode
	Given click the Thermal mode area

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep08_Check GPU columnar area should NOT be highlighted and icon should NOT be shown
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep08 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep09_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep09 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep10_Check the CPU columnar area should be highlighted and lightning icon should be shown before frequency string in the CPU area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep10 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep12_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Overclocked
	Then Take Screen Shot VAN27944_TestStep11 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUOCOn 
Scenario: VAN27944_TestStep13_Check the VRAM columnar area should NOT be highlighted and lightning icon should NOT be shown in the VRAM area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep13 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep14_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep14 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep22_Check the GPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the GPU area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep22 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep23_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep23 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep24_Check the CPU columnar area should be highlighted and lightning icon should be shown before frequency string in the CPU area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep24 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep26_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Overclocked
	Then Take Screen Shot VAN27944_TestStep26 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep27_Check the VRAM columnar area should NOT be highlighted and lightning icon should NOT be shown in the VRAM area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep27 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep28_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep28 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep36_Check the GPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the GPU area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep36 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep37_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep37 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep38_Check the CPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the CPU area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep38 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep40_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked
	Then Take Screen Shot VAN27944_TestStep40 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep41_Check the VRAM columnar area should NOT be highlighted and lightning icon should NOT be shown in the VRAM area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep41 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUOCOn
Scenario: VAN27944_TestStep42_Check VRAM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep42 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value
