Feature: VAN8149_GamingReskinSupport
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-8149
	Author： Wei Xu

Background:
	Given Machine is Gaming 

@GamingReskinSupport
Scenario: VAN8149_TestStep01_Open Support Page By Click Support Link In Navigation Bar
	When Click the Support Icon
	When Check Open Support page

@GamingReskinSupport
Scenario: VAN8149_TestStep02_Check Support Link In Navigation Bar
	When Click the Support Icon
	When Check Open Support link
	When Check the Support link

@GamingReskinSupport
Scenario: VAN8149_TestStep03_Click Support Link In Navigation Bar
	When Click the Support Icon
	When Check Open Support link
	When Click the Support link
	When Check Open Support page

@GamingReskinSupport
Scenario: VAN8149_TestStep04_Support Page Is Gaming Style
	When Click the Support Icon
	Then Take Screen Shot TestStep04 in 8149 under GamingScreenShotResult