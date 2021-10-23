Feature: VAN17284_Part1_PowerPlanSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17284
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-276
	Author： Pengjie Chen

@DPM @PowerPlan 
Scenario: VAN17284_TestStep01_Check the Power Plan section content is consistent with UI spec
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then Take Screen Shot DPM_PowerPlan in DPM under DPM
	
@DPM @PowerPlan @DPMSmokePowerPlan
Scenario: VAN17284_TestStep02_Check The Power Plan section is below Power use section on Power page in My Device Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan section is below Power use section

@DPM @PowerPlan @DPMSmokePowerPlan
Scenario: VAN17284_TestStep03_Check the Power Plan text
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan text is correct
	"""
	Choose a power plan to control the computer performance, system temperature, and power usage.
	"""

@DPM @PowerPlan @DPMSmokePowerPlan
Scenario: VAN17284_TestStep04_Check only current plan showing when drop down menu list collapsed
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan Section only current plan showing

@DPM @PowerPlan 
Scenario: VAN17284_TestStep06_Check The all predefined power plan in drop down menu should be showing 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The all predefined power plan in drop down menu should be showing 

@DPM @PowerPlan
Scenario: VAN17284_TestStep08_Check The power plan dropdown list is collapsed normally
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	Then The power plan dropdown list is collapsed normally

@DPM @PowerPlan
Scenario: VAN17284_TestStep09_Check The power plan only showing the chosed power plan just now
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Energy Saving'
	Then The power plan only showing the chosed power plan just now 'Maximum Energy Saving'

@DPM @PowerPlan
Scenario: VAN17284_TestStep10_Check The power plan in windows settings is consistent with DPM page
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Timers off (Presentation)'
	Then The Power Plan Section only current plan showing

@DPM @PowerPlan
Scenario: VAN17284_TestStep11_Check 4 item values in Power use section also changed accordingly
	Given The Machine support DPM
	Given The All Power plans default value
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	Given Get current power plan values in power plan page
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Energy Saving'
	Then The values in Power use section also changed accordingly when choose another power plan

@DPM @PowerPlan
Scenario: VAN17284_TestStep12_Check 4 item values in Windows Settings are consistent with the values in DPM page
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'High performance'
	Given Get current power plan values in power plan page
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Energy Saving'
	Then The values in Power use section also changed accordingly when choose another power plan
	Then The values in Windows Settings are consistent with the values in DPM page 'Maximum Energy Saving'
