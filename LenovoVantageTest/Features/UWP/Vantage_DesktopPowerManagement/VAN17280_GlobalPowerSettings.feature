Feature: VAN17280_GlobalPowerSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17280
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-277
	Author： Pengjie Chen

@DPM @GlobalPowerSettings @GPS @GPSDebug
Scenario: VAN17280_TestStep01_Check REQUIRED SIGN IN drop down menu list is displaying normally
	Given The Machine support DPM
	Given The Machine is not pwd
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON and REQUIRED SIGN IN options are displaying normally

@DPM @GlobalPowerSettings @GPS @GPSDebug
Scenario: VAN17280_TestStep02_Check REQUIRED SIGN IN not show in windows settings
	Given The Machine support DPM
	Given The Machine is not pwd
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The REQUIRED SIGN IN not show in windows settings

@DPM @GlobalPowerSettings @GPS @GPSDebug
Scenario: VAN17280_TestStep03_Check REQUIRED SIGN IN not show in windows settings
	Given The Machine support DPM
	Given Set a pwd for the machine '1'
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON and REQUIRED SIGN IN options are displaying normally

@DPM @GlobalPowerSettings @GPS @GPSDebug
Scenario: VAN17280_TestStep04_Check REQUIRED SIGN IN not show in windows settings
	Given The Machine support DPM
	Given Set a pwd for the machine '1'
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The REQUIRED SIGN IN show in windows settings

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep05_Check The REQUIRED SIGN IN drop down menu default option is consistent with Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The POWER BUTTON option is consistent with Windows Settings
	Then The REQUIRED SIGN IN drop down menu option is consistent with Windows Settings

@DPM @GlobalPowerSettings @GPS @DPMSmokeGlobalPowerSettings
Scenario: VAN17280_TestStep06_Check The REQUIRED SIGN IN Note Text
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	Then The REQUIRED SIGN IN description is consistent with defined document
	"""
	Note: This only works if system password set.
	"""

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep07_Check The REQUIRED SIGN IN valid options should be showing 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	Then The REQUIRED SIGN IN valid options should be showing

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep09_Check There is only one option When PC wakes up from sleep selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'When PC wakes up from sleep'
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'When PC wakes up from sleep'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep10_Check The option in Windows Settings When PC wakes up from sleep and it is consistent with DPM page option
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'When PC wakes up from sleep'
	Then The REQUIRED SIGN IN option consistent with DPM page option in windows settings 'When PC wakes up from sleep'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep12_Check There is only one option Never selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'Never'
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'Never'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep13_Check The option in Windows Settings When PC wakes up from sleep and it is consistent with DPM page option
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'Never'
	Then The REQUIRED SIGN IN option consistent with DPM page option in windows settings 'Never'

@DPM @GlobalPowerSettings @GPS @GPSS3S4
Scenario: VAN17280_TestStep14_Check The systme can be entered directly
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'Never'
	Then The REQUIRED SIGN IN option consistent with DPM page option in windows settings 'Never'
	When enter sleep
	Then The POWER BUTTON and REQUIRED SIGN IN options are displaying normally

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep15_Check It will show latest sign in option When PC wakes up from sleep in DPM page and it is consistent with Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'Never'
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'Never'
	Given User select one REQUIRED SIGN IN option in windows settings 'When PC wakes up from sleep'
	When wait 30 seconds
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'When PC wakes up from sleep'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17280_TestStep16_Check It will show latest sign in option Nerver in DPM page and it is consistent with Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click REQUIRED SIGN IN menu list
	When User select one REQUIRED SIGN IN option in drop down menu 'When PC wakes up from sleep'
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'When PC wakes up from sleep'
	Given User select one REQUIRED SIGN IN option in windows settings 'Never'
	When wait 30 seconds
	Then The REQUIRED SIGN IN option only showing the chosed REQUIRED SIGN IN option just now 'Never'
