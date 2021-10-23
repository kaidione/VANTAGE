Feature: VAN17284_Part3_PowerPlanSettings
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17284
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-276
	Author： Pengjie Chen

@DPM @PowerPlan @DPMRelaunch
Scenario: VAN17284_TestStep25_Check The new created power plan name more than 128 characters and only show 128 characters in tips
	When close lenovo vantage
	When User create new power plan in windows settings '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty1234567890qwertyuiopasdfghjklzx128sfreg'
	Given The Machine support DPM
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The new power plan only has 128 characters is show in tips '1234567890qwertyuiopasdfghjklzxcvbnm !@#$%%^^&&*()_++|}P:?;./[]QWEARSTDGFYHUJIOKPLMNBVCXZsacty1234567890qwertyuiopasdfghjklzx128sfreg'
	Then Take Screen Shot New_Power_Plan_Characters_VAN17284_TestSteps25 in DPM under DPM
	When close lenovo vantage

@DPM @PowerPlan
Scenario: VAN17284_TestStep26_Check The new created power plan name with special characters can be shown normally
	Given The Machine support DPM
	When User create new power plan in windows settings '!~@#$%^&*()<>{}|:;'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now '!~@#$%^&*()<>{}|:;'
	When User click power plan in drop down menu
	Then The new power plan is show in power plan drop down menu '!~@#$%^&*()<>{}|:;'

@DPM @PowerPlan
Scenario: VAN17284_TestStep27_Check delete power plan and refreshed to real power plan
	Given The Machine support DPM
	When User create new power plan in windows settings 'Del power plan 27'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now 'Del power plan 27'
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	When User delete one power plan in windows settings 'Del power plan 27'
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Del power plan 27'
	Then Current power plan will refreshed to real power plan 'Maximum Performance'

@DPM @PowerPlan
Scenario: VAN17284_TestStep28_Check delete power plan and refreshed to real power plan and values in Power use are changed accordingly
	Given The Machine support DPM
	When User create new power plan in windows settings 'Del power plan 28'
	Given Set special value for new power plan 'Del power plan 28'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The power plan only showing the chosed power plan just now 'Del power plan 28'
	Given Get current power plan values in power plan page
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	When User delete one power plan in windows settings 'Del power plan 28'
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Del power plan 28'
	Then Current power plan will refreshed to real power plan 'Maximum Performance'
	Then The values in Power use section also changed accordingly when choose another power plan

@DPM @PowerPlan @DPMRelaunch
Scenario: VAN17284_TestStep29_Check delete power plan does not show in windows settings
	Given The Machine support DPM
	When User create new power plan in windows settings 'Del power plan 29'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	When close lenovo vantage
	When User delete one power plan in windows settings 'Del power plan 29'
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	When Go to Power Plan Section for DPM
	When User click power plan in drop down menu
	Then The deleted power plan in Windows Settings will not be shown 'Del power plan 29'
	When close lenovo vantage

@DPM @PowerPlan
Scenario: VAN17284_TestStep30_Check delete power plan does not show and current power plan show correct
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan Section only current plan showing
	Then The power plan only showing the chosed power plan just now 'Maximum Performance'

@DPM @PowerPlan @DPMRelaunch
Scenario: VAN17284_TestStep31_Check delete power plan does not show and current power plan values change
	Given The Machine support DPM
	When User create new power plan in windows settings 'Del power plan 31'
	Given Set special value for new power plan 'Del power plan 31'
	When Go to My Device Settings page
	Given Get current power plan values in power plan page
	When User select one power plan in windows settings 'Power Source Optimized'
	When User delete one power plan in windows settings 'Del power plan 31'
	When close lenovo vantage
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	When Go to Power Plan Section for DPM
	Then The Power Plan Section only current plan showing
	Then The values in Power use section also changed accordingly when choose another power plan
	When close lenovo vantage
