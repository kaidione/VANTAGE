Feature: VAN7746_Part1_GamingNetworkBoost
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-7746
	Author： Jinglong Zhao

Background: 
	When Start the IMC service in the task manager
	Given Machine support Network boost

@GamingNetworkBoost
Scenario: VAN7746_TestStep01_Network boost is displayed in legion edge and toggle status is off
	Given Install Vantage
	When close lenovo vantage
	Given ReLaunch Vantage
	Then Take Screen Shot TestStep01 in 7746 under GamingScreenShotResult
	Then Network boost toggle status is off
	Then Network Boost is displayed in Legion edge 
	
@GamingNetworkBoost @GamingSmokeNetworkBoost
Scenario: VAN7746_TestStep02_The gear icon is diplayed before the toggle switch and ui spec
	Then The gear icon is displayed before the toggle

@GamingNetworkBoost @GamingSmokeNetworkBoost
Scenario: VAN7746_TestStep03_Network boost subpage is opened and the toggle switch status is off
	When Click network boost gear icon
	Then jump to network boost subpage
	Then The toggle display off status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep04_Click back go to homepage
	When Click network boost gear icon
	When Click back button
	Then jump to homepage

@GamingNetworkBoost
Scenario: VAN7746_TestStep05_The toggle status is on
	When Turn off network boost
	When Switch network boost toggle
	Then Network boost toggle status is on

@GamingNetworkBoost
Scenario: VAN7746_TestStep06_Network boost subpage is opened and the toggle status is on
	When Turn on network boost
	When Click network boost gear icon
	Then jump to network boost subpage
	Then The toggle display on status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep07_The toggle status is off
	When Click network boost gear icon
	When Turn off network boost in subpage
	Then The toggle display off status in network boost subpage

@GamingNetworkBoost
Scenario: VAN7746_TestStep08_The toggle status is off
	When Click network boost gear icon
	When Turn off network boost in subpage
	When Click back button
	Then Network boost toggle status is off

@GamingNetworkBoostS3
Scenario: VAN7746_TestStep09_Enter S3 back the function is normal and the subpage layout is consistent with UI spec
	When Click network boost gear icon
	When Get toggle status from network boost subpage
	When enter sleep
	Then Take Screen Shot TestStep09 in 7746 under GamingScreenShotResult
	Then Network boost subpage toggle not charge
	When Switch toggle from network boost subpage
	Then Network boost subpage toggle will be charge

@GamingNetworkBoostS3
Scenario: VAN7746_TestStep10_Enter S4 back the function is normal and the subpage layout is consistent with UI spec
	When Click network boost gear icon
	When Get toggle status from network boost subpage
	When Click Network Boost Header Title
	When enter sleep
	Then Take Screen Shot TestStep10 in 7746 under GamingScreenShotResult
	Then Network boost subpage toggle not charge
	When Switch toggle from network boost subpage
	Then Network boost subpage toggle will be charge