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
using OnBaseTool.Tools;

namespace OnBaseTool
{
    public partial class Form1 : Form
    {
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
            ClickOnce.UnitySimpleUninstall();
            ClickOnce.UnityInstall();
            if (chkCloseAfter.Checked)
            {
                Environment.Exit(0);
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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ClickOnce.OutlookAddinInstall();
            if (chkCloseAfter.Checked)
            {
                Environment.Exit(0);
            }
        }
    }
}
