@echo off

dotnet restore

dotnet build --no-restore -c Release

move /Y Panosen.CodeDom.Scss\bin\Release\Panosen.CodeDom.Scss.*.nupkg D:\LocalSavoryNuget\
move /Y Panosen.CodeDom.Scss.Engine\bin\Release\Panosen.CodeDom.Scss.Engine.*.nupkg D:\LocalSavoryNuget\

pause