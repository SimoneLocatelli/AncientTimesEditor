SET "logDirectory=%1"
FOR %%F IN ("%logDirectory%*.*") DO (
IF %%~zF LSS 1 DEL %%F
)