Feature: VAN28380_HeartbeatMetricsNewOSQuickRegression
	Test Case： https://jira.tc.lenovo.com/browse/VAN-28380
	Author： DaQi Fang

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep05
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	Given Adjust The System Time To 1 Days Later
	When Wait 1 minutes
	Then Addin has sent the HeartBeat data
	Then Check HeartBeatValue format

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep06
	Then Addin has sent the HeartBeat data
	Then Get HeartBeat metric data Value
	Then Write log 'Check HeartBeatValue' to report for 'settingsaddinheartbeatdata' type

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep07
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	When enter sleep
	When Wait 1 minutes
	Given Toolbar has "sent" the HeartBeat data
	Given Addin is "running"
	When enter sleep
	When Wait 2 minutes
	Then Addin will not send again
	When enter hibernate
	When Wait 2 minutes
	Then Addin will not send again

@NormalOSHeartBeatNoSupportRegion
Scenario: VAN28380_TestStep08
	Given The region is "nosupport" Addin
	When pin toolbar on Taskbar settings
	When Addin is "norunning"

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep09
	Given The region is "Support" Addin
	When pin toolbar on Taskbar settings
	Given Addin is "running"
	When enter sleep
	When Wait 2 minutes
	Given Toolbar has "sent" the HeartBeat data
	Then Addin will not send again
	When enter hibernate
	When Wait 2 minutes
	Then Addin will not send again

#@NormalOSHeartBeatSupportRegion
#Scenario: VAN28380_TestStep10
#	When unpin toolbar on Taskbar settings
#	Given Delect the HeartBeat Regedit Value
#	Given delete eventlog
#	Given Adjust The System Time To 1 Days Later
#	When enter sleep
#	When Wait 1 minutes
#	Given The region is "Support" Addin
#	Given Addin is "running"
#	When enter sleep
#	When Wait 2 minutes
#	Then Addin has sent the HeartBeat data

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep11
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	When enter sleep
	When Wait 1 minutes
	Given The region is "Support" Addin
	When pin toolbar on Taskbar settings
	When Wait 1 minutes
	Given Toolbar has "sent" the HeartBeat data
	When unpin toolbar on Taskbar settings
	Given Addin is "running"
	When enter sleep
	When Wait 2 minutes
	Then Addin will not send again

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep12
	Given The region is "Support" Addin
	When pin toolbar on Taskbar settings
	Given Toolbar has "sent" the HeartBeat data
	When unpin toolbar on Taskbar settings
	Given delete eventlog
	Given Adjust The System Time To 1 Days Later
	Given Addin is "running"
	When enter sleep
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep13
	Given The region is "Support" Addin
	When pin toolbar on Taskbar settings
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	When unpin toolbar on Taskbar settings
	When Get Memory and Cpu value
	Given delete eventlog
	Given Adjust The System Time To 1 Days Later
	Given Addin is "running"
	When enter sleep
	Then Wait and Check Cpu Memory Value

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep14
	When unpin toolbar on Taskbar settings
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	When Get Memory and Cpu value
	Given Adjust The System Time To 1 Days Later
	When Wait 1 minutes
	Given Addin is "running"
	Then Check Cpu and Memory Value

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep23
	Then Addin is "running"
	When Enter hibernate
	Then Addin is "running"
	When enter sleep
	Then Addin is "running"

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep25
	Then Addin has sent the HeartBeat data
	When Enter hibernate
	Then Addin has sent the HeartBeat data
	When enter sleep
	Then Addin has sent the HeartBeat data

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep27
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Enter hibernate
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Enter sleep
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data
	Given Set System Time Automatically To Sync

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep29
	When unpin toolbar on Taskbar settings
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Enter hibernate
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Enter sleep
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep32
	Then Addin is "running"
	When Enter hibernate
	Then Addin is "running"
	When enter sleep
	Then Addin is "running"

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep34
	Then Addin has sent the HeartBeat data
	When Enter hibernate
	Then Addin has sent the HeartBeat data
	When enter sleep
	Then Addin has sent the HeartBeat data
	Given Set System Time Automatically To Sync
	When pin toolbar on Taskbar settings

@NewOSHearBeatSupportRegion
Scenario: VAN28380_TestStep38
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Wait 2 minutes
	Then Addin has sent the HeartBeat data
	Then HeartBeat data shouldn't show TrackPointSettings TouchpadSettings And AdvancedPointingSettings Mode

@NormalOSHeartBeatSupportRegion
Scenario: VAN28380_TestStep39
	Given Set Windows Region "122"
	When unpin toolbar on Taskbar settings
	Then Addin has sent the HeartBeat data
	Given Delect the HeartBeat Regedit Value
	Given delete eventlog
	Given Set Time to "nearnextday"
	When Wait 2 minutes
	Given The region is "Support" Addin
	Then HeartBeat data shouldn't show TrackPointSettings TouchpadSettings And AdvancedPointingSettings Mode
	Then Windows Region Is Current Version
