Feature: VAN17284_Part2_PowerPlanSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17284
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-276
	Author： Pengjie Chen

@DPM @PowerPlan
Scenario: VAN17284_TestStep13_Check power plan in Windows Settings are consistent in DPM page
	Given The Machine support DPM
	When User select one power plan in windows settings 'Maximum Performance'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan Section only current plan showing

@DPM @PowerPlan
Scenario: VAN17284_TestStep14_Check 4 item values about Power use in Windows Settings are changed accordingly
	Given The Machine support DPM
	When User select one power plan in windows settings 'Balanced'
	Then The values in Power use section also changed accordingly when choose another power plan in windows settings 'Maximum Energy Saving'

@DPM @PowerPlan
Scenario: VAN17284_TestStep15_Check 4 item values in Windows Settings are consistent with the values in DPM page
	Given The Machine support DPM
	When User select one power plan in windows settings 'High performance'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	#When User click power plan in drop down menu
	Then The values in Windows Settings are consistent with the values in DPM page 'High performance'

@DPM @PowerPlan
Scenario: VAN17284_TestStep16_Check The new created power plan is selected in current power plan drop down menu
	Given The Machine support DPM
	When User create new power plan in windows settings 'Auto Test Plan'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now 'Auto Test Plan'

@DPM @PowerPlan
Scenario: VAN17284_TestStep17_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The all predefined power plan in drop down menu should be showing
	Then The new power plan is show in power plan drop down menu 'Auto Test Plan'

@DPM @PowerPlan
Scenario: VAN17284_TestStep18_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The values in Windows Settings are consistent with the values in DPM page 'Auto Test Plan'

@DPM @PowerPlan
Scenario: VAN17284_TestStep19_Check The new created power plan is show in current power plan
	Given The Machine support DPM
	When User create new power plan in windows settings '381b4222-f694-41f0-9685-ff5bb260df2e-New-Power-Plan-Characters'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now '381b4222-f694-41f0-9685-ff5bb260df2e-New-Power-Plan-Characters'

@DPM @PowerPlan
Scenario: VAN17284_TestStep20_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The new power plan is show in power plan drop down menu '381b4222-f694-41f0-9685-ff5bb260df2e-New-Power-Plan-Characters'

@DPM @PowerPlan
Scenario: VAN17284_TestStep21_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The new power plan is hover in power plan drop down menu '381b4222-f694-41f0-9685-ff5bb260df2e-New-Power-Plan-Characters'
	Then Take Screen Shot New_Power_Plan_Characters_VAN17284_TestSteps19_21 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17284_TestStep22_Check The new created power plan is show in current power plan
	Given The Machine support DPM
	When User create new power plan in windows settings '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty'

@DPM @PowerPlan
Scenario: VAN17284_TestStep23_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The new power plan is show in power plan drop down menu '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty'

@DPM @PowerPlan
Scenario: VAN17284_TestStep24_Check The new created power plan is show in power plan drop down menu
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The new power plan is hover in power plan drop down menu '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty'
	Then Take Screen Shot New_Power_Plan_Characters_VAN17284_TestSteps22_24 in DPM under DPM
