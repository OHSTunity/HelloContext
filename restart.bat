@echo off
staradmin kill all

REM Start Barcodes
call "%~dp0..\Barcodes\run.bat"

call "%~dp0run.bat"