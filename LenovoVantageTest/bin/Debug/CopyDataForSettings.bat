@echo off
net use \\10.119.39.24 /user:share Aa123456
:: BatchGotAdmin
:-------------------------------------
REM  --> Check for permissions
    IF "%PROCESSOR_ARCHITECTURE%" EQU "amd64" (
>nul 2>&1 "%SYSTEMROOT%\SysWOW64\cacls.exe" "%SYSTEMROOT%\SysWOW64\config\system"
) ELSE (
>nul 2>&1 "%SYSTEMROOT%\system32\cacls.exe" "%SYSTEMROOT%\system32\config\system"
)

REM --> If error flag set, we do not have admin.
if '%errorlevel%' NEQ '0' (
    echo NO administrative privileges...
    
) 

    pushd "%CD%"
    CD /D "%~dp0"
:--------------------------------------   

cd %cd%
net use \\10.119.39.24 /user:share Aa123456
if exist Data (
rmdir  "Data"  /S /Q
mklink /d "Data" "\\10.119.39.24\Tangram\Data"
)
if not exist Data (
mklink /d "Data" "\\10.119.39.24\Tangram\Data"
)

xcopy /E /I /C  /Y data\TestData\Vantage_Assets\assets assets:
copy /Y /V  data\TestData\Vantage_Assets\i18n.js i18n.js
xcopy /E /I /C /Y data\tools\ExternalUIAHelper ExternalUIAHelper
xcopy /E /I /C /Y Data\Tools\IdeaPadNoteBookPluginDll  IdeaPadNoteBookPluginDll