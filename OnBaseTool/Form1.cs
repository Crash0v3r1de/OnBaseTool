using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
            UpdateStatus(WorkType.Uninstalling);
            UpdateStatus(WorkType.Installing);
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() =>
            {
                ClickOnce.UnitySimpleUninstall();
                ClickOnce.UnityInstall();
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
            ClickOnce.UnitySimpleUninstall();
            FolderHelper foldz = new FolderHelper();
            foldz.Remove2_0Folder();
            ClickOnce.UnityInstall();
            if (chkCloseAfter.Checked)
            {
                Environment.Exit(0);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chkCloseAfter.ForeColor = Color.FromArgb(207, 184, 124, 1);
            lblWait.ForeColor = Color.FromArgb(207, 184, 124, 1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Installing);
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.OutlookAddin(); });
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Installing);
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.ExcelAddin(); });
        }

        private void button6_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Installing);
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
            UpdateStatus(WorkType.Uninstalling);
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.UnitySimpleUninstall(); });
        }

        private void button8_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Uninstalling);
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.OutlookAddin(); });
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Uninstalling);
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.ExcelAddin(); });
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateStatus(WorkType.Uninstalling);
            Settings.UninstallAddin = true;
            Task.Run(() =>
            {
                WaitForCompletetion();
            });
            Task.Run(() => { ClickOnce.WordAddin(); });
        }

        private void WaitForCompletetion()
        {
            lblWait.Visible = true;
            while (!WorkStatus.AddinDone || !WorkStatus.RepairDone || !WorkStatus.UnityDone)
            {
                Thread.Sleep(300);
            }

            lblWait.Visible = false;
            if (chkCloseAfter.Checked)
            {
                Environment.Exit(0);
            }
        }

        private void lblWait_Click(object sender, EventArgs e)
        {

        }
    }
}
