using SteamGamesNet.Models;

namespace SteamGamesNet
{
    public class SteamGamesClient
    {
        private string Lang_ { get; }
        private string Useragent_ { get; }

        public SteamGamesClient(string language = "", string useragent = "")
        {
            if (!string.IsNullOrEmpty(language))
            {
                Lang_ = language;
            }
            if (!string.IsNullOrEmpty(useragent))
            {
                Useragent_ = useragent;
            }
        }

        public RawSteamGame GetAppData(int steamappid)
        {
            return SteamRequestManager.GetAppData(steamappid, Lang_, Useragent_);
        }

        public int[] GetAllSteamGameIds(string CustomPath = "")
        {
            Utils.OsWinCheck();

            string SteamInstallationPath = string.Empty;
            List<int> SteamAppIdList = new();

            if (string.IsNullOrEmpty(CustomPath))
            {
                if (Utils.IsSteamInRegistry())
                {
                    SteamInstallationPath = Utils.GetSteamRegistryInstallPath();
                }
            }
            else
            {
                SteamInstallationPath = CustomPath;
            }

            foreach (string file in Directory.GetFiles(Path.Combine(SteamInstallationPath, "steamapps"), "appmanifest_*.acf"))
            {
                int SteamGameId = Utils.StripAcfFilename(Path.GetFileName(file));
                SteamAppIdList.Add(SteamGameId);
            }

            return SteamAppIdList.ToArray();
        }
    }
}