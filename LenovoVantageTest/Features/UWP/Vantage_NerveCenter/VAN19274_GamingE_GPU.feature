Feature: VAN19274_Gaminge-GPU
Test Case： https://jira.tc.lenovo.com/browse/VAN-19274
	Author：Xiang Tian

Background:
	Given Machine is Gaming 

@NotSupportGaminge-GPU
Scenario: VAN19274_TestStep01_GPU name and values should be consistent with dGPU
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Given eGPU function Unsupport
	Then Vantage GPU name and values should be consistent with dGPU

@NotSupportGaminge-GPU
Scenario: VAN19274_TestStep02_GPU name and values should be consistent with dGPU
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Given eGPU function Unsupport	
	Then Vantage GPU name and values should be consistent with dGPU

@Gaminge-GPU
Scenario: VAN19274_TestStep03_GPU name and values should be consistent with d-GPU
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Then Vantage GPU name and values should be consistent with dGPU

@Gaminge-GPU
Scenario: VAN19274_TestStep04_GPU name and values should be consistent with d-GPU
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Then Vantage GPU name and values should be consistent with dGPU

@Gaminge-GPU
Scenario: VAN19274_TestStep06_Auto close should be worked correctly
	Given eGPU and dGPU driver version are the same
	Given Plug in the external graphics card
	Given The machine support auto close
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	Given Go to auto close subpage
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close NotePad
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage NotePad
	When Launch the specifie game GameWorldOfWarcraft
	Then The added app run or not run NotePad norun
	When Stop the specified app GameWorldOfWarcraft
	
@Gaminge-GPU
Scenario: VAN19274_TestStep07_Touchpad lock should be worked correctly
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	When Touchpad Lock is Enable
	Then Touchpad Lock Enabled
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad disalbed when game running
	When Stop the game

@Gaminge-GPU
Scenario: VAN19274_TestStep08_Hybrid Mode should be worked correctly
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Then Hybrid Mode should be worked correctly

@Gaminge-GPU
Scenario: VAN19274_TestStep09_Macro key should be worked correctly
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "asdf1234"
	Given Click the STOP RECORDING button 
	When Set to "Enabled Only When Gaming" option
	Then "3" will be output whenever "3" is pressed
	When Launch the specifie game GameWorldOfWarcraft
	Then "asdf1234" will be output whenever "3" is pressed
	When Stop the specified app GameWorldOfWarcraft

@Gaminge-GPU
Scenario: VAN19274_TestStep10_ Auto Switch in the Thermal mode should be worked correctly.
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@Gaminge-GPU
Scenario: VAN19274_TestStep11_GPU OC value should be worked correctly.
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	When Check the OC values in the tools
	Then It will display yes OC values

@Gaminge-GPU
Scenario: VAN19274_TestStep12_Vantage GPU name and values should be consistent with dGPU
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Then Vantage GPU name and values should be consistent with dGPU

@Gaminge-GPU
Scenario: VAN19274_TestStep13_Vantage GPU name and values should be consistent with Integrated Graphics
	Given Plug in the external graphics card
	Given eGPU and dGPU driver version are the same
	Then Vantage GPU name and values should be consistent with dGPU

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep15_Auto close should be worked correctly
	#Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	Given The machine support auto close
	When Stop the specified app all
	When Launch the specified app as current user NotePad
	Given Go to auto close subpage
	When The user turn on auto close toggle within subpage
	Then The auto close toggle status is on or off within subpage on
	Given The user remove one or all apps from auto close all
	When The user Click add button for auto close
	Then The add apps to auto close popup window show or hide show
	When The user add specified app to auto close NotePad
	When The user click X button on add apps popup window
	Then The select app added to auto close subpage NotePad
	When Launch the specifie game GameWorldOfWarcraft
	Then The added app run or not run NotePad norun
	When Stop the specified app GameWorldOfWarcraft

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep16_Touchpad lock should be worked correctly
	#Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	When Touchpad Lock is Enable
	Then Touchpad Lock Enabled
	When Launch the specifie game GameWorldOfWarcraft
	Then Touchpad disalbed when game running
	When Stop the game

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep17_Hybrid Mode should be worked correctly
	#Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	Then Hybrid Mode should be worked correctly

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep18_Macro key should be worked correctly
	#Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	When Click the macrokey icon in the System tools area
	Given Select the number 3
	Given Click the START RECORDING button
	Given Type in "asdf1234"
	Given Click the STOP RECORDING button 
	When Set to "Enabled Only When Gaming" option
	Then "3" will be output whenever "3" is pressed
	When Launch the specifie game GameWorldOfWarcraft
	Then "asdf1234" will be output whenever "3" is pressed
	When Stop the specified app GameWorldOfWarcraft

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep19_ Auto Switch in the Thermal mode should be worked correctly
	#Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	Given The Thermal Mode Setting popup is displaying
	Given The thermal mode is Balance Mode
	Given Auto switch toggle is ON
	When Launch the specifie game GameWorldOfWarcraft
	When Check Thermal mode in the Thermal Mode Setting popup
	Then The thermal mode is Performance Mode in the Thermal Mode Setting popup

@PullOutGaminge-GPU
Scenario: VAN19274_TestStep20_GPU OC should be worked correctly.
	Given Plug in the external graphics card
	#Given eGPU and dGPU driver version are the same
	#Given pull out external graphics card
	Given The Thermal Mode Setting popup is displaying
	Given The Enable Overclocking Checkbox is checked
	Given The thermal mode is Performance Mode
	Given Click X button in Thermal Mode Setting popup
	Given Open the XTU and GPU OC tool
	When Check the OC values in the tools
	Then It will display yes OC values

@Gaminge-GPU
Scenario: VAN19274_TestStep21_Vantage GPU name and values should be consistent with dGPU
	Given eGPU and dGPU driver version are the same
	Given Plug in the external graphics card
	Then Vantage GPU name and values should be consistent with dGPU