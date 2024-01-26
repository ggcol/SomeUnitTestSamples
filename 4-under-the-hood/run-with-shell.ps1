$testDllPath = "C:\Users\GianlucaColombo\source\repos\personal\SomeUnitTestSamples\3-dependency-handling\ALibrary.Tests\bin\Debug\net8.0\ALibrary.Tests.dll"

# LEGACY - using mstest.exe
# won't work
$defaultLocation = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE";

Set-Location($defaultLocation);

.\mstest.exe $testDllPath;

# using vstest.console.exe
# https://learn.microsoft.com/en-us/visualstudio/test/vstest-console-options?view=vs-2022
$defaultLocation = "C:\Program Files\Microsoft Visual Studio\2022\Community\Common7\IDE\CommonExtensions\Microsoft\TestWindow";

Set-Location($defaultLocation);

.\vstest.console.exe $testDllPath;

# using dotnet test
# https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test
dotnet test $testDllPath;