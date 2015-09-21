SET "solutionPath=%1"
SET "solutionName=%2"
SET "configuration=%3"
SET "verbosity=%4"
SET "action=%5"
SET "logFolder=%6"
SET "logFile=%logFolder%%solutionName%_%configuration%_%action%.log"
SET "errorsLogFile=%logFolder%%solutionName%_%configuration%_%action%_errors.log"
SET "warningsLogFile=%logFolder%%solutionName%_%configuration%_%action%_warning.log"

ECHO -----------------------------------------------------
ECHO Building %solutionPath%%solutionName%
ECHO LogFile %logfile%
ECHO ErrorsLogFile %errorsLogFile%
ECHO WarningsLogFile %warningsLogFile%
ECHO -----------------------------------------------------

"C:\Program Files (x86)\MSBuild\12.0\Bin\MSBuild.exe" %solutionPath%%solutionName% /m:4 /p:BuildInParallel=true /t:%action% /verbosity:%verbosity% /p:Configuration=%configuration% /nologo  /fl1 /fl2 /fl3 /flp1:logfile=%logFile% /flp2:logfile=%errorsLogFile%;errorsonly /flp3:logfile=%warningsLogFile%;warningsonly 

CALL cleanEmptyLogFiles.bat %logFolder%