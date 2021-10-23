Feature: VAN7746_Part5_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author ：Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost
	When Kill process for app list
	When Kill cloudmusic by processName

@GamingNetworkBoost
Scenario: VAN7746_TestStep56_Five apps are added to the Network boost list, add button is gray and cannot be clicked
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Set app list is 5
	Then Take Screen Shot TestStep56 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep68_Hove to remove icon effects
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set app list is 1
	When Hover the remove icon
	Then Take Screen Shot TestStep68 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep69_Remove apps effects
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set app list is 1
	Then Remove apps effects

@GamingNetworkBoost
Scenario: VAN7746_TestStep70_Select icon and restore icon
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then Select icon Restore

@GamingNetworkBoost
Scenario: VAN7746_TestStep71_Kill app click icon the app cannot be added to the list
	When Start NetEase Cloud Music app
	When Click network boost gear icon 
	When Remove all app from add app list
	When Turn on network boost in subpage
	When Click the add icon
	When Select NetEase Cloud Music app
	When kill cloudmusic and wait 0 second 
	When Unselect NetEase Cloud Music app
	When Close network boost add apps pop window
	Then The app can not bedisplayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep72_Remove five app the add list is empty
	When Click network boost gear icon
	When Set app list is 5
	When Remove all app from add app list
	When Kill process for app list
	Then Network boost app list is empty

@GamingNetworkBoost
Scenario: VAN7746_TestStep73_Uninstall app the app can not be displayed in the add list
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Remove all app from add app list
	When Click the add icon
	When Select NetEase Cloud Music app
	When Close network boost add apps pop window
	Then The app displayed in add app list
	When Network boost back to the homepage
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	Then The app can not bedisplayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep74_Turn off apps pop window no app is running UI spec and apps pop window is emtpy
	When Click network boost gear icon
	When Turn off network boost in subpage
	When OOBE dialog
	When Set pop window no app is running
	Then Take Screen Shot TestStep74 in 7746 under GamingScreenShotResult
	Then Pop window display no app running

@GamingNetworkBoost
Scenario: VAN7746_TestStep75_The apps name in add apps window are the running apps name
	When Kill process for app list
	When Click network boost gear icon
	When Turn off network boost in subpage
	When OOBE dialog
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	Then Apps name in add apps window are the running apps name

@GamingNetworkBoost
Scenario: VAN7746_TestStep76_The apps icon in add-apps window are the running apps icon
	When Kill process for app list
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn off network boost in subpage
	When OOBE dialog
	When Click the add icon
	Then Take Screen Shot TestStep76 in 7746 under GamingScreenShotResult