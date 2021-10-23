@TestSealedWarrnty
Feature: VAN32667_Part2_BatteryWarranty
	Test Case： https://jira.tc.lenovo.com/browse/VAN-32667
	Author: Haiye Li

@TestSealedWarrnty
Scenario: VAN32667_TestStep03_Check Battery Warranty UI
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo_No_SN and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Power Warranty feature will be Hidden

@TestSealedWarrnty
Scenario: VAN32667_TestStep05_Check Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section              | id                                                  | desc                        |
	| BatteryWarrantyLink  | jumptoSetting-battery                               | Battery warranty & settings |
	| BatteryWarrantyTitle | device-settings-batterySettings-collapse-card-title | Battery warranty & settings |

@TestSealedWarrnty
Scenario: VAN32667_TestStep06_Check Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section                | id                             | desc                                                                                                                                                                                                                                                                                                                                                                |
	| BatteryWarrantycaption | power-battery-warranty-caption | Every machine which has a sealed battery, has a 1-year sealed battery warranty by default. Protect your investment by extending beyond the 1-year battery warranty, and make sure this crucial component gets the same coverage as the rest of your device. Extend your battery warranty with Sealed Battery Warranty which is available for up to 3-year coverage. |

@TestSealedWarrnty
Scenario: VAN32667_TestStep07_Check Battery Warranty UI
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then Click More Button
	And No More Button Show Less Button
	Then  Click Less Button
	Then No Less Button Show More Button

@TestSealedWarrnty
Scenario: VAN32667_TestStep08_Check Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then Click More Button
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section                     | id                             | desc                                                                                             |
	| BatteryWarrantyBendfitText1 | battery-warranty-benefit-text1 | - Low upfront cost is significantly less than that of a non-covered replacement battery          |
	| BatteryWarrantyBendfitText2 | battery-warranty-benefit-text2 | - Be assured of an effective and efficient battery replacement with Lenovo certified technicians |
	| BatteryWarrantyBendfitText3 | battery-warranty-benefit-text3 | - Sealed batteries are difficult to get to and are non-customer replaceable units                |

@TestSealedWarrnty
Scenario: VAN32667_TestStep09_Check Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then Click More Button
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section                     | id                                 | desc                                                                             |
	| BatteryWarrantyBendfitText4 | battery-warranty-benefit-text-more | For more information on Sealed Battery Warranty, go to Warranty and Protection . |
	Then Click Warranty and Protection
	Then Click 'Warranty and Protection' It Will Launch A Website 
	Then Take Screen Shot TestStep09_JumpToWarrantyAndProtection in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep10_Check Battery Warranty UI 
	Given Close Vantage
	Given Change system language to zh-CN
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then Click More Button
	Then BatteryWarrantyBendfitText4 And Warranty and Protection shoule be hidden
	Given Change system language to en-US

@TestSealedWarrnty
Scenario: VAN32667_TestStep11_Check Sealed Battery Warranty UI 
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then Click More Button
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section   | id                             | desc                   |
	| ContactUs | battery-upsell-contact-us-text | Need customer service? |
	Then Click Contact Us
	Then Click 'Contact Us' It Will Launch A Website
	Then Take Screen Shot TestStep11_JumpToContactUs in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep12_Check Sealed Battery Warranty UI Status level=005-1 SoH ＜80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section     | id										 | desc																											|
	| Title       | battery-warranty-not-available-title     | Battery Warranty:																						    |
	| Value       | battery-warranty-not-available-value     | Not available																								|
	| Tip         | battery-warranty-note-content		     | Sealed Battery Warranty extension is only available within the first 12 months since computer purchase.	    |
	| Button      | battery-warranty-extend-and-explore	     | EXPLORE MORE																									|

@TestSealedWarrnty
Scenario: VAN32667_TestStep13_Check Sealed Battery Warranty UI Status level=005-1 SoH ＜80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXPLORE MORE' Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep13_ItWillShowIframe3 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep14_Check Sealed Battery Warranty UI Status level=005-1 SoH >=80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section | id                                   | desc                                                                                                    |
	| Title   | battery-warranty-not-available-title | Battery Warranty:                                                                                       |
	| Value   | battery-warranty-not-available-value | Not available                                                                                           |
	| Tip     | battery-warranty-note-content        | Sealed Battery Warranty extension is only available within the first 12 months since computer purchase. |
	| Button  | battery-warranty-extend-and-explore	 | EXTEND BATTERY WARRANTY																				   |

@TestSealedWarrnty
Scenario: VAN32667_TestStep15_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXTEND BATTERY WARRANTY' Button
	Then It Will Show Iframe Sealed Battery Warranty
	Then It Will Show Iframe Sealed Battery
	Then Take Screen Shot TestStep15_ItWillShowIframe1 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep16_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe2 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section       | id                                   | desc                                                                                                    |
	| WarrantyTitle | battery-warranty-not-available-title | Battery Warranty:                                                                                       |
	| Value         | battery-warranty-not-available-value | Not available                                                                                           |
	| Tip           | battery-warranty-note-content        | Sealed Battery Warranty extension is only available within the first 12 months since computer purchase. |
	| Button        | battery-warranty-extend-and-explore  | EXTEND BATTERY WARRANTY                                                                                 |

@TestSealedWarrnty
Scenario: VAN32667_TestStep17_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXTEND BATTERY WARRANTY' Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty
	Then Take Screen Shot TestStep17_ItWillShowIframe2 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep21_Check Sealed Battery Warranty UI Status level=004
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo4 and SB00
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
	#Then GetResponse from BatteryWarranty Restful API with 'PF21H368' and '' and '90' Type BatteryWarrantySettingsUI
	Then GetResponse from BatteryWarranty Restful API with 'PF230WCP' and '' and '90' Type BatteryWarrantySettingsUI

@TestSealedWarrnty
Scenario: VAN32667_TestStep22_Check Sealed Battery Warranty UI Status level=004
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battery Warranty Question Mark
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section         | id                               | desc                                                                                                                           |
	| QuestionMarkTip | battery-warranty-tooltip-content | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply. |

@TestSealedWarrnty
Scenario: VAN32667_TestStep23_Check Sealed Battery Warranty UI Status level=004
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXPLORE MORE' Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep23_ItWillShowIframe3 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep24_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
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
	| Button         | battery-warranty-extend-and-explore  | EXPLORE MORE																									|
	#Then GetResponse from BatteryWarranty Restful API with 'MP1L8D4V' and '81CU0040US' and '60' Type BatteryWarrantySettingsUI
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '60' Type BatteryWarrantySettingsUI

@TestSealedWarrnty
Scenario: VAN32667_TestStep25_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battery Warranty Question Mark
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section         | id                               | desc                                                                                                                           |
	| QuestionMarkTip | battery-warranty-tooltip-content | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply. |

@TestSealedWarrnty
Scenario: VAN32667_TestStep26_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXPLORE MORE' Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep26_ItWillShowIframe3 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep27_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe2 and SB90
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
	| Button         | battery-warranty-extend-and-explore  | EXTEND BATTERY WARRANTY																						|
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '90' Type BatteryWarrantySettingsUI

@TestSealedWarrnty
Scenario: VAN32667_TestStep28_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battery Warranty Question Mark
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section         | id                               | desc                                                                                                                           |
	| QuestionMarkTip | battery-warranty-tooltip-content | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply. |

@TestSealedWarrnty
Scenario: VAN32667_TestStep29_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battert Settings 'EXTEND BATTERY WARRANTY' Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty
	Then Take Screen Shot TestStep29_ItWillShowIframe2 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep30_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB90
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
	| Button         | battery-warranty-extend-and-explore  | EXTEND BATTERY WARRANTY																						|
	#Then GetResponse from BatteryWarranty Restful API with 'MP1L8D4V' and '81CU0040US' and '90' Type BatteryWarrantySettingsUI
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '90' Type BatteryWarrantySettingsUI

@TestSealedWarrnty
Scenario: VAN32667_TestStep31_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Given Jump to Battery settings
	When Click Battery Warranty Question Mark
	Then The Battery Warranty Settings value and Tip should follow the SPEC
	| section         | id                               | desc                                                                                                                           |
	| QuestionMarkTip | battery-warranty-tooltip-content | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply. |

@TestSealedWarrnty
Scenario: VAN32667_TestStep32_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	When Click Battert Settings 'EXTEND BATTERY WARRANTY' Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty
	Then Take Screen Shot TestStep31_ItWillShowIframe1 in VAN32667 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN32667_TestStep33_Check Battery Warranty UI
	Given Install Vantage
	Given Close Vantage
	Given Modifying the Service fileSmb Value Add
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB00
	When Restart Vantage Service
	Given ReLaunch Vantage
	When Go to Power Page
	Then The Battery Warranty UI should be displayed within 3 seconds when first launch
	Given Close Vantage
	Given ReLaunch Vantage
	When Go to Power Page
	Then The Battery Warranty UI should be displayed within 2 seconds when second launch
