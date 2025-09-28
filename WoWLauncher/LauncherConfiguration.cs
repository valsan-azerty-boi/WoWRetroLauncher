namespace WoWRetroLauncher
{
    public static class LauncherConfiguration
    {
        /// <summary>
        /// Web frame URI configuration
        /// </summary>
        public const string WebFrameUriToLoadDefault = "https://worldofwarcraft.blizzard.com/en-us/news";
        public const string WebFrameUriToLoadFr = "https://worldofwarcraft.blizzard.com/fr-fr/news";
        public const string WebFrameUriToLoadGb = "https://worldofwarcraft.blizzard.com/en-gb/news";
        public const string WebFrameUriToLoadDe = "https://worldofwarcraft.blizzard.com/de-de/news";
        public const string WebFrameUriToLoadCn = "https://wow.blizzard.cn/news";
        public const string WebFrameUriToLoadEs = "https://worldofwarcraft.blizzard.com/es-es/news";
        public const string WebFrameUriToLoadMx = "https://worldofwarcraft.blizzard.com/es-mx/news";
        public const string WebFrameUriToLoadBr = "https://worldofwarcraft.blizzard.com/pt-br/news";
        public const string WebFrameUriToLoadPt = "https://worldofwarcraft.blizzard.com/en-gb/news";
        public const string WebFrameUriToLoadIt = "https://worldofwarcraft.blizzard.com/it-it/news";
        public const string WebFrameUriToLoadKo = "https://worldofwarcraft.blizzard.com/ko-kr/news";
        public const string WebFrameUriToLoadRu = "https://worldofwarcraft.blizzard.com/ru-ru/news";
        public const string WebFrameUriToLoadTw = "https://worldofwarcraft.blizzard.com/zh-tw/news";

        /// <summary>
        /// Game executable
        /// </summary>
        public static string[] ExeFileCandidates = { "Wow-64.exe", "Wow64.exe", "Wow.exe" };

        /// <summary>
        /// Temp folder name for your web frame
        /// </summary>
        public const string TempFolder = "WebView2TempProfileWoWRetroLauncher";
    }
}
