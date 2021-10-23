Feature: VAN7746_Part6_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author ：Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost
	When Kill process for app list
	When Kill cloudmusic by processName

@GamingNetworkBoost
Scenario: VAN7746_TestStep77_Check app name sorted
	When Click network boost gear icon
	When Remove all app from add app list
	When Turn off network boost in subpage
	When OOBE dialog
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	Then Take Screen Shot TestStep77 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep78_New installed app can be displayed in pop up window
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then The app displayed in pop up window

@GamingNetworkBoost
Scenario: VAN7746_TestStep79_Uninstall app still exists in pop up window
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then The app displayed in pop up window

@GamingNetworkBoost
Scenario: VAN7746_TestStep80_Minimized vantage install new app will be display new installed app 
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Minimize vantage
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Max vantage
	When Click the add icon
	Then The app displayed in pop up window

@GamingNetworkBoost
Scenario: VAN7746_TestStep81_Uninstall app still in pop up window
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then The app displayed in pop up window
	When Uninstall NetEase Cloud Music
	Then The app displayed in pop up window

@GamingNetworkBoost
Scenario: VAN7746_TestStep82_Uninstall app reopen vantage the app should be disappeared in pop up window
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then The app displayed in pop up window
	When Uninstall NetEase Cloud Music
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Click the add icon
	Then NetEase Cloud Music app can not be displayed in pop window

@GamingNetworkBoostS3
Scenario: VAN7746_TestStep89_Added apps list is consistent with before enter to the S3 mode
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	When Click The Network Boost Popup Window Description
	When Enter sleep
	When The user connect or disconnect WiFi on lenovo
	When wait 20 seconds
	Then Apps list not charge

@GamingNetworkBoostS4
Scenario: VAN7746_TestStep90_Added apps list is consistent with before enter to the S4 mode
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	When Click The Network Boost Popup Window Description
	When Enter hibernate
	When wait 20 seconds
	Then Apps list not charge

@GamingNetworkBoost
Scenario: VAN7746_TestStep98_The icon and name of apps should be display normally
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	Then Take Screen Shot TestStep98 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep99_Add apps process icon display normal
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	When Minimized vantage
	Then Take Screen Shot TestStep99 in 7746 under GamingScreenShotResult