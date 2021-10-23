Feature: VAN4320_Part2_GamingDriverLackNetfilterTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4320
	Author ：Xiao Yunyan

Background:
	Given Machine is Gaming 

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep14_The Toggle Of Network Boost Can Display Within Vantage Homepage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Then The toggle of network boost can display within Vantage homepage

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep15_The Toggle Of Network Boost Can Display Within Network Boost Subpage
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then jump to network boost subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Then The toggle of network boost can display within Network Boost subpage

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep16_Toggle Cannot Be Changed And NetFilter Driver Lack Window Will Pop Up
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    Then Network Boost Toggle Cannot Be Changed After Click
    Then The NetFilter driver lack window will pop up

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep17_Toggle Can Be Changed Within Subpage
    When Install Gaming driver
    Given Close Vantage
     When ReLaunch Vantage
    When Click network boost gear icon
    Then jump to network boost subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    When Turn on network boost in subpage
    Then The toggle display on status in network boost subpage

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep18_Click The Add Icon
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then jump to network boost subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Then The toggle display on status in network boost subpage
    When Click the add icon
    Then The network boost turn on dialog will be not displayed
    Then The add apps network boost pop window is displayed
    Then Close add apps network boost pop window
    When Turn off network boost in subpage
    Then The toggle display off status in network boost subpage
    When Click the add icon
    Then The network boost dialog is displayed

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep19_Default Toggle Is Off In Homepage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When NetFilter Driver exist or not exist 'not exist'
    Then Network boost toggle status is off

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep20_Default Toggle Is Off In Subpage
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then jump to network boost subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Then The toggle display off status in network boost subpage

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep21_Toggle Status Is Synchronized
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    Then Network boost toggle status is off
    When Click network boost gear icon
    Then jump to network boost subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Then The toggle display off status in network boost subpage
    When Turn on network boost in subpage
    Then The toggle display on status in network boost subpage
    When Click Y logo
    Then Network boost toggle status is on

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep22_Click Install In NetFilter Driver Lack Window
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up
    When Click 'INSTALL' in NetFilter driver lack window
    Then System subpage will be opened

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep23_Click X In NetFilter Driver Lack Window
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up
    When Click 'X' in NetFilter driver lack window
    Then NetFilter driver lack window will be closed and stay current page

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep24_Click Install In NetFilter Driver Lack Window
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up
    When Click 'Cancel' in NetFilter driver lack window
    Then NetFilter driver lack window will be closed and stay current page

@OldDriverLackNetfilterS3
Scenario: VAN4320_TestStep25_NetFilter Driver Lack Window Will Pop Up After Sleep
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Enter sleep
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up

@OldDriverLackNetfilterS4
Scenario: VAN4320_TestStep26_NetFilter Driver Lack Window Will Pop Up After Hibernate
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep28_Open System Update Subpage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click network boost gear icon
    Then The NetFilter driver lack window will pop up
    When Click 'INSTALL' in NetFilter driver lack window
    Then System subpage will be opened

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep29_NetFilter Driver Lack Window Will Pop Up
    When Install Gaming driver
    Given Close Vantage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click Network Boost toggle
    Then The NetFilter driver lack window will pop up
    Then Network Boost Toggle Cannot Be Changed After Click

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep30_NetFilter Driver Lack Window Will Not Pop Up
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    When Uninstall Lenovo Gaming NetFilter Device Driver
    When Click Network Boost toggle
    Then The NetFilter driver lack window will not pop up
    Then Network Boost Toggle Can Be Changed After Click

@OldDriverLackNetfilter
Scenario: VAN4320_TestStep33_NetFilter Driver Installed And Works
    When Install Gaming driver
    Given Close Vantage
    When ReLaunch Vantage
    When Click Network Boost toggle
    Then The NetFilter driver lack window will not pop up
    Then Network Boost Toggle Can Be Changed After Click

@OldDriverLackNetfilterS4
Scenario: VAN4320_TestStep34_NetFilter Driver Installed And Works
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When Click Network Boost toggle
    Then The NetFilter driver lack window will not pop up
    Then Network Boost Toggle Can Be Changed After Click