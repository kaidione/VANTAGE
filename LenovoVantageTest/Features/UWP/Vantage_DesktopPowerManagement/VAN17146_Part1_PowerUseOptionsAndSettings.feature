Feature: VAN17146_Part1_PowerUseOptionsAndSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17146
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-279
	Author： Pengjie Chen

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep01_Check collapse text is showing normally
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The collapse text is showing normally in power settings page

@DPM @PowerUse
Scenario: VAN17146_TestStep02_Check collapse button is showing normally
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The collapse text is showing normally in power settings page

@DPM @PowerUse
Scenario: VAN17146_TestStep04_Check all content descriptions are consistent with the designed spec 
	Given The Machine support DPM
	When Go to My Device Settings page
	Then Take Screen Shot Power_Use_VAN17146_TestStep04 in DPM under DPM

@DPM @PowerUse
Scenario: VAN17146_TestStep05_Check Collapse button is disappeared and the Expand button is displaying
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The expand text is showing normally in power settings page

@DPM @PowerUse
Scenario: VAN17146_TestStep06_Check all contents below the Power are collapsed
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The all contents below the Power are collapsed in power settings page

@DPM @PowerUse
Scenario: VAN17146_TestStep07_Check collapse text is showing normally
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The expand text is showing normally in power settings page
	When Back to the homepage via vantage L logo for Power settings
	When Go to My Device Settings page
	Then The collapse text is showing normally in power settings page

@DPM @PowerUse
Scenario: VAN17146_TestStep08_Check all contents below the Power are showing
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The expand text is showing normally in power settings page
	When Back to the homepage via vantage L logo for Power settings
	When Go to My Device Settings page
	Then The all contents below the Power are showing in power settings page

@DPM @PowerUse @DPMRelaunch
Scenario: VAN17146_TestStep09_Check reopen vantage and collapse text is showing normally
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The expand text is showing normally in power settings page
	When close lenovo vantage
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for Power Use
	Then The collapse text is showing normally in power settings page
	When close lenovo vantage

@DPM @PowerUse @DPMRelaunch
Scenario: VAN17146_TestStep10_Check reopen vantage and all contents below the Power are showing
	Given The Machine support DPM
	When Go to My Device Settings page
	When User Change Collapse Expand status in power settings page 'Collapse'
	Then The expand text is showing normally in power settings page
	When close lenovo vantage
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for Power Use
	Then The all contents below the Power are showing in power settings page
	When close lenovo vantage

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep11_Check display options in the drop down menu list
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'display'
	Then The 'display' options in the drop down menu list

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep12_Check display drop down menu only show current value
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'display'
	When The user click special drop down menu in power use section 'display'
	Then The drop down menu only show current value 'display'
	