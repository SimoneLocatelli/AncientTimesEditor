@echo off

SET "buildConfiguration=%1"

cls

IF "%1."=="." (
ECHO Please, enter which build configuration you want to use [Debug or Release]
goto :eof
)
SET verbosityLevel=normal

call editor %buildConfiguration% Build %verbosityLevel% 

:eof
pause