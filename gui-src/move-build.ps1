# Lpk 2022, Nie mam pomysłu na nazwe RP

if(Test-Path -Path '../client_packages/cef/**'){
    if(Test-Path -Path './dist'){
        Remove-Item -Path '../client_packages/cef/**'
        Copy-Item -Path './dist/**/**' -Destination '../client_packages/cef/'
        Write-Output 'Files Copied'
    } else {
        Write-Output 'Build project first'
    }
} else {
    Write-Output 'no cef fodler in ./client_packages/'
}