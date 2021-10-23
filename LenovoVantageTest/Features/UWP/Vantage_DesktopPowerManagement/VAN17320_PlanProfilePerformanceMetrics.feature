Feature: VAN17320_PlanProfilePerformanceMetrics
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17320
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VFC-274
	Author： Pengjie Chen

@DPM @PowerPlan @DPMSmokePlanProfile
Scenario: VAN17320_TestStep01_Check PLAN PROFILE text is showing below the Power Plan drop-down list
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The PLAN PROFILE text is showing below the Power Plan dropdown list

@DPM @PowerPlan @DPMSmokePlanProfile
Scenario: VAN17320_TestStep02_Check PLAN PROFILE options Max performance and Max system temperature and Max power usage are showing normally
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The PLAN PROFILE options are showing normally

@DPM @PowerPlan
Scenario: VAN17320_TestStep03_Check PLAN PROFILE default status is consistent with the Windows Settings
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then The Power Plan Section only current plan showing
	Then Take Screen Shot Plan_Profile_DefaultStatus_VAN17320_TestStep03 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17320_TestStep04_Check each predefined power plan profile is correct 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then Take Screen shots for each predefined power plan profile

@DPM @PowerPlan
Scenario: VAN17320_TestStep05_Check each new power plan profile is consistent with the each existing plan profile 
	Given The Machine support DPM
	Given The user create one new power plan with the same configuration as the existing plan 'Maximum Performance'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Given Get current power plan values in power plan page
	Then Take Screen Shot Existing_Plan_Profile_Maximum_Performance_Copy_VAN17320_TestStep05 in DPM under DPM
	When User click power plan in drop down menu
	When User select one power plan in drop down menu 'Maximum Performance'
	Then Take Screen Shot Existing_Plan_Profile_Maximum_Performance_VAN17320_TestStep05 in DPM under DPM
	Then The new power plan profile is consistent with the each existing plan profile and values not changed

@DPM @PowerPlan
Scenario: VAN17320_TestStep06_Check changed power plan value and power plan profile is not changed
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then Take Screen Shot Plan_Profile_Changed_Value_Before_VAN17320_TestStep06 in DPM under DPM
	When The user random modify power plan valus  
	Then Take Screen Shot Plan_Profile_Changed_Value_After_VAN17320_TestStep06 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17320_TestStep07_Check each customized power plan profile is correct 
	Given The Machine support DPM
	When User create new power plan in windows settings 'Customized power plan 07'
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then Take Screen Shot Plan_Profile_Customized_VAN17320_TestStep07 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17320_TestStep08_Check changed power plan value and power plan profile is not changed
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	Then Take Screen Shot Plan_Profile_Customize_Changed_Value_Before_VAN17320_TestStep08 in DPM under DPM
	When The user random modify power plan valus  
	Then Take Screen Shot Plan_Profile_Customize_Changed_Value_After_VAN17320_TestStep08 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17320_TestStep09_Check create new power plan profile is correct 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User create new power plan in windows settings 'VAN17320_TestStep09'
	Then The current power plan name is new create power plan
	Then Take Screen Shot  Plan_Profile_Create_New_Power_Plan_VAN17320_TestStep09 in DPM under DPM

@DPM @PowerPlan
Scenario: VAN17320_TestStep10_Check change to other power plan profile is correct 
	Given The Machine support DPM
	When Go to My Device Settings page
	When Go to Power Plan Section for DPM
	When User select one power plan in windows settings 'Maximum Energy Saving'
	Then The current power plan name is new create power plan
	Then Take Screen Shot Plan_Profile_Change_To_Other_Power_Plan_Maximum_Energy_Saving_VAN17320_TestStep10 in DPM under DPM

@DPM @PowerPlan @DPMRelaunch
Scenario: VAN17320_TestStep11_Check create new power plan and relaunch vantage profile is correct
	Given The Machine support DPM
	Given Close Vantage
	When User create new power plan in windows settings 'VAN17320_TestStep11'
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	When Go to Power Plan Section for DPM
	Then Take Screen Shot Plan_Profile_Reopen_Create_New_Power_Plan_VAN17320_TestStep11 in DPM under DPM
	Given Close Vantage

@DPM @PowerPlan @DPMRelaunch
Scenario: VAN17320_TestStep12_Check change to other power plan and relaunch vantage profile is correct 
	Given The Machine support DPM
	Given Close Vantage
	When User select one power plan in windows settings 'Maximum Energy Saving'
	Given Launch Vantage
	When Go to My Device Settings page
	Given Get Session for Power Plan Settings
	When Go to Power Plan Section for DPM
	Then Take Screen Shot Plan_Profile_Reopen_Change_To_Other_Power_Plan_Maximum_Energy_Saving_VAN17320_TestStep12 in DPM under DPM
	Given Close Vantage
