Feature: VAN17279_Part1_GlobalPowerSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17279
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-278
	Author： Pengjie Chen

@DPM @GlobalPowerSettings @GPS @DPMSmokeGlobalPowerSettings
Scenario: VAN17279_TestStep01_Check Global power settings section is below Power plan section
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The Global power settings section is below Power plan section

@DPM @GlobalPowerSettings @GPS @DPMSmokeGlobalPowerSettings
Scenario: VAN17279_TestStep02_Check Global power settings description 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The Global power settings description is consistent with defined document
	"""
	This feature will override Power plan or Power use settings.
	"""
	Then Take Screen Shot Global_Power_Settings_VAN17279_TestStep02 in DPM under DPM

@DPM @GlobalPowerSettings @GPS @DPMSmokeGlobalPowerSettings
Scenario: VAN17279_TestStep03_Check Global power settings section options POWER BUTTON and REQUIRED SIGN IN
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON and REQUIRED SIGN IN options are displaying normally

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep04_Check option of POWER BUTTON is consistent witn Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON option is consistent with Windows Settings

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep05_Check default option of POWER BUTTON is consistent witn Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON option is consistent with Windows Settings

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep06_Check POWER BUTTON valid options should be showing 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	Then The POWER BUTTON valid options should be showing 

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep08_Check Select option Do nothing and only one item Do nothing selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Do nothing'
	Then The power button option only showing the chosed power button option just now 'Do nothing'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep09_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Do nothing'
	Then The power button option consistent with DPM page option in windows settings 'Do nothing'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep11_Check Select option Sleep and only one item Sleep selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Sleep'
	Then The power button option only showing the chosed power button option just now 'Sleep'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep12_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Sleep'
	Then The power button option consistent with DPM page option in windows settings 'Sleep'
