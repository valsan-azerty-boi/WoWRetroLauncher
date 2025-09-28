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
            try
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
            }
            catch
            {
                // Do nothing
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += Application_ThreadException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

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

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            HandleException(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            HandleException(e.ExceptionObject as Exception);
        }

        private static void HandleException(Exception ex)
        {
#if DEBUG
            MessageBox.Show(ex.ToString(), @"Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
#else
            // Do Nothing, not recommended, it hides exception in release
#endif
        }
    }
}
