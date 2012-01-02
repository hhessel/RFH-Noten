using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net.Mail;
using System.Net;
using RFHNC;

namespace RFHNC_Console
{
    class Program
    {
        private static bool noteChanged { get; set; }
        private static Semester currentSemester { get; set; }

        public static void checkForUpdates(Semester newUpdate, Semester oldData)
        {
            bool changed = false;
            if (oldData != null)
            {
                foreach (Note note in newUpdate.noten)
                {
                    if (oldData.noten.Any(m => m.modulbezeichnung == note.modulbezeichnung))
                    {
                        Note oldNote = oldData.noten.Single(m => m.modulbezeichnung == note.modulbezeichnung);
                        if (oldNote.note != note.note)
                        {
                            changed = changed ? true : true;
                            oldNote.changed = true;
                            note.changed = true;
                        }
                    }
                }
                if (changed)
                {
                    noteChanged = true;
                }
                else
                {
                    noteChanged = false;
                }
            }
        }

        static void Main(string[] args)
        {
            Timer timer = new Timer(new TimerCallback(TimeCallBack), null, 1000, 500000);
            Console.Read();
            timer.Dispose();

            while (true)
            {
                
                if (Console.KeyAvailable)
                {
                    ConsoleKey k = Console.ReadKey().Key; 
                    if (k == ConsoleKey.Escape) 
                    {
                        break; 
                    }
                }
            }


        }

        public static void TimeCallBack(object o)
        {
            Parsing parser = new Parsing();
            Console.WriteLine("{0}  - Checked Notes", DateTime.Now);
            if (currentSemester == null)
            {   
                parser.login("XXX", "XXX");
                parser.pullNotes();
                currentSemester = parser.parse();
            }
            else {
                parser.login("XXX", "XXX");
                parser.pullNotes();
                Semester newSemester = parser.parse();
                checkForUpdates(newSemester, currentSemester);
                if (noteChanged) {
                    string subject = "RFH - Neue Note eingetragen!";

                    StringBuilder emailBody = new StringBuilder();
                    emailBody.Append(currentSemester + Environment.NewLine);
                    foreach (Note note in currentSemester.noten)
                    {
                        if (note.changed)
                        {
                            emailBody.Append(note.modulbezeichnung + " : " + note.note + Environment.NewLine);
                            note.changed = false;
                        }
                    }
                    string body = emailBody.ToString();
                    SendMail("hhessel@gmail.com", "hhessel@gmail.com", "", body, subject);
                }
            }
        }

        public static void SendMail(string ToMail, string FromMail, string Cc, string Body, string Subject)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 25);
            MailMessage mailmsg = new MailMessage();

            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential("XXX", "XXX");

            mailmsg.From = new MailAddress(FromMail);
            mailmsg.To.Add(ToMail);

            if (Cc != "")
            {
                mailmsg.CC.Add(Cc);
            }
            mailmsg.Body = Body;
            mailmsg.Subject = Subject;
            mailmsg.IsBodyHtml = true;

            mailmsg.Priority = MailPriority.High;

            try
            {
                smtp.Timeout = 500000;
                smtp.Send(mailmsg);
                mailmsg.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
