Set-StrictMode -Version Latest
Clear
#=============================


$channelName = 'build-notifications'

$channel = Open-NotificationChannel $channelName
$conf = New-BuildConfiguration

$messages = @(
    (New-BuildMessage $conf "Init" "Message 1"),
    (New-BuildMessage $conf "Start" "Message 2"),
    (New-BuildMessage $conf "Progress" "Message 3"),
    (New-BuildMessage $conf "Warning" "Message 4"),
    (New-BuildMessage $conf "Error" "Message 5"),
    (New-BuildMessage $conf "Finish" "Message 6")
)

foreach($message in $messages){
    Write-Host "Sending message '$($message.Message)'"
    Push-Notification $channel $message
    
    Start-Sleep -s 2
}