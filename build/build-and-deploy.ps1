Set-StrictMode -Version Latest
Clear
#=============================


Import-Module -Name "$PSScriptRoot\Invoke-MsBuild.psm1" -DisableNameChecking

$moduleName = 'GrafGenerator.BuildNotificationTools.Commands'
$dependencyModuleName = 'GrafGenerator.BuildNotificationTools.Interop'
$docsFolder = [Environment]::GetFolderPath('MyDocuments')
$installFolder = "$docsFolder\WindowsPowerShell\Modules\$moduleName"
$modulePath = "$installFolder\$moduleName.dll"
$dependencyModulePath = "$installFolder\$dependencyModuleName.dll"
$manifestPath = "$installFolder\$moduleName.psd1"

$rootFolder = "$PSScriptRoot\.."
$artifactsFolder = "$rootFolder\artifacts"
$solutionPath = "$rootFolder\src\GrafGenerator.BuildNotificationTools.sln"



# build

$buildSucceeded = Invoke-MsBuild -Path $solutionPath -MsBuildParameters "/target:Clean;Build /property:Configuration=Release;OutDir=$artifactsFolder"

if ($buildSucceeded)
{ Write-Host "Build completed successfully." }
else
{ Write-Host "Build failed. Check the build log file for errors." }


#install

Write-Host "Install module."

#try to create required folders first
New-Item -ItemType File -Path $modulePath -Force | Out-Null

Copy-Item -Path "$artifactsFolder\$dependencyModuleName.dll" -Destination $dependencyModulePath -Force | Out-Null
Copy-Item -Path "$artifactsFolder\$moduleName.dll" -Destination $modulePath -Force | Out-Null
Copy-Item -Path "$artifactsFolder\$moduleName.psd1" -Destination $manifestPath -Force | Out-Null

$depExist = Test-Path $dependencyModulePath
$dllExist = Test-Path $modulePath
$psdExist = Test-Path $manifestPath

if($depExist -eq $false -or $dllExist -eq $false -or $psdExist -eq $false){
    Write-Host "Installation failed. Module not installed."
}
else {
    Write-Host "Installation succeeded. Module installed."
    Write-Host "Module path: $modulePath"
}