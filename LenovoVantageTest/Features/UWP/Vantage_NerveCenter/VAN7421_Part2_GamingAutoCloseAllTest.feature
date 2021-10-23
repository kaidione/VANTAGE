Feature: VAN7421_Part2_GamingAutoCloseAllTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7421
	Author： Pengjie Chen
Background: 
	Given Machine is Gaming

 @AutoClose
Scenario: VAN7421_TestStep13_Check turn on auto close popup winodows show and dont ask again checkbox status unselected
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	Then Take Screen Shot TestStep13 in 7421 under GamingScreenShotResult
	Then The turn on auto close popup window dont ask again checkbox status unselected

 @AutoClose
Scenario: VAN7421_TestStep14_Check turn on auto close popup winodows show and dont ask again checkbox status unselected
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	Then Take Screen Shot TestStep14 in 7421 under GamingScreenShotResult
	Then The turn on auto close popup window dont ask again checkbox status unselected

 @AutoClose
Scenario: VAN7421_TestStep15_Check turn on auto close popup winodows show and dont ask again checkbox status unselected
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	Then Take Screen Shot TestStep15 in 7421 under GamingScreenShotResult
	Then The turn on auto close popup window dont ask again checkbox status unselected

 @AutoClose
Scenario: VAN7421_TestStep16_Check click add btn popup winodows show again
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	
 @AutoClose
Scenario: VAN7421_TestStep17_Check add apps popup winodows show and toggle is off
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click X button on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep18_Check add apps popup winodows show and toggle is off
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click X button on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep19_Check click add btn popup winodows show again
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click X button on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show

 @AutoClose
Scenario: VAN7421_TestStep20_Check add apps popup winodows show and toggle is off
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click Not Now link on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep21_Check add apps popup winodows show and toggle is off
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click Not Now link on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	Then The auto close toggle status is on or off within subpage off

 @AutoClose
Scenario: VAN7421_TestStep22_Check turn on auto close popup window show again
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click Not Now link on turn on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show

 @AutoClose
Scenario: VAN7421_TestStep23_Check turn on popup window and auto close toggle is on
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click turn on button on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	Then The auto close toggle status is on or off within subpage on

 @AutoClose
Scenario: VAN7421_TestStep24_Check turn on popup window and auto close toggle is on
	When The user turn off auto close toggle within home page
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage off
	When The user Click add button for auto close
	Then The turn on auto close popup window show or hide show
	When The user click turn on button on auto close popup window
	Then The turn on auto close popup window show or hide hide
	Then The add apps to auto close popup window show or hide show
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide
	Then The auto close toggle status is on or off within subpage on