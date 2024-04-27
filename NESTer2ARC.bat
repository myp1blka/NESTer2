@echo off

echo = making backup
echo.
echo.

echo =================================================
echo BackUP NESTer2 to \NESTer2ARC
echo. 
echo =================================================

echo = deleting "\pub"
rmdir /s /q .\NESTer2\pub
echo.
echo = deleting "\bin"
rmdir /s /q .\NESTer2\bin
echo.
echo = deleting "\obj"
rmdir /s /q .\NESTer2\obj
echo.

for /f "tokens=1-2 delims=:,./- " %%I in ("%TIME%") do set BKUP_TIME=%%I.%%J
"C:\Program Files\7-Zip\7z" a .\NESTer2ARC\NESTer_2.24_src_%date%_%BKUP_TIME%.7z .\NESTer2
echo.
echo = OK =

pause
