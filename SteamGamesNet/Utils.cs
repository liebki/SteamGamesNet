using System;
using System.Linq;
using Microsoft.Win32;
using System.Runtime.InteropServices;

namespace SteamGamesNet
{
    internal static class Utils
    {
        private const string SteamRegistryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam";

        internal static void OsWinCheck()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                PlatformNotSupportedException WinOnly = new($"The platform {RuntimeInformation.OSArchitecture} is not supported, WIN only because of the need to access the registry!");
                throw WinOnly;
            }
        }

        internal static int StripAcfFilename(string fileinput)
        {
            string SteamId = fileinput;
            SteamId = SteamId.Replace("appmanifest_", string.Empty);
            SteamId = SteamId.Replace(".acf", string.Empty);
            return int.Parse(SteamId);
        }

        internal static bool IsSteamInRegistry()
        {
            bool InstallationGefunden = true;
            string SteamInstallationsPfad = (string)Registry.GetValue(SteamRegistryPath, "InstallPath", null);

            if (string.IsNullOrEmpty(SteamInstallationsPfad))
            {
                InstallationGefunden = false;
            }
            return InstallationGefunden;
        }
        internal static string GetSteamRegistryInstallPath()
        {
            return (string)Registry.GetValue(SteamRegistryPath, "InstallPath", null);
        }

    }
}
