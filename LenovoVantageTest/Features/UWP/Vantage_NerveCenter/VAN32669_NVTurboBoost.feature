Feature: VAN32669_NVTurboBoost
	Test Case: https://lnvusjira.lenovonet.lenovo.local/browse/VAN-32669
	Author: Yang Liu
	Automated Test Step 01-13

@NVTurboBoostNotSupported
Scenario: VAN32669_TestStep01_Check NV turbo boost is NOT supported
    Then The Gaming mode value is 0 And the Method is GetGPUThermalSettingVersion

@NVTurboBoost
Scenario: VAN32669_TestStep02_Check TGP value of Performance mode should be consistent with spec definition
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "100" In "Performance"

@NVTurboBoost
Scenario: VAN32669_TestStep03_Check the Temperature target value of Performance mode by running the BIOS tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "83" In "Performance"

@NVTurboBoost
Scenario: VAN32669_TestStep04_Check the TGP target value of Balance mode by running the BIOS tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "90" In "Balance"

@NVTurboBoost
Scenario: VAN32669_TestStep05_Check the Temperature target value of Balance mode by running the BIOS tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "75" In "Balance"

@NVTurboBoost
Scenario: VAN32669_TestStep06_Check the TGP target value of Quiet mode by running the BIOS tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "70" In "Quiet"

@NVTurboBoost
Scenario: VAN32669_TestStep07_Check the Temperature target value of Quiet mode by running the BIOS tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "65" In "Quiet"

@NVTurboBoost
Scenario: VAN32669_TestStep08_Check the TGP value of Performance mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "100" In "Performance"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then "TGP" Value Should Not Be Changed

@NVTurboBoost
Scenario: VAN32669_TestStep09_Check the Temperature value of Performance mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "83" In "Performance"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Then "Temperature" Value Should Not Be Changed

@NVTurboBoost
Scenario: VAN32669_TestStep10_Check the TGP value of Balance mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "90" In "Balance"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then "TGP" Value Should Not Be Changed

@NVTurboBoost
Scenario: VAN32669_TestStep11_Check the Temperature value of Balance mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "75" In "Balance"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Click X button in Thermal Mode Setting popup
	Then "Temperature" Value Should Not Be Changed

@NVTurboBoost
Scenario: VAN32669_TestStep12_Check the TGP value of Quiet mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "TGP" Value Should Be "70" In "Quiet"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then "TGP" Value Should Not Be Changed

@NVTurboBoost
Scenario: VAN32669_TestStep13_Check the Temperature value of Quiet mode by running the NV tool
    Then The Gaming mode value is 1 And the Method is GetGPUThermalSettingVersion
	Given Get The Graphics Card "Vendor" Id Is "4318"
	Given Get The Graphics Card "Device" Id Is "9350"
	Then "Temperature" Value Should Be "65" In "Quiet"
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Quiet Mode
	Given Click X button in Thermal Mode Setting popup
	Then "Temperature" Value Should Not Be Changed
