Feature: VAN17146_Part3_PowerUseOptionsAndSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17146
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-279
	Author： Pengjie Chen

@DPM @PowerUse
Scenario: VAN17146_TestStep24_Check stop imc and current value is consistent with the changed value
	Given The Machine support DPM
	When Go to My Device Settings page
	Given Get current power plan values in power plan page
	When Stop the IMC service in the task manager
	When The user random modify power plan valus
	Then The values in Power use section also changed accordingly when choose another power plan

@DPM @PowerUse
Scenario: VAN17146_TestStep25_Check stop imc and current value is consistent with the changed value
	When Start the IMC service in the task manager
	Given The Machine support DPM
	When Go to My Device Settings page
	Given Get current power plan values in power plan page
	When Stop the IMC service in the task manager
	When The user random modify power plan valus
	Then The values will show previous value in window settings

@DPM @PowerUse
Scenario: VAN17146_TestStep26_Check restart imc and current value is consistent with the previous value or changed
	When Start the IMC service in the task manager
	Given The Machine support DPM
	When Go to My Device Settings page
	Given Get current power plan values in power plan page
	When Stop the IMC service in the task manager
	When The user click special drop down menu in power use section 'display'
	When The user selected special valus '2' in power use section 'display'
	When The user click special drop down menu in power use section 'hdd'
	When The user selected special valus '7' in power use section 'hdd'
	When The user click special drop down menu in power use section 'sleep'
	When The user selected special valus '13' in power use section 'sleep'
	When The user click special drop down menu in power use section 'hibernate'
	When The user selected special valus '5' in power use section 'hibernate'
	When Start the IMC service in the task manager
	Then The current value is consistent with the previous value or changed '2,7,13,5'
	Then Write log 'Display,Hdd,Sleep,Hibernate Values' to report for 'DPM' type


@DPM @PowerUse
Scenario: VAN17146_TestStep27_Check restart imc and keeping the previous value in settings 
	When Start the IMC service in the task manager
	Given The Machine support DPM
	When Go to My Device Settings page
	Given Get current power plan values in power plan page
	When Stop the IMC service in the task manager
	When The user click special drop down menu in power use section 'display'
	When The user selected special valus '5' in power use section 'display'
	When The user click special drop down menu in power use section 'hdd'
	When The user selected special valus '15' in power use section 'hdd'
	When The user click special drop down menu in power use section 'sleep'
	When The user selected special valus '3' in power use section 'sleep'
	When The user click special drop down menu in power use section 'hibernate'
	When The user selected special valus '7' in power use section 'hibernate'
	When Start the IMC service in the task manager
	Then The current value is consistent with the previous value in windows settings or changed '5,15,3,7'
	Then Write log 'Display,Hdd,Sleep,Hibernate Values' to report for 'DPM' type

@DPM @PowerUse
Scenario: VAN17146_TestStep28_Check restart imc and keeping the previous value in settings 
	When Start the IMC service in the task manager
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user random modify power plan valus
	When The user click special drop down menu in power use section 'display'
	When The user selected special valus '5' in power use section 'display'
	When The user click special drop down menu in power use section 'hdd'
	When The user selected special valus '9' in power use section 'hdd'
	When The user click special drop down menu in power use section 'sleep'
	When The user selected special valus '10' in power use section 'sleep'
	When The user click special drop down menu in power use section 'hibernate'
	When The user selected special valus '6' in power use section 'hibernate'
	When Back to the homepage via vantage L logo for Power settings
	When Go to My Device Settings page
	Then The items are showing changed values '5,9,10,6'

@DPM @PowerUse @DPMRelaunch
Scenario: VAN17146_TestStep29_Check values are showing correct values with the Windows Settings
	Given close lenovo vantage
	When User set power plan values in windows settings '20,120,45,0'
	Given The Machine support DPM
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for Power Use
	Then The items are showing changed values '6,11,9,15'
	Given close lenovo vantage

@DPM @PowerUse
Scenario: VAN17146_TestStep30_Check values are showing correct values with the Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When User set power plan values in windows settings '240,60,15,0'
	When wait 30 seconds
	Then The items are showing changed values '13,10,5,15'

@DPM @PowerUse
Scenario: VAN17146_TestStep31_Check values are showing correct values with the Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When User set power plan values in windows settings '20,45,1,120'
	When Back to the homepage via vantage L logo for Power settings
	When Go to My Device Settings page
	When wait 30 seconds
	Then The items are showing changed values '6,9,0,11'

@DPM @PowerUse
Scenario: VAN17146_TestStep32_Check set value which is not included in list in Windows Settings and the values show as blank  
	Given The Machine support DPM
	When Go to My Device Settings page
	When User set power plan values in windows settings '4,33,49,360'
	When wait 30 seconds
	Then The set values not included in list in Windows Settings and values show as blank

@DPM @PowerUse
Scenario: VAN17146_TestStep33_Check values are showing correct values with the Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When User set power plan values in windows settings '5,45,300,0'
	When wait 30 seconds
	Then The items are showing changed values '3,9,14,15'
