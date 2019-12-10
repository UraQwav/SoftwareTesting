cd Web
msbuild.exe Web.csproj
cd ../packages\NUnit.ConsoleRunner.3.10.0\tools
nunit3-console.exe --testparam:browser=Google --testparam:environment=dev "../../../Web/bin/Debug/netcoreapp3.0/Web.dll"
