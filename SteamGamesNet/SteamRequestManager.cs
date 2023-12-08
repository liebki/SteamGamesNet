using Newtonsoft.Json;
using SteamGamesNet.Models;

namespace SteamGamesNet
{
    internal static class SteamRequestManager
    {
        private const string SteamApiUrl = "https://store.steampowered.com/api/appdetails/?";
        private const string SteamApiGetAppListUrl = "https://api.steampowered.com/ISteamApps/GetAppList/v0002/";
        private static string HttpUserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; Valve Steam GameOverlay/1701289036) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/85.0.4183.121 Safari/537.36";
        private static readonly HttpClient HttpClient = new();

        internal static async Task<RawSteamGame> GetAppDataAsync(int steamappid, string language = "", string useragent = "")
        {
            string SteamApiAppRequestUrl = SteamApiUrl;
            if (!string.IsNullOrEmpty(language) && language.Length > 3)
            {
                SteamApiAppRequestUrl += $"l={language}&";
            }

            SteamApiAppRequestUrl += $"appids={steamappid}";
            string jsonResponse = await QuerySteamAsync(SteamApiAppRequestUrl, useragent);

            RawSteamGame gameData = null;
            if (!jsonResponse.Contains("success\":false"))
            {
                try
                {
                    Dictionary<string, RawSteamGame> dict = JsonConvert.DeserializeObject<Dictionary<string, RawSteamGame>>(jsonResponse);
                    gameData = dict[steamappid.ToString()];
                }
                catch (Exception)
                {
                    throw new($"Couldn't get data for {steamappid}, app is probably not supplied right from steam.");
                }
            }

            return gameData;
        }

        internal static async Task<AppListContainer> GetAppList()
        {
            string jsonResponse = await QuerySteamAsync(SteamApiGetAppListUrl, HttpUserAgent);
            AppListContainer appListContainer = null;

            try
            {
                appListContainer = JsonConvert.DeserializeObject<AppListContainer>(jsonResponse);
            }
            catch (Exception)
            {
                throw new Exception($"Could not load the applist from steam api!");
            }

            return appListContainer;
        }

        private static async Task<string> QuerySteamAsync(string url, string useragent = "")
        {
            if (!string.IsNullOrEmpty(useragent) && useragent.Length > 3)
            {
                HttpUserAgent = useragent;
            }

            HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(HttpUserAgent);
            HttpResponseMessage response = await HttpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        internal static int[] GetActiveDownloadedGames(string path)
        {
            List<int> IdList = new();

            foreach (string dir in Directory.EnumerateDirectories(path))
            {
                DirectoryInfo directoryInfo = new(dir);
                bool IsParseable = int.TryParse(directoryInfo.Name, out int AppId);

                if (IsParseable)
                {
                    IdList.Add(AppId);
                }
            }

            return IdList.ToArray();
        }

        internal static async Task<List<SteamSignatureValue>> SteamFilesWithSignatures(string CustomPath)
        {
            string[] SignatureFileContent;
            List<SteamSignatureValue> SteamFiles = new();

            string SteamSignatureFilePath = Path.Combine(CustomPath, "steam.signatures");
            if (File.Exists(SteamSignatureFilePath))
            {
                SignatureFileContent = await File.ReadAllLinesAsync(SteamSignatureFilePath);
                if (SignatureFileContent.Length > 0)
                {
                    foreach (string file in SignatureFileContent)
                    {
                        if (!string.IsNullOrWhiteSpace(file))
                        {
                            if (!file.StartsWith("DIGEST:"))
                            {
                                string[] GeneralContent = file.Split("~");
                                string FilePath = Path.Combine(CustomPath, GeneralContent[0].Replace("...\\", string.Empty));

                                string[] HashContentAlgoName = GeneralContent[1].Split(":");
                                string[] HashContentValue = HashContentAlgoName[1].Split(";");

                                SteamSignatureValue ShaDigest = new(FilePath, HashContentAlgoName[0], HashContentValue[0], HashContentAlgoName[2], false);
                                SteamFiles.Add(ShaDigest);
                            }
                            else
                            {
                                SteamSignatureValue ShaDigest = new(string.Empty, string.Empty, file.Replace("DIGEST:", string.Empty), string.Empty, true);
                                SteamFiles.Add(ShaDigest);
                            }
                        }
                    }
                }
            }

            return SteamFiles;
        }

        internal static async Task<List<RawSteamGame>> GetActiveDownloadedGamesWithInfoAsync(string path)
        {
            int[] IdList = GetActiveDownloadedGames(path);
            List<RawSteamGame> SteamGameList = new();

            foreach (int AppId in IdList)
            {
                RawSteamGame rawSteamGame = await GetAppDataAsync(AppId);
                SteamGameList.Add(rawSteamGame);
            }

            return SteamGameList;
        }
    }
}