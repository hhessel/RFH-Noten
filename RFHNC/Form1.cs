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
using System.Net.Mail;
using System.Net;

namespace RFHNC
{
    public partial class Form1 : Form
    {
        public Parsing parsing { get; set; }
        public Semester semester { get; set; }
        private Timer t1 { get; set; }
        private bool noteChanged { get; set; } 

        public Form1()
        {
            InitializeComponent();
        }

        public void checkForUpdates(Semester newUpdate)
        {
            bool changed = false;
            Semester oldData = (Semester)Settings.Default.semester;
            if (oldData != null)
            {
                foreach (Note note in newUpdate.noten)
                {
                    Note oldNote = oldData.noten.Single(m => m.modulbezeichnung == note.modulbezeichnung);
                    if (oldNote.note != note.note)
                    {
                        changed = changed ? true : true;
                        oldNote.changed = true;
                        note.changed = true;
                    }
                }
                if (changed)
                {
                    noteChanged = true;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Settings.Default.matrikelnummer = tb_username.Text;
            Settings.Default.passwort = tb_password.Text;
            Settings.Default.sendemail = cb_sendemail.Checked;
            Settings.Default.checking = checkBox1.Checked;
            Settings.Default.email_user = tb_mail_user.Text;
            Settings.Default.email_pass = tb_mail_pass.Text;
            Settings.Default.email_to = tb_mail_to.Text;

            Settings.Default.Save();
            button1.Enabled = false;

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
            backgroundWorker1.RunWorkerAsync();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            parsing = new Parsing();
            t1 = new Timer();
            t1.Interval = 300000;
            t1.Tick += new EventHandler(checkForUpdate);
            if (checkBox1.Checked) t1.Start();

            notifyIcon1.Visible = true;
            tb_username.Text = Settings.Default.matrikelnummer;
            tb_password.Text = Settings.Default.passwort;
            cb_sendemail.Checked = Settings.Default.sendemail;
            checkBox1.Checked = Settings.Default.checking;
            tb_mail_user.Text = Settings.Default.email_user;
            tb_mail_pass.Text = Settings.Default.email_pass;
            tb_mail_to.Text = Settings.Default.email_to;

            if (cb_sendemail.Checked)
            {
                tabControl1.Enabled = true;
            }
            else
            {
                tabControl1.Enabled = false;
            }


            
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
            semester = parsing.parse();
            checkForUpdates(semester);
            Settings.Default.semester = semester;
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

            if (noteChanged) { 
                ballonBox.Append("NEUE NOTE!!!" + Environment.NewLine);
                if (cb_sendemail.Checked) sendMail();
            }
            foreach (Note note in Settings.Default.semester.noten)
            {
                ballonBox.Append(note.modulbezeichnung + " : " + note.note + Environment.NewLine);
            }
            notifyIcon1.BalloonTipText = ballonBox.ToString();
            notifyIcon1.ShowBalloonTip(4000);
            
            button1.Enabled = true;
        }

        private void sendMail() {
            var fromAddress = new MailAddress(tb_mail_user.Text, "RFH Noten");
            var toAddress = new MailAddress(tb_mail_to.Text, "You");
            string fromPassword = tb_mail_pass.Text;
            string subject = "RFH - Neue Note eingetragen!";

            StringBuilder emailBody = new StringBuilder();
            emailBody.Append(Settings.Default.semester.semester + Environment.NewLine);
            foreach (Note note in Settings.Default.semester.noten)
            {
                if (note.changed)
                {
                    emailBody.Append(note.modulbezeichnung + " : " + note.note + Environment.NewLine);
                    note.changed = false;
                }
            }
            string body = emailBody.ToString();

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.matrikelnummer = tb_username.Text;
            Settings.Default.passwort = tb_password.Text;
            Settings.Default.sendemail = cb_sendemail.Checked;
            Settings.Default.checking = checkBox1.Checked;
            Settings.Default.email_user = tb_mail_user.Text;
            Settings.Default.email_pass = tb_mail_pass.Text;
            Settings.Default.email_to = tb_mail_to.Text;
            Settings.Default.semester = semester;

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
                t1.Start();
            } else {
                t1.Stop();
            }
        }

        private void cb_sendemail_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_sendemail.Checked)
            {
                tabControl1.Enabled = true;
            }
            else {
                tabControl1.Enabled = false;
            }
        }
    }
}
