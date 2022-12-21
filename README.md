# SteamGamesNet
A wrapper, to get all (possible) informations about apps/games using the ID, which will be supplied as RawSteamGame to easily access data without parsing.

## Technologies

### Created using
- .NET Core 6.0

### Nugets/Dependencies used
- Newtonsoft.Json

## Features

### Nuget
- A nuget package exists here: https://www.nuget.org/packages/SteamGamesNet

### General
- Get a "RawSteamGame" object, which has following (sometimes optional) fields
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

```
//Epic Roller Coasters (VR)
int ExampleSteamAppId = 787790;

//Wrong (not existing) id
int ExampleCorruptSteamAppId = 899998;

RawSteamGame ExampleApp = SteamGamesClient.GetAppData(ExampleSteamAppId, "", "");
if (ExampleApp != null)
{
	Console.WriteLine("Example output:");
	Console.WriteLine(ExampleApp.Data.ToString());
}
else
{
	Console.WriteLine("This app obviously doesn't exist, the id is wrong or something else is not working correctly!");
}

RawSteamGame ExampleCorruptApp = SteamGamesClient.GetAppData(ExampleCorruptSteamAppId);
if (ExampleCorruptApp != null)
{
	Console.WriteLine("Example corrupt output:");
	Console.WriteLine(ExampleCorruptApp.Data.ToString());
}
else
{
	Console.WriteLine("This app obviously doesn't exist, the id is wrong or something else is not working correctly!");
}
```

### Optional parameters

#### Custom language
- SteamGamesClient.GetAppData(ExampleSteamAppId, language:"german");

#### Custom useragent
- SteamGamesClient.GetAppData(ExampleSteamAppId, useragent:"Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");

#### Both (language > useragent)
- SteamGamesClient.GetAppData(ExampleSteamAppId, "german", "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:110.0) Gecko/20100101 Firefox/110.0");

## FAQ

#### Does this work on every OS?

I created this on windows 10 and tested it on other windows 10 machines, I cant guarantee anything for other operating systems or versions. But it should work everywhere, where .NET Core 5-7 works.

## License

**Software:** SteamGamesNet

**License:** GNU General Public License v3.0

**Licensor:** Kim Mario Liebl

[GNU](https://choosealicense.com/licenses/gpl-3.0/)

## Roadmap

- More to come..

## DISCLAIMER SECTION

#### [Read the full disclaimer in the DISCLAIMER.md file!](https://github.com/liebki/SteamGamesNet/blob/master/DISCLAIMER.md)

**liebki (me) or this project** isn’t endorsed by Steam/Valve and doesn’t reflect the 
views or opinions of Steam/Valve or anyone officially involved in managing it.
Steam is a trademark and/or registered trademark of "Valve".