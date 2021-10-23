Feature: VAN15886_HardwareSettingsEnergyStarLogoQuickRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-15886
	Author： Jinxin Li

@EnergyStarLogo
Scenario: VAN15886_TestStep01_Registry Editor is 1
	Given Machine is IdeaPad or ThinkPad
	Given Go to My Device Settings page
	When The value of the "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\Settings" and  "DisplayEnergyStar" in Registry Editor is "1"
	Then There shows the Energy Star logo at the bottom of Power page

@EnergyStarLogo
Scenario: VAN15886_TestStep02_Registry Editor is 1
	Given Machine is IdeaPad or ThinkPad	
	Given Go to My Device Settings page
	When The value of the "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\Settings" and  "DisplayEnergyStar" in Registry Editor is "1"
	Then The UI appearance of Energy Star logo shoul follow the UI SPEC
	Then Take Screen Shot 02 in 13280 under HSScreenShotResult
	Given Reset value of the "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\Settings" and  "DisplayEnergyStar" in Registry Editor is "1"

@EnergyStarLogo
Scenario: VAN15886_TestStep03_Registry Editor is 0
	Given Machine is IdeaPad or ThinkPad
	Given Go to My Device Settings page
	When The value of the "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\Settings" and  "DisplayEnergyStar" in Registry Editor is "0"
	Given Go to My Device
	Given Go to My Device Settings page
	Then There should not shows the Energy Star logo at the bottom of Power page
	Given Reset value of the "SOFTWARE\WOW6432Node\Lenovo\PWRMGRV\Settings" and  "DisplayEnergyStar" in Registry Editor is "1"
