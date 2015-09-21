RMDIR /S /Q ".\Output"
RMDIR /S /Q ".\Documentation"
del /S /Q /F /AH *.suo
del /S /Q /F *.log
del /S /Q /F *.CAL.log
del /S /Q /F *.lastcodeanalysissucceeded
for /d /r . %%d in (packages) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (FakesAssemblies) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (TestResults) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (obj) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (bin) do @if exist "%%d" rd /s/q "%%d"
for /d /r . %%d in (log) do @if exist "%%d" rd /s/q "%%d"
for /f "delims=" %%d in ('dir /s /b /ad ^| sort /r') do rd "%%d"