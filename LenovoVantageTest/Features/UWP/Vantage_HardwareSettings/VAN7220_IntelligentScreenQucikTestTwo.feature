Feature: VAN7220_IntelligentScreenQucikTestTwo
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7220
	Author: Haiye Li

@NoIntelligentScreenOnThink @SmokeIntelligentScreenNoPage @NotIntelligentScreenLe
Scenario: VAN7220_TestStep28_Machine is ThinkPad but not Yoge, there is no Intelligent Screen feature
	Given Go to Smart Assist page
	Then There Is No Intelligent Screen Function
