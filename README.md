# SteamGamesNet
A wrapper, to get all (possible) informations about apps/games using the ID, which will be supplied as RawSteamGame to easily access data without parsing.

## Technologies

### Created using
- .NET Core 6.0

### Nugets/Dependencies used
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)

## Features

### Nuget
- A nuget package exists here: [SteamGamesNet](https://www.nuget.org/packages/SteamGamesNet)

### General
- Get a "[RawSteamGame](https://github.com/liebki/SteamGamesNet/blob/master/SteamGamesNet/Models/RawSteamGame.cs)" object, which has following (sometimes optional) fields
	- Data (to access the main data and the most valuable informations)
		- Type of app
		- name of app
		- Languages
		- Many more..
	- Category
		- Id
		- Description
	- Genre
		- Id
		- Description
	- Platforms (bool)
		- Windows
		- Mac
		- Linux
	- PriceOverview
		- Currency
		- Discount
		- Many more..
	- Screenshot
		- Id
		- Thumbnail path
		- Image path
	- SupportInfo
		- Support url
		- Support mail

## Usage

## Example

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

## License

**Software:** SteamGamesNet

**License:** GNU General Public License v3.0

**Licensor:** Kim Mario Liebl

[GNU](https://choosealicense.com/licenses/gpl-3.0/)

## Roadmap

- Implement a method
	- To get the app data using the name
	- To get the app id using the name
- More to come..

## DISCLAIMER SECTION

#### [Read the full disclaimer in the DISCLAIMER.md file!](https://github.com/liebki/SteamGamesNet/blob/master/DISCLAIMER.md)

**liebki (me) or this project** isn’t endorsed by Steam/Valve and doesn’t reflect the 
views or opinions of Steam/Valve or anyone officially involved in managing it.
Steam is a trademark and/or registered trademark of "Valve".