namespace SteamGamesNet
{
    public static class SteamGamesClient
    {
        public static RawSteamGame GetAppData(int steamappid, string language = "", string useragent = "")
        {
            return SteamRequestManager.GetAppData(steamappid, language, useragent);
        }
    }
}