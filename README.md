# SteamGamesNet
A wrapper, to get all (possible) informations about apps/games using the ID, which will be supplied as RawSteamGame-object for easy access to informations.


## Technologies used

SteamGamesNet was created using .NET Core 8.0 and relies on:
- [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)


## Features ⭐

### Nuget
SteamGamesNet is available as a Nuget package, get it at: [SteamGamesNet](https://www.nuget.org/packages/SteamGamesNet)


## Usage

## Example 🔧

For examples on how to use the wrapper, open the demo-project.

### Available Methods

- **GetAppListAsync**
  - Retrieves all Steam app IDs and names.
  - ```csharp
    AppListContainer appListContainer = await SteamClient.GetAppListAsync();
    ```

- **SteamFilesWithSignaturesAsync**
  - Retrieves the content of the steam.signatures file as a list of `SteamSignatureValue` containing HashAlgorithm, HashValue, FilePath, CrcValue, and DIGEST.
  - ```csharp
    IEnumerable<SteamSignatureValue> signatureValues = await SteamClient.SteamFilesWithSignaturesAsync();
    ```

- **GetAllDownloadingGames**
  - Retrieves the IDs of games that are currently downloading or updating.
  - ```csharp
    int[] SteamIdList = SteamClient.GetAllDownloadingGames()
    ```

- **GetAllDownloadingGamesWithDataAsync**
  - Retrieves all games that are currently downloading or updating as `RawSteamGame`.
  - ```csharp
    IEnumerable<RawSteamGame> ActiveDownloadingSteamappsWithInfo = await SteamClient.GetAllDownloadingGamesWithDataAsync();
    ```

- **GetAppDataAsync**
  - Retrieves data of a specific game using its Steam App ID, returning a `RawSteamGame` if it exists.
  - ```csharp
    RawSteamGame ExampleApp = await SteamClient.GetAppDataAsync(787790);
    ```

- **GetAllSteamGameIds**
  - Retrieves all Steam app IDs that are currently on the device.
  - ```csharp
    int[] SteamIdList = SteamClient.GetAllSteamGameIds();
    ```


## License 📜

SteamGamesNet is licensed under the GNU General Public License v3.0.

You can read the full license details of the GNU General Public License v3.0 [here](https://choosealicense.com/licenses/gpl-3.0/).

SteamGamesNet is licensed under the GNU General Public License v3.0. 
This project is not endorsed by Steam/Valve and does not reflect the views or opinions of Steam/Valve or anyone officially involved in managing it. 
Steam is a trademark and/or registered trademark of Valve.


## Disclaimer ⚠️

#### [Read the full disclaimer in the DISCLAIMER.md file!](https://github.com/liebki/SteamGamesNet/blob/master/DISCLAIMER.md)

Please read the full disclaimer in the DISCLAIMER.md file before using this project. 
The author (liebki (me)) of the project and the project itself are not endorsed by Steam/Valve and do not reflect the views or opinions of Steam/Valve or anyone officially involved in managing it.