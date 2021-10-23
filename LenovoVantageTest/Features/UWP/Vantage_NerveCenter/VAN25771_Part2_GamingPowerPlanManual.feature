Feature: VAN25771_Part2_GamingPowerPlanManualTwoPlans
	Test Case： https://jira.tc.lenovo.com/browse/VAN-25771
	Author： Chen Pengjie
	Automated Test Step：TWoPlans 16-33

Background:
	Given Machine is Gaming
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page

@PowerPlanPBPlans
Scenario: VAN25771_TestStep16_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPBPlans
Scenario: VAN25771_TestStep17_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanPBPlans
Scenario: VAN25771_TestStep18_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPBPlans
Scenario: VAN25771_TestStep19_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanPBPlans
Scenario: VAN25771_TestStep20_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPBPlans
Scenario: VAN25771_TestStep21_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanPQPlans
Scenario: VAN25771_TestStep22_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given wait 2 seconds
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPQPlans
Scenario: VAN25771_TestStep23_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanPQPlans
Scenario: VAN25771_TestStep24_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPQPlans
Scenario: VAN25771_TestStep25_Check Active mode should be Legion Quiet mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanPQPlans
Scenario: VAN25771_TestStep26_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given wait 2 seconds
	Given The thermal mode is Quiet Mode
    Given wait 2 seconds
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPQPlans
Scenario: VAN25771_TestStep27_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanBQPlans
Scenario: VAN25771_TestStep28_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBQPlans
Scenario: VAN25771_TestStep29_Check Active mode should be Legion Quiet mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanBQPlans
Scenario: VAN25771_TestStep30_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBQPlans
Scenario: VAN25771_TestStep31_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanBQPlans
Scenario: VAN25771_TestStep32_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBQPlans
Scenario: VAN25771_TestStep33_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'