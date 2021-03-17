path = C:\Windows\Microsoft.NET\Framework64\v4.0.30319
set str=%~nx1
@if "%1"=="" (
start cmd \k
) else (
@echo off
csc -nologo %str%
cls
%str:cs=exe%
pause >NUL
)

