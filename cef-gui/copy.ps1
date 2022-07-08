if (Test-Path -Path "..\client_packages\web-gui\dist")
{
    Remove-Item "..\client_packages\web-gui\dist\" -Force
}
if (Test-Path -Path ".\dist")
{
    Copy-Item -Path ".\dist" -Destination "..\client_packages\web-gui\"
} else {
    Write-Error "You need to build project first"
}