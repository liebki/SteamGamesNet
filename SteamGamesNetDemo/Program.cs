using SteamGamesNet;
using SteamGamesNet.Models;

namespace SteamGamesNetDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
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

            int[] SteamIdList = SgC.GetAllSteamGameIds();
            if (SteamIdList.Length > 0)
            {
                SteamIdList.ToList().ForEach(SteamGameId => Console.WriteLine(SteamGameId));
            }
            else
            {
                Console.WriteLine("No games found on this device");
            }
        }
    }
}