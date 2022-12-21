using Newtonsoft.Json;

namespace SteamGamesNet
{
    internal static class SteamRequestManager
    {
        const string SteamApiUrl = "https://store.steampowered.com/api/appdetails/?";
        static string HttpUserAgent = "Mozilla/5.0 (Windows; U; Windows NT 10.0; en-US; Valve Steam GameOverlay/1639697812; ) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.105 Safari/537.36";
        public static RawSteamGame GetAppData(int steamappid, string language = "", string useragent = "")
        {
            string SteamApiAppRequestUrl = SteamApiUrl;
            if (!string.IsNullOrEmpty(language) && language.Length > 3)
            {
                SteamApiAppRequestUrl += $"l={language}&";
            }

            SteamApiAppRequestUrl += $"appids={steamappid}";
            string JsonResponse = QuerySteam(SteamApiAppRequestUrl, useragent);

            RawSteamGame gameData = null;
            if (!JsonResponse.Contains("success\":false"))
            {
                Dictionary<string, RawSteamGame> dict = new();
                try
                {
                    dict = JsonConvert.DeserializeObject<Dictionary<string, RawSteamGame>>(JsonResponse);
                }
                catch (Exception)
                {
                    throw new($"Couldn't get data for {steamappid}, app is probably not supplied right from steam.");
                }
                gameData = dict[steamappid.ToString()];
            }
            return gameData;
        }

        private static string QuerySteam(string url, string useragent = "")
        {
            string JsonResponse = string.Empty;
            using (HttpClient client = new())
            {
                if (!string.IsNullOrEmpty(useragent) && useragent.Length > 3)
                {
                    HttpUserAgent= useragent;
                }

                client.DefaultRequestHeaders.Add("User-Agent", HttpUserAgent);
                HttpResponseMessage response = client.GetAsync(url).GetAwaiter().GetResult();

                response.EnsureSuccessStatusCode();
                JsonResponse = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            }

            return JsonResponse;
        }
    }
}