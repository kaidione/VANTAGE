Feature: VAN7421_Part4_GamingAutoCloseAllTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7421
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming
	When Stop the specified app all

 @AutoClose
Scenario: VAN7421_TestStep37_Check no app and add apps popup winodw show
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Given The user add all or one apps to auto close all
	Then The app count is zero on add apps popup window
	Then Take Screen Shot TestStep37 in 7421 under GamingScreenShotResult

 @AutoClose
Scenario: VAN7421_TestStep38_Check apps exist and add apps popup winodw show
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The app total on popup windows is the same as plugin contract request total
	Then Take Screen Shot TestStep38 in 7421 under GamingScreenShotResult

 @AutoClose
Scenario: VAN7421_TestStep39_Check added app or not added app status is correct
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user add all or one apps to auto close one
	Then The app icon change or unchange on add app popup window is correct

 @AutoClose
Scenario: VAN7421_TestStep40_Check selected app not show on add app window
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user add all or one apps to auto close one
	When The user click X button on add apps popup window
	Then The add apps to auto close popup window show or hide hide

 @AutoClose
Scenario: VAN7421_TestStep41_Check selected app is added and unselected app not added to auto close area
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user add all or one apps to auto close more
	Then The checked app added to auto close area
	Then The unchecked app not added to auto close area

 @AutoClose
Scenario: VAN7421_TestStep42_Check selected app is added and unselected app not added to auto close area
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user add all or one apps to auto close more
	Then The checked app added to auto close area
	Then The unchecked app not added to auto close area

 @AutoClose
Scenario: VAN7421_TestStep43_Check selected app unchecked and not added to auto close area
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user selected one app and unchecked
	When The user click X button on add apps popup window
	Then The selected app and unchecked not added to auto close area

 @AutoClose
Scenario: VAN7421_TestStep44_Check selected app is added to auto close area
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Given The user remove one or all apps from auto close all
	Then The auto close toggle status is on or off within subpage on
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user add all or one apps to auto close more
	Then The checked app added to auto close area

 @AutoClose
Scenario: VAN7421_TestStep45_Check not run app will not show add apps to auto close popup windows
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The current run app list for auto close
	When The user click X button on add apps popup window
	When Stop the specified app NotePad
	When Stop the specified app IE
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then Stop the specified app will not show on add appp to auto close NotePad
	Then Stop the specified app will not show on add appp to auto close IE

 @AutoClose
Scenario: VAN7421_TestStep46_Check toggle is off and run game and run added app still run
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	When The user turn off auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage off
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close NotePad
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage NotePad
	Then The select app added to auto close subpage IE
	When Launch the specifie game GameWorldOfWarcraft
	Then The added app run or not run NotePad run
	Then The added app run or not run IE run
	When Stop the specified app GameWorldOfWarcraft

 @AutoClose
Scenario: VAN7421_TestStep47_Check Check toggle is on and run game and added run app will not run
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close NotePad
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage NotePad
	Then The select app added to auto close subpage IE
	When Launch the specifie game GameWorldOfWarcraft
	Then The added app run or not run NotePad norun
	Then The added app run or not run IE norun
	When Stop the specified app GameWorldOfWarcraft

 @AutoClose
Scenario: VAN7421_TestStep48_Check toggle is on and stop added app and the stop app still show
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close NotePad
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage NotePad
	Then The select app added to auto close subpage IE
	When Stop the specified app NotePad
	When Stop the specified app IE
	Then The select app added to auto close subpage NotePad
	Then The select app added to auto close subpage IE