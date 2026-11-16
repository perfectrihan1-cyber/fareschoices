@echo off
echo Starting fareschoices on http://localhost:8081...
start "" "%LOCALAPPDATA%\IISExpress\IIS Express\iisexpress.exe" /site:fareschoices /systray:false
start http://localhost:8081
