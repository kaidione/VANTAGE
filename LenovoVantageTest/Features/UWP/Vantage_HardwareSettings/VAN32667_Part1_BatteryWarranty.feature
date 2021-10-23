Feature: VAN32667_Part1_BatteryWarranty
	Test Case： https://jira.tc.lenovo.com/browse/VAN-32667
	Author: Haiye Li

#@TestSealedWarrntyDesktop
Scenario: VAN32667_TestStep01_Check Battery Warranty UI
	When Go to Power Page
	Then The Power Warranty feature will be Hidden

#@TestSealedWarrntyThink
Scenario: VAN32667_TestStep02_Check Battery Warranty UI
	When Go to Power Page
	Then The Power Warranty feature will be Hidden

#@TestSealedWarrnty
Scenario: VAN32667_TestStep04_Check Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo-null and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then Take Screen Shot TestStep04_ItWillShowSealedWarrantyFeature in VAN32667 under WarrantyShotResult
	Then The Power Warranty feature will be Hidden

#@TestSealedWarrnty
Scenario: VAN32667_TestStep18_Check Sealed Battery Warranty UI Status level=003
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo3 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section        | id                                   | desc                                                                                                    |
	| WarrantyTitle  | battery-warranty-duration-title      | Battery Warranty:                                                                                       |
	| RemainingTitle | battery-warranty-timeRemaining-title | Time Remaining:                                                                                         |
	| StartDate      | battery-warranty-startDate-title     | Start Date:                                                                                             |
	| EndDate        | battery-warranty-endDate-title       | End Date:                                                                                               |
	| Tip            | battery-warranty-note-content        | Sealed Battery Warranty extension is only available within the first 12 months since computer purchase. |
	| Button         | battery-warranty-extend-and-explore  | EXPLORE MORE                                                                                            |						
	Then GetResponse from BatteryWarranty Restful API with 'PF2E1ZCH' and '81Y6000DUS' and '00' Type BatteryWarrantySettingsUI

#@TestSealedWarrnty
Scenario: VAN32667_TestStep19_Check Sealed Battery Warranty UI Status level=003
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battery Warranty Question Mark
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section         | id                               | desc                                                                                                                           |
	| QuestionMarkTip | battery-warranty-tooltip-content | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply. |

#@TestSealedWarrnty
Scenario: VAN32667_TestStep20_Check Sealed Battery Warranty UI Status level=003
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXPLORE MORE' Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep20_ItWillShowIframe3 in VAN32667 under WarrantyShotResult

