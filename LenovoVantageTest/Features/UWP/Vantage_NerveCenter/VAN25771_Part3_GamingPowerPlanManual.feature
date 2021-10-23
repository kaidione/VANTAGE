Feature: VAN25771_Part3_GamingPowerPlanManualOnePowerPlan
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-25771
    Author： Xu Wei
    Automated Test Step：34-51

Background: 
    Given Machine is Gaming

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep34_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep35_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep36_Check Legion Perfromance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep37_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep38_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Performance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanPerformanceMode
Scenario: VAN25771_TestStep39_Check Active mode should be Legion Performance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is '52521609-efc9-4268-b9ba-67dea73f18b2'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Active'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Active'

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep40_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep41_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep42_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep43_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep44_Check Legion Balance mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Balance Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanBalanceMode
Scenario: VAN25771_TestStep45_Check Active mode should be Legion Balance mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is '85d583c5-cf2e-4197-80fd-3789a227a72c'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Active'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Active'

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep46_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep47_Check Active mode should be Legion Quiet mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep48_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep49_Check Active mode should be Legion Quiet mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep50_Check Legion Quiet mode should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Legion Quiet Mode' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanQuietPlan
Scenario: VAN25771_TestStep51_Check Active mode should be Legion Quiet mode and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Active'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Active'