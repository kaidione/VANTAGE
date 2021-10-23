Feature: VAN4320_Part3_GamingDriverLackXTUTest
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-4320
	Author ：Xiao Yunyan
    Test Step: 35 - 42,44,45

Background:
	Given Machine is Gaming

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep35_CPU/RAM OC Toggle Display
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Uninstall XTU Driver
    Then CPU OC display
    Then RAM OC display
    Then There is no OC driver lack window pop up

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep36_Click CPU/RAM OC Toggle Within Homepage
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then RAM OC toggle will not change after click

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep37_Close Pop UP Window And Click CPU/RAM OC Toggle Within Homepage
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Then Click 'X' button in CPU OC driver lack window
    Then There is no OC driver lack window pop up
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then Click 'X' button in RAM OC driver lack window
    Then There is no OC driver lack window pop up
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then RAM OC toggle will not change after click

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep38_Click Install Button And Open System Update Subpage
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Then Click 'INSTALL' button in CPU OC driver lack window
    Then System subpage will be opened
    Given Close Vantage
    Given Launch Vantage
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then Click 'INSTALL' button in RAM OC driver lack window
    Then System subpage will be opened

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep39_Click Close Button
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Then Click 'X' button in CPU OC driver lack window
    Then There is no OC driver lack window pop up
    Given Close Vantage
    When ReLaunch Vantage
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then Click 'X' button in RAM OC driver lack window
    Then There is no OC driver lack window pop up

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep40_Click Cancel Button
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Then Click 'Cancel' button in CPU OC driver lack window
    Then There is no OC driver lack window pop up
    Given Close Vantage
    When ReLaunch Vantage
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then Click 'Cancel' button in RAM OC driver lack window
    Then There is no OC driver lack window pop up

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep41_Open System Update Subpage
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Then Click 'INSTALL' button in CPU OC driver lack window
    Then System subpage will be opened
    Given Close Vantage
    When ReLaunch Vantage
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then Click 'INSTALL' button in RAM OC driver lack window
    Then System subpage will be opened

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep42_Click CPU/RAM OC Toggle Within Homepage After Sleep
    When Uninstall XTU Driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    When close lenovo vantage
    Given Launch Vantage
    When Enter sleep
    When Click CPU area within homepage
    Then CPU OC driver lack window pop up
    Given Launch Vantage
    When Enter sleep
    When Click RAM OC toggle within homepage
    Then RAM OC driver lack window pop up
    Then RAM OC toggle will not change after click

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep44_Install Driver And No Pop Up
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click CPU area within homepage
    Then There is no OC driver lack window pop up
    Given Close Vantage
    When ReLaunch Vantage
    When Click RAM OC toggle within homepage
    Then There is no OC driver lack window pop up
    Then RAM OC toggle will not change after click

@OldDriverLackXTUS4
Scenario: VAN4320_TestStep45_Install Driver And Hibernate
    When Install Gaming driver
    When Enter hibernate
    When Wait '300' seconds until the machine enters the system
    Given Launch Vantage
    When Click CPU area within homepage
    Then There is no OC driver lack window pop up
    Given Close Vantage
    When ReLaunch Vantage
    When Click RAM OC toggle within homepage
    Then There is no OC driver lack window pop up
    Then RAM OC toggle will not change after click