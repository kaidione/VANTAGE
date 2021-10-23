Feature: VAN4320_Part1_2_GamingDriverLackTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4320
	Author ：Xiao Yunyan
    Test Step: 1-9,11-13

Background:
	Given Machine is Gaming 

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep01_Lighting Section Display
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    Then The Lighting section is display or not display in homepage 'display'

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep02_Lighting Driver Lack Window Pop Up
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '2' in homepage
    Then The lighting driver lack window will pop up
    Given Close Vantage
    Given Launch Vantage
    When Click Profile 'off' in homepage
    Then The lighting driver lack window will pop up

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep03_Lighting Driver Lack Window Pop Up Again
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '3' in homepage
    Then The lighting driver lack window will pop up
    When Click "X" on lighting driver lack window
    Then Lighting driver lack window is closed and stay current page
    When Click Profile '3' in homepage
    Then The lighting driver lack window will pop up

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep04_Open System Update Subpage
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '1' in homepage
    Then The lighting driver lack window will pop up
    When Click "INSTALL" on lighting driver lack window
    Then System subpage will be opened

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep05_Lighting Driver Lack Window Closed
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '3' in homepage
    Then The lighting driver lack window will pop up
    When Click "X" on lighting driver lack window
    Then Lighting driver lack window is closed and stay current page

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep06_Lighting Driver Lack Window Closed
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '3' in homepage
    Then The lighting driver lack window will pop up
    When Click "Cancel" on lighting driver lack window
    Then Lighting driver lack window is closed and stay current page

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep07_Lighting Driver Lack Window Not Pop Up
    When Install Gaming driver
    Given Close Vantage
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Uninstall Lenovo Gaming LED Driver
    When Click Profile '3' in homepage
    Then The lighting driver lack window will not pop up 

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep08_Lighting Driver Lack Window Pop Up After Sleep
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Enter sleep
    When Click lighting Customize Icon in homepage
    Then The lighting driver lack window will pop up

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep09_Lighting Driver Lack Window Pop Up After Hibernate
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Enter hibernate
    When Click lighting Customize Icon in homepage
    Then The lighting driver lack window will pop up

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep11_Open System Update Subpage
    When Uninstall Lenovo Gaming LED Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click Profile '1' in homepage
    Then The lighting driver lack window will pop up
    When Click "INSTALL" on lighting driver lack window
    Then System subpage will be opened

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep12_Lighting Subpage Will Show After Install Driver
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    When Launch Vantage
    When Click Profile '3' in homepage
    Then The lighting driver lack window will not pop up
    When Click the Customize button
    Then The Lighting subpage will show

@OldDriverLackLightingS4
Scenario: VAN4320_TestStep13_Lighting Subpage Will Work After Hibernate
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    When Launch Vantage
    When Click Profile '3' in homepage
    Then The lighting driver lack window will not pop up
    When Click the Customize button
    Then The Lighting subpage will show
    When Click Profile 'off' in Lighting subpage
    Then The brightness slider will not show
    When Click Profile '3' in Lighting subpage
    Then The brightness slider will show