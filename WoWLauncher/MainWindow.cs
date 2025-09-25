using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WoWRetroLauncher
{
    public partial class MainWindow : Form
    {
        private SoundPlayer soundPlayer;
        public string Locale;

        public MainWindow()
        {
            InitializeComponent();
            this.Load += MainWindow_Load;
        }

        private async void MainWindow_Load(object sender, EventArgs e)
        {
            await InitWebView();
        }

        private async Task InitWebView()
        {
            try
            {
                var tempFolder = Path.Combine(Path.GetTempPath(), "WebView2TempProfileWoWRetroLauncher");
                var env = await CoreWebView2Environment.CreateAsync(userDataFolder: tempFolder);
                await webView21.EnsureCoreWebView2Async(env);

                _ = Task.Run(() =>
                {
                    webView21.Invoke(new Action(() =>
                    {
                        var webPageToDisplay = Constants.WebFrameUriToLoad ?? string.Empty;
                        if (!string.IsNullOrEmpty(webPageToDisplay) && Helper.ConnectionAlive(webPageToDisplay))
                            webView21.Source = new Uri(webPageToDisplay);
                        else
                        {
                            webView21.Visible = false;
                            webView21.Enabled = false;
                        }
                    }));
                });
            }
            catch
            {
                webView21.Visible = false;
                webView21.Enabled = false;
            }
        }

        private void OnLoad(object sender, EventArgs e)
        {
            try
            {
                Locale = Helper.LoadLocale();
                if (Locale == "frFR")
                {
                    this.buttonPlay.Name = "Jouer";
                    this.buttonPlay.Type = LauncherButton.ButtonType.PlayFr;
                }

                var (versionDetails, realmDetails) = Helper.GetCurrentWoWDetails(Locale);
                if (!string.IsNullOrEmpty(versionDetails) && string.IsNullOrEmpty(realmDetails))
                {
                    this.gameDetailsShort.Text = @"World of Warcraft " + versionDetails;
                    this.Text = @"World of Warcraft " + versionDetails;
                }
                else if (string.IsNullOrEmpty(versionDetails) && !string.IsNullOrEmpty(realmDetails))
                {
                    this.gameDetailsLarge.Text = @"World of Warcraft" + Environment.NewLine + realmDetails;
                    this.Text = @"World of Warcraft Launcher";
                }
                else if(string.IsNullOrEmpty(versionDetails) && string.IsNullOrEmpty(realmDetails))
                {
                    this.gameDetailsShort.Text = @"World of Warcraft Launcher";
                    this.Text = @"World of Warcraft Launcher";
                }
                else
                {
                    this.gameDetailsLarge.Text = @"World of Warcraft " + versionDetails + Environment.NewLine + realmDetails;
                    this.Text = @"World of Warcraft " + versionDetails;
                }

                new TextureManager();
                soundPlayer = new SoundPlayer(Properties.Resources.play);
                TextureManager.GetInstance().SetSkin();
                ReloadTextures();
            }
            catch
            {
                // Do nothing
            }
        }

        private void Click_play(object sender, EventArgs e)
        {
            try
            {
                
                var currentDir = AppDomain.CurrentDomain.BaseDirectory;
                string[] candidates = { "Wow-64.exe", "Wow.exe" };
                soundPlayer.Play();

                foreach (var exeName in candidates)
                {
                    var exePath = Path.Combine(currentDir, exeName);
                    if (!File.Exists(exePath)) continue;
                    Process.Start(exePath);
                    this.WindowState = FormWindowState.Minimized;
                    buttonPlay.Enabled = false;
                    Click_DelayQuitApplication();
                    break;
                }
            }
            catch
            {
                // Do nothing
            }
        }

        private static async void Click_DelayQuitApplication()
        {
            await Task.Delay(4000);
            Application.Exit();
        }

        private void ReloadTextures()
        {
            buttonPlay.OnRelease(null, null);
            if (Helper.DisableButtons())
            {
                buttonPlay.BackgroundImage = TextureManager.GetInstance().GetPlayButtonTexture(3);
                buttonPlay.Enabled = false;
            }
            else if (!buttonPlay.Enabled)
            {
                if (Locale == "frFR")
                    buttonPlay.BackgroundImage = TextureManager.GetInstance().GetPlayFrButtonTexture(3);
                else
                    buttonPlay.BackgroundImage = TextureManager.GetInstance().GetPlayButtonTexture(3);
            }
            Color.FromArgb(50, 30, 15);
            BackgroundImage = TextureManager.GetInstance().GetBackground(0);
            Color.FromArgb(238, 190, 83);
        }

        private class MyRenderer : ToolStripProfessionalRenderer
        {
            public MyRenderer() : base(new MyColors()) { }
            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = Color.White;
                base.OnRenderArrow(e);
            }
        }

        private class MyColors : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(112, 112, 122);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(112, 112, 122);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(112, 112, 122);
            public override Color MenuItemPressedGradientBegin => Color.FromArgb(112, 112, 122);
            public override Color MenuItemPressedGradientMiddle => Color.FromArgb(112, 112, 122);
            public override Color MenuItemPressedGradientEnd => Color.FromArgb(112, 112, 122);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuBorder => Color.FromArgb(52, 52, 52);
            public override Color ToolStripDropDownBackground => Color.FromArgb(14, 20, 31);
            public override Color ImageMarginGradientBegin => Color.FromArgb(14, 20, 31);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(14, 20, 31);
            public override Color ImageMarginGradientEnd => Color.FromArgb(14, 20, 31);
        }
    }
}
