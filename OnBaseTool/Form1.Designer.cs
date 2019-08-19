using System.Windows.Forms;

namespace OnBaseTool
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.chkCloseAfter = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.prgWait = new System.Windows.Forms.ProgressBar();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-9, 220);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(342, 58);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(30, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "Install OnBase";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(123, 16);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "Repair OnBase Issues";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(216, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 46);
            this.button3.TabIndex = 3;
            this.button3.Text = "Exit";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(18, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 32);
            this.button4.TabIndex = 4;
            this.button4.Text = "Outlook Addin";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(111, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 32);
            this.button5.TabIndex = 5;
            this.button5.Text = "Excel Addin";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(204, 19);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 32);
            this.button6.TabIndex = 6;
            this.button6.Text = "Word Addin";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // chkCloseAfter
            // 
            this.chkCloseAfter.AutoSize = true;
            this.chkCloseAfter.Checked = true;
            this.chkCloseAfter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCloseAfter.ForeColor = System.Drawing.Color.White;
            this.chkCloseAfter.Location = new System.Drawing.Point(78, 228);
            this.chkCloseAfter.Name = "chkCloseAfter";
            this.chkCloseAfter.Size = new System.Drawing.Size(166, 17);
            this.chkCloseAfter.TabIndex = 7;
            this.chkCloseAfter.Text = "Close this when install is done";
            this.chkCloseAfter.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblWait);
            this.groupBox1.Controls.Add(this.prgWait);
            this.groupBox1.Controls.Add(this.button10);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.chkRepair);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 118);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Office Add-ins";
            // 
            // lblWait
            // 
            this.lblWait.AutoSize = true;
            this.lblWait.Font = new System.Drawing.Font("HelveticaNeueLT Pro 57 Cn", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.White;
            this.lblWait.Location = new System.Drawing.Point(69, 3);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(169, 34);
            this.lblWait.TabIndex = 10;
            this.lblWait.Text = "Please Wait...";
            this.lblWait.Visible = false;
            this.lblWait.Click += new System.EventHandler(this.lblWait_Click);
            // 
            // prgWait
            // 
            this.prgWait.Location = new System.Drawing.Point(68, 33);
            this.prgWait.Name = "prgWait";
            this.prgWait.Size = new System.Drawing.Size(170, 23);
            this.prgWait.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgWait.TabIndex = 11;
            this.prgWait.Visible = false;
            // 
            // button10
            // 
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(204, 57);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(87, 23);
            this.button10.TabIndex = 10;
            this.button10.Text = "Uninstall";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(111, 57);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 23);
            this.button9.TabIndex = 9;
            this.button9.Text = "Uninstall";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Location = new System.Drawing.Point(18, 57);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 23);
            this.button8.TabIndex = 8;
            this.button8.Text = "Uninstall";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Location = new System.Drawing.Point(75, 89);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(157, 17);
            this.chkRepair.TabIndex = 7;
            this.chkRepair.Text = "Repair the Add-in if installed";
            this.chkRepair.UseVisualStyleBackColor = true;
            this.chkRepair.CheckedChanged += new System.EventHandler(this.chkRepair_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(18, 67);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 23);
            this.button7.TabIndex = 9;
            this.button7.Text = "Uninstall";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(111, 67);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(121, 23);
            this.button11.TabIndex = 10;
            this.button11.Text = "Addin Runtime Install";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(238, 68);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(75, 23);
            this.button12.TabIndex = 11;
            this.button12.Text = "Virtual Print";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(333, 278);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkCloseAfter);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button7);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "OnBase Install Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox chkCloseAfter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private Label lblWait;
        private ProgressBar prgWait;
        private Button button11;
        private Button button12;
    }
}

