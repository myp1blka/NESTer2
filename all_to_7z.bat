@echo off
set _in="./roms_nes"
set _out="./roms_nes"
set _arcpath=C:\Program Files\7-Zip
for %%i in (%_in%\*.nes) do "%_arcpath%\7z" a "%_out%\%%~ni.7z" "%%i"
echo.
echo OK
pause