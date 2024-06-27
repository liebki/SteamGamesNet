using System.Runtime.InteropServices;
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

        public async Task<RawSteamGame> GetAppDataAsync(int steamappid)
        {
            return await SteamRequestManager.GetAppDataAsync(steamappid, Lang_, Useragent_);
        }

        public async Task<AppListContainer> GetAppListAsync()
        {
            return await SteamRequestManager.GetAppList();
        }

        public int[] GetAllDownloadingGames(string CustomPath = "")
        {
            Utils.CheckOS();
            string SteamInstallationPath = GetSteamFolderPath(CustomPath);

            SteamInstallationPath = Path.Combine(SteamInstallationPath, "steamapps", "downloading");
            return SteamRequestManager.GetActiveDownloadedGames(SteamInstallationPath);
        }

        public async Task<IEnumerable<RawSteamGame>> GetAllDownloadingGamesWithDataAsync(string CustomPath = "")
        {
            Utils.CheckOS();
            string SteamInstallationPath = GetSteamFolderPath(CustomPath);

            SteamInstallationPath = Path.Combine(SteamInstallationPath, "steamapps", "downloading");
            return await SteamRequestManager.GetActiveDownloadedGamesWithInfoAsync(SteamInstallationPath);
        }

        public async Task<IEnumerable<SteamSignatureValue>> SteamFilesWithSignaturesAsync(string CustomPath = "")
        {
            string SteamInstallationPath = GetSteamFolderPath(CustomPath);
            return await SteamRequestManager.SteamFilesWithSignatures(SteamInstallationPath);
        }

        private static string GetSteamFolderPath(string CustomPath)
        {
            string SteamInstallationPath = string.Empty;

            if (string.IsNullOrEmpty(CustomPath))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    if (Utils.IsSteamInstalled())
                    {
                        SteamInstallationPath = Utils.GetSteamRegistryInstallPath();
                    }
                }
                else
                {
                    SteamInstallationPath = $"/Users/{Environment.UserName}/Library/Application Support/Steam/";
                }
            }
            else
            {
                SteamInstallationPath = CustomPath;
            }

            return SteamInstallationPath;
        }

        public int[] GetAllSteamGameIds(string CustomPath = "")
        {
            Utils.CheckOS();
            List<int> SteamAppIdList = new();

            string SteamInstallationPath = GetSteamFolderPath(CustomPath);

            foreach (string file in Directory.GetFiles(Path.Combine(SteamInstallationPath, "steamapps"), "appmanifest_*.acf"))
            {
                int SteamGameId = Utils.StripAcfFilename(Path.GetFileName(file));
                SteamAppIdList.Add(SteamGameId);
            }

            return SteamAppIdList.ToArray();
        }
    }
}