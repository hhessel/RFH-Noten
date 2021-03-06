﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Net;
using System.IO;
using RFHNC.Properties;
using System.Web;

namespace RFHNC
{
    public class Parsing
    {
        public string htmlContent { get; set; }

        public void login(String username, String password) {

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://www.studse.rfh-koeln.de/?func=login_check");
            
            StringBuilder loginString = new StringBuilder();
            loginString.Append("Benutzer=" + username + "&");
            loginString.Append("passwort=" + password + "&");
            loginString.Append("login=Login");

            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.7 (KHTML, like Gecko) Chrome/16.0.912.63 Safari/535.7";
            webRequest.ContentLength = loginString.Length;
            webRequest.Method = "POST";
            webRequest.Proxy = null;
            webRequest.AllowAutoRedirect = true;
            webRequest.Timeout = 10000;

            using (var writer = new StreamWriter(webRequest.GetRequestStream()))
            {
                writer.Write(loginString.ToString());
            }

            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();

            Settings.Default.sessionId = webResponse.ResponseUri.Query.Split('=')[1];
            Settings.Default.Save();

        }

        public void pullNotes() {

            StringBuilder loginString = new StringBuilder();
            loginString.Append("https://www.studse.rfh-koeln.de/vpruef/pruefungsergebnisse.php?");
            loginString.Append("PHPSESSID=" + Settings.Default.sessionId + "&");
            loginString.Append("nav=1");

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(loginString.ToString());

            webRequest.Proxy = null;
            webRequest.AllowAutoRedirect = true;
            webRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.7 (KHTML, like Gecko) Chrome/16.0.912.63 Safari/535.7";

            try
            {
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                // StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(28591));
                StringBuilder contentBuilder = new StringBuilder();

                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.GetEncoding(28591)))
                {
                    contentBuilder.Append(sr.ReadToEnd());
                    sr.Close();
                }
                /*
                while (-1 != sr.Peek())
                {
                    contentBuilder.Append(sr.ReadLine());
                    contentBuilder.Append("\r\n");
                }
                */
                htmlContent = contentBuilder.ToString();
            }
            catch (Exception ex) { 
               
            }

        }

        public Semester parse()
        { 
             string[] stringSeparators = new string[] {"&nbsp;&nbsp;&nbsp;"};
             Semester semester = new Semester();
             HtmlDocument doc = new HtmlDocument();
             // doc.Load("C:\\Users\\HenrikPHessel\\Desktop\\Studentenportal - Rheinische Fachhochschule Köln.htm");

             if(htmlContent == null) { 
                pullNotes();
             }

             doc.LoadHtml(htmlContent);

             // Pull Semester
             var semesterHtml = doc.DocumentNode.SelectNodes("//*[contains(concat( \" \", @class, \" \" ), concat( \" \", \"semester_bez\", \" \" ))]");
             semester.semester = semesterHtml.First().InnerText;
             semester.noten = new List<Note>(); 
   

             var notenHtml = doc.DocumentNode.SelectNodes("//td");

             bool isDone = false;
             foreach (HtmlNode link in notenHtml) {
                 if(isDone) break;
                 if (link.InnerText.Contains("Termin"))
                 {
                     HtmlNode next = link.ParentNode.NextSibling;
                     while (next.ChildNodes.Count() > 1)
                     {
                         Note note = new Note();
                         note.modulbezeichnung = HttpUtility.HtmlDecode(next.ChildNodes[0].InnerText.Split(stringSeparators, StringSplitOptions.None)[0]);
                         note.note = next.ChildNodes[1].InnerText;
                         note.changed = false;
                         semester.noten.Add(note);
                         next = next.NextSibling;
                         if (next == null || next.ChildNodes.Count() == 1) { isDone = true; break; }
                     }
                 }
                 
             }

             Settings.Default.lastupdated = DateTime.Now;
             Settings.Default.Save();

             return semester;

        }


    }
}
