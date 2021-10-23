@TestSealedWarrnty
Feature: VAN30769_Part2_SettingsSealedBatteryWarranty
	Test Case： https://jira.tc.lenovo.com/browse/VAN-30769
	Author: Haiye Li

@TestSealedWarrnty
Scenario: VAN30769_TestStep04_Check Sealed Battery Warranty UI Status level=null
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo_No_SN and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Sealed Warranty feature will be Hidden

@TestSealedWarrnty
Scenario: VAN30769_TestStep06_Check Sealed Battery Warranty UI Status level=005-1 SoH ＜80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section     | desc                                                                                               |
	| SealedTitle | Sealed Battery Warranty                                                                            |
	| Title       | Battery Warranty:                                                                                  |
	| Value       | Not available                                                                                      |
	| Tip         | Your sealed battery warranty is not available. Check for more Lenovo premium options and services. |
	| Button      | EXPLORE MORE                                                                                       |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	Then GetResponse from BatteryWarranty Restful API with 'PF2HT1ZE' and '' and '60' Type SMBInfo1SB60
	When go to Audio page
	Then The Sealed Warranty feature will be Displayed
	When Go to Display & Camera page
	Then The Sealed Warranty feature will be Displayed
	When Go to input page
	Then The Sealed Warranty feature will be Displayed
	When Go to Smart Assist page
	Then The Sealed Warranty feature will be Displayed

@TestSealedWarrnty
Scenario: VAN30769_TestStep07_Check Sealed Battery Warranty UI Status level=005-1 SoH ＜80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep08_Check Sealed Battery Warranty UI Status level=005-1 SoH ＜80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep08_ItWillShowIframe3 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep09_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe1 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section     | desc																												  |
	| SealedTitle | Sealed Battery Warranty																								  |
	| Title       | Battery Warranty:																									  |
	| Value       | Not available																										  |
	| Tip         | Protect your investment by extending beyond the 1-year battery warranty up to 3-year coverage with low upfront cost.  |
	| Button      | EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	Then GetResponse from BatteryWarranty Restful API with 'PF2HT1ZE' and '' and '90' Type SMBInfo1SB60

@TestSealedWarrnty
Scenario: VAN30769_TestStep10_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep11_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Sealed Battery Warranty
	Then Take Screen Shot TestStep11_ItWillShowIframe1 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep12_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo001-iframe2 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section     | desc																												  |
	| SealedTitle | Sealed Battery Warranty																								  |
	| Title       | Battery Warranty:																									  |
	| Value       | Not available																										  |
	| Tip         | Protect your investment by extending beyond the 1-year battery warranty up to 3-year coverage with low upfront cost.  |
	| Button      | EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	Then GetResponse from BatteryWarranty Restful API with 'PF2KFTG1' and '' and '90' Type SMBInfo1SB60

@TestSealedWarrnty
Scenario: VAN30769_TestStep13_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep14_Check Sealed Battery Warranty UI Status level=001 SoH >=80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty
	Then Take Screen Shot TestStep14_ItWillShowIframe2 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep18_Check Sealed Battery Warranty UI Status level=004
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo4 and SB00
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section				| desc																												  |
	| SealedTitle			| Sealed Battery Warranty																							  |
	| Title					| Battery Warranty:																									  |
	| Tip					| Your sealed battery is fully protected now! Check for more Lenovo premium options and services.					  |
	| Button				| EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	#Then GetResponse from BatteryWarranty Restful API with 'PF21H368' and '' and '90' Type SMBInfo4SB90
	Then GetResponse from BatteryWarranty Restful API with 'PF230WCP' and '' and '90' Type SMBInfo4SB90

@TestSealedWarrnty
Scenario: VAN30769_TestStep19_Check Sealed Battery Warranty UI Status level=004
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep20_Check Sealed Battery Warranty UI Status level=004
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep20_ItWillShowIframe3 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep21_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section				| desc                                                                                               |
	| SealedTitle			| Sealed Battery Warranty                                                                            |
	| Title					| Battery Warranty:                                                                                  |
	| Tip					| Your sealed battery is in warranty! Check for more Lenovo premium options and services.		     |
	| Button				| EXPLORE MORE                                                                                       |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	#Then GetResponse from BatteryWarranty Restful API with 'MP1L8D4V' and '81CU0040US' and '60' Type SMBInfoiframe1SB60
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '60' Type SMBInfoiframe1SB60

@TestSealedWarrnty
Scenario: VAN30769_TestStep22_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep23_Check Sealed Battery Warranty UI Status level=005-2 SoH ＜80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep23_ItWillShowIframe3 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep24_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe2 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section					| desc																												  |
	| SealedTitle				| Sealed Battery Warranty																							  |
	| Title						| Battery Warranty:																									  |
	| BatteryUpSellendDateText	| End Date:																											  |
	| Tip						| Protect your investment by extending beyond the 1-year battery warranty up to 3-year coverage with low upfront cost.|
	| Button					| EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '90' Type SMBInfo2SB90

@TestSealedWarrnty
Scenario: VAN30769_TestStep25_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep26_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty
	Then Take Screen Shot TestStep26_ItWillShowIframe2 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep27_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB90
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section					| desc																												  |
	| SealedTitle				| Sealed Battery Warranty																							  |
	| Title						| Battery Warranty:																									  |
	| BatteryUpSellendDateText	| End Date:																											  |
	| Tip						| Protect your investment by extending beyond the 1-year battery warranty up to 3-year coverage with low upfront cost.|
	| Button					| EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	#Then GetResponse from BatteryWarranty Restful API with 'MP1L8D4V' and '81CU0040US' and '90' Type SMBInfo2SB90
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '90' Type SMBInfo2SB90

@TestSealedWarrnty
Scenario: VAN30769_TestStep28_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep29_Check Sealed Battery Warranty UI Status level=002 SoH >80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Lenovo Premium Service
	Then It Will Show Iframe Sealed Battery
	Then It Will Show Iframe Lenovo Warranty 
	Then Take Screen Shot TestStep29_ItWillShowIframe1 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep30_Check Sealed Battery Warranty UI Status level=002 SoH <80%
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Jump to Battery settings
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section					| desc																												  |
	| SealedTitle				| Sealed Battery Warranty																							  |
	| Title						| Battery Warranty:																									  |
	| Tip						| Your sealed battery is in warranty! Check for more Lenovo premium options and services.							  |
	| Button					| EXPLORE MORE																										  |
	Then The EXPLORE MORE Button Displayed and under the Value Tip 
	#Then GetResponse from BatteryWarranty Restful API with 'MP1L8D4V' and '81CU0040US' and '60' Type SMBInfoiframe1SB60
	Then GetResponse from BatteryWarranty Restful API with 'PF2FT8MY' and '' and '60' Type SMBInfoiframe1SB60

@TestSealedWarrnty
Scenario: VAN30769_TestStep31_Check Sealed Battery Warranty UI Status level=002 SoH <80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The Question Mark
	Then The Battery Warranty value and Tip should follow the SPEC
	| section		  | desc																															|
	| QuestionMarkTip | After you purchase the Sealed Battery Warranty, it might take 24 hours or longer for the updated battery entitlement to apply.	|

@TestSealedWarrnty
Scenario: VAN30769_TestStep32_Check Sealed Battery Warranty UI Status level=002 SoH <80%
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When Click The EXPLORE MORE Button
	Then It Will Show Iframe Upgrade Support & Service
	Then Take Screen Shot TestStep32_ItWillShowIframe3 in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep33_Check The feature will be hidden
	Given Close Vantage
	Given Modifying the Service fileSmb Value Add
	When Restart Vantage Service
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When The user connect or disconnect WiFi off lenovo
	When Go to Power Page
	Then The Sealed Warranty feature will be Hidden
	When The user connect or disconnect WiFi on lenovo

@TestSealedWarrnty
Scenario: VAN30769_TestStep34_Check The feature will be hidden
	Given Install Vantage
	Given Close Vantage
	Given Modifying the Service fileSmb Value Add
	When Restart Vantage Service
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section					| desc																												  |
	| SealedTitle				| Sealed Battery Warranty																							  |
	| Title						| Battery Warranty:																									  |
	| Tip						| Your sealed battery is in warranty! Check for more Lenovo premium options and services.							  |
	| Button					| EXPLORE MORE																										  |
	Given Close Vantage
	When ReLaunch Vantage
	When The user connect or disconnect WiFi off lenovo
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	Then The Battery Warranty value and Tip should follow the SPEC
	| section					| desc																												  |
	| SealedTitle				| Sealed Battery Warranty																							  |
	| Title						| Battery Warranty:																									  |
	| Tip						| Your sealed battery is in warranty! Check for more Lenovo premium options and services.							  |
	| Button					| EXPLORE MORE																										  |
	When The user connect or disconnect WiFi on lenovo

@TestSealedWarrnty
Scenario: VAN30769_TestStep35_Check the UI should be correct, not overlap or truncate
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	When go to Audio page
	Then The Sealed Warranty feature will be Displayed
	When Go to Display & Camera page
	Then The Sealed Warranty feature will be Displayed
	When Go to input page
	Then The Sealed Warranty feature will be Displayed
	When Go to Smart Assist page
	Then The Sealed Warranty feature will be Displayed

@TestSealedWarrnty
Scenario: VAN30769_TestStep36_Check the UI should be correct, not overlap or truncate
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Then The Sealed Warranty feature will be Displayed
	Given Close Vantage
	Given ReLaunch Vantage
	When go to Audio page
	Then The Sealed Warranty feature will be Displayed
	Given Close Vantage
	Given ReLaunch Vantage
	When Go to Display & Camera page
	Then The Sealed Warranty feature will be Displayed
	Given Close Vantage
	Given ReLaunch Vantage
	When Go to input page
	Then The Sealed Warranty feature will be Displayed
	Given Close Vantage
	Given ReLaunch Vantage
	When Go to Smart Assist page
	Then The Sealed Warranty feature will be Displayed

@TestSealedWarrnty
Scenario: VAN30769_TestStep40_Check the UI should be correct, not overlap or truncate
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	When Minimize vantage
	When Maximize Vatnage
	Then The Sealed Warranty feature will be Displayed
	Then Take Screen Shot TestStep40_Check_minimizeAndMaximize in VAN30769 under WarrantyShotResult

@TestSealedWarrnty
Scenario: VAN30769_TestStep41_Check the UI should be correct, not overlap or truncate
	Given Close Vantage
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	When ReLaunch Vantage
	When Go to Power Page
	Given Change DPI to 200
	Then The Sealed Warranty feature will be Displayed
	Then Take Screen Shot TestStep41_Check_DPI200 in VAN30769 under WarrantyShotResult
	Given Change DPI to 300
	Given change resolution 2560 to 1440
	Then The Sealed Warranty feature will be Displayed
	Then Take Screen Shot TestStep41_Check_Resolution2560-1440 in VAN30769 under WarrantyShotResult
	Given change resolution 3840 to 2160

@TestSealedWarrnty
Scenario: VAN30769_TestStep42_Check performance
	Given Install Vantage
	Given Close Vantage
	Given Modifying the Service fileSmb Value Add
	When Modify the SMBinfor file with SMBInfo002-iframe1 and SB60
	When Restart Vantage Service
	Given ReLaunch Vantage
	When Go to Power Page
	Then The UI should be displayed within 3 seconds when first launch
	Given Close Vantage
	Given ReLaunch Vantage
	When Go to Power Page
	Then The UI should be displayed within 2 seconds when second launch
