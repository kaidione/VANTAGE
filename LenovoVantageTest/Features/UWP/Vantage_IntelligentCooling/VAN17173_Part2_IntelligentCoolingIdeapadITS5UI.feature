Feature: VAN17173_Part2_IntelligentCoolingIdeapadITS5UI
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-17173
	Author: Xiaoxiong Li

 Background:
	Given Is Support ITS5UI

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_A_beforetest
    Given Set Metric on
	And Launch Http Traffic Capturer
	And Start Capture 

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_TestStep21_Check Vantage will send the checked state metrics data and should follow the SPEC
	Given Go to Power Page
	Given Turn off auto-transition
	Given clear data
	Given Turn on auto-transition
	Then the metric data is as expected with Test VAN17173 and Name ItemValueOn and Timeout 20

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_TestStep22_Check Vantage will send the unchecked state metrics data and should follow the SPEC
	Given Go to Power Page
	Given Turn on auto-transition
	Given clear data
	Given Turn off auto-transition
	Then the metric data is as expected with Test VAN17173 and Name ItemValueOff and Timeout 20

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_TestStep23_Check Vantage will send the More link metrics data and should follow the SPEC
	Given Go to Power Page
	Given clear data
	When The user click Read more link for ideapad ITS Five more 
	Then the metric data is as expected with Test VAN17173 and Name ExpandedToReadMore and Timeout 20

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_TestStep24_Check  Vantage won't send the Less link metrics data and should follow the SPEC
	Given Go to Power Page
	When The user click Read more link for ideapad ITS Five less 

@ITS5UI_17173_metrics
Scenario: VAN17173_Part2_Z_Resandbox
	Given Stop Capture