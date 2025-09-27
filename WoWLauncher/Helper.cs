using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using File = System.IO.File;

namespace WoWRetroLauncher
{
    public static class Helper
    {
        public static bool DisableButtons()
        {
            try
            {
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;

                foreach (var exeName in LauncherConfiguration.ExeFileCandidates)
                {
                    var exePath = Path.Combine(currentDir, exeName);
                    if (File.Exists(exePath))
                    {
                        return false;
                    }
                }
            }
            catch
            {
                return true;
            }

            return true;
        }

        public static bool ConnectionAlive(string genericWebUri)
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(genericWebUri);
                request.Method = "HEAD";
                request.UserAgent = "Mozilla/5.0";
                request.Timeout = 3000;

                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;
                }
            }
            catch
            {
                return false;
            }
        }

        public static string LoadLocale()
        {
            try
            {
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                var configPath = Path.Combine(currentDir, "WTF", "Config.wtf");

                if (File.Exists(configPath))
                {
                    foreach (var line in File.ReadLines(configPath))
                    {
                        if (line.StartsWith("SET locale", StringComparison.OrdinalIgnoreCase) || line.StartsWith("SET textLocale", StringComparison.OrdinalIgnoreCase))
                        {
                            if (line.Contains("SET locale \"enUS\"") || line.Contains("SET textLocale \"enUS\""))
                                return "enUS";
                            if (line.Contains("SET locale \"enGB\"") || line.Contains("SET textLocale \"enGB\""))
                                return "enGB";
                            if (line.Contains("SET locale \"frFR\"") || line.Contains("SET textLocale \"frFR\""))
                                return "frFR";
                            if (line.Contains("SET locale \"deDE\"") || line.Contains("SET textLocale \"deDE\""))
                                return "deDE";
                            if (line.Contains("SET locale \"itIT\"") || line.Contains("SET textLocale \"itIT\""))
                                return "itIT";
                            if (line.Contains("SET locale \"esES\"") || line.Contains("SET textLocale \"esES\""))
                                return "esES";
                            if (line.Contains("SET locale \"esMX\"") || line.Contains("SET textLocale \"esMX\""))
                                return "esMX";
                            if (line.Contains("SET locale \"ptBR\"") || line.Contains("SET textLocale \"ptBR\""))
                                return "ptBR";
                            if (line.Contains("SET locale \"ptPT\"") || line.Contains("SET textLocale \"ptPT\""))
                                return "ptPT";
                            if (line.Contains("SET locale \"koKR\"") || line.Contains("SET textLocale \"koKR\""))
                                return "koKR";
                            if (line.Contains("SET locale \"ruRU\"") || line.Contains("SET textLocale \"ruRU\""))
                                return "ruRU";
                            if (line.Contains("SET locale \"zhCN\"") || line.Contains("SET textLocale \"zhCN\"") || line.Contains("SET locale \"enCN\"") || line.Contains("SET textLocale \"enCN\""))
                                return "zhCN";
                            if (line.Contains("SET locale \"zhTW\"") || line.Contains("SET textLocale \"zhTW\"") || line.Contains("SET locale \"enTW\"") || line.Contains("SET textLocale \"enTW\""))
                                return "zhTW";
                        }
                    }
                }
            }
            catch
            {
                return "enUS";
            }

            return "enUS";
        }

        public static (string, string) GetCurrentWoWDetails(string locale = "enUS")
        {
            try
            {
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                var realmInfo = GetRealmlist(locale);

                foreach (var exeName in LauncherConfiguration.ExeFileCandidates)
                {
                    var exePath = Path.Combine(currentDir, exeName);
                    if (File.Exists(exePath))
                    {
                        var info = FileVersionInfo.GetVersionInfo(exePath);
                        return ($"v{info.FileVersion}".Replace(", ", "."), realmInfo);
                    }
                }
            }
            catch
            {
                return (string.Empty, string.Empty);
            }

            return (string.Empty, string.Empty);
        }

        private static string GetRealmlist(string locale = "enUS")
        {
            string[] localeFolders = { locale, "enUS", "enGB" };

            var dataRootRealmlist = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "realmlist.wtf");
            if (File.Exists(dataRootRealmlist))
            {
                var result = ParseRealmlist(dataRootRealmlist);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            foreach (var loc in localeFolders)
            {
                var dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", loc);
                var realmlistFile = Path.Combine(dataPath, "realmlist.wtf");
                if (File.Exists(realmlistFile))
                {
                    var result = ParseRealmlist(realmlistFile);
                    if (!string.IsNullOrEmpty(result))
                        return result;
                }
            }

            var rootRealmlist = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "realmlist.wtf");
            if (File.Exists(rootRealmlist))
            {
                var result = ParseRealmlist(rootRealmlist);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            var wtfConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "WTF", "Config.wtf");
            if (File.Exists(wtfConfig))
            {
                var result = ParseConfigWtf(wtfConfig);
                if (!string.IsNullOrEmpty(result))
                    return result;
            }

            return string.Empty;
        }

        private static string ParseRealmlist(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("set realmlist", StringComparison.OrdinalIgnoreCase))
                {
                    var parts = trimmed.Split(new[] { ' ' }, 3, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length >= 3) return parts[2].Trim();
                }
            }

            return string.Empty;
        }

        private static string ParseConfigWtf(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                var trimmed = line.Trim();
                if (trimmed.StartsWith("SET realmList", StringComparison.OrdinalIgnoreCase))
                {
                    var match = Regex.Match(trimmed, "\"([^\"]+)\"");
                    if (match.Success) return match.Groups[1].Value.Trim();
                }
            }

            return string.Empty;
        }
    }
}
