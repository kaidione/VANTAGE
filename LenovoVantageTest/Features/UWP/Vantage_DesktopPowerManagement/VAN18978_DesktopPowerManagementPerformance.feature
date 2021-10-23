Feature: VAN18978_DesktopPowerManagementPerformance
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18978
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-275
	Author： Pengjie Chen

@DPM @DPMPerformance @DPMRelaunch
Scenario:  VAN18978_TestStep01_Check first enter DPM page and DPM should correctly loading and display on the DPM section in 5 seconds 
	Given The Machine support DPM
	When close lenovo vantage
	Given Reset Vantage
	Given OOBE for DPM
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for DPM Common
	When wait 5 seconds
	Given Get Page Source Info for DPM performance test
	Then The all DPM contents are showing in power settings page
	Then The all DPM contents are showing in page source
	When close lenovo vantage

@DPM @DPMPerformance
Scenario:  VAN18978_TestStep02_Check enter DPM page and DPM should correctly loading and display on the DPM section in 2 seconds 
	Given The Machine support DPM
	When Go to My Device Settings page
	When wait 2 seconds
	Given Get Page Source Info for DPM performance test
	Then The all DPM contents are showing in power settings page
	Then The all DPM contents are showing in page source
	
@DPM @DPMPerformance @DPMRelaunch
Scenario: VAN18978_TestStep03_Check relaunch vantage and DPM should correctly loading and display on the DPM section in 3 seconds 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	When close lenovo vantage
	When User select one power plan in windows settings 'High performance'
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Now Time for DPM performance test
	Given Get Session for DPM Common
	Then The Power Plan Section only current plan showing for performance
	Then The DPM loading and show correctly for performance test '3'
	When close lenovo vantage

@DPM @DPMPerformance
Scenario: VAN18978_TestStep04_Check refresh within 30 seconds 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	Given Get Now Time for DPM performance test
	When User select one power plan in windows settings 'Maximum Energy Saving'
	Then The Power Plan Section only current plan showing for performance
	Then The DPM loading and show correctly for performance test '30'

@DPM @DPMCommon @DPMRelaunch
Scenario:  VAN17644_TestStep13_Check DPM plugin not exist and DPM content should not be shown
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page
	When close lenovo vantage
	When Stop the IMC service in the task manager
	When Remove DPM Plugin
	Then the DPM Plugin not found
	#When Start the IMC service in the task manager
	Given Reset Vantage
	Given OOBE for DPM
	Given Launch Vantage
	#When Stop the IMC service in the task manager
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for DPM Common
	Then The all DPM contents are hidden in power settings page
	Then Restore DPM Plugin
	When Start the IMC service in the task manager
	When close lenovo vantage

@DPM @DPMDefault
Scenario:Set Sleep Hdd Display Hibernate to Nerver
	Given Set Sleep Hdd Display Hibernate to Nerver

@PLCTest
Scenario: PLCTest
	Given Set System Power Status 'on' via PLC
	Given Set System Power Status 'off' via PLC
	