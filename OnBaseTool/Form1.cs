using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OnBaseTool.Enums;
using OnBaseTool.IO;
using OnBaseTool.Properties;
using OnBaseTool.StaticClasses;
using OnBaseTool.Tools;
using Settings = OnBaseTool.StaticClasses.Settings;

namespace OnBaseTool
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern bool EnableWindow(IntPtr hwnd, bool bEnable);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForeGroundWindow();

        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);

        private int Angle;
        private Image Art; // you may need to resample larger images to a smaller image dynamically!
        private int AngleStep = 20;
        private System.Drawing.Drawing2D.GraphicsPath Vinyl = new System.Drawing.Drawing2D.GraphicsPath();






        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkStatus.UnityStarted();
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() =>
            {
                ClickOnce.UnitySimpleUninstall(true);
                ClickOnce.UnityInstall(); // Status completion happens in this function since threaded
            });
        }

        private void UpdateStatus(WorkType type)
        {
            switch (type)
            {
                case WorkType.Completed:
                    WorkStatus.UnityDone = true;
                    WorkStatus.AddinDone = true;
                    WorkStatus.RepairDone = true;
                    WorkStatus.UnityDone = true;
                    break;
                case WorkType.Installing:
                    WorkStatus.UnityDone = false;
                    WorkStatus.AddinDone = true;
                    WorkStatus.RepairDone = true;
                    WorkStatus.UnityDone = true;
                    break;
                case WorkType.RemovingFolders:
                    WorkStatus.UnityDone = true;
                    WorkStatus.AddinDone = true;
                    WorkStatus.RepairDone = false;
                    WorkStatus.UnityDone = true;
                    break;
                case WorkType.Uninstalling:
                    WorkStatus.UnityDone = true;
                    WorkStatus.AddinDone = true;
                    WorkStatus.RepairDone = true;
                    WorkStatus.UnityDone = false;
                    break;
                case WorkType.idle:
                    WorkStatus.UnityDone = true;
                    WorkStatus.AddinDone = true;
                    WorkStatus.RepairDone = true;
                    WorkStatus.UnityDone = true;
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WorkStatus.RepairStarted();
            Task.Run(() => { WaitForCompletetion();});
            Task.Run(() =>
            {
                ClickOnce.UnitySimpleUninstall(true);
                FolderHelper foldz = new FolderHelper();
                foldz.Remove2_0Folder();
                ClickOnce.UnityInstall();
            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkCloseAfter.ForeColor = Color.FromArgb(207, 184, 124, 1);
            lblWait.ForeColor = Color.FromArgb(207, 184, 124, 1);
            chkRepair.ForeColor = Color.FromArgb(207, 184, 124, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinInstalling();
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.OutlookAddin(); });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinInstalling();
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.ExcelAddin(); });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinInstalling();
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.WordAddin(); });
        }

        private void chkRepair_CheckedChanged(object sender, EventArgs e)
        {
            Settings.ReinstallAddins = chkRepair.Checked;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            WorkStatus.UnityUninstall();
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.UnitySimpleUninstall(); });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinUninstaling();
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.OutlookAddin(); });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinUninstaling();
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.ExcelAddin(); });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WorkStatus.AddinUninstaling();
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.WordAddin(); });
        }

        private void WaitForCompletetion()
        {
            Debug.WriteLine("Starting wait label...");
            ShowWait();
            int setOnce = 0;
            while (!WorkStatus.AllDone)
            {
                // This function is not a major thing at the moment
                // Just want to use WinAPI to bring out tool UI in focus when the ClickOnce UI comes up
                // It by default minimizes our UI
                try
                {
                    IntPtr active = GetForeGroundWindow();
                    if (active != Handle & setOnce == 0)
                    {
                        setOnce = 1;
                        Debug.WriteLine("Bringing forward once..");
                        SetFocus(Handle);
                    }
                }
                catch
                {
                }

                if (WorkStatus.AllDone) break;
                Thread.Sleep(600);
            }

            Debug.WriteLine("Apparently it's done...");
            HideWait();
            if (chkCloseAfter.Checked)
            {
                Debug.WriteLine("Done...");
                Environment.Exit(0);
            }else Debug.WriteLine("Wait thread is complete...");
        }

        private void ShowWait()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(ShowWait));
                return;
            }

            prgWait.Enabled = true;
            prgWait.Visible = true;
            prgWait.Step = 10;
            EnableWindow(Handle, false);
            lblWait.Visible = true;
        }

        private void HideWait()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(HideWait));
                return;
            }

            prgWait.Enabled = false;
            prgWait.Visible = false;
            EnableWindow(Handle, true);
            lblWait.Visible = false;
        }

        private void lblWait_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            RuntimeHelper runtime = new RuntimeHelper();
            runtime.InstallAddinRuntime();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            RuntimeHelper runtime = new RuntimeHelper();
            runtime.InstallVirtuePrintD();
        }
    }
}
