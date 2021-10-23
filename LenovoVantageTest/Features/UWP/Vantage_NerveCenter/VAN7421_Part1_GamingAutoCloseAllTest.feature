Feature: VAN7421_Part1_GamingAutoCloseAllTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7421
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming

 @AutoClose @GamingSmokeAutoClose
Scenario: VAN7421_TestStep01_Check Auto Close show and toggle status is off within legion home page
	Given AC Condition(Connect the Adapter)
	Then The auto close will be shown within legion home page
	Then Take Screen Shot TestStep01_02 in 7421 under GamingScreenShotResult

 @AutoClose
Scenario: VAN7421_TestStep02_Check Auto Close show and toggle status is off within legion home page
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Install Vantage
	Given Launch Vantage
	Then The auto close toggle status is on or off within home page off
	Then The auto close will be shown within legion home page

 @AutoClose @GamingSmokeAutoClose
Scenario: VAN7421_TestStep03_Check Auto Close show and toggle status is off within subpage
	When The user turn off auto close toggle within home page
	Then The auto close toggle status is on or off within home page off
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep04_Check Auto Close show and toggle status is off within subpage
	Given Go to auto close subpage
	Then The auto close will be shown within subpage
	When The user click auto close back button
	Then The current page is home or subpage for auto close home

 @AutoClose
Scenario: VAN7421_TestStep05_Check Auto Close show and toggle status is on within home page
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on

 @AutoClose
Scenario: VAN7421_TestStep06_Check Auto Close toggle status is on within sub page
	When The user turn on auto close toggle within home page
	Then The auto close toggle status is on or off within home page on
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on

 @AutoClose
Scenario: VAN7421_TestStep07_Check Auto Close toggle status is off within sub page
	Given Go to auto close subpage
	When The user turn off auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep08_Check Auto Close toggle status is on within home page
	Given Go to auto close subpage
	When The user turn off auto close toggle within subpage
	When The user click auto close back button
	Then The auto close toggle status is on or off within home page off

 @AutoCloseS3
Scenario: VAN7421_TestStep09_Check Auto Close show S3
	Given Go to auto close subpage
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on
	When Enter sleep
	Then Take Screen Shot TestStep09 in 7421 under GamingScreenShotResult
	Then The auto close toggle status is on or off within subpage on
	When The user turn off auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage off

 @AutoCloseS4
Scenario: VAN7421_TestStep10_Check Auto Close show S4
	Given Go to auto close subpage
	When The user turn off auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage off
	When Enter hibernate
	Then Take Screen Shot TestStep10 in 7421 under GamingScreenShotResult
	Then The auto close toggle status is on or off within subpage off
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on

 @AutoClose
Scenario: VAN7421_TestStep12_Check the subpage displayed is consitent with UI defination
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	Then Take Screen Shot TestStep12 in 7421 under GamingScreenShotResult
	Then The auto close description is correct
	"""
	Add apps that you want to close when you launch a game. This will free up unused resources to maximize the gaming performance. NOTE: This feature closes the app completely. So always make sure that you've saved your work.
	"""