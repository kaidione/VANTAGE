Feature: VAN7746_Part3_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author： Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost

@GamingNetworkBoost
Scenario: VAN7746_TestStep23_Don't ask again checkbox is selected
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	Then The checkbox status is selected

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep24_Check the Turn on dialog is closed and Add apps to Network Boost pop-up window is displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Close network boost dialog
	Then The add apps network boost pop window is displayed
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep25_Check the Turn on dialog will not be displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Close network boost dialog
	When Close network boost add apps pop window
	When Click the add icon
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep26_Check the Network boost toggle switch status is OFF
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Close network boost dialog
	When Close network boost add apps pop window
	Then The toggle display off status in network boost subpage

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep27_Check the Turn on dialog is closed and Add apps to Network Boost pop-up window is displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click the not now link
	Then The add apps network boost pop window is displayed
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep28_Check Network Boost toggle switch status is OFF
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click the not now link
	When Close network boost add apps pop window
	Then The toggle display off status in network boost subpage

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep29_Check the Turn on dialog will not be displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click the not now link
	When Close network boost add apps pop window
	When Click the add icon
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep30_Click turn on The network boost turn on dialog will be not displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click turn on button
	When Close network boost add apps pop window
	When Click the add icon
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep31_Click turn on The network boost turn on dialog will be not displayed and Add apps to Network Boost pop up window is displayed
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click turn on button
	Then The add apps network boost pop window is displayed
	Then The network boost turn on dialog will be not displayed

@GamingNetworkBoostInstallVantage
Scenario: VAN7746_TestStep32_Click turn on The Network Boost toggle switch status is ON
	When Stop the IMC service in the task manager
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click the add icon
	When Select don't ask agin checkbox in network boost subpage
	When Click turn on button
	When Close network boost add apps pop window
	Then The toggle display on status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep33_Turn on dialog The toggle status is on
	When close lenovo vantage
	Given ReLaunch Vantage
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	Then The add apps network boost pop window is displayed

@GamingNetworkBoost
Scenario: VAN7746_TestStep34_Apps pop window no app is running UI spec and apps pop window is emtpy
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set pop window no app is running
	Then Take Screen Shot TestStep34 in 7746 under GamingScreenShotResult
	Then Pop window display no app running

@GamingNetworkBoost
Scenario: VAN7746_TestStep35_Check the Add apps to Network Boost pop-up window
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set pop window is running
	Then Take Screen Shot TestStep35 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep36_Check the icon under app name goes from + to change √ icon
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set pop window is running
	Then Icon under the app name
	Then Take Screen Shot TestStep36 in 7746 under GamingScreenShotResult

@GamingNetworkBoost
Scenario: VAN7746_TestStep37_Kill process apps still displayed in add apps list
	When Install NetEase Cloud Music app
	When Start NetEase Cloud Music app
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Set some running for add apps list
	When kill cloudmusic and wait 0 second 
	Then The app displayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep38_Kill process apps add app still displayed in add apps list
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Remove NetEase Cloud Music from add app list
	When Start NetEase Cloud Music app
	When Minimized vantage
	When Click the add icon
	When kill cloudmusic and wait 0 second 
	When Select NetEase Cloud Music app
	When Close network boost add apps pop window
	Then The app displayed in add app list

@GamingNetworkBoost
Scenario: VAN7746_TestStep40_New app can not be dislapyed in pop window
	When Click network boost gear icon
	When Turn on network boost in subpage
	When Click the add icon
	When Install NetEase Cloud Music app
	Then NetEase Cloud Music app can not be displayed in pop window
