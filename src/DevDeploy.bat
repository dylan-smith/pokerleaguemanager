"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\ReadyRoll\OctoPack\tools\Nuget.exe" Restore "%~dp0\PokerLeagueManager.sln"
"C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\Common7\IDE\devenv.com" "PokerLeagueManager.sln" /Build Debug
"C:\Program Files (x86)\Microsoft SQL Server\140\DAC\bin\sqlpackage.exe" /SourceFile:"PokerLeagueManager.DB.EventStore\bin\Debug\PokerLeagueManager.DB.EventStore.dacpac" /Action:Publish /TargetServerName:localhost /TargetDatabaseName:PokerLeagueManager.DB.EventStore /p:CreateNewDatabase=true
"C:\Program Files (x86)\Microsoft SQL Server\140\DAC\bin\sqlpackage.exe" /SourceFile:"PokerLeagueManager.DB.QueryStore\bin\Debug\PokerLeagueManager.DB.QueryStore.dacpac" /Action:Publish /TargetServerName:localhost /TargetDatabaseName:PokerLeagueManager.DB.QueryStore /p:CreateNewDatabase=true
%~dp0\PokerLeagueManager.Utilities\bin\Debug\PokerLeagueManager.Utilities.exe CreateEventSubscriber localhost PokerLeagueManager.DB.EventStore http://localhost:13831
%~dp0\PokerLeagueManager.Utilities\bin\Debug\PokerLeagueManager.Utilities.exe GenerateSampleData http://localhost:4224 400

pause