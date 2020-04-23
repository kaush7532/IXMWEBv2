@echo off

set batchdir=%cd%

set solnfile="%batchdir%\IXMWEBv2.sln"

echo Building Solution

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\MSBuild\15.0\Bin\MSBuild.exe" %solnfile% /property:Configuration=Release


set testrunsettingfile="%batchdir%\test.runsettings"
set dllpath="%batchdir%\IXMWEBv2\bin\Release\IXMWEBv2.dll"

echo Run Tests

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow\vstest.console.exe" %dllpath% /Settings:%testrunsettingfile% /TestCaseFilter:"TestCategory=DeviceConfiguration" /Logger:trx"


pause