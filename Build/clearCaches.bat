REM Controllare se i percorsi di default corrispondono ai propri
REM Il primo set di comandi rimuove i file SUO mentre il secondo svuota la cache di Resharper

@echo off

CLS 

ECHO DELETING SUO FILES
cd ..
del /s /p /f /ah *.suo 

ECHO DELETING RESHARPER CACHE
rd /s/q "%LOCALAPPDATA%\JetBrains\ReSharper\v8.1\SolutionCaches"
 
ECHO Done
pause