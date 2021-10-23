Feature: VAN17644_DesktopPowerManagementCommon
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17644
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-273
	Author： Pengjie Chen

Background: 
	Given Set Sleep Hdd Display Hibernate to Nerver
	When The user connect or disconnect WiFi on lenovo

@DPM @DPMCommon @DPMSmokeCommonCheck
Scenario:  VAN17644_TestStep01_Check Brand is Think and DPM content should be shown normally
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon
Scenario:  VAN17644_TestStep02_Check Brand is lenovo and DPM content should be shown normally
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMNetWork @DPMRelaunch
Scenario:  VAN17644_TestStep03_Check disconnect WiFi Brand is Think and DPM content should be shown normally
	Given The Machine support DPM
	When close lenovo vantage
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for DPM Common
	Then The all DPM contents are showing in power settings page
	When close lenovo vantage

@DPM @DPMCommon @DPMNetWork @DPMRelaunch
Scenario:  VAN17644_TestStep04_Check disconnect WiFi Brand is lenovo and DPM content should be shown normally
	Given The Machine support DPM
	When close lenovo vantage
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for DPM Common
	Then The all DPM contents are showing in power settings page
	When close lenovo vantage

@DPM @DPMCommon @DPMNetWork
Scenario:  VAN17644_TestStep05_Check disconnect WiFi Brand is Think and DPM content should be shown normally
	#Given Enable Ethernet
	Given The Machine support DPM
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMNetWork
Scenario:  VAN17644_TestStep06_Check disconnect WiFi Brand is lenovo and DPM content should be shown normally
	#Given Enable Ethernet
	Given The Machine support DPM
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMNetWork
Scenario:  VAN17644_TestStep07_Check connect WiFi Brand is Think and DPM content should be shown normally
	Given Close Vantage
	Given Launch Vantage
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	Given The Machine support DPM
	When The user connect or disconnect WiFi on lenovo
	#Given Enable Ethernet
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMNetWork
Scenario:  VAN17644_TestStep08_Check connect WiFi Brand is lenovo and DPM content should be shown normally
	When The user connect or disconnect WiFi off lenovo
	#Given Disable Ethernet
	Given The Machine support DPM
	When The user connect or disconnect WiFi on lenovo
	#Given Enable Ethernet
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMRelaunch
Scenario:  VAN17644_TestStep10_Check upgrade vantage experience and DPM content should be shown normally
	Given The Machine support DPM
	When close lenovo vantage
	When Change Vantage Service 'qa-2'
	Given OOBE for DPM
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for DPM Common
	Then The all DPM contents are showing in power settings page
	When Change Vantage Service 'default'
	When close lenovo vantage
	Given OOBE for DPM
	When close lenovo vantage

@DPM @DPMCommon @NotDPM
Scenario:  VAN17644_TestStep12_Check Brand is not Think Lenovo or SubBrand is not ThinkCentre and DPM content should not be shown
	Given The Machine does not support DPM
	When Go to My Device Settings page
	Then The all DPM contents are hidden in power settings page

@DPM @DPMCommon @DPMS3S4
Scenario:  VAN17644_TestStep14_Check S3 and DPM content should be shown
	Given The Machine support DPM
	When Start the IMC service in the task manager
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page
	Given User select one REQUIRED SIGN IN option in windows settings 'Never'
	When Enter sleep
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon @DPMS3S4
Scenario:  VAN17644_TestStep15_Check S4 and DPM content should be shown
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The all DPM contents are showing in power settings page
	Given User select one REQUIRED SIGN IN option in windows settings 'Never'
	When Enter hibernate
	Then The all DPM contents are showing in power settings page

@DPM @DPMCommon
Scenario:  VAN17644_TestStep16_Check execute command and DPM content should be shown normally
	Given The Machine support DPM
	When The user execute the command 'lenovo-vantage3:power'
	When wait 15 seconds
	Then The all DPM contents are showing in power settings page