Feature: VAN7421_Part5_GamingAutoCloseAllTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7421
	Author： Pengjie Chen

Background: 
	Given Machine is Gaming
	When Stop the specified app all

 @AutoClose
Scenario: VAN7421_TestStep50_Check toggle is on and added 10 apps and the added apps show
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 10 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 10 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Stop the specified app all

 @AutoClose
Scenario: VAN7421_TestStep52_Check toggle is on and added 10 apps and the added apps show
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 10 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 10 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Stop the specified app all

 @AutoClose45App
Scenario: VAN7421_TestStep51_Check toggle is on and added 50 apps and the added apps show
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 45 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user selected one app and unchecked
	Then Take Screen Shot TestStep51 in 7421 under GamingScreenShotResult
	Then The running 45 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Stop the specified app all

 @AutoClose45App
Scenario: VAN7421_TestStep53_Check toggle is on and added 50 apps and the added apps show
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 45 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Given The user selected one app and unchecked
	Then Take Screen Shot TestStep52 in 7421 under GamingScreenShotResult
	Then The running 45 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Stop the specified app all

 @AutoClose
Scenario: VAN7421_TestStep54_Check toggle is on and hover added app X button show
	When Stop the specified app all
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage IE
	When The user hover to added app on auto close subpage IE
	Given The user remove one or all apps from auto close one
	Then The remove app will not show on auto close subpage

 @AutoClose
Scenario: VAN7421_TestStep55_Check toggle is on and hover added app X button show
	When Stop the specified app all
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage IE
	When The user hover to added app on auto close subpage IE
	Given The user remove one or all apps from auto close one
	Then The remove app will not show on auto close subpage

 @AutoClose
Scenario: VAN7421_TestStep56_Check run a game and not added app still run
	When Stop the specified app all
	When Launch the specified app as current user IE
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close IE
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage IE
	Given The user remove one or all apps from auto close one
	Then The remove app will not show on auto close subpage
	When Launch the specifie game GameWorldOfWarcraft
	Then The added app run or not run IE run
	When Stop the specified app GameWorldOfWarcraft

 @AutoCloseS3
Scenario: VAN7421_TestStep57_Check run a game S3 and not added app still run 
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 3 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 3 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Enter sleep
	When Launch the specifie game GameWorldOfWarcraft
	Then The added applist run or not run norun

 @AutoCloseS4
Scenario: VAN7421_TestStep58_Check run a game S4 and not added app still run
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 5 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 5 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Enter hibernate
	When Launch the specifie game GameWorldOfWarcraft
	Then The added applist run or not run norun

 @AutoCloseS3S4
Scenario: VAN7421_TestStep60_Check toggle is on S3 S4 and hover added app X button show
	When Stop the specified app all
	Given Go to auto close subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When Launch the specified 3 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 3 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Enter hibernate
	When Launch the specifie game GameWorldOfWarcraft
	Then The added applist run or not run norun
	Given The user remove one or all apps from auto close all
	Then The remove app will not show on auto close subpage
	When Stop the specified app all
	When Launch the specified 5 app as current user
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	Then The running 5 apps show on add app to auto close popup windows
	When The user add specified applist to auto close
	When The user click X button on add apps popup window
	Then The select applist added to auto close subpage
	When Enter sleep
	When Launch the specifie game GameWorldOfWarcraft
	Then The added applist run or not run norun
	Given The user remove one or all apps from auto close all
	Then The remove app will not show on auto close subpage
	When Stop the specified app GameWorldOfWarcraft