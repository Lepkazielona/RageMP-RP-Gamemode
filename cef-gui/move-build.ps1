if (Test-Path -Path ".\dist"){
    if (Test-Path -Path "..\client_packages\web-gui\dist"){
        Remove-Item "..\client_packages\web-gui" -Recurse
    }
    Copy-Item -Path ".\dist" -Destination "..\client_packages\web-gui\"  -Recurse
    Write-Output "File Copied"
} else {
    Write-Output "Dist folder does not exist, build first"
}