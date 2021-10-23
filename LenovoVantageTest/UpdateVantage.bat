powershell "Get-AppxPackage *Lenovo* | Remove-AppxPackage"
del /f vantage.zip
wget --no-check-certificate -P  %USERPROFILE%\Downloads -O vantage.zip  %bamboo.zipurl%

rmdir /S/Q "%USERPROFILE%\Downloads\AppPackages"
powershell Set-ExecutionPolicy Unrestricted
powershell Expand-Archive %USERPROFILE%\Downloads\vantage.zip -DestinationPath %USERPROFILE%\Downloads\ 
echo . | powershell %USERPROFILE%\Downloads\AppPackages\VantageShell_10.2003.6.0_Test\Add-AppDevPackage.ps1
(echo {"webURL":"https://vantage-qa-2.csw.lenovo.com/"})>%USERPROFILE%\AppData\Local\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\LocalState\config.json
