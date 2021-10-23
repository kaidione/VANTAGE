Feature: VAN25773_GamingPowerPlanModify
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25773
	Author： Yang Liu

Background:
	Given Machine is Gaming 

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep01_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Performance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep02_Check Active mode should be Legion Performance mode and GUID is 52521609-efc9-4268-b9ba-67dea73f18b
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Performance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep03_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Quiet Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep04_Check Active mode should be Legion Quiet mode and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Quiet Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep05_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Balance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep06_Check Active mode should be Legion Balance mode and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Go To Power Options Page
	Given Change Plan Settings For The 'Legion Balance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep07_Check Perfromance mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Performance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep08_Check Active mode should be Legion Performance mode and GUID is 52521609-efc9-4268-b9ba-67dea73f18b
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Performance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep09_Check Balance mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Balance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep10_Check Active mode should be Legion Balance mode and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Balance Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep11_Check Quiet mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Quiet Mode' Plan
	Given Modify And Save The Plan Settings
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep12_Check Active mode should be Legion Quiet mode and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Not Selected'
	Given Change Plan Settings For The 'Legion Quiet Mode' Plan
	Given Modify And Save The Plan Settings
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'
	Given Change Plan Settings For The 'Legion Performance Mode' Plan
	Given Reset The Plan Settings
	Given Change Plan Settings For The 'Legion Balance Mode' Plan
	Given Reset The Plan Settings
	Given Change Plan Settings For The 'Legion Quiet Mode' Plan
	Given Reset The Plan Settings
	Then Close The Power Options Page

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep13_Check abcde should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given Modify The Name Of 'Legion Performance Mode' to 'abcde'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'abcde' Is 'Selected'
	Then Close The Power Options Page
	Given Modify The Name Of 'abcde' to 'Legion Performance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep14_Check Active mode should be abcde and GUID is 52521609-efc9-4268-b9ba-67dea73f18b
	Given Modify The Name Of 'abcde' to 'Legion Performance Mode'
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given Modify The Name Of 'Legion Performance Mode' to 'abcde'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'abcde' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'
	Given Modify The Name Of 'abcde' to 'Legion Performance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep15_Check ~!@#$% should be selected in the System Power Plans
	Given Modify The Name Of 'abcde' to 'Legion Performance Mode'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given Modify The Name Of 'Legion Quiet Mode' to '~!@#$%'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '~!@#$%' Is 'Selected'
	Then Close The Power Options Page
	Given Modify The Name Of '~!@#$%' to 'Legion Quiet Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep16_Check Active mode should be ~!@#$% and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Given Modify The Name Of '~!@#$%' to 'Legion Quiet Mode'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given Modify The Name Of 'Legion Quiet Mode' to '~!@#$%'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID '~!@#$%' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'
	Given Modify The Name Of '~!@#$%' to 'Legion Quiet Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep17_Check 780311 should be selected in the System Power Plans
	Given Modify The Name Of '~!@#$%' to 'Legion Quiet Mode'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given Modify The Name Of 'Legion Balance Mode' to '780311'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '780311' Is 'Selected'
	Then Close The Power Options Page
	Given Modify The Name Of '780311' to 'Legion Balance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep18_Check Active mode should be 780311 and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Given Modify The Name Of '780311' to 'Legion Balance Mode'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given Modify The Name Of 'Legion Balance Mode' to '780311'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID '780311' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'
	Given Modify The Name Of '780311' to 'Legion Balance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep19_Check Performance mode should be selected in the Thermal mode settings page
	Given Modify The Name Of '780311' to 'Legion Balance Mode'
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given Modify The Name Of 'Legion Performance Mode' to 'asdf7890'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'asdf7890' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given Modify The Name Of 'asdf7890' to 'Legion Performance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep20_Check Active mode should be asdf7890 and GUID is 52521609-efc9-4268-b9ba-67dea73f18b
	Given Modify The Name Of 'asdf7890' to 'Legion Performance Mode'
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given Modify The Name Of 'Legion Performance Mode' to 'asdf7890'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'asdf7890' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID 'asdf7890' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'
	Given Modify The Name Of 'asdf7890' to 'Legion Performance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep21_Check Balance mode should be selected in the Thermal mode settings page
	Given Modify The Name Of 'asdf7890' to 'Legion Performance Mode'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given Modify The Name Of 'Legion Balance Mode' to '[]{}qwer'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '[]{}qwer' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup
	Given Modify The Name Of '[]{}qwer' to 'Legion Balance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep22_Check Active mode should be []{}qwer and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Given Modify The Name Of '[]{}qwer' to 'Legion Balance Mode'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given Modify The Name Of 'Legion Balance Mode' to '[]{}qwer'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '[]{}qwer' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID '[]{}qwer' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'
	Given Modify The Name Of '[]{}qwer' to 'Legion Balance Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep23_Check Quiet mode should be selected in the Thermal mode settings page
	Given Modify The Name Of '[]{}qwer' to 'Legion Balance Mode'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given Modify The Name Of 'Legion Quiet Mode' to '1-2=%89'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '1-2=%89' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup
	Given Modify The Name Of '1-2=%89' to 'Legion Quiet Mode'

@PowerPlanModifyPlanSettings
Scenario: VAN25773_TestStep24_Check Active mode should be 1-2=%89 and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Given Modify The Name Of '1-2=%89' to 'Legion Quiet Mode'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given Modify The Name Of 'Legion Quiet Mode' to '1-2=%89'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan '1-2=%89' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID '1-2=%89' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'
	Given Modify The Name Of '1-2=%89' to 'Legion Quiet Mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep25_Check Power plan should not be changed in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Performance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Performance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep26_Check Active mode and GUID should not be changed
	Then Power Plan Or GUID 'Legion Performance mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Performance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'
	When User delete one power plan in windows settings 'Legion Performance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep27_Check Power plan should not be changed in the System Power Plans
	Then Power Plan Or GUID 'Legion Quiet mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Quiet mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Quiet mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep28_Check Active mode and GUID should not be changed
	Then Power Plan Or GUID 'Legion Quiet mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Quiet mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'
	When User delete one power plan in windows settings 'Legion Quiet mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep29_Check Power plan should not be changed in the System Power Plans
	Then Power Plan Or GUID 'Legion Balance mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Balance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Balance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep30_Check Active mode and GUID should not be changed
	Then Power Plan Or GUID 'Legion Balance mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Balance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'
	When User delete one power plan in windows settings 'Legion Balance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep31_Check the Thermal mode in the Thermal mode settings page not change
	Then Power Plan Or GUID 'Legion Performance mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	When User create new power plan in windows settings 'Legion Performance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Performance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep32_Check Active mode should be Legion Performance mode and GUID is NOT 52521609-efc9-4268-b9ba-67dea73f18b
	Then Power Plan Or GUID 'Legion Performance mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Performance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID 'Legion Performance mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b' Is 'Hidden'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Performance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep33_Check the Thermal mode in the Thermal mode settings page not change
	Then Power Plan Or GUID 'Legion Balance mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	When User create new power plan in windows settings 'Legion Balance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Balance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep34_Check Active mode should be Legion Balance mode and GUID is NOT 85d583c5-cf2e-4197-80fd-3789a227a72c
	Then Power Plan Or GUID 'Legion Balance mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Balance mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID 'Legion Balance mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Balance mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep35_Check the Thermal mode in the Thermal mode settings page not change
	Then Power Plan Or GUID 'Legion Quiet mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	When User create new power plan in windows settings 'Legion Quiet mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Quiet mode'

@PowerPlanModifyPlanCreateSamePlan
Scenario: VAN25773_TestStep36_Check Active mode should be Legion Quiet mode and GUID is NOT 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Then Power Plan Or GUID 'Legion Quiet mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	When User create new power plan in windows settings 'Legion Quiet mode'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet mode' Is 'Not Selected'
	Then Close The Power Options Page
	Then Power Plan Or GUID 'Legion Quiet mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page
	When User delete one power plan in windows settings 'Legion Quiet mode'
