using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OnBaseTool.Tools
{
    public class ClickOnceInstaller
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public bool Install()
        {
            LoadAppManifest();
            WaitForUI();
            SendConfirmationKeys();
            WaitForCompletion();

            return false;
        }

        private void LoadAppManifest()
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"C:\Program Files\Internet Explorer\iexplore.exe";
            proc.Arguments = "https://dm-clickonce.prod.cu.edu/UnityClient/UnityClientDMOPRD.application";
            proc.CreateNoWindow = true;
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(proc);
        }

        private void WaitForUI()
        {
            while (true)
            {
                try
                {
                    if (Process.GetProcessesByName("dfsvc")[0].MainWindowTitle ==
                        "Application Install - Security Warning")
                    {
                        break;
                    }
                }
                catch
                {
                    // Junk who cares
                }
                Thread.Sleep(300);
            }
        }

        private void SendConfirmationKeys()
        {
            const int WM_SYSKEYDOWN = 0x0104;
            const int VK_RETURN = 0x0D;
            const int VK_TAB = 0x09;

            var p = Process.GetProcessesByName("dfsvc");
            for (var x = 0; x < p.Length; x++)
            {
                IntPtr WindowToFind = p[x].MainWindowHandle;
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_TAB, 0);
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_TAB, 0);
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_TAB, 0);
                PostMessage(WindowToFind, WM_SYSKEYDOWN, VK_RETURN, 0);
            }
        }

        private void WaitForCompletion()
        {
            while (true)
            {
                try
                {
                    if (Process.GetProcessesByName("obunity")[0].MainWindowTitle ==
                        "Login" & Process.GetProcessesByName("obunity").Length != 0)
                    {
                        break;
                    }
                }
                catch
                {
                    // Junk who cares
                }
                Thread.Sleep(300);
            }
        }
    }
}
