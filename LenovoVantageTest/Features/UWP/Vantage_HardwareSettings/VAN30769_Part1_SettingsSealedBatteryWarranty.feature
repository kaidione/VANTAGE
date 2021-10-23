Feature: VAN30769_Part1_SettingsSealedBatteryWarranty
		Test Case： https://jira.tc.lenovo.com/browse/VAN-30769
	Author: Haiye Li

@TestSealedWarrntyDesktop
Scenario: VAN30769_TestStep01_Check Sealed Battery Warranty UI
	When Go to Power Page
	Then The Sealed Warranty feature will be Hidden

@TestSealedWarrntyThink
Scenario: VAN30769_TestStep02_Check Sealed Battery Warranty UI
	When Go to Power Page
	Then The Sealed Warranty feature will be Hidden

#@TestSealedWarrnty
Scenario: VAN30769_TestStep05_Check Sealed Battery Warranty UI Status level=null
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo-null and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then Take Screen Shot TestStep05_ItWillShowSealedWarrantyFeature in VAN30769 under WarrantyShotResult
	Then The Sealed Warranty feature will be Hidden
	Then GetResponse from BatteryWarranty Restful API with 'R9125ZZL' and '81X20005US' and '00' Type SMBInfoNull

#@TestSealedWarrnty
Scenario: VAN30769_TestStep15_Check Sealed Battery Warranty UI Status level=003
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo3 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section				| desc																												  |
	| SealedTitle			| Sealed Battery Warranty																							  |
	| Title					| Battery Warranty:																									  |
	| BatteryUpSellexpired  | (expired)																											  |
	| Tip					| Your sealed battery is now out of warranty. Check for more Lenovo premium options and services.					  |
	| Button				| EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	Then GetResponse from BatteryWarranty Restful API with 'PF2E1ZCH' and '81Y6000DUS' and '90' Type SMBInfo3SB00

#@TestSealedWarrnty
Scenario: VAN30769_TestStep16_Check Sealed Battery Warranty UI Status level=003
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

#@TestSealedWarrnty
Scenario: VAN30769_TestStep17_Check Sealed Battery Warranty UI Status level=003
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep17_ItWillShowIframe3 in VAN30769 under WarrantyShotResult


@TestSealedWarrntySleephibernate
Scenario: VAN30769_TestStep37_Check the UI should be correct, not overlap or truncate
	Given Modifying the Service fileSmb Value Add
	Given Modifying IdeaNotbookPlugin to ForTesting Version
	Given Restart IMC Service 
	When Restart Vantage Service
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	When enter sleep
	Then The Sealed Warranty feature will be Displayed
	Then Take Screen Shot TestStep37_Sleep in VAN30769 under WarrantyShotResult
	Given Modifying the Service fileSmb Value Delete
	Given Modifying IdeaNotbookPlugin to Staging Version
	Given Delete lenovo vantage SMBInfo json file And Delete regedit SmartBatteryV2
	Given Restart IMC Service 
	When Restart Vantage Service

@TestSealedWarrntySleephibernate
Scenario: VAN30769_TestStep38_Check the UI should be correct, not overlap or truncate
	Given Modifying the Service fileSmb Value Add
	Given Modifying IdeaNotbookPlugin to ForTesting Version
	Given Restart IMC Service 
	When Restart Vantage Service
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	When enter hibernate
	Then The Sealed Warranty feature will be Displayed
	Then Take Screen Shot TestStep37_Hhibernate in VAN30769 under WarrantyShotResult
	Given Modifying the Service fileSmb Value Delete
	Given Delete lenovo vantage SMBInfo json file And Delete regedit SmartBatteryV2
	Given Modifying IdeaNotbookPlugin to Staging Version
	Given Restart IMC Service 
	When Restart Vantage Service