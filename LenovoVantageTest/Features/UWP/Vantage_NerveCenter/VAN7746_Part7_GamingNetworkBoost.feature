Feature: VAN7746_Part7_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author ：Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	When Kill process for app list
	When Kill cloudmusic by processName

@GamingNetworkBoost
Scenario: VAN7746_TestStep100_Reinstall vantage cannot be displayed in the list
	Given Machine support Network boost
	#Given Install Vantage
	When Click network boost gear icon
	When Turn on network boost in subpage
	#When Click the add icon
	When Set app list is 5
	#Given Close Vantage
	#Given Launch Vantage network boost
	Given Install Vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	Then Network boost app list is empty

@GamingNetworkBoost
Scenario: VAN7746_TestStep101_Open pop up window navigation bar cannot click
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Kill process for app list
	#When Click the add icon
	When Set app list is 3
	#When Click the add icon
	Then Navigation bar cannot click

@GamingNetworkBoost
Scenario: VAN7746_TestStep102_Network boost add app popup display empty
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Pop up window apps is no running
	Then Pop window display no app running

@GamingNetworkBoost
Scenario: VAN7746_TestStep103_Popup add-apps windows list and display current running apps process
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	When Set The number of pop up window apps is no less than 3
	Then Apps name in add apps window are the running apps name

@GamingNetworkBoost
Scenario: VAN7746_TestStep104_Popup add-apps windows list and display current running apps process
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	#When Click the add icon
	When Set app list is 3
	When Hover the remove icon
	Then Take Screen Shot TestStep104 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep105_Click icon the APP will be removed from the apps added list
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	#When Click the add icon
	When Set app list is 3
	When Remove all app from add app list
	Then Network boost app list is empty

@GamingNetworkBoost
Scenario: VAN7746_TestStep106_Click icon the APP will be removed from the apps added list
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	#When Click the add icon
	When Set app list is 3
	When Remove all app from add app list
	When Kill process for add app list
	Then Network boost app list is empty

@GamingNetworkBoost
Scenario: VAN7746_TestStep107_Should be removed from the add-apps window and display have no apps running
	Given Machine support Network boost
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove all app from add app list
	When Kill process for app list
	When Pop up window apps is no running
	When Click the add icon
	When Set The number of pop up window apps is no less than 1
	When Select 1 icon for network bosst pop up window
	When Close network boost add apps pop window
	When Click the add icon
	Then Pop window display no app running