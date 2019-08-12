using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OnBaseTool.Tools
{
    public static class ClickOnce
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        private static bool noUninstaller = false;
        
        public static void UnitySimpleUninstall()
        {
            KillIfRunning();
            StartUninstall();
            WaitForUI();
            SendConfirmationKeys();
        }

        public static void UnityInstall()
        {
            ClickOnceInstaller clicker = new ClickOnceInstaller();
            clicker.Install();
        }

        public static void OutlookAddinInstall()
        {
            Plugins plug = new Plugins();
            plug.OutlookAddin();
        }


        #region Function Codes
        private static void WaitForUI()
        {
            if (!noUninstaller)
            {
                while (true)
                {
                    try
                    {
                        if (Process.GetProcessesByName("dfsvc")[0].MainWindowTitle ==
                            "Hyland Unity Client [DMOPRD] Maintenance")
                        {
                            break;
                        }
                    }
                    catch
                    {
                        // Junk who cares
                    }
                }
            }
        }
        private static void KillIfRunning()
        {
            ProcessHelper unitCheck = new ProcessHelper();
            if (unitCheck.OnBaseRunning())
            {
                unitCheck.KillOnBase();
            }

            var finder = Process.GetProcessesByName("dfsvc");
            if (finder.Length != 0)
            {
                for (int x = 0; x < finder.Length; x++)
                {
                    finder[x].Kill();
                }
            }
            ProcessHelper procHelp = new ProcessHelper();
            if (procHelp.OnBaseRunning())
            {
                procHelp.KillOnBase();
            }
        }
        private static void StartUninstall()
        {
            try
            {
                string tmp = UninstallString().Replace("rundll32.exe ", "");
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.Arguments = tmp;
                proc.FileName = "rundll32.exe";
                Process.Start(proc);
            }
            catch
            {
                // Uninstall not found
                noUninstaller = true;
            }
        }
        private static void SendConfirmationKeys()
        {
            const int WM_SYSKEYDOWN = 0x0104;
            const int VK_RETURN = 0x0D;
            const int VK_TAB = 0x09;

            var p = Process.GetProcessesByName("dfsvc");
            for(var x=0;x<p.Length;x++)
            {
                IntPtr WindowToFind = p[x].MainWindowHandle;
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_TAB, 0);
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_TAB, 0);
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_RETURN, 0);
            }

        }
        private static string UninstallString()
        {
            var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (var item in key.GetSubKeyNames())
            {
                RegistryKey entryInfo = key.OpenSubKey(item);
                if (entryInfo != null)
                {
                    var values = entryInfo.GetValueNames();
                    for (int x = 0; x < values.Length; x++)
                    {
                        string uninstall = entryInfo.GetValue("UninstallString").ToString();
                        if (uninstall.Contains("UnityClient"))
                        {
                            return uninstall;
                        }
                    }
                }
            }

            return null;
        }
        #endregion
    }
}
