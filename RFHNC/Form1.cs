using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RFHNC.Properties;
using System.Deployment.Application;

namespace RFHNC
{
    public partial class Form1 : Form
    {
        public Parsing parsing { get; set; }
        private Timer t1 { get; set; }

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.matrikelnummer = tb_username.Text;
            Settings.Default.passwort = tb_password.Text;
            Settings.Default.Save();
            button1.Enabled = false;

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();

            t1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.Visible = true;
            tb_username.Text = Settings.Default.matrikelnummer;
            tb_password.Text = Settings.Default.passwort;

            t1 = new Timer();
            t1.Interval = 300000;
            t1.Tick += new EventHandler(checkForUpdate);

            parsing = new Parsing();
        }

        private void checkForUpdate(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void doUpdate() {
            notifyIcon1.BalloonTipText = "Prüfe Noten";
            notifyIcon1.ShowBalloonTip(10000);

            if ((DateTime.Now.Subtract(Settings.Default.lastupdated).Minutes > 10))
            {
                parsing.login(Settings.Default.matrikelnummer, Settings.Default.passwort);
            }

            parsing.pullNotes();
            Settings.Default.semester = parsing.parse();
            Settings.Default.Save();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) {
                notifyIcon1.ShowBalloonTip(4000);
            } 
        }

        private void prüfeErgebnisseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            doUpdate(); 
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            StringBuilder ballonBox = new StringBuilder();
            ballonBox.Append(Settings.Default.semester.semester + Environment.NewLine);
            foreach (Note note in Settings.Default.semester.noten)
            {
                ballonBox.Append(note.modulbezeichnung + " : " + note.note + Environment.NewLine);
            }
            notifyIcon1.BalloonTipText = ballonBox.ToString();
            notifyIcon1.ShowBalloonTip(4000);
            button1.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }

        private void neuesUpdateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ApplicationDeployment updateCheck = ApplicationDeployment.CurrentDeployment;
            UpdateCheckInfo info = updateCheck.CheckForDetailedUpdate();
            if (info.UpdateAvailable)
            {
                updateCheck.Update();
                MessageBox.Show("Neues Update vorhanden. Jetzt neustarten?");
                Application.Restart();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) {
                t1.Tick += new EventHandler(checkForUpdate);
                t1.Start();
            } else {
                t1.Stop();
            }
        }
    }
}
