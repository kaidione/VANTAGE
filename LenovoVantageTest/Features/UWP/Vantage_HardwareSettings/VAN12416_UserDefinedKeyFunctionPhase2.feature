Feature: VAN12416_UserDefinedKeyFunctionPhase2
	Test Case： https://jira.tc.lenovo.com/browse/VAN-12416
	Related Task : https://jira.tc.lenovo.com/browse/HAIDIAN-469
	Author: Jingting Jia

@UserDefinedKeyNotSupport
Scenario: VAN12416_TestStep01_Check there is no userdefined feature under ThinkPad not support
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	Then There is no UserDefinedFeatureDescription Element

@UserDefinedKey
Scenario: VAN12416_TestStep03_Check the five option of this feature
	Given Turn on or off the narrator 'off'
	Given Thinkpad machines
	And Machine support User defined key
	When Copy UserDefinedKeyFile
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the DelectKeySequence Input Page Element
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the EnterTextOption Input Page Element
	When Click the EnterTextHelpTip Input Page Element
	When Press 2 Backspace button
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	Then Check the PleaseSelectOption UIElement
	Then Check the OpenAppFileOption UIElement
	Then Check the OpenWebsiteOption UIElement
	Then Check the InvokeKeyOption UIElement
	Then Check the EnterTextOption UIElement
	Then Check the UserDefinedFeatureDescription UIElement

@UserDefinedKey
Scenario: VAN12416_TestStep04_Check the Select option will disapper
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	Then There is no PleaseSelectOption Element

@UserDefinedKey
Scenario: VAN12416_TestStep05_Init Environment
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the PleaseSelectOption Input Page Element
	When Click the DisplayCameraPage Input Page Element
	When Get the PrivacyGuardToggle Elements State
	When close lenovo vantage
	When Simulate Press F12 Event
	Then Dashboard or Privacy Gauge will be Launched

@UserDefinedKey
Scenario: VAN12416_TestStep06_Check the Dropdown title after select the Open App and File
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	Then The DropDown List Title is OpenAppFileOption

@UserDefinedKey
Scenario: VAN12416_TestStep07_Check the defaule UI after select the Open App and File
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	Then Check the UserDefinedKeyApplicationsTitle UIElement
	Then Check the UserDefinedKeyApplicationsPlusIcon Element
	Then Check the UserDefinedKeyFilesTitle UIElement
	Then Check the UserDefinedKeyFilesPlusIcon Element
	Then Take Screen Shot 07AddAPPInitUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep08_Select any app or file press F12 to launch Vantage or Privacy Guard
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click the DisplayCameraPage Input Page Element
	When Get the PrivacyGuardToggle Elements State
	When close lenovo vantage
	When Simulate Press F12 Event
	Then Dashboard or Privacy Gauge will be Launched

@UserDefinedKey
Scenario: VAN12416_TestStep09_Check the application list for Standalone and Store App
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	Then Check the StandaloneAppList Element
	Then Take Screen Shot 09StandaloneAppList in 12416 under HSScreenShotResult
	Then Check the StoreAppList Element
	When Click the StoreAppList Input Page Element
	Then Take Screen Shot 09StoreAppList in 12416 under HSScreenShotResult
	When Click the AddAppCancelButton Input Page Element

@UserDefinedKey
Scenario: VAN12416_TestStep10_Check the UI after user cancel to add app
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppCancelButton Input Page Element
	Then Check the UserDefinedKeyApplicationsPlusIcon Element

@UserDefinedKey
Scenario: VAN12416_TestStep11_Check the UI after user add an app
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	Then Check the UserDefinedKeyApplicationsTitle UIElement
	Then Check the UserDefinedKeyApplicationsADDLink UIElement
	Then Check the PaintApp UIElement
	Then Check the DeletePaintApp UIElement
	Then Take Screen Shot 11AfterAddAppUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep12_Check the UI after user add 6 app
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the DeletePaintApp Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Click the NotepadApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Click the QuickAssistApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Click the SnippingToolApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Click the StepsRecorderApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Click the WindowsMediaPlayerApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Hover the mouse on the UserDefinedKeyApplicationsADDLink Element
	#Then The ADD link state is unclicked
	Then Take Screen Shot 12AddLinkGreyout in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep13_Press F12 to invoke the 6 app
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Simulate Press F12 Event
	Then mspaint will be Launched
	Then notepad will be Launched
	Then quickassist will be Launched
	Then SnippingTool will be Launched
	Then psr will be Launched
	Then wmplayer will be Launched

@UserDefinedKey
Scenario: VAN12416_TestStep14_Delect one app and the ADD link can be clicked
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click the DeletePaintApp Input Page Element
	#Then The ADD link state is clicked
	When Hover the mouse on the UserDefinedKeyApplicationsADDLink Element
	Then Take Screen Shot 14AddLinkResumeBlue in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep15_Delete all the Added App
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 6 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	Then Check the UserDefinedKeyApplicationsPlusIcon Element

@UserDefinedKey
Scenario: VAN12416_TestStep16_Add the Paint App twice
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When wait 5 seconds
	When Click the UserDefinedKeyApplicationsADDLink Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element
	When wait 5 seconds
	Then There is noly 1 PaintApp Element

@UserDefinedKey
Scenario: VAN12416_TestStep17_Add the Edge App and rename
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Stop the IMC service in the task manager
	When Start the IMC service in the task manager
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the Edge Input Page Element
	When Click the AddAppOKButton Input Page Element
	When Remane the Edge exe
	When wait 5 seconds
	When Simulate Press F12 Event
	Then Take Screen Shot 17AppCannotLaunch in 12416 under HSScreenShotResult
	Then The Keyboard Manager Windows will be pupped up

@UserDefinedKey
Scenario: VAN12416_TestStep19_Add the Edge App and rename
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Remane the Edge exe
	When wait 5 seconds
	When Simulate Press F12 Event
	Then msedge will be Launched

@UserDefinedKey
Scenario: VAN12416_TestStep20_Click the Add File Icon and Check the Windows
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	Then Check the FileNameTitle UIElement
	Then Check the FilePathDropDown Element
	Then Check the FileType Element
	Then Check the FileOpenButton UIElement
	Then Check the FileCanaelButton UIElement

@UserDefinedKey
Scenario: VAN12416_TestStep21_Cancel Add File and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Click the FileCanaelButton Input Page Element
	Then Check the UserDefinedKeyFilesPlusIcon Element

@UserDefinedKey
Scenario: VAN12416_TestStep22_Add one file and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	Then Check the UserDefinedKeyFilesTitle UIElement
	Then Check the UserDefinedKeyFilesADDLink UIElement
	Then Check the File1 UIElement
	Then Check the DeleteFile1 UIElement
	Then Take Screen Shot 22AfterAddFileUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep23_Add 6 file and check the ADD link
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When Add the File 2 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When Add the File 3 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When Add the File 4 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When Add the File 5 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When Add the File 6 in Vantage
	When Click the FileOpenButton Input Page Element
	When Hover the mouse on the UserDefinedKeyFilesADDLink Element
	Then Take Screen Shot 23ADDLinkGreyState in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep24_Check all the six file is in opened state
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Simulate Press F12 Event
	When wait 60 seconds
	Then File 1 will be launched
	Then File 2 will be launched
	Then File 3 will be launched
	Then File 4 will be launched
	Then File 5 will be launched
	Then File 6 will be launched

@UserDefinedKey
Scenario: VAN12416_TestStep25_Delete 1 file and check the ADD link
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the DeleteFile1 Input Page Element
	When Hover the mouse on the UserDefinedKeyFilesADDLink Element
	Then Take Screen Shot 25ADDLinkClickState in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep26_Delete All the added file and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	Then Check the UserDefinedKeyFilesPlusIcon Element

@UserDefinedKey
Scenario: VAN12416_TestStep27_Add a file twice and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	When Click the UserDefinedKeyFilesADDLink Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	Given Type in "{PGDN}"
	#Then There is noly 1 File1 Element
	Then Take Screen Shot 27ADDFileTwice in 12416 under HSScreenShotResult
	When Click all The Delete Button Element

@UserDefinedKey
Scenario: VAN12416_TestStep28_Rename The file name
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	When Remane the File 1 name to X
	When wait 5 seconds
	When Simulate Press F12 Event
	Then The Keyboard Manager Windows will be pupped up

@UserDefinedKey
Scenario: VAN12416_TestStep29_Remove The file name
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Remane the File X name to 1
	When Remove the File 1 to C
	When Simulate Press F12 Event
	Then The Keyboard Manager Windows will be pupped up

#@UserDefinedKey
Scenario: VAN12416_TestStep30_Add a long file to UserDefinedKey
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Copy UserDefinedKeyFile
	When Created a long file
	When wait 5 seconds
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Add the LongFile in Vantage
	When Click the FileOpenButton Input Page Element
	When Hover the mouse on the LongFile Element
	Then Take Screen Shot 30LongFileUI in 12416 under HSScreenShotResult
	When Simulate Press F12 Event
	Then wait 30 seconds
	Then File LLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLA will be launched

@UserDefinedKey
Scenario: VAN12416_TestStep31_Delete file for UserDefinedKey
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Copy UserDefinedKeyFile
	When Click the UserDefinedKeyFilesPlusIcon Input Page Element
	When wait 5 seconds
	When Add the File 1 in Vantage
	When Click the FileOpenButton Input Page Element
	When Detele File 1
	When wait 5 seconds
	When Simulate Press F12 Event
	Then The Keyboard Manager Windows will be pupped up

@UserDefinedKey
Scenario: VAN12416_TestStep32_Create the file again for UserDefinedKey
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Copy UserDefinedKeyFile
	When wait 5 seconds
	When Simulate Press F12 Event
	When wait 30 seconds
	Then File 1 will be launched

@UserDefinedKey
Scenario: VAN12416_TestStep33_Select Invoke Key Sequence check the Drop-down text
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	Then The DropDown List Title is InvokeKeyOption

@UserDefinedKey
Scenario: VAN12416_TestStep34_Select Invoke Key Sequence check the Note
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	Then Check the InvokeKeyNote UIElement

@UserDefinedKey
Scenario: VAN12416_TestStep35_Select Invoke Key Sequence check the text title
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	Then Check the InvokeKeySeuqenceTextTitle UIElement

@UserDefinedKey
Scenario: VAN12416_TestStep36_Select Invoke Key Sequence check the "5 keys at most"
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the InvokeKeySequenceInputForm Input Page Element
	Then Take Screen Shot 36InvokeKeyHintText in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep38_Select Invoke Key Sequence press a key check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	When Click the InvokeKeySequenceInputForm Input Page Element
	Given Type in "1"
	Then Check the InvokeKeySequenceInputForm UIElement Display 1

@UserDefinedKey
Scenario: VAN12416_TestStep39_Select Invoke Key Sequence press 6 key check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	When Click the InvokeKeySequenceInputForm Input Page Element
	Given Type in "1"
	When wait 1 seconds
	Given Type in "2"
	When wait 1 seconds
	Given Type in "3"
	When wait 1 seconds
	Given Type in "4"
	When wait 1 seconds
	Given Type in "5"
	When wait 1 seconds
	Given Type in "6"
	Then Check the InvokeKeySequenceInputForm UIElement Display 1+ 2+ 3+ 4+ 5

@UserDefinedKey
Scenario: VAN12416_TestStep40_Select Invoke Key Sequence press 6 key check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	When Click the InvokeKeySequenceApplyButton Input Page Element
	Then The InvokeKeySequenceApplyButton element is in Greyout state

@UserDefinedKey
Scenario: VAN12416_TestStep41_Select Invoke Key Sequence press F12
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the DisplayCameraPage Input Page Element
	When Get the PrivacyGuardToggle Elements State
	When close lenovo vantage
	When Simulate Press F12 Event
	Then Dashboard or Privacy Gauge will be Launched

@UserDefinedKey
Scenario: VAN12416_TestStep42_Add Invoke Key Sequence check the add tip
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the InvokeKeyOption Input Page Element
	When Click the InvokeKeySequenceInputForm Input Page Element
	Given Type in "1"
	When wait 1 seconds
	When Click the InvokeKeySequenceApplyButton Input Page Element
	Then Take Screen Shot 42ApplytipDisplay in 12416 under HSScreenShotResult
	When wait 10 seconds
	Then Check the DelectKeySequence UIElement
	Then Take Screen Shot 42ApplytipHidden in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep43_Delete Invoke Key Sequence check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the DelectKeySequence Input Page Element
	Then Take Screen Shot 43DeleteKeySequence in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep45_Refresh Page and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the DisplayCameraPage Input Page Element
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the InputMoreLink Input Page Element
	Then Take Screen Shot 45RefreshPageUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep46_ReLaunch Page and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the InputMoreLink Input Page Element
	Then Take Screen Shot 46ReLaunchVantageUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep47_Resize Page and check the UI
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Resize Vantage to 500 and 500 windows
	When Click the InputMoreLink Input Page Element
	Then Take Screen Shot 47ResizeVantageUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep48_TestStep55_TestStep62_Check the default UI of Open website
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenWebsiteOption Input Page Element
	Then Check the WebSiteURLText Element
	Then The Apply button for URL is Greyout
	Then The default Help Tips should follow the UISPEC
	When Pagedown
	Then Take Screen Shot 48DefaultWebUI in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep49 Open the website user input
	When Only Print 'Please check TestStep65'

@UserDefinedKey
Scenario: VAN12416_TestStep50_Input a invalid URL of Open website
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenWebsiteOption Input Page Element
	When Click the WebsiteHelpTip Input Page Element
	Given Type in "666233" with interval "1" seconds
	When Pagedown
	When Click the WebsiteApplyButton Input Page Element
	Then Check the InvalidURLTip Element

@UserDefinedKey
Scenario: VAN12416_TestStep51_TestStep52_TestStep60_Check the default UI of Enter text
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the EnterTextOption Input Page Element
	Then Check the EnterTextNote UIElement
	Then Check the EnterTextBoxTitle UIElement
	Then The EnterText default Help Tip follow UISPEC
	Then The Apply button for Text is Greyout
	When Pagedown
	Then Take Screen Shot 51DefaultTextUI in 12416 under HSScreenShotResult
	
@UserDefinedKey
Scenario: VAN12416_TestStep52 Open the website user input
	When Only Print 'Please check TestStep51'
	
@UserDefinedKey
Scenario: VAN12416_TestStep53 Check Enter Text Apply tip and work well
	When Only Print 'Please check TestStep65_TestStep61'

@UserDefinedKey
Scenario: VAN12416_TestStep54_Input a invalid URL of Open website
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenWebsiteOption Input Page Element
	When Click the WebsiteHelpTip Input Page Element
	Given Type in "666233" with interval "1" seconds
	When Pagedown
	When Click the WebsiteApplyButton Input Page Element
	When wait 5 seconds
	Then The InvalidURLTip will Disapperaed

@UserDefinedKey
Scenario: VAN12416_TestStep55 Open the website user input
	When Only Print 'Please check TestStep48'

@UserDefinedKey
Scenario: VAN12416_TestStep57 Open the website user input
	When Only Print 'Please check TestStep65'

@UserDefinedKey
Scenario: VAN12416_TestStep58 Open the website user input
	When Only Print 'Please check TestStep65'

@UserDefinedKey
Scenario: VAN12416_TestStep59 Check Enter Text Apply tip and work well 
	When Only Print 'Please check TestStep65_TestStep61'

@UserDefinedKey
Scenario: VAN12416_TestStep60 Open the website user input
	When Only Print 'Please check TestStep51'

@UserDefinedKey
Scenario: VAN12416_TestStep62 Open the website user input
	When Only Print 'Please check TestStep48'

@UserDefinedKey
Scenario: VAN12416_TestStep63_Type a text and check help url hidden
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenWebsiteOption Input Page Element
	When Click the WebsiteHelpTip Input Page Element
	Given Type in "666233" with interval "1" seconds
	When Pagedown
	Then Take Screen Shot 63URLHidden in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep64_Delete the URL in Open website check help text
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenWebsiteOption Input Page Element
	When Click the WebsiteHelpTip Input Page Element
	Given Type in "6" with interval "1" seconds
	When Pagedown
	When Press 1 Backspace button
	Then The default Help Tips should follow the UISPEC
	Then Take Screen Shot 64DefaultTextUIBack in 12416 under HSScreenShotResult

@UserDefinedKey
Scenario: VAN12416_TestStep65_TestStep57_TestStep58_TestStep49 Open the website user input
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the OpenWebsiteOption Input Page Element
	When Click the WebsiteHelpTip Input Page Element
	Given Type in "https://www.bilibili.com/" with interval "1" seconds
	When Pagedown
	When Click the WebsiteApplyButton Input Page Element
	Then Check the SuccURLTip Element
	When wait 5 seconds
	Then The SuccURLTip will Disapperaed
	When Simulate Press F12 Event
	When wait 30 seconds
	Then "https://www.bilibili.com/" Web will be launched

@UserDefinedKey
Scenario: VAN12416_TestStep65_TestStep61 Check Enter Text Apply tip and work well 
	Given Thinkpad machines
	And Machine support User defined key
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Scrool 4 times screen 30
	When Click the EnterTextOption Input Page Element
	When Click the EnterTextHelpTip Input Page Element
	Given Type in "6" with interval "1" seconds
	When Pagedown
	When Click the EnterTextApplyButton Input Page Element
	Then Check the SuccURLTip Element
	When wait 5 seconds
	Then The SuccURLTip will Disapperaed
	When Click the EnterTextHelpTip Input Page Element
	When Simulate Press F12 Event
	When wait 5 seconds
	Then Check the Text "66" has Entered correctly
	Given Go to My Device Settings page
	When Click the InputPage Input Page Element
	When wait 10 seconds
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the InvokeKeyOption Input Page Element
	When Click the DelectKeySequence Input Page Element
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the EnterTextOption Input Page Element
	When Click the EnterTextHelpTip Input Page Element
	When Press 2 Backspace button
	When Click the UserDefinedKeyDropdownBtn Input Page Element
	When Click the OpenAppFileOption Input Page Element
	When Click all The Delete Button Element
	When Click the UserDefinedKeyApplicationsPlusIcon Input Page Element
	When Wait the App displayed
	When Click the PaintApp Input Page Element
	When Click the AddAppOKButton Input Page Element