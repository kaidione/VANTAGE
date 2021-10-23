@ITSToolbarCase
Feature: VAN28164_DynamicThermalDYTCToolbarOnNewOS
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-28164
	Author： Jinxin Li

Background: 
	When Current Machine OS is "more" than "21354"

@NAITSDYTCToolbarOnNewOSDYTC5
Scenario:VAN28164_TestStep01 Check DYTC5 features in Toolbar On NewOS
	Given delete eventlog
	Given Adjust The System Time To 2 Days Later
	When wait 60 seconds
	Then Read "DYTC5" Heartbeat "Not" Eventlog
	Given Adjust The System Time To -2 Days Later
	When Change the Status of the 'Power Saver' 
	Then Take screen shot 0101UI in 28164 under ITSScreenShotResult after 0 seconds
	Given Launch Toolbar On NewOS
	Then It will not show DYTC features On NewOS
	Then Hover Toolbar on NewOS
	Then Take screen shot 0102UI in 28164 under ITSScreenShotResult after 0 seconds

@NAITSDYTCToolbarOnNewOSDYTC6NoAMT
Scenario:VAN28164_TestStep02 Check Support DYTC6 No AMT On NewOS
	When Change the Status of the 'Power Saver' 
	Then Take screen shot 0101UI in 28164 under ITSScreenShotResult after 0 seconds
	Given Launch Toolbar On NewOS
	Then It will not show DYTC features On NewOS
	Given delete eventlog
	Given Adjust The System Time To 2 Days Later
	When wait 60 seconds
	Then Read "DYTC6NOAMT" Heartbeat "Not" Eventlog
	Given Adjust The System Time To -2 Days Later
	Then Hover toolbar on NewOS
	Then Take screen shot 0102UI in 28164 under ITSScreenShotResult after 0 seconds

@NAITSDYTCToolbarOnNewOSDYTC6AMT
Scenario:VAN28164_TestStep03 Machine support DYTC6 AMT On NewOS
	When Change the Status of the 'Power Saver' 
	Then Take screen shot 0101UI in 28164 under ITSScreenShotResult after 0 seconds
	Given Launch Toolbar On NewOS
	Then It will not show DYTC features On NewOS
	Given delete eventlog
	Given Adjust The System Time To 2 Days Later
	When wait 60 seconds
	Then Read "DYTC6AMT" Heartbeat "Not" Eventlog
	Given Adjust The System Time To -2 Days Later
	Then Hover toolbar on NewOS
	Then Take screen shot 0102UI in 28164 under ITSScreenShotResult after 0 seconds

@NAITSDYTCToolbarDYTC6MWSOnNewOS
Scenario:VAN28164_TestStep04 Machine Support DYTC6 MWS On NewOS
	When Change the Status of the 'Power Saver' 
	Then Take screen shot 0101UI in 28164 under ITSScreenShotResult after 0 seconds
	Given Launch Toolbar On NewOS
	Then It will not show DYTC features On NewOS
	Given delete eventlog
	Given Adjust The System Time To 2 Days Later
	When wait 60 seconds
	Then Read "DYTC6MWS" Heartbeat "Not" Eventlog
	Given Adjust The System Time To -2 Days Later
	Then Hover toolbar on NewOS
	Then Take screen shot 0102UI in 28164 under ITSScreenShotResult after 0 seconds