using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickOnce.UnitySimpleUninstall();
            FolderHelper foldz = new FolderHelper();
            foldz.Remove2_0Folder();
            ClickOnce.UnityInstall();
        }
    }
}
