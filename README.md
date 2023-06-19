# SteamGamesNet
A wrapper, to get all (possible) informations about apps/games using the ID, which will be supplied as RawSteamGame to easily access data without parsing.


## Technologies used

SteamGamesNet was created using .NET Core 6.0 and relies on the following Nuget packages and dependencies:
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)


## Features

### Nuget
SteamGamesNet is available as a Nuget package. You can download it from here: [SteamGamesNet](https://www.nuget.org/packages/SteamGamesNet)


## Usage

## Example

#### Constructor parameters for optional changes
You can optionally provide language and user-agent information while instantiating the SteamGamesClient object as shown below:

``` SteamGamesClient(string language = "", string useragent = "") ```

#### Get the content of the steam.signatures file as object
The SteamFilesWithSignatures() method gives back a List<SteamSignatureValue>, containing HashValues, Filepaths etc.
``` SteamFilesWithSignatures() ```

```
List<SteamSignatureValue> signatureValues = await SteamClient.SteamFilesWithSignatures();
```


#### Get all games that are currently downloading or updating
The GetActiveDownloadedGames() or GetActiveDownloadedGamesWithInfoAsync() methods give you a list of app id's or a list of RawSteamGame-objects
``` GetActiveDownloadedGames() ```
``` GetActiveDownloadedGamesWithInfoAsync() ```

```
int[] ActiveDownloadingSteamappsWithoutInfo in SteamClient.GetActiveDownloadedGames()

List<RawSteamGame> ActiveDownloadingSteamappsWithInfo = await SteamClient.GetActiveDownloadedGamesWithInfoAsync();
```


#### Get all installed steamapps on the device (Windows only)
The GetAllSteamGameIds() method is used to get all installed Steam apps on the device (Windows only). 
Here is an example:

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

#### Get data of an app, using the app id
The GetAppData() method is used to get app data using an app ID. 
Here is an example:

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


## License
SteamGamesNet is licensed under the GNU General Public License v3.0. 
This project is not endorsed by Steam/Valve and does not reflect the views or opinions of Steam/Valve or anyone officially involved in managing it. 
Steam is a trademark and/or registered trademark of Valve.

You can read the full license details of the GNU General Public License v3.0 here: [GNU](https://choosealicense.com/licenses/gpl-3.0/)


## Roadmap
The following items are planned for future releases:

- Implement a method to get the app data using the name
- Implement a method to get the app ID using the name
- and more...


## DISCLAIMER SECTION

#### [Read the full disclaimer in the DISCLAIMER.md file!](https://github.com/liebki/SteamGamesNet/blob/master/DISCLAIMER.md)

Please read the full disclaimer in the DISCLAIMER.md file before using this project. 
The author (liebki (me)) of the project and the project itself are not endorsed by Steam/Valve and do not reflect the views or opinions of Steam/Valve or anyone officially involved in managing it.