Feature: DPMSmokeClients
	DPM Smoke Bamboo Agent 1 To Multiple Client

# http://10.119.168.54/common/index.html
@DPMSmokeClientsSpecFlow
Scenario: Run Common DPM Local Run  Client Agent-43
	Given Run Clients '10.119.168.54' And Run Version 'CommonBrand=Common' Run Cat 'cat=DPMSmokePowerUse || cat=DPMSmokeGlobalPowerSettings || cat=DPMSmokePowerPlan || cat=DPMSmokePlanProfile || cat=DPMSmokeCommonCheck'