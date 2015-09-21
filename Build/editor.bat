SET "configuration=%1"
SET "action=%2"
SET "verbosity=%3" 
For /f "tokens=1-4 delims=/ " %%a in ('date /t') do (set date=%%a%%b%%c)
For /f "tokens=1-2 delims=/:" %%a in ('time /t') do (set time=%%a%%b)
SET "logFolder=..\Log\%date%_%time%\"

MD %logFolder% 

ECHO Starting to %action% - %configuration%
ECHO verbosity: %verbosity%
ECHO date: %date%
ECHO time: %time%
ECHO logfolder: %logfolder%

call msbuild ..\ InnerCore.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\ OuterCore.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\ Desktop.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\ Applications.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\Source\Plugins\ OutputWindow.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\Source\Plugins\ ProjectExplorer.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\Source\Plugins\ PokemonEditor.sln %configuration% %verbosity% %action% %logFolder%
call msbuild ..\Source\Plugins\ ItemEditor.sln %configuration% %verbosity% %action% %logFolder%

ECHO %action% - %configuration% Done