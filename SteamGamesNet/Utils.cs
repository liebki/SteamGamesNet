using Microsoft.Win32;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;

namespace SteamGamesNet
{
    internal static class Utils
    {
        private const string SteamRegistryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam";

        internal static void CheckOS()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new PlatformNotSupportedException("This function is not supported on Linux.");
            }
        }

        internal static int StripAcfFilename(string fileinput)
        {
            try
            {
                string fileName = Path.GetFileNameWithoutExtension(fileinput);
                string steamId = fileName.Replace("appmanifest_", string.Empty);

                return int.Parse(steamId);
            }
            catch (FormatException ex)
            {
                throw new FormatException("Invalid file path specified. Unable to extract Steam ID.", ex);
            }
        }

        internal static bool IsSteamInstalled()
        {
            try
            {
                string steamInstallationPath = GetSteamRegistryInstallPath();
                return !string.IsNullOrEmpty(steamInstallationPath);
            }
            catch (SecurityException ex)
            {
                throw new SecurityException("Access to the registry key is denied. Please run this application with elevated privileges.", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while accessing the registry key. Please make sure that Steam is installed.", ex);
            }
        }

        internal static string GetSteamRegistryInstallPath()
        {
            return (string)Registry.GetValue(SteamRegistryPath, "InstallPath", null);
        }

    }
}
