# SteamGamesNet
A wrapper, to get all (possible) informations about apps/games using the ID, which will be supplied as RawSteamGame to easily access data without parsing.

Example code:
```
//Epic Roller Coasters (VR)
int ExampleSteamAppId = 787790;

RawSteamGame ExampleApp = SteamGamesClient.GetAppData(ExampleSteamAppId);
if (ExampleApp != null)
{
    Console.WriteLine("Example output:");
    Console.WriteLine(ExampleApp.Data.ToString());
}
else
{
    Console.WriteLine("This app is obviously doesn't exist, the id is wrong or something else is not working correctly!");
}
```