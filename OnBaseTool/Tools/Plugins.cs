using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnBaseTool.Enums;

namespace OnBaseTool.Tools
{
    public class Plugins
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        public void OutlookAddin()
        {
            LoadAppManifest(AddinType.Outlook16);
            WaitForUI();
            SendConfirmationKeys();
            WaitForCompletion();
        }



        private void LoadAppManifest(AddinType type)
        {
            string addin = "";
            switch (type)
            {
                case AddinType.Excel16:
                    addin = "https://dm-clickonce.prod.cu.edu/Excel2016/ExcelAddin2016DMOPRD.vsto";
                    break;
                case AddinType.Outlook16:
                    addin = "https://dm-clickonce.prod.cu.edu/Outlook2016/OutlookIntegration2016DMOPRD.vsto";
                    break;
                case AddinType.Word16:
                    addin = "https://dm-clickonce.prod.cu.edu/Word2016/WordAddin2016DMOPRD.vsto";
                    break;
            }

            if (!String.IsNullOrEmpty(addin))
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.FileName = @"C:\Program Files\Internet Explorer\iexplore.exe";
                // Hidden seems to be irrelevant, not really worried about it right now
                proc.Arguments = addin;
                proc.CreateNoWindow = true;
                proc.WindowStyle = ProcessWindowStyle.Hidden;
                Process.Start(proc);
            }
        }

        private void WaitForUI()
        {
            while (true)
            {
                try
                {
                    Debug.WriteLine(Process.GetProcessesByName("VSTOInstaller")[1].MainWindowTitle);
                    if (Process.GetProcessesByName("VSTOInstaller")[0].MainWindowTitle ==
                        "Microsoft Office Customization Installer")
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
                Debug.WriteLine(Process.GetProcessesByName("dfsvc")[0].MainWindowTitle);
                try
                {
                    if (Process.GetProcessesByName("dfsvc")[0].MainWindowTitle ==
                        "Login")
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
