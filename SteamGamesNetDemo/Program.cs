using SteamGamesNet;
using SteamGamesNet.Models;

namespace SteamGamesNetDemo
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            SteamGamesClient SteamClient = new();

            #region Get all steam app id's and names 
            
            AppListContainer appListContainer = await SteamClient.GetAppListAsync();
            
            #endregion Get all steam app id's and names 
            
            
            #region Get the content of the steam.signatures file as List<SteamSignatureValue> containing HashAlgorithm, HashValue, FilePath, CrcValue and DIGEST
            
            IEnumerable<SteamSignatureValue> signatureValues = await SteamClient.SteamFilesWithSignaturesAsync();
            foreach (SteamSignatureValue signatureItem in signatureValues)
            {
                if (signatureItem.IsDigestValue)
                {
                    Console.WriteLine(signatureItem.HashValue);
                }
                else
                {
                    Console.WriteLine(signatureItem.ToString());
                }
            }
            
            #endregion Get the content of the steam.signatures file as List<SteamSignatureValue> containing HashAlgorithm, HashValue, FilePath, CrcValue and DIGEST
            
            
            #region Get all id's of games that are currently downloading or updating
            
            foreach (int dapp in SteamClient.GetAllDownloadingGames())
            {
                Console.WriteLine(dapp);
            }
            
            #endregion Get all id's of games that are currently downloading or updating


            #region Get all games as RawSteamGame's that are currently downloading or updating

            IEnumerable<RawSteamGame> ActiveDownloadingSteamappsWithInfo = await SteamClient.GetAllDownloadingGamesWithDataAsync();
            foreach (RawSteamGame game in ActiveDownloadingSteamappsWithInfo)
            {
                Console.WriteLine(game.Data.ToString());
            }

            #endregion Get all games as RawSteamGame's that are currently downloading or updating


            #region Query data by using a steamappid, get a RawSteamGame as result (if existing)
            
            int ExampleSteamAppId = 787790;
            RawSteamGame ExampleApp = await SteamClient.GetAppDataAsync(ExampleSteamAppId);
            
            if (ExampleApp != null)
            {
                Console.WriteLine("Output:");
                Console.WriteLine(ExampleApp.Data.ToString());
            }
            else
            {
                Console.WriteLine("This app obviously doesn't exist, the id is wrong or something else is not working correctly!");
            }
            
            #endregion Query data by using a steamappid, get a RawSteamGame as result (if existing)


            #region Get all appid's as array, that are currently on this device

            int[] SteamIdList = SteamClient.GetAllSteamGameIds();
            if (SteamIdList.Length > 0)
            {
                SteamIdList.ToList().ForEach(SteamGameId => Console.WriteLine(SteamGameId));
            }
            else
            {
                Console.WriteLine("No games found on this device");
            }

            #endregion Get all appid's as array, that are currently on this device
        }
    }
}