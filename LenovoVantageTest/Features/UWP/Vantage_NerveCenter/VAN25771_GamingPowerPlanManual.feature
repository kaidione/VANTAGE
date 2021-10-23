Feature: VAN25771_GamingPowerPlanManualThreePlans
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25771
	Author： Yang Liu
	Automated Test Step：ThreePlans 1-15

Background:
	Given Machine is Gaming

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep01_Check the power plans in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Shown'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Shown'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Shown'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep02_Check the GUID of three modes
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep03_Check thermal mode should be consistent with Power plan with target GUID
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep04_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep05_Check Active mode should be Legion Performance mode and GUID is 52521609-efc9-4268-b9ba-67dea73f18b2
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep06_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep07_Check Active mode should be Legion Quiet mode and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep08_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep09_Check Active mode should be Legion Balance mode and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep10_Check Perfromance mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep11_Check Active mode should be Legion Performance mode and GUID is 52521609-efc9-4268-b9ba-67dea73f18b
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'
	Then Close The Power Options Page

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep12_Check Balance mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Balance Mode in the Thermal Mode Setting popup

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep13_Check Active mode should be Legion Balance mode and GUID is 85d583c5-cf2e-4197-80fd-3789a227a72c
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'
	Then Close The Power Options Page

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep14_Check Quiet mode should be selected in the Thermal mode settings page
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Not Selected'
	Then Close The Power Options Page
	Given click the Thermal mode area
	Then The thermal mode is Quiet Mode in the Thermal Mode Setting popup

@PowerPlanManualThreePlans
Scenario: VAN25771_TestStep15_Check Active mode should be Legion Quiet mode and GUID is 16edbccd-dee9-4ec4-ace5-2f0b5f2a8975
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'
	Then Close The Power Options Page
	  