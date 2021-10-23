Feature: VAN5936_GamingRapidCharge
    Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-5936
	Author ：Wenhuan Zhang

Background: 
	Given Machine is Gaming

@GamingUnSupportRapidChargeTest @C730 @GamingSmokeNoRapidCharge
Scenario: VAN5936_TestStep01_Check Rapid Charge not display in desktop
	Then Rapid Charge is displayed no

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep02_Check Rapid Charge display in notebook
	Then Rapid Charge is displayed exist
	Then Rapid Charge Toggle status off

@GamingRapidChargeTest @Y550 @GamingSmokeRapidCharge
Scenario: VAN5936_TestStep03
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep04
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When ReLaunch Vantage
	Then Rapid Charge Toggle status on

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep05
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When Enter to other subpage
	When Return to homepage
	Then Rapid Charge Toggle status on

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep06
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When Click power icon in the system tools
	Then The Device settings power page is opened

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep07
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When Click power icon in the system tools
	Then The Device settings power page is opened
	Then Power page rapid charge toggle status on

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep08
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When Click power icon in the system tools
	Then The Device settings power page is opened
	Then Power page rapid charge toggle status on
	When Click the Rapid Charge toggle in the Power page
	Then Power page rapid charge toggle status off

@GamingRapidChargeTest @Y550 
Scenario: VAN5936_TestStep09
	Then Rapid Charge is displayed exist
	When Switch Rapid Charge toggle status to on
	Then Rapid Charge Toggle status on
	When Click power icon in the system tools
	Then The Device settings power page is opened
	Then Power page rapid charge toggle status on
	When Click the Rapid Charge toggle in the Power page
	Then Power page rapid charge toggle status off
	When Return to homepage
	Then Rapid Charge Toggle status Off