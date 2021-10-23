Feature: VAN17173_Part1_IntelligentCoolingIdeapadITS5UI
    Help: Vantage Settings ITS5.0 IdeaPad UI Test
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17173
	Developer: chenpj
	Total：14
	Automated：1,2,3,4,5,6,7,8,9,10,11,12,13,14
	Not automated: 
		7: 缺少 vantage 卸载重装
		15: nls 
		16: DPI  后续自动化
		17: 缺少触发条件
		18: toast nls
		19: DPI 后续自动化
		20: Accessibility test
		21，22,23,24：Metric data   后续自动化
	Check ui:


 Background: 
    Given The Machine support Intelligent Cooling for ideapad ITS Five
	Given Is Support ITS5UI
	Given Go to Power Page
	Given Jump to power smart settings section

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep01_Check Jump link and Power Smart settings section is exist
	Given Read Intelligent cooling run mark for all test case
	Then  There should have Power Smart settings Jump link
	Then  There should have Power Smart settings section

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep02_Check intelligent cooling description is correct
	Given Read Intelligent cooling run mark for all test case
	Then  There should have Power Smart settings section
	Then  The Intelligent cooling feature icon should be displayed
	Then  The Intelligent cooling feature title should be displayed
	Then  The Intelligent cooling feature description should be displayed for ideapad ITS Five
	"""
	This feature enables you to adjust your fan speed, maximize the system performance, or extend your battery life if needed. It has three modes below. You also can switch the modes using hotkeys (Fn+Q) or from Lenovo Vantage Toolbar.
	"""

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep03_Check intelligent cooling mode should keep the same with ITS drive
	Given Read Intelligent cooling run mark for all test case
	Then The intelligent cooling mode should keep the same with ITS drive for ideapad ITS Five

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep04_Check intelligent cooling three radio button are exist
	Given Read Intelligent cooling run mark for all test case
	Then Intelligent cooling Extreme performance Battery saving mode Three radio button will be displayed for ideapad ITS Five

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep05_Check intelligent cooling ICM text description is correct
	Given Read Intelligent cooling run mark for all test case
    When The user select ICM mode for ideapad ITS Five
	Then The intelligent cooling ICM mode description will be display for ideapad ITS Five
	"""
	This mode enables the best experience with fan speed and system performance balanced. For example, when in gaming, it optimizes the performance. While in the office, it reduces the noise.
	"""

@ITS5UI_17173  @ITSSmokeITS5
Scenario: VAN17173_TestStep06_Check intelligent cooling auto transition text description are correct
	Given Read Intelligent cooling run mark for all test case
    When The user select ICM mode for ideapad ITS Five
	Then The intelligent cooling auto transition checkbox will be display for ideapad ITS Five
	Then The intelligent cooling auto transition checkbox description will be display for ideapad ITS Five
	"""
	Enable auto-transition to "Extreme performance" mode. When enabled, your computer might enter "Extreme performance" mode, depending on the system load and user scenario. In this mode, the temperature on your computer and fan noise might increase.
	"""

@ITS5UI_17173
Scenario: VAN17173_TestStep07_Check default value of auto-transition check-box is unchecked state
	Given Read Intelligent cooling run mark for all test case
    When The user select ICM mode for ideapad ITS Five
	When The user select on auto transition checkbox for ideapad ITS Five
	Then The auto transition checkbox status is on for ideapad ITS Five
	Given Install Vantage
	Given Launch Vantage
	Given Go to Power Page
	Given jump to power smart settings section
	Then The auto transition checkbox status is off for ideapad ITS Five

@ITS5UI_17173
Scenario: VAN17173_TestStep08_Check MORE dropdown link is exist
	Given Read Intelligent cooling run mark for all test case
	When The user select ICM mode for ideapad ITS Five
	Then The intelligent cooling MORE dropdown link will be display for ideapad ITS Five

@ITS5UI_17173
Scenario: VAN17173_TestStep09_Check link title will change to LESS
	Given Read Intelligent cooling run mark for all test case
	When The user select ICM mode for ideapad ITS Five
	When The user click Read more link for ideapad ITS Five less
	Then Take Screen Shot 09 in 17173 under ITSScreenShotResult

@ITS5UI_17173
Scenario: VAN17173_TestStep10_Check  intelligent cooling three sub description text are correct
	Given Read Intelligent cooling run mark for all test case
    When The user select ICM mode for ideapad ITS Five
	When The user click Read more link for ideapad ITS Five less
	Then The intelligent cooling Read more sub description will be display for ideapad ITS Five
	"""
	a. In office, Windows update, online movie, or system light loading scenarios, the system can be quiet. While in normal gaming scenarios, it has better performance.
	b. When playing heavy gaming, the system might probably switch to "Extreme performance" mode. In this case, the temperature on your computer surface and fan noise may increase.
	c. When the battery capacity is lower than 30%, the system automatically switches to the "Battery saving" mode.
	"""

@ITS5UI_17173
Scenario: VAN17173_TestStep11_Check link title is MORE then three sub description will be hidden
	Given Read Intelligent cooling run mark for all test case
	When The user select ICM mode for ideapad ITS Five
	When The user click Read more link for ideapad ITS Five more
	Then The intelligent cooling Read more description will be hide for ideapad ITS Five

@ITS5UI_17173
Scenario: VAN17173_TestStep12_Check link title will change to MORE
	Given Read Intelligent cooling run mark for all test case
	When The user select ICM mode for ideapad ITS Five
	When The user click Read more link for ideapad ITS Five more
	Then Take Screen Shot 12 in 17173 under ITSScreenShotResult

@ITS5UI_17173
Scenario: VAN17173_TestStep13_Check intelligent cooling EPM text description is correct
	Given Read Intelligent cooling run mark for all test case
    When The user select EPM mode for ideapad ITS Five
	Then The intelligent cooling EPM mode description will be display for ideapad ITS Five
	"""
	This mode enables the maximum system performance. In this mode, the fast fan speed might cause big noise.
	"""

@ITS5UI_17173
Scenario: VAN17173_TestStep14_Check intelligent cooling BSM text description is correct
	Given Read Intelligent cooling run mark for all test case
    When The user select BSM mode for ideapad ITS Five
	Then The intelligent cooling BSM mode description will be display for ideapad ITS Five
	"""
	This mode enables the maximum battery life by automatically adjusting the brightness, changing the power settings, disabling Dolby audio, and etc. With all the above, it can extend up to 20% of the battery life.
	"""
	