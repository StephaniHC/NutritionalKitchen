﻿# PURPOSE: Automates the running of Unit Tests and Code Coverage
# REF: https://stackoverflow.com/a/70321555/495455

# If running outside the test folder
#cd E:\Dev\XYZ\src\XYZTestProject

# This only needs to be installed once (globally), if installed it fails silently: 
dotnet tool install -g dotnet-reportgenerator-globaltool --version 5.1.26

# Save currect directory into a variable
$dir = pwd

# Delete previous test run results (there's a bunch of subfolders named with guids)
Remove-Item -Recurse -Force $dir/TestResults/

# Run the Coverlet.Collector - REPLACING YOUR SOLUTION NAME!!!
$output = [string] (& dotnet test --collect:"XPlat Code Coverage" 2>&1)
Write-Host "Last Exit Code: $lastexitcode"
Write-Host $output

# Extract the GUID from the Output eg,
#"Attachments: E:\Dev\XYZ\src\XYZTestProject\TestResults\0f26f16d-bbe8-463b-856b-6d4fbee673

$i = $output.LastIndexOf("TestResults") + 11
$j = $output.LastIndexOf("coverage")
$cmdGuid = $output.SubString($i, $j - $i - 1)
Write-Host $cmdGuid

# Delete previous test run reports - note if you're getting wrong results do a Solution Clean and Rebuild to remove stale DLLs in the bin folder
Remove-Item -Recurse -Force $dir/coveragereport/

# To keep a history of the Code Coverage we need to use the argument: -historydir:SOME_DIRECTORY 
if (!(Test-Path -path $dir/CoverageHistory)) {  
 New-Item -ItemType directory -Path $dir/CoverageHistory
}

# Generate the Code Coverage HTML Report
reportgenerator -reports:"$dir/**/coverage.cobertura.xml" -targetdir:"$dir/coveragereport" -reporttypes:Html -historydir:$dir/CoverageHistory 

# Open the Code Coverage HTML Report (if running on a WorkStation)
$osInfo = Get-CimInstance -ClassName Win32_OperatingSystem
if ($osInfo.ProductType -eq 1) {
(& "$dir/coveragereport/index.html")
}