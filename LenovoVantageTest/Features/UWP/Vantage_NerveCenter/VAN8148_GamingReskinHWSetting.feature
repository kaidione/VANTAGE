Feature: VAN8148_GamingReskinHWSetting
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-8148
	Author： Wei Xu

Background:
	Given Machine is Gaming 

@GamingReskinHWSetting @GamingSmokePowerpage
Scenario: VAN8148_TestStep01_Enter HardWare Settings Page
	When Click the Power icon
	When Check Open Power page
	Then Take Screen Shot TestStep01 in 8148 under GamingScreenShotResult

@GamingReskinHWSetting
Scenario: VAN8148_TestStep02_Enter Input Page
	When Click the Power icon
	When Check Open Power page
	When Click Input Label
	When Check Open Input page
	Then Take Screen Shot TestStep02 in 8148 under GamingScreenShotResult

@GamingReskinHWSetting
Scenario: VAN8148_TestStep03_Open Audio Page
	When Click the Power icon
	When Click Audio Label
	When Check Open Audio page

@GamingReskinHWSetting
Scenario: VAN8148_TestStep04_Audio Page Is Gaming Style
	When Click the Power icon
	When Click Audio Label
	When Check Open Audio page
	Then Take Screen Shot TestStep04 in 8148 under GamingScreenShotResult

@GamingReskinHWSetting
Scenario: VAN8148_TestStep05_Open DisplayCamera Page
	When Click the Power icon
	When Click Display&Camera Label
	When Check Open Display&Camera page

@GamingReskinHWSetting
Scenario: VAN8148_TestStep06_Open DisplayCamera Page
	When Click the Power icon
	When Click Display&Camera Label
	When Check Open Display&Camera page
	Then Take Screen Shot TestStep06 in 8148 under GamingScreenShotResult

@GamingReskinHWSetting @GamingSmokeAudiopage
Scenario: VAN8148_TestStep07_Open DisplayCamera Page By Click Media Icon
	When Click the Media icon
	When Check Open Display&Camera page

@GamingReskinHWSetting
Scenario: VAN8148_TestStep08_DisplayCamera Page Is Gaming Style
	When Click the Media icon
	When Check Open Display&Camera page
	Then Take Screen Shot TestStep08 in 8148 under GamingScreenShotResult