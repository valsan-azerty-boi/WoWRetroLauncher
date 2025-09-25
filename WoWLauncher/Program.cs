using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace WoWRetroLauncher
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!IsNet472Installed())
            {
                MessageBox.Show(
                    @".NET Framework 4.7.2 is required: https://dotnet.microsoft.com/download/dotnet-framework/net472",
                    @"Missing .NET Framework",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }

        private static bool IsNet472Installed()
        {
            using (var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                       .OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"))
            {
                if (key?.GetValue("Release") == null) return false;
                var release = (int)key.GetValue("Release");
                return release >= 461808;
            }
        }
    }
}
