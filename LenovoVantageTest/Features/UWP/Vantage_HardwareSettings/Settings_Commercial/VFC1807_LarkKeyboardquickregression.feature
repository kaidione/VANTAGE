Feature: VFC1807_LarkKeyboardquickregression
	Test Case： https://jira.tc.lenovo.com/browse/VFC-1807
	Author: DaQi Fang

@nolarkKeyBoard
Scenario: VFC1807_Step02 no lark no show more
	Given Go to input page
	Then not show "More"

@larkKeyBoard @SmokelarkKeyBoard
Scenario: VFC1807_Step03 show a tip under Intelligent Keyboard
	Given Go to input page
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard

@larkKeyBoard @SmokelarkKeyBoard
Scenario: VFC1807_Step04 show user defined key
	Given Go to input page
	Then Show Userdefined key function

@larkKeyBoard
Scenario: VFC1807_Step05 not show link and more
	Given Go to input page
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"

##larkKeyBoard
#Scenario: VFC1807_Step07 show a tip under Intelligent Keyboard
#	Given Go to input page
#	Then Turn "On" bluetooth
#	Then Waiting 15 seconds
#	Given Go to dashboad page
#	Given Go to input page
#	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
#	Then Show Userdefined key function
#	Then not show "Touchpad link"
#	Then not show "Trackpoint link"
#	Then not show "More"
#
##larkKeyBoard
#Scenario: VFC1807_Step08 show a tip under Intelligent Keyboard
#	Given Go to input page
#	Then Turn "Off" bluetooth
#	When Click the OpenAppFileOption Input Page Element
#	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
#	When Wait the App displayed
#	When Click the PaintApp Input Page Element
#	When Click the AddAppOKButton Input Page Element
#	Then Turn "On" bluetooth
#	Then Waiting 15 seconds
#	When Simulate Press F12 Event
#	Then mspaint will be Launched

@larkKeyBoard
Scenario: VFC1807_Step09 reflush resize reopen le 
	Given Go to input page
	Given Go to dashboad page
	Given Go to input page
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
	Then Show Userdefined key function
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"
	When Relaungh vantage conservation mode
	Given Go to input page
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
	Then Show Userdefined key function
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"
	When Resize vantage conservation mode
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
	Then Show Userdefined key function
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"

@larkKeyBoard
Scenario: VFC1807_Step11 reinstall the element show normally
	Given Uninstall the lenovo vatage
	Given Install Vantage
	Given Go to input page
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
	Then Show Userdefined key function
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"

@larkKeyBoard
Scenario: VFC1807_Step12_06 off bluetooth element show normally
	Given Go to input page
	Then Turn "Off" bluetooth
	Given Go to dashboad page
	Given Go to input page
	Then Show "Please connect a matching Bluetooth keyboard to use this function." under IntelligentKeyBoard
	Then Show Userdefined key function
	Then not show "Touchpad link"
	Then not show "Trackpoint link"
	Then not show "More"