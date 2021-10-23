Feature: VAN8128_GamingEnableHWScan
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-8128
	Author： Wei Xu

Background:
	Given Machine is Gaming 

@GamingEnableHWScan
Scenario: VAN8128_TestStep01_HareWare Scan is displayed in Gaming
	When Check the HareWare Scan icon

@GamingEnableHWScan @GamingSmokeHardwareScan
Scenario: VAN8128_TestStep02_Open HareWare Scan page
	When Click the HareWare Scan icon
	Then Open HareWare Scan page

@GamingEnableHWScan
Scenario: VAN8128_TestStep03_HareWare Scan page is not missing
	When Enter Auto Close page
	When Back to the homepage
	When Check the HareWare Scan icon

@GamingEnableHWScan
Scenario: VAN8128_TestStep04_HareWare Scan page is Gaming Style
	When Click the HareWare Scan icon
	Then Take Screen Shot TestStep04 in 8128 under GamingScreenShotResult
