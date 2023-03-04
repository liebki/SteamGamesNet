# SteamGamesNet
Get all game related informations using the app id or get all installed games that are found on a device.

Example code:

#### Constructor parameters for optional change of language/useragent

``` SteamGamesClient(string language = "", string useragent = "") ```

#### Get all installed steamapps on the device (WIN only)

``` GetAllSteamGameIds() ```

```
SteamGamesClient SgC = new();
int[] SteamIdList = SgC.GetAllSteamGameIds();

if (SteamIdList.Length > 0)
{
    SteamIdList.ToList().ForEach(SteamGameId => Console.WriteLine(SteamGameId));
}
else
{
    Console.WriteLine("No games found on this device");
}
```

#### Get app data using an appid

``` GetAppData() ```

```
SteamGamesClient SgC = new();
int ExampleSteamAppId = 787790;

int ExampleCorruptSteamAppId = 899998;
RawSteamGame ExampleApp = SgC.GetAppData(ExampleSteamAppId);

if (ExampleApp != null)
{
    Console.WriteLine("Example output:");
    Console.WriteLine(ExampleApp.Data.ToString());
}
else
{
    Console.WriteLine("This app obviously doesn't exist, the id is wrong or something else is not working correctly!");
}
```