using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OnBaseTool.Enums;
using OnBaseTool.Properties;

namespace OnBaseTool.Tools
{
    public class Plugins
    {
        [DllImport("user32.dll")]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("User32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern long GetWindowText(IntPtr hwnd, StringBuilder lpString, long cch);
        [DllImport("User32.dll")]
        static extern IntPtr GetParent(IntPtr hwnd);

        private const int BUTTON_ID = 00081152;
        private const int WM_COMMAND = 0x0111;
        private const int BN_CLICKED = 0;
        private const int WIN_HANDLE = 00081152;

        public void OutlookAddin()
        {
            if(CertMissing()) InstallCert();
            Install(AddinType.Outlook16);
        }

        public void ExcelAddin()
        {
            if (CertMissing()) InstallCert();
            Install(AddinType.Excel16);
        }

        public void WordAddin()
        {
            if (CertMissing()) InstallCert();
            Install(AddinType.Word16);
        }

        private int Install(AddinType type)
        {
            switch (type)
            {
                case AddinType.Excel16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Excel2016/ExcelAddin2016DMOPRD.vsto");
                    break;
                case AddinType.Outlook16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Outlook2016/OutlookIntegration2016DMOPRD.vsto");
                    break;
                case AddinType.Word16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Word2016/WordAddin2016DMOPRD.vsto");
                    break;
            }

            return 991;
        }

        private bool CertMissing()
        {
            bool missing = true;
            X509Store certs = new X509Store(StoreName.TrustedPublisher,StoreLocation.CurrentUser);
            certs.Open(OpenFlags.ReadOnly);
            for (int i = 0; i < certs.Certificates.Count; i++)
            {
                if (certs.Certificates[i].GetNameInfo(X509NameType.SimpleName,false) == "University of Colorado. at Boulder - Custom Requests")
                {
                    missing = false;
                }
            }
            certs.Close();
            certs = null;
            return missing;
        }

        private void InstallCert()
        {
            X509Certificate2 cert = new X509Certificate2();
            cert.Import(Resources.UCB);
            X509Store certs = new X509Store(StoreName.TrustedPublisher, StoreLocation.CurrentUser);
            certs.Open(OpenFlags.ReadWrite);
            certs.Add(cert);
            certs.Close();
            cert = null;
            certs = null;
        }

        private int VSTOInstall(string url)
        {
            ProcessStartInfo installer = new ProcessStartInfo();
            installer.Arguments = $"/i \"{url}\" /s";
            // I should make this dynamic for future versions to iterate and find where VSTO is installed.
            installer.FileName = "c:\\Program Files\\Common Files\\Microsoft Shared\\VSTO\\10.0\\VSTOInstaller.exe";
            var status = Process.Start(installer);
            while (!status.HasExited)
            {
                Thread.Sleep(300); // Wait
            }
            // Exit code 0 is success
            return status.ExitCode;
        }

    }
}
