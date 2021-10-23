Feature: VAN25771_Part4_GamingPowerPlanManualNoPlan
    Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-25771
    Author： Xu Wei
    Automated Test Step：52-57

Background: 
    Given Machine is Gaming
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Not Selected'
	Then Close The Power Options Page

@PowerPlanNoPlan
Scenario: VAN25771_TestStep52_Check Balanced Plan should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanNoPlan
Scenario: VAN25771_TestStep53_Check Active mode should be Balanced Plan and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Performance Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'

@PowerPlanNoPlan
Scenario: VAN25771_TestStep54_Check Balanced Plan should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanNoPlan
Scenario: VAN25771_TestStep55_Check Active mode should be Balanced Plan and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Quiet Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'

@PowerPlanNoPlan
Scenario: VAN25771_TestStep56_Check Balanced Plan should be selected in the System Power Plans
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Given View Control Panel via 'small' type
	Given Choose A Power Plan 'Balanced (recommended)' Is 'Selected'
	Then Close The Power Options Page

@PowerPlanNoPlan
Scenario: VAN25771_TestStep57_Check Active mode should be Balanced Plan and GUID
	Then Power Plan Or GUID 'Legion Performance Mode' Is 'Hidden'
	Then Power Plan Or GUID '52521609-efc9-4268-b9ba-67dea73f18b2' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Balance Mode' Is 'Hidden'
	Then Power Plan Or GUID '85d583c5-cf2e-4197-80fd-3789a227a72c' Is 'Hidden'
	Then Power Plan Or GUID 'Legion Quiet Mode' Is 'Hidden'
	Then Power Plan Or GUID '16edbccd-dee9-4ec4-ace5-2f0b5f2a8975' Is 'Hidden'
	Given click the Thermal mode area
	Given The thermal mode is Balance Mode
	Then Power Plan Or GUID 'Balanced' Is 'Active'
	Then Power Plan Or GUID '381b4222-f694-41f0-9685-ff5bb260df2e' Is 'Active'