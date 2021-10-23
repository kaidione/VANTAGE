Feature: VAN7746_Part2_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author： Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost

@GamingNetworkBoost
Scenario: VAN7746_TestStep12_Check network boost subpage ui spec
	When Click network boost gear icon
	Then Take Screen Shot TestStep12 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep13_The turn on dialog is displayed
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	Then The network boost dialog is displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep14_Check the Turn-on dialog
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	Then Take Screen Shot TestStep14 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep15_Don't ask again checkbox status is unselected
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	Then The network boost dialog checkbox status is unselected

@GamingNetworkBoost
Scenario: VAN7746_TestStep16_The turn on dialog is displayed
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Close network boost dialog
	When Close network boost add apps pop window
	When Click the add icon
	Then The network boost dialog is displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep17_Close network boost pop up window is displayed
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Close network boost dialog
	Then The add apps network boost pop window is displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep18_Network boost subpage toggle status is off
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Close network boost dialog
	When Close network boost add apps pop window
	Then The toggle display off status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep19_Click not now add apps to network boost pop up window is displayed
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Click the not now link
	Then The add apps network boost pop window is displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep20_The toggle display off status in network boost subpage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Close network boost dialog
	When Close network boost add apps pop window
	Then The toggle display off status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep21_Click turn on button dialog will be close and pop up is displayed
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Click turn on button
	Then The add apps network boost pop window is displayed
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep22_Turn on dialog The toggle status is on
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Unselect don't ask agin in network boost checkbox
	When Click turn on button
	When Close network boost add apps pop window
	Then The toggle display on status in network boost subpage
