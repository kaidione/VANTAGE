@IntelligentScreenOnly
Feature: VAN7220_VFC246_IntelligentScreenQucikTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7220
	Author: Jingting Jia
	Author: Haiye Li

@IntelligentScreenOnly @SmokeIntelligentScreenOnly
Scenario: VAN7220_TestStep01_Check Auto screen off and Keep my display
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then  Display Auto screen off and Keep my display

@IntelligentScreenOnly
Scenario: VAN7220_TestStep02_Displays a collapse button on the right
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then  Display a collapse button on the right

@IntelligentScreenOnly
Scenario: VAN7220_TestStep03_Displays intelligent screen context description
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then  Shows the context description as Interlligent

@IntelligentScreenOnly @SmokeIntelligentScreenOnly
Scenario: VAN7220_TestStep04_Displays Auto screen off context description
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then  Shows the context description as Autoscreenoff

@IntelligentScreenOnly
Scenario: VAN7220_TestStep05_Displays Auto screen off red context
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Given Turn On AutoScreenOff btn
	Given Select DisplayAC to 0 minutes
	Then  Shows the context description as Autoscreenoff red context
	When  wait 30 seconds
	Then  Take Screen Shot 05TestStep in 7220 under HSScreenShotResult 
	Given Turn Off AutoScreenOff btn
	Then  Noshows the context description as Autoscreenoff red context 

@IntelligentScreenOnly
Scenario: VAN7220_TestStep06_Displays Keep my display context
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Given Turn On Keepmydisplay btn
	Given Turn Off Keepmydisplay btn
	Then  Check keep my display Caption
	Then  Check keep my display Slidertitle
	Then  Take Screen Shot 06TestStep in 7220 under HSScreenShotResult
	Then  Check keep my display DisplaySlider
	Then  Check keep my display MinMinutes
	Then  Check keep my display MaxMinutes
	
@IntelligentScreenOnly
Scenario: VAN7220_TestStep21_Displays a collapse button on the right
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Given Turn On AutoScreenOff btn
	Given Select DisplayAC to 0 minutes
	Then  Shows the context description as Autoscreenoff red context
	Then  Take Screen Shot 21TestStep1 in 7220 under HSScreenShotResult
	Given Change DPI to 125
	Then  Take Screen Shot 21TestStepDPI1 in 7220 under HSScreenShotResult
	Given Change DPI to 200

@IntelligentScreenOnly
Scenario: VAN7220_TestStep22_Displays a collapse button on the right
	Given Go to Smart Assist page
	Given Click Intelligent Screen Link
	Given Turn On AutoScreenOff btn
	Given Select DisplayAC to 0 minutes
	Then  Shows the context description as Autoscreenoff red context
	Then  Take Screen Shot 22TestStep1 in 7220 under HSScreenShotResult
	Given change resolution 1028 to 800
	Then  Take Screen Shot 22TestStep2 in 7220 under HSScreenShotResult
	Given change resolution 2560 to 1440

@IntelligentScreenOnly
Scenario: VAN7220_TestStep29_TestStep30_Set Auto Screen off, Battery turn off display never and there is no tip
	Given Select DisplayDC to 300 minutes
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	When Turn off the Auto Screen Off toggle
	Given Select DisplayDC to 0 minutes
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then Take Screen Shot 29NoTip in 7220 under HSScreenShotResult
	#Then There is no AutoScreenNever tip
	When Turn on the Auto Screen Off toggle
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	Then The AutoScreenOff Toggle is On
	Then The AutoScreenOff Toggle is Enabled
	Given Click Intelligent Screen Link
	Then Take Screen Shot 30NeverTip in 7220 under HSScreenShotResult
	#Then There has a AutoScreenNever tip
	Then  Shows the context description as Autoscreenoff red context

@IntelligentScreenOnly
Scenario: VAN7220_TestStep31_Set Auto Screen on, AC turn off display never and there is no tip
	Given Select DisplayDC to 300 minutes
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	When Turn on the Auto Screen Off toggle
	Given Select DisplayAC to 0 minutes
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	Given Click Intelligent Screen Link
	Then The AutoScreenOff Toggle is Enabled
	Then Take Screen Shot 30NoTip in 7220 under HSScreenShotResult
