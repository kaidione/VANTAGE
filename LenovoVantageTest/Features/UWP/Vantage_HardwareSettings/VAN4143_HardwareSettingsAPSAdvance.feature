Feature: VAN4143_VFC178_HardwareSettingsAPSAdvance
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4143
	Author： Chenpj5

@APS @SmokeAPS
Scenario: VAN4143_TestStep01_Check pen input drop down menu will not be displayed
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The APS Advance Settings change to show or hide 'hide'
	Given The 'Pen' function is enable or disable 'disable'
	Then The pen input drop down menu will not be displayed
	Then Take Screen Shot VAN4143_TestStep01 in 4143 under HSScreenShotResult

@APS
Scenario: VAN4143_TestStep03_Check pen input drop down menu default value is 0 seconds
	Given The machine support or not support APS 'support'
	Given Go to Smart Assist page
	Given Go to APS section via jump link
	Given The 'APS' function is enable or disable 'enable'
	Given The APS Advance Settings change to show or hide 'hide'
	Given The 'Pen' function is enable or disable 'enable'
	Then The pen input drop down menu value is correct '0 seconds'
	Then Take Screen Shot VAN4143_TestStep03 in 4143 under HSScreenShotResult