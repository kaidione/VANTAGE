Feature: VAN10210_Part3_ToolbarRegressionTest
	Test Case： https://lnvusjira.lenovonet.lenovo.local/browse/VAN-10210
	Author： Jinglong Zhao
	Update： Pengjie Chen
	Conmments: TestStep81-120

Background:
	Given Turn on or off the narrator 'on'

@CameraToolbar 
Scenario: VAN10210_TestStep084_The Camera privacy mode button displays same as with Vantage Settings Page
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given turn off Lenovo Vantage permission for Camera from system settings
	Given turn on Lenovo Vantage permission for Camera from system settings
	Given toolbar is launched
	When turn on Camera Privacy from Toolbar
	Then The Camera privacy mode button on displays same as with Vantage Settings Page

@CameraToolbar
Scenario: VAN10210_TestStep085_The hover tips display is "Camera privacy mode"
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn off Camera Privacy from Toolbar
	When turn on Camera Privacy from Toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button Camera
	When Take Screen Shot AC85on_TipsCameraon in 10210 under ToolbarScreenShotResult
	When Launch toolbar
	When turn off Camera Privacy from Toolbar
	When Close toolbar
	When Launch toolbar
	When Hover the mouse on the button Camera
	When Take Screen Shot AC85off_TipsCameraoff in 10210 under ToolbarScreenShotResult

@CameraToolbar 
Scenario: VAN10210_TestStep086_The Camera privacy display on status
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given launch toolbar
	When turn on Camera Privacy from Toolbar
	Then The camera button display on status from toolbar

@CameraToolbar 
Scenario: VAN10210_TestStep087_The text display is "Camera privacy mode on",The text info is displayed in the middle
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn off Camera Privacy from Toolbar
	When turn on Camera Privacy from Toolbar
	When Take screen shot AC87_textDisplayCameraCameraPrivacyModeOn in 10210 under ToolbarScreenShotResult after 0 seconds

@CameraToolbar 
Scenario: VAN10210_TestStep088_The Camera privacy display off status
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn off Camera Privacy from Toolbar
	Then The camera button display off status from toolbar

@CameraToolbar 
Scenario: VAN10210_TestStep089_The text display is "Camera privacy mode off"
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn on Camera Privacy from Toolbar
	When turn off Camera Privacy from Toolbar
	When Take screen shot AC89_textDisplayCameraCameraPrivacyModeOff in 10210 under ToolbarScreenShotResult after 0 seconds

@CameraToolbar 
Scenario: VAN10210_TestStep090_The Camera privacy display on status on vantage display page
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn on Camera Privacy from Toolbar
	When Go to display page
	Then The Camera privacy display on status from vantage display page

@CameraToolbar 
Scenario: VAN10210_TestStep091_The Camera privacy display on status from toolbar
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	When Go to display page
	Given turn on Camera Privacy from Display and Camera page
	Given toolbar is launched
	Then The camera button display on status from toolbar

@CameraToolbar 
Scenario: VAN10210_TestStep092_The Camera privacy display on status on dashboard page
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given toolbar is launched
	When turn on Camera Privacy from Toolbar
	Given Go to dashboad page
	Then The Camera privacy display on status on dashboard page

@CameraToolbar 
Scenario: VAN10210_TestStep093_The Camera privacy mode doesn't display
	Given Pin toolbar to taskbar
	Given turn on the Allow access to the camera toggle on this device
	Given disable camera driver
	Given toolbar is launched
	Then The camera button doesn't display on toolbar

@CameraToolbar 
Scenario: VAN10210_TestStep094_The Camera privacy display on status
	Given Pin toolbar to taskbar
	Given enable camera driver
	Given turn on the Allow access to the camera toggle on this device
	Given launch toolbar
	When turn on Camera Privacy from Toolbar
	Given disable camera driver
	Given enable camera driver
	Given launch toolbar
	Then The camera button display on status from toolbar

@CameraToolbar 
Scenario: VAN10210_TestStep095_jump to Camera&display page
	Given Pin toolbar to taskbar
	Given turn off the Allow access to the camera toggle on this device
	Given toolbar is launched
	When Click camera button on toolbar
	Then My Device settings Display page is opened

@TopRowToolbarIdea
Scenario: VAN10210_TestStep096_the Top-row function button status is displayed same as Vantage
	Given Pin toolbar to taskbar
	Given Go to input page
	Given toolbar is launched
	Then the Top-row function button status is displayed same as Vantage for ideapad

@TopRowToolbarIdea
Scenario: VAN10210_TestStep097_The button display Special function statue on toolbar
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on Special function from toolbar
	Then The Top-row function button display Special function status on toolbar

@TopRowToolbarIdea
Scenario: VAN10210_TestStep098_The text display is "Special function enabled" and the text info is displayed in the middle
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	When Turn on Special function from toolbar
	Then Take screen shot AC98_textDisplaySpecialFunctionEnabled in 10210 under ToolbarScreenShotResult after 0 seconds

@TopRowToolbarIdea
	Scenario: VAN10210_TestStep099_the text display is "Keyboard top-row function"
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot AC99_textDisplayKeyboardTopRowFunction in 10210 under ToolbarScreenShotResult

@TopRowToolbarIdea
Scenario: VAN10210_TestStep100_The Top-row function button display Special function status on vantage input page
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on Special function from toolbar
	Given Go to input page
	Then The Top-row function button display Special function status on vantage input page for ideapad

@TopRowToolbarIdea
Scenario: VAN10210_TestStep101_The button display F1-F12 function statue on toolbar
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	Then The Top-row function button display F1-F12 function status on toolbar

@TopRowToolbarIdea 
Scenario: VAN10210_TestStep102_The text display is "F1-F12 function enabled" and the text info is displayed in the middle
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on Special function from toolbar
	When Turn on F1-F12 function from toolbar
	Then Take screen shot AC102_textDisplayFnFunctionEnabled in 10210 under ToolbarScreenShotResult after 0 seconds

@TopRowToolbarIdea 
Scenario: VAN10210_TestStep103_the text display is "Keyboard top-row function"
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot AC103_textDisplayKeyboardTopRowFunction in 10210 under ToolbarScreenShotResult

@TopRowToolbarIdea 
Scenario: VAN10210_TestStep104_The button display F1-F12 function statue on vantage input page
	Given Pin toolbar to taskbar
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	Given Close toolbar
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page for ideapad

@TopRowToolbarIdea 
Scenario: VAN10210_TestStep105_The button display Special function statue on vantage input page
	Given Pin toolbar to taskbar
	Given Go to input page
	When Turn on Special function on vantage input page for ideapad
	Given toolbar is launched
	Then The Top-row function button display Special function status on toolbar

@TopRowToolbarIdea 
Scenario: VAN10210_TestStep106_The button display F1-F12 function statue on vantage input page
	Given Pin toolbar to taskbar
	Given Go to input page
	When Turn on F1-F12 function on vantage input page for ideapad
	Given toolbar is launched
	Then The Top-row function button display F1-F12 function status on toolbar

@TopRowToolbarThinkpad
Scenario: VAN10210_TestStep107_the Top-row function button status is displayed same as Vantage
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	Then the Top-row function button status is displayed same as Vantage

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep108_The button display Special function statue on toolbar
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on Special function from toolbar
	Then The Top-row function button display Special function status on toolbar

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep109_The text display is "Special function enabled" and the text info is displayed in the middle
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	When Turn on Special function from toolbar
	Then Take screen shot AC109_textDisplaySpecialFunctionEnabled in 10210 under ToolbarScreenShotResult after 0 seconds

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep110_the text display is "Keyboard top-row function"
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Hover the mouse on the button TopRowKey
	Then Take Screen Shot AC110_textDisplayKeyboardTopRowFunction in 10210 under ToolbarScreenShotResult
	
@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep111_The button display Special function statue on toolbar
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on Special function from toolbar
	When Close toolbar
	When Launch toolbar
	Then The Top-row function button display Special function status on toolbar

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep112_The button display Special function statue on vantage input page
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on Special function from toolbar
	Given Go to display page
	Given Go to input page
	Given Waiting 5 seconds
	Then The Top-row function button display Special function status on vantage input page

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep113_The button display F1-F12 function status on toolbar
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	Then The Top-row function button display F1-F12 function status on toolbar

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep114_The button display F1-F12 function status on vantage input page
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	Given Go to display page
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page

@TopRowToolbarThinkpad 
Scenario: VAN10210_TestStep115_the Top-row button display spection function icon and gray out status
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	When Close toolbar
	Given turn on Fn Sticky Key method
	Given toolbar is launched
	Then The Top-row function button is disabled
	Then Take Screen Shot AC115_TopRowButtonDisplaySpectionFunctionIconAndGrayOutStatus in 10210 under ToolbarScreenShotResult

@TopRowToolbarThinkpad
Scenario: VAN10210_TestStep116_the Top-row button display spection function icon and gray out status
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is off
	Given turn on Normal method
	Given toolbar is launched
	When Turn on F1-F12 function from toolbar
	When Close toolbar
	Given turn on Fn Sticky Key method
	Given turn on Normal method
	Given toolbar is launched
	Then The Top-row function button display Special function status on toolbar
	Then Take Screen Shot AC116_TopRowButtonDisplaySpectionFunctionIconAndGrayOutStatus in 10210 under ToolbarScreenShotResult

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep117_The button display F1-F12 function statue on toolbar
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Launch toolbar
	When Turn on F1-F12 function from toolbar
	Then The Top-row function button display F1-F12 function status on toolbar

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep118_The text display is "F1-F12 function enabled" and the text info is displayed in the middle
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Launch toolbar
	When Turn on Special function from toolbar
	When Turn on F1-F12 function from toolbar
	Then Take screen shot AC118_textDisplayF1_F12FunctionEnabled in 10210 under ToolbarScreenShotResult after 0 seconds

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep119_The button display F1-F12 function status on vantage input page
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Launch toolbar
	When Turn on F1-F12 function from toolbar
	Given Close toolbar
	Given Go to display page
	Given Go to input page
	Then The Top-row function button display F1-F12 function status on vantage input page

@TopRowToolbarOnThinkpad
Scenario: VAN10210_TestStep120_The button display Special function status on toolbar
	Given Pin toolbar to taskbar
	Given Go to input page
	Given click AdvanceSettings link
	Given Reversing the default primary function toggle is on
	Given turn on Normal method
	When Turn on Special function on vantage input page 
	When Launch toolbar
	Then The Top-row function button display Special function status on toolbar