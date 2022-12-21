using SteamGamesNet;

namespace SteamGamesNetDemo
{
    public class Program
    {
        private static void Main(string[] args)
        {
            //Epic Roller Coasters (VR)
            int ExampleSteamAppId = 787790;

            //Wrong (not existing) id
            int ExampleCorruptSteamAppId = 899998;

            RawSteamGame ExampleApp = SteamGamesClient.GetAppData(ExampleSteamAppId);
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
        }
    }
}