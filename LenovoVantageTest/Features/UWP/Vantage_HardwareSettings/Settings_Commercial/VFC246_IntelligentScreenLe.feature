@IntelligentScreenLe
Feature: VFC246_IntelligentScreenLe
	Test Case： https://jira.tc.lenovo.com/browse/VFC-246
	Author: DaQi Fang

@IntelligentScreenLe
Scenario: VFC246_TestStep02_Displays a collapse button on the right
	Given Go to Smart Assist page
	Then  Display a collapse button on the right

@IntelligentScreenLe
Scenario: VFC246_TestStep03_Displays intelligent screen context description
	Given Go to Smart Assist page
	Then  Shows the context description as Interlligent

@IntelligentScreenLe
Scenario: VFC246_TestStep04_Displays Auto screen off context description
	Given Go to Smart Assist page
	Then  Shows the context description as Autoscreenoff

@IntelligentScreenLe
Scenario: VFC246_Step05 Check 
	Given Go to Smart Assist page
	Then The AutoScreenOff Toggle is disabled
	#Then There has a AutoScreenNever tip
	Then Take Screen Shot VFC246step05 in VFC246 under HSScreenShotResult

@IntelligentScreenLe
Scenario: VFC246_TestStep21_Displays a collapse button on the right
	Given Go to Smart Assist page
	Given Turn On AutoScreenOff btn
	Given Select DisplayAC to 0 minutes
	Then  Shows the context description as Autoscreenoff red context
	Then  Take Screen Shot 21TestStep1 in 7220 under HSScreenShotResult
	Given Change DPI to 125
	When  Scroll the screen 8 in homepage
	Then  Take Screen Shot 21TestStepDPI1 in 7220 under HSScreenShotResult
	When  Scroll the screen 15 in homepage
	Then  Take Screen Shot 21TestStepDPI2 in 7220 under HSScreenShotResult
	Given Change DPI to 100

@IntelligentScreenLe
Scenario: VFC246_TestStep22_Displays a collapse button on the right
	Given Go to Smart Assist page
	When Scroll the screen 30 in homepage
	Given Turn On AutoScreenOff btn
	Given Select DisplayAC to 0 minutes
	Then  Shows the context description as Autoscreenoff red context
	Then  Take Screen Shot 22TestStep1 in 7220 under HSScreenShotResult
	Given change resolution 1028 to 800
	When  Scroll the screen 8 in homepage
	Then  Take Screen Shot 22TestStep2 in 7220 under HSScreenShotResult
	Given change resolution 1366 to 768

@IntelligentScreenLe
Scenario: VFC246_TestStep29_TestStep30_Set Auto Screen off, Battery turn off display never and there is no tip
	Given Select DisplayDC to 300 minutes
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	When Turn off the Auto Screen Off toggle
	Given Select DisplayDC to 0 minutes
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	When  Scroll the screen 30 in homepage
	Then Take Screen Shot 29NoTip in 7220 under HSScreenShotResult
	#Then There is no AutoScreenNever tip
	When Turn on the Auto Screen Off toggle
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	Then The AutoScreenOff Toggle is On
	Then The AutoScreenOff Toggle is disabled
	When  Scroll the screen 30 in homepage
	Then Take Screen Shot 30NeverTip in 7220 under HSScreenShotResult
	#Then There has a AutoScreenNever tip
	Then  Shows the context description as Autoscreenoff red context

@IntelligentScreenLe
Scenario: VFC246_TestStep30_Set Auto Screen off, Battery turn off display never and there is no tip
	When Only Print 'Please check TestStep29'

@IntelligentScreenLe
Scenario: VFC246_TestStep31_Set Auto Screen on, AC turn off display never and there is no tip
	Given Select DisplayDC to 300 minutes
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	When Turn on the Auto Screen Off toggle
	Given Select DisplayAC to 0 minutes
	Given into Dashboard page
	Given Hover the mouse on the 'Device' button using the automationId specified with json path '$.Navbar.device'
	And Go to Smart Assist page
	Then The AutoScreenOff Toggle is Enabled
	Then Take Screen Shot 30NoTip in 7220 under HSScreenShotResult
