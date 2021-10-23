Feature: VAN27944_Part1_HardWareInfoIntelCPUGPUOn
	Test Case： https://jira.tc.lenovo.com/browse/VAN-27944
	Author： Yang Liu
	Test Steps:1-7,15-21,29-35

Background: 
	Given Machine is Gaming
	Given AC Condition(Connect the Adapter)
	Then The OC value is 3 And the Method is GetBIOSOCMode
	Given click the Thermal mode area

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep01_Check the GPU columnar area should be highlighted and lightning icon should be shown before frequency strings in the GPU area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep01 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep02_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep02 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep03_Check the CPU columnar area should be highlighted and lightning icon should be shown before frequency string in the CPU area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep03 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep05_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Overclocked
	Then Take Screen Shot VAN27944_TestStep05 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep06_Check the VRAM columnar area should be highlighted and lightning icon should be shown before frequency string in the VRAM area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep06 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep07_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep07 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep15_Check the GPU columnar area should be highlighted and lightning icon should be shown before frequency strings in the GPU area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep15 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep16_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep16 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep17_Check the CPU columnar area should be highlighted and lightning icon should be shown before frequency string in the CPU area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep17 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep19_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Overclocked
	Then Take Screen Shot VAN27944_TestStep19 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep20_Check the VRAM columnar area should be highlighted and lightning icon should be shown before frequency string in the VRAM area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep20 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep21_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep21 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep29_Check the GPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the GPU area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep29 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep30_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep30 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Given The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep31_Check the CPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the CPU area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep31 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep33_Check CPU Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Given Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked
	Then Take Screen Shot VAN27944_TestStep33 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep34_Check the VRAM columnar area should NOT be highlighted and lightning icon should NOT be shown in the VRAM area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN27944_TestStep34 in VAN27944 under GamingScreenShotResult

@HWInfoIntelCPUGPUOCOn
Scenario: VAN27944_TestStep35_Check VRAM Realtime Frequency Maximum Frequency and value and OC status
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Given Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Given Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Take Screen Shot VAN27944_TestStep35 in VAN27944 under GamingScreenShotResult
	Given The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Given The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Given Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value
