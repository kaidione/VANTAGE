Feature: VAN25984_Part2_HardWareInfoAMD
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25984
	Author： Yang Liu

Background: 
	Given Machine is Gaming

@HWInfoAMD
Scenario: VAN25984_TestStep04_Check the frequency strings in the GPU area
	Then Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMD
Scenario: VAN25984_TestStep05_Check the frequency strings in the VRAM area
	Then Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep13_Check the GPU columnar area should be highlighted and lightning icon should be shown before frequency strings in the GPU area
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep13 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep14_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep14 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Then The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep15_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep15 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep16_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep16 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Then Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCON
Scenario: VAN25984_TestStep18_Check VRAM columnar area should be highlighted and icon should be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep18 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep19_Check VARM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep19 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Then The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep27_Check the GPU columnar area should be highlighted and lightning icon should be shown before frequency strings in the GPU area
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep27 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep28_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep28 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Then The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep29_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep29 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep30_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep30 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Then Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCON
Scenario: VAN25984_TestStep32_Check VRAM columnar area should be highlighted and icon should be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep32 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep33_Check VRAM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep33 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Then The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep41_Check The GPU columnar area should NOT be highlighted and lightning icon should NOT be shown in the GPU area
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep41 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep42_Check GPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'GPU'
	Then Take Screen Shot VAN25984_TestStep42 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'GPU' name in the Task manager
	Then The 'GPU' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Graphics' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Graphics' Value

@HWInfoAMDOCON
Scenario: VAN25984_TestStep43_Check CPU columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep43 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep44_Check CPU Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'CPU'
	Then Take Screen Shot VAN25984_TestStep44 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'CPU' name in the Task manager
	Then Get CPU Overclock Frequency And the Method is GetCpuFrequency When Unoverclocked

@HWInfoAMDOCON
Scenario: VAN25984_TestStep46_Check VRAM columnar area should NOT be highlighted and icon should NOT be shown
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then Take Screen Shot VAN25984_TestStep46 in VAN25984 under GamingScreenShotResult

@HWInfoAMDOCON
Scenario: VAN25984_TestStep47_Check VRAM Realtime Frequency Maximum Frequency and value and OC status
	Given AC Condition(Connect the Adapter)
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	When Hover the GPU CPU VRAM or HardDisk area 'VRAM'
	Then Take Screen Shot VAN25984_TestStep47 in VAN25984 under GamingScreenShotResult
	Then The GPU CPU VRAM or HardDisk model should be consistent with 'VRAM' name in the Task manager
	Then The 'VRAM' model Usage rate should be shown or hidden 'hidden'
	Then Frequency Strings Should Be Consistent With Current Clocks 'Memory' Value In The GPU Boost Tool
	Then Maximum Frequency Should Be Shown And Consistent With Maximum Clocks 'Memory' Value