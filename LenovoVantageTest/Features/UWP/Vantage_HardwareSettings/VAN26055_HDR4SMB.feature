Feature: VAN26055_HDR4SMB
	Test Case： https://jira.tc.lenovo.com/browse/Van-26055
	Author： Helen Xiong

@SMBNonCreator
Scenario: VAN26055_TestStep01 No Creator settings no HDR feature
	Given Vantage has no Creator settings page
	Then HDR shouldn't show

@CreatorHDR
Scenario: VAN26055_TestStep02 Creator settings page should have HDR feature
	Given Vantage has Creator settings page
	When Check HDR exist or not
	Given Slide The Page To "-100"
	Then Take Screen Shot  VAN26055step2HDR in 26055 under ScreenShotResult

@CreatorHDR
Scenario: VAN26055_TestStep03 Check HDR feature UI 
	Given Vantage has Creator settings page
	When Check HDR exist or not
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|

@CreatorHDR
Scenario: VAN26055_TestStep04 Click here
	Given Vantage has Creator settings page
    When Click here of HDR feature 
	Then It will open Windows Display settings page
	Then Take Screen Shot  VAN26055step4HDR in 26055 under ScreenShotResult

@CreatorHDR
Scenario: VAN26055_TestStep05 Refresh the page
	Given Vantage has Creator settings page
    When Refresh the page
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|
	Given Slide The Page To "-100"
	Then Take Screen Shot  VAN26055step5HDR in 26055 under ScreenShotResult

@CreatorHDR
Scenario: VAN26055_TestStep06 relaunch vantage
	Given Vantage has Creator settings page
	Given ReLaunch Lenovo Vantage
	Given Vantage has Creator settings page
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|
	Given Slide The Page To "-100"
	Then Take Screen Shot  VAN26055step6HDR in 26055 under ScreenShotResult

@CreatorHDR
Scenario: VAN26055_TestStep07 Resize the page
	Given Vantage has Creator settings page
    When Resize the page
	When wait 2 seconds
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|
	Given Slide The Page To "-200"
	Then Take Screen Shot  VAN26055step7HDR in 26055 under ScreenShotResult
	
@CreatorHDR
Scenario: VAN26055_TestStep08 Resize the page
	Given Vantage has Creator settings page
    Given Change DPI to 125
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|
	Given Slide The Page To "-200"
	Then Take Screen Shot  VAN26055step8HDR in 26055 under ScreenShotResult
	Given Change DPI to 200
	Given change resolution 1028 to 800
	Then HDR Title and description should be correct
	| section  |  desc                      |
	| title    |  Windows HD color settings |
	| paragraph1 | Windows HD color displays high dynamic range (HDR) and wide color gamut (WCG) content, such as photos, videos, and games on your device if supported.|
	| paragraph2 | To change Windows HD color settings, click here.|
	Given Slide The Page To "-200"
	Then Take Screen Shot  VAN26055step8-1HDR in 26055 under ScreenShotResult
	Given change resolution 2880 to 1800