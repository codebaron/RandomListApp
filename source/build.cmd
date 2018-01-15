@echo off

::run default tasks
IF x%1==x powershell .\build.ps1 -target default

::run provided task
IF NOT x%1==x powershell .\build.ps1 -target %1