namespace RFHNC
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.prüfeErgebnisseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.neuesUpdateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tb_mail_user = new System.Windows.Forms.TextBox();
            this.tb_mail_pass = new System.Windows.Forms.TextBox();
            this.tb_mail_to = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_sendemail = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 75);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(221, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Prüfe Noten";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RFH Noten";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prüfeErgebnisseToolStripMenuItem,
            this.toolStripSeparator1,
            this.neuesUpdateToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 54);
            // 
            // prüfeErgebnisseToolStripMenuItem
            // 
            this.prüfeErgebnisseToolStripMenuItem.Name = "prüfeErgebnisseToolStripMenuItem";
            this.prüfeErgebnisseToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.prüfeErgebnisseToolStripMenuItem.Text = "Prüfe Ergebnisse";
            this.prüfeErgebnisseToolStripMenuItem.Click += new System.EventHandler(this.prüfeErgebnisseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(160, 6);
            // 
            // neuesUpdateToolStripMenuItem
            // 
            this.neuesUpdateToolStripMenuItem.Name = "neuesUpdateToolStripMenuItem";
            this.neuesUpdateToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.neuesUpdateToolStripMenuItem.Text = "Prüfe auf Update";
            this.neuesUpdateToolStripMenuItem.Click += new System.EventHandler(this.neuesUpdateToolStripMenuItem_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(104, 12);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(125, 20);
            this.tb_username.TabIndex = 1;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(104, 43);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(125, 20);
            this.tb_password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Matrikelnummer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Passwort";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Daten und Nutzung ohne Gewähr!";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 104);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Prüfe alle 5 Minuten";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(8, 150);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(221, 120);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tb_mail_to);
            this.tabPage1.Controls.Add(this.tb_mail_pass);
            this.tabPage1.Controls.Add(this.tb_mail_user);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(213, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "E-Mail";
            // 
            // tb_mail_user
            // 
            this.tb_mail_user.Location = new System.Drawing.Point(88, 6);
            this.tb_mail_user.Name = "tb_mail_user";
            this.tb_mail_user.Size = new System.Drawing.Size(119, 20);
            this.tb_mail_user.TabIndex = 0;
            // 
            // tb_mail_pass
            // 
            this.tb_mail_pass.Location = new System.Drawing.Point(88, 32);
            this.tb_mail_pass.Name = "tb_mail_pass";
            this.tb_mail_pass.PasswordChar = '*';
            this.tb_mail_pass.Size = new System.Drawing.Size(119, 20);
            this.tb_mail_pass.TabIndex = 1;
            // 
            // tb_mail_to
            // 
            this.tb_mail_to.Location = new System.Drawing.Point(88, 58);
            this.tb_mail_to.Name = "tb_mail_to";
            this.tb_mail_to.Size = new System.Drawing.Size(119, 20);
            this.tb_mail_to.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Gmail Benutzer";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Gmail Passwort";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Sende Email an";
            // 
            // cb_sendemail
            // 
            this.cb_sendemail.AutoSize = true;
            this.cb_sendemail.Location = new System.Drawing.Point(12, 127);
            this.cb_sendemail.Name = "cb_sendemail";
            this.cb_sendemail.Size = new System.Drawing.Size(231, 17);
            this.cb_sendemail.TabIndex = 8;
            this.cb_sendemail.Text = "Sende E-Mail wenn neue Noten vorhanden";
            this.cb_sendemail.UseVisualStyleBackColor = true;
            this.cb_sendemail.CheckedChanged += new System.EventHandler(this.cb_sendemail_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 297);
            this.Controls.Add(this.cb_sendemail);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "RFH Noten";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem prüfeErgebnisseToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TextBox tb_username;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem neuesUpdateToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox tb_mail_to;
        private System.Windows.Forms.TextBox tb_mail_pass;
        private System.Windows.Forms.TextBox tb_mail_user;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cb_sendemail;
    }
}

