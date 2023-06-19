using SteamGamesNet;
using SteamGamesNet.Models;

namespace SteamGamesNetDemo
{
    public class Program
    {
        private static async Task Main(string[] args)
        {
            SteamGamesClient SteamClient = new();

            #region Get the content of the steam.signatures file as List<SteamSignatureValue> containing HashAlgorithm, HashValue, FilePath, CrcValue and DIGEST

            List<SteamSignatureValue> signatureValues = await SteamClient.SteamFilesWithSignatures();
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

            foreach (int dapp in SteamClient.GetActiveDownloadedGames())
            {
                Console.WriteLine(dapp);
            }

            #endregion Get all id's of games that are currently downloading or updating


            #region Get all games as RawSteamGame's that are currently downloading or updating

            List<RawSteamGame> ActiveDownloadingSteamappsWithInfo = await SteamClient.GetActiveDownloadedGamesWithInfoAsync();
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
                Console.WriteLine("Example output:");
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