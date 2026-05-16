@echo off
rem publish-linux-x64.bat
rem Usage: publish-linux-x64.bat [self-contained]

setlocal enabledelayedexpansion

rem プロジェクトパス（ワークスペースルートからの相対パス）
set "ROOT=%~dp0"
set "PROJECT=%ROOT%PPCalculationAPI\PPCalculationAPI.csproj"
set "CONFIG=Release"
set "RID=linux-x64"
set "OUTPUT=%ROOT%publish\%RID%"

rem 引数で self-contained を渡すと自己完結型バイナリを生成します。
if "%1"=="self-contained" (
  set "SC=--self-contained true"
) else (
  set "SC=--no-self-contained"
)

echo Publishing "%PROJECT%" for %RID% (Configuration: %CONFIG%)...
dotnet publish "%PROJECT%" -c %CONFIG% -r %RID% -o "%OUTPUT%" %SC%
if errorlevel 1 (
  echo.
  echo Publish failed with exit code %ERRORLEVEL%.
  pause
  exit /b %ERRORLEVEL%
)

echo.
echo Publish succeeded. Output: "%OUTPUT%"
endlocal
pause
