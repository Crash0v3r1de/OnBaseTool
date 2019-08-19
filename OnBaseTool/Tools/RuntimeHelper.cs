using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace OnBaseTool.Tools
{
    public class RuntimeHelper
    {
        private string tmpRuntimeLoc = Path.GetTempPath()+"onb_tmp.zip";
        private string tmpVPDLoc = Path.GetTempPath() + "VPD_tmp.zip";
        private string tmpRuntimeDir = Path.GetTempPath()+"onbase_tool";
        private string tmpVPDDir = Path.GetTempPath() + "onbase_vpd";
        private const string MsiName = "Hyland Office Integration Dependencies.msi";
        private const string VPDMsi = "Hyland OnBase Virtual Print Driver x64.msi";
        private const string Runtime = "https://dm-dev.dev.cu.edu/Clients/OnBase_ClickOnce_Office_Dependencies.zip";
        private const string VPD = "https://dm-dev.dev.cu.edu/Clients/OnBase_VPD_x64.zip";

        public void InstallAddinRuntime()
        {
            if (MissingRuntime())
            {
                DownloadZip(Runtime, tmpRuntimeLoc);
                Unzip(tmpRuntimeLoc, tmpRuntimeDir);
                InstallRuntimes($"{tmpRuntimeDir}\\{MsiName}");
            }
        }

        public void InstallVirtuePrintD()
        {
            if (MissingVPD())
            {
                DownloadZip(VPD, tmpVPDLoc);
                Unzip(tmpVPDLoc, tmpVPDDir);
                InstallRuntimes($"{tmpVPDDir}\\{VPDMsi}");
            }
        }

        private void PrepPaths()
        {
            if (File.Exists(tmpRuntimeLoc))
            {
                File.Delete(tmpRuntimeLoc);
            }

            if (Directory.Exists(tmpRuntimeDir))
            {
                Directory.Delete(tmpRuntimeDir,true);
            }
            if (File.Exists(tmpVPDLoc))
            {
                File.Delete(tmpVPDLoc);
            }

            if (Directory.Exists(tmpVPDDir))
            {
                Directory.Delete(tmpVPDDir, true);
            }
        }

        private void PrepUnzip(string path)
        {
            Directory.CreateDirectory(path);
        }

        private void DownloadZip(string url,string tmpName)
        {
            PrepPaths();
            new WebClient().DownloadFile(url, tmpName);
        }

        private void Unzip(string url,string path)
        {
            PrepUnzip(path);
            ZipFile.ExtractToDirectory(url, path);
        }

        private void InstallRuntimes(string fullPath)
        {
            ProcessStartInfo msi = new ProcessStartInfo();
            msi.FileName = "msiexec";
            msi.Arguments = $"/i \"{fullPath}\" /quiet";
            msi.Verb = "runas"; // request admin
            try
            {
                var code = Process.Start(msi);
            }
            catch
            {
                MessageBox.Show("Install canceled by user!\r\nPlease contact your DDS tech for install.");
                // Probly needs admin or they got confused
            }
        }


        private bool MissingVPD()
        {
            bool found = false;
            var key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            foreach (var item in key.GetSubKeyNames())
            {
                RegistryKey entryInfo = key.OpenSubKey(item);
                if (entryInfo != null)
                {
                    var values = entryInfo.GetValueNames();
                    for (int x = 0; x < values.Length; x++)
                    {
                        string uninstall = entryInfo.GetValue("DisplayName").ToString();
                        if (uninstall.Contains("Hyland OnBase Virtual Print Driver"))
                        {
                            found = true;
                        }
                    }
                }
            }
            return found;
        }

        private bool MissingRuntime()
        {
            // I should change this to the regkey location eventually
            return File.Exists("C:\\Program Files (x86)\\Hyland\\Office Integration\\Dependencies\\dsoframer.ocx");
        }
    }
}
