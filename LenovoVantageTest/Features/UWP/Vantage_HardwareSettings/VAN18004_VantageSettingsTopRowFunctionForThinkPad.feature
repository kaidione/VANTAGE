Feature: VAN18004_VFC195_VantageSettingsTopRowFunctionForThinkPad
	Test Case：https://lnvusjira.lenovonet.lenovo.local/browse/VAN-18004
	Author： Pengjie Chen

@KBDTopRow @SmokeKBDTopRow
Scenario: VAN18004_TestStep01_Check top row title and advance settings link show
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Then The top row title show 'Keyboard top-row function'
	Then The Advance Settings Link show on the bottom

@KBDTopRow
Scenario: VAN18004_TestStep02_Check top row SPECIAL FUNCTION and F1-F12 FUNCTION show
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Then The Special key and Function key show

@KBDTopRow
Scenario: VAN18004_TestStep03_Check top row SPECIAL FUNCTION and F1-F12 FUNCTION show
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Then The top row description show correct
	| section             | desc                                                                                             |
	| top row desc        | The top row of the keyboard provides the following two functions. Select the one you want:       |
	| top row subdesc     | You also can switch the two functions by pressing Fn+Esc. The refresh will take several seconds. |
	| top row subdescl le | To switch the above two functions, press Fn+Esc.												 | 

@KBDTopRow
Scenario: VAN18004_TestStep04_Check SPECIAL FUNCTION should be selected and highlighted
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When The select 'Special Key' function within top row function
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Then The 'Special Key' function within top row fucntion status is correct 'selected'

@KBDTopRow
Scenario: VAN18004_TestStep05_Check F1-F12 FUNCTION should be selected and highlighted
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When The select 'Function Key' function within top row function
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Then The 'Function Key' function within top row fucntion status is correct 'selected'

@KBDTopRow
Scenario: VAN18004_TestStep06_Check Reversing the default primary function and How to use Fn key combinations can show
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The Reversing the default primary function will be shown or hidden 'shown'
	Then The How to use Fn key combinations will be shown or hidden 'shown'

@KBDTopRow
Scenario: VAN18004_TestStep07_Check Reversing the default primary function UI
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The Reversing the default primary function will be shown or hidden 'shown'
	Then The top row description show correct
	| section                                 | desc                                                                                                                                                    |
	| reversing default primary function desc | When on, the default primary function will be changed from the factory settings to the opposite. Restart your computer to make the changes take effect. |

@KBDTopRow
Scenario: VAN18004_TestStep08_Check Reversing the default primary function UI
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	When Turn on or off Reversing the default primary function 'off' 
	When Turn on or off Reversing the default primary function 'on' 
	Then The Reversing the default primary function pop up show correct
	"""
	Changing the default top row function requires you to restart your computer. Are you sure to restart?
	"""

@KBDTopRow
Scenario: VAN18004_TestStep10_Check the UI of How to use Fn key combinations 
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The How to use Fn key combinations will be shown or hidden 'shown'
	Then The top row description show correct
	| section                  | desc                                                                                                                                                                                                                                                                                                                                                 |
	| fn key combinations desc | Using the Normal method, to use the Fn key combinations, you need to press Fn+function keys. With the Fn Sticky key method, you can press (instead of pressing and holding) the Fn key to keep it in a pressed condition. Then press the desired function key. The action is equivalent to pressing the function key simultaneously with the Fn key. |

@KBDTopRow
Scenario: VAN18004_TestStep11_Check the UI of How to use Fn key combinations 
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The How to use Fn key combinations will be shown or hidden 'shown'

@KBDTopRow
Scenario: VAN18004_TestStep12_Check Normal method is selected and no note show
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	When The select 'Normal method' function within top row function
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The 'Normal method' function within top row fucntion status is correct 'selected'
	Then The How to use Fn key combinations note show or hide 'hide'

@KBDTopRow
Scenario: VAN18004_TestStep13_Check the UI of How to use Fn key combinations
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	When The select 'Fn Sticky Key method' function within top row function
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The 'Fn Sticky Key method' function within top row fucntion status is correct 'selected'
	Then The top row description show correct
	| section                   | desc                                                                                                                                                                                                                                                                |
	| fn sticky key method desc | Note: When you press the Fn key twice, the Fn key is locked in the pressed condition until you press it again. When the Fn key is locked, the Fn Lock indicator is turned on. You can press the desired function key directly to initiate the non-default function. |
	Then Take Screen Shot VAN18004_TestStep13_FnKeyCombinationsUI in 18004 under HSScreenShotResult

@KBDTopRow
Scenario: VAN18004_TestStep14_Check refresh pages and the UI should be displayed normally
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	When The select 'Normal method' function within top row function
	Then The 'Normal method' function within top row fucntion status is correct 'selected'
	When The select 'Function Key' function within top row function
	Then The 'Function Key' function within top row fucntion status is correct 'selected'
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	When Click Advance Link within top row function
	Then The 'Normal method' function within top row fucntion status is correct 'selected'
	Then The 'Function Key' function within top row fucntion status is correct 'selected'

@KBDTopRow
Scenario: VAN18004_TestStep15_Check resize Vantage and the UI should be displayed normally
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	Given Go to Keyboard top row function section
	Given Resize the window
	| isSession | width | height | classname | windowname |
	| yes       | 500   | 500    |           |            |
	Given Go to Keyboard top row function section
	Then Take Screen Shot VAN18004_TestStep15_ResizeVantage in 18004 under HSScreenShotResult
