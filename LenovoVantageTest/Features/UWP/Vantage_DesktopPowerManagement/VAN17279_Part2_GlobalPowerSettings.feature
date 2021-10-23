Feature: VAN17279_Part2_GlobalPowerSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17279
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-278
	Author： Pengjie Chen

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep14_Check Select option Hibernate and only one item Hibernate selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Hibernate'
	Then The power button option only showing the chosed power button option just now 'Hibernate'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep15_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Hibernate'
	Then The power button option consistent with DPM page option in windows settings 'Hibernate'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep17_Check Select option Shut down and only one item Shut down selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Shut down'
	Then The power button option only showing the chosed power button option just now 'Shut down'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep18_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Shut down'
	Then The power button option consistent with DPM page option in windows settings 'Shut down'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep20_Check Select option Turn off the display and only one item Turn off the display selected
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Turn off the display'
	Then The power button option only showing the chosed power button option just now 'Turn off the display'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep21_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Turn off the display'
	Then The power button option consistent with DPM page option in windows settings 'Turn off the display'

@DPM @GlobalPowerSettings @GPS @DPMRelaunch
Scenario: VAN17279_TestStep23_Check power button option consistent with DPM page option in windows settings
	Given close lenovo vantage
	Given User select one power button option in windows settings 'Shut down'
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	Given Get Session for Global Power Settings
	When Go to Global power settings Section for DPM
	Then The power button option only showing the chosed power button option just now 'Shut down'
	Then The power button option consistent with DPM page option in windows settings 'Shut down'
	Given close lenovo vantage

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep24_Check power button option consistent with DPM page option in windows settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Turn off the display'
	Given User select one power button option in windows settings 'Hibernate'
	Then The power button option only showing the chosed power button option just now 'Turn off the display'
	Then The power button option consistent with DPM page option in windows settings 'Hibernate'
	When wait 30 seconds
	Then The power button option only showing the chosed power button option just now 'Hibernate'

@DPM @GlobalPowerSettings @GPS
Scenario: VAN17279_TestStep25_Check global power setting option is not changed
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Global power settings Section for DPM
	When The User Click POWER BUTTON menu list
	When User select one power button option in drop down menu 'Turn off the display'
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'High performance'
	Then The power button option only showing the chosed power button option just now 'Turn off the display'
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	Then The power button option only showing the chosed power button option just now 'Turn off the display'
