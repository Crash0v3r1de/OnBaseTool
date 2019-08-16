using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using OnBaseTool.Enums;
using OnBaseTool.Properties;
using Settings = OnBaseTool.StaticClasses.Settings;

namespace OnBaseTool.Tools
{
    public class Plugins
    {
        public void OutlookAddin(bool reinstall = false)
        {
            if (!Settings.UninstallAddin)
            {
                if (reinstall) Uninstall(AddinType.Outlook16);
                if (CertMissing()) InstallCert();
                Install(AddinType.Outlook16);
            }
            else
            {
                Uninstall(AddinType.Outlook16);
                Settings.UninstallAddin = false;
            }
        }

        public void ExcelAddin(bool reinstall = false)
        {
            if (!Settings.UninstallAddin)
            {
                if (reinstall) Uninstall(AddinType.Excel16);
                if (CertMissing()) InstallCert();
                Install(AddinType.Excel16);
            }
            else
            {
                Uninstall(AddinType.Excel16);
                Settings.UninstallAddin = false;
            }
        }

        public void WordAddin(bool reinstall = false)
        {
            if (!Settings.UninstallAddin)
            {
                if (reinstall) Uninstall(AddinType.Word16);
                if (CertMissing()) InstallCert();
                Install(AddinType.Word16);
            }
            else
            {
                Uninstall(AddinType.Word16);
                Settings.UninstallAddin = false;
            }
        }

        private int Uninstall(AddinType type)
        {
            switch (type)
            {
                // I can always have the addin names as a static class down the road if i don't want them direct like this
                case AddinType.Excel16:
                    return VSTOUninstall(UninstallString("Hyland Excel"));
                case AddinType.Outlook16:
                    return VSTOUninstall(UninstallString("OutlookIntegration"));
                case AddinType.Word16:
                    return VSTOUninstall(UninstallString("ExcelAddin"));
            }

            return 991;
        }

        private int Install(AddinType type)
        {
            switch (type)
            {
                case AddinType.Excel16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Excel2016/ExcelAddin2016DMOPRD.vsto");
                case AddinType.Outlook16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Outlook2016/OutlookIntegration2016DMOPRD.vsto");
                case AddinType.Word16:
                    return VSTOInstall("https://dm-clickonce.prod.cu.edu/Word2016/WordAddin2016DMOPRD.vsto");
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

        private int VSTOUninstall(string strng)
        {
            ProcessStartInfo installer = new ProcessStartInfo();
            installer.Arguments = $"/u \"{strng}\" /s";
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

        private string UninstallString(string addinName)
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
                        if (uninstall.Contains(addinName))
                        {
                            return RegexPath(uninstall);
                        }
                    }
                }
            }

            return null;
        }

        private string RegexPath(string uninstallString)
        {
            return Regex.Match(uninstallString, "\\/Uninstall (.*)").Groups[1].Value;
        }

    }
}
