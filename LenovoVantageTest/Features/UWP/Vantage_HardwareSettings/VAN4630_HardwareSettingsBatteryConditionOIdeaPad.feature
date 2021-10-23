Feature: VAN4630_HardwareSettingsBatteryConditionOIdeaPad
	Test Case： https://jira.tc.lenovo.com/browse/VAN-4630
	Author： DaQi Fang

@IdeaPadBatteryConditionWithBattery
Scenario: VAN4630_TestStep01_IdeaPad Battery is good condition Green Checkmark Icon is show
	Given IdeaPad Machine
	Given Go to My Device Settings page
	Then Green Checkmark Icon is show

@IdeaPadBatteryConditionWithBattery
Scenario: VAN4630_TestStep02_IdeaPad Battery is good there should display a The battery is in good condition. 
	Given IdeaPad Machine
	Given Go to My Device Settings page
	Then Display a "The battery is in good condition."

@IdeaPadBatteryConditionWithBattery
Scenario: VAN4630_TestStep03_IdeaPad Battery is good the Battery Health panel title name should be "Battery". 
	Given IdeaPad Machine
	Given Go to My Device Settings page
	Then Title name should be "Battery"

@IdeaPadBatteryConditionWithBattery
Scenario: VAN4630_TestStep04_IdeaPad no ac adapter there should show remaining time. 
	Given IdeaPad Machine
	Given No AC adapter
	Given Go to My Device Settings page
	Then Remaining time should be show
	Then AC adapter

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep012_IdeaPad with no battery there display a red cross icon
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then Red cross Icon is show

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep013_IdeaPad with no battery there should be "No battery detected."
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then There Display a "No battery detected."

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep014_IdeaPad with no battery there should not show remaining time.
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then Remaining time should not be show

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep015_IdeaPad with no battery the tips in battery gauge.
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then The tips in Battery Gauge

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep016_IdeaPad with no battery the Battery Health panel title name should be "Battery". 
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then Title name should be "Battery"

@IdeaPadBatteryConditionWithOutBattery
Scenario: VAN4630_TestStep017_IdeaPad with no battery the color of Battery Gauge outline should be red. 
	Given IdeaPad Machine
	Given There is No battery detected
	Given Go to My Device Settings page
	Then Take Screen Shot 017IdeaPadNoBatteryRedBatteryGauge in 4630 under HSScreenShotResult
	