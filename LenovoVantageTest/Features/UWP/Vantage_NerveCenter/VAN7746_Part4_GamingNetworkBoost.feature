Feature: VAN7746_Part4_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author ：Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost
	When Kill process for app list
	When Kill cloudmusic by processName

@GamingNetworkBoost
Scenario: VAN7746_TestStep39_Hover the icon The icon is highlight
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Start NetEase Cloud Music app
	When Remove NetEase Cloud Music from add app list
	When Hover the mouse on the NetEase Cloud Music icon
	Then Take Screen Shot TestStep39 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep41_Check the new app can not be displayed in the Network Boost pop up window
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	Then NetEase Cloud Music app can not be displayed in pop window

@GamingNetworkBoost
Scenario: VAN7746_TestStep42_Check the new process can be displayed in add process dialog
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Close network boost add apps pop window
	When Click the add icon
	Then The app displayed in pop up window

@GamingNetworkBoost
Scenario: VAN7746_TestStep43_Check the new installed process can not be displayed in add process dialog
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Install NetEase Cloud Music app
	When kill cloudmusic and wait 0 second 
	When Click the add icon
	Then NetEase Cloud Music app can not be displayed in pop window

@GamingNetworkBoost
Scenario: VAN7746_TestStep44_Check the + icon under the new installed will be changed to the √ icon
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Click the add icon
	Then Select icon will be changed

@GamingNetworkBoost
Scenario: VAN7746_TestStep45_Install app not running can not be in dialog, start the app the icon will be changed, the app will be add to list
	When Uninstall NetEase Cloud Music
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Click the add icon
	Then Select icon will be changed
	When Close network boost add apps pop window
	Then The app displayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep46_Check the app can be added and icon goes from + to change √ icon
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Click the add icon
	Then The app displayed in pop up window
	When Uninstall NetEase Cloud Music
	Then Select icon will be changed

@GamingNetworkBoost
Scenario: VAN7746_TestStep47_Check the app that uninstalled can not be added to Network Boost list
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Click the add icon
	Then The app displayed in pop up window
	When Uninstall NetEase Cloud Music
	Then Select icon will be changed
	When Close network boost add apps pop window
	Then The app can not bedisplayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep48_Click icon descriptions remainding "You can add up to 5 additional apps to boost(1 of 5 added)"
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 1
	When Select 1 icon for network bosst pop up window
	When Kill process for app list
	Then Pop up window decription remainding
	"""
	You can add up to 5 additional apps to boost (1 of 5 added )
	"""

@GamingNetworkBoost
Scenario: VAN7746_TestStep49_Click icon descriptions remainding "You can add up to 5 additional apps to boost(2 of 5 added)"
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 2
	When Select 2 icon for network bosst pop up window
	When Kill process for app list
	Then Pop up window decription remainding
	"""
	You can add up to 5 additional apps to boost (2 of 5 added )
	"""

@GamingNetworkBoost
Scenario: VAN7746_TestStep50_Click icon descriptions remainding "You can add up to 5 additional apps to boost(3 of 5 added)"
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	When Select 3 icon for network bosst pop up window
	When Kill process for app list
	Then Pop up window decription remainding
	"""
	You can add up to 5 additional apps to boost (3 of 5 added )
	"""
	
@GamingNetworkBoost
Scenario: VAN7746_TestStep51_Click icon descriptions remainding "You can add up to 5 additional apps to boost(4 of 5 added)"
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 4
	When Select 4 icon for network bosst pop up window
	When Kill process for app list
	Then Pop up window decription remainding
	"""
	You can add up to 5 additional apps to boost (4 of 5 added )
	"""

@GamingNetworkBoost
Scenario: VAN7746_TestStep52_Click icon descriptions remainding "You can add up to 5 additional apps to boost(5 of 5 added)"
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 5
	When Select 5 icon for network bosst pop up window
	When Kill process for app list
	Then Pop up window decription remainding
	"""
	You can add up to 5 additional apps to boost (5 of 5 added )
	"""

@GamingNetworkBoost
Scenario: VAN7746_TestStep53_Five apps are added to the Network boost list, The icon is gray and cannot be clicked
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Click the add icon
	When Set The number of pop up window apps is no less than 6
	When Select 5 icon for network bosst pop up window
	Then Take Screen Shot TestStep53 in 7746 under GamingScreenShotResult