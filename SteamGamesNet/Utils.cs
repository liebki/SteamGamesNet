﻿using System;
using System.Linq;
using Microsoft.Win32;
using System.Security;
using System.Runtime.InteropServices;

namespace SteamGamesNet
{
    internal static class Utils
    {
        private const string SteamRegistryPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Valve\Steam";

        internal static void CheckIfWindows()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                throw new PlatformNotSupportedException("This function is only supported on Windows.");
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
                throw new ArgumentException("Invalid file path specified. Unable to extract Steam ID.", ex);
            }
        }

        internal static bool IsSteamInstalled()
        {
            try
            {
                string steamInstallationPath = (string)Registry.GetValue(SteamRegistryPath, "InstallPath", null);
                return !string.IsNullOrEmpty(steamInstallationPath);
            }
            catch (SecurityException ex)
            {
                throw new Exception("Access to the registry key is denied. Please run this application with elevated privileges.", ex);
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
