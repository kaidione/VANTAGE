Feature: VAN17146_Part2_PowerUseOptionsAndSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17146
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-279
	Author： Pengjie Chen

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep13_Check hdd options in the drop down menu list
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hdd'
	Then The 'hdd' options in the drop down menu list

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep14_Check hdd drop down menu only show current value
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hdd'
	When The user click special drop down menu in power use section 'hdd'
	Then The drop down menu only show current value 'hdd'

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep15_Check sleep options in the drop down menu list
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'sleep'
	Then The 'sleep' options in the drop down menu list

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep16_Check sleep drop down menu only show current value
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'sleep'
	When The user click special drop down menu in power use section 'sleep'
	Then The drop down menu only show current value 'sleep'

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep17_Check hibernate options in the drop down menu list
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hibernate'
	Then The 'hibernate' options in the drop down menu list

@DPM @PowerUse @DPMSmokePowerUse
Scenario: VAN17146_TestStep18_Check hibernate drop down menu only show current value
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hibernate'
	When The user click special drop down menu in power use section 'hibernate'
	Then The drop down menu only show current value 'hibernate'

@DPM @PowerUse
Scenario: VAN17146_TestStep19_Check all valus in Windows Settings are consistent
	Given The Machine support DPM
	When Go to My Device Settings page
	Then The two values in Windows Settings are consistent with the values in DPM page 'all'

@DPM @PowerUse
Scenario: VAN17146_TestStep20_Check display value in Windows Settings are consistent
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'display'
	When The user selected special valus '20' in power use section 'display'
	Then The two values in Windows Settings are consistent with the values in DPM page 'display' 

 @DPM @PowerUse
Scenario: VAN17146_TestStep21_Check hdd value in Windows Settings are consistent
	Given The Machine support DPM 
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hdd'
	When The user selected special valus '20' in power use section 'hdd'
	Then The two values in Windows Settings are consistent with the values in DPM page 'hdd' 

@DPM @PowerUse
Scenario: VAN17146_TestStep22_Check sleep value in Windows Settings are consistent
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'sleep'
	When The user selected special valus '20' in power use section 'sleep'
	Then The two values in Windows Settings are consistent with the values in DPM page 'sleep' 

@DPM @PowerUse
Scenario: VAN17146_TestStep23_Check hibernate value in Windows Settings are consistent
	Given The Machine support DPM
	When Go to My Device Settings page
	When The user click special drop down menu in power use section 'hibernate'
	When The user selected special valus '20' in power use section 'hibernate'
	Then The two values in Windows Settings are consistent with the values in DPM page 'hibernate' 
