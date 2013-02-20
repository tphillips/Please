/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace PleaseBLL
{

    [Serializable]
    public class Message
    {

        public DateTime CreateDate { get; set; }


        public string Subject
        {
            get;
            set;
        }

        public string Body
        {
            get;
            set;
        }

        public string To
        {
            get;
            set;
        }

        public string ToEmail
        {
            get;
            set;
        }

        public string ToSMS
        {
            get;
            set;
        }

        public Message()
        {
        }

        public void Send(SystemSettings s)
        {
            if (s.ThreadEmails)
            {
                Thread t = new Thread(_Send);
                t.Start(s);
            }
            else
            {
                _Send(s);
            }
        }

        public void _Send(object settings)
        {
            SystemSettings s = (SystemSettings)settings;
            SmtpClient smtp = new SmtpClient(s.SMTPServer, s.SMTPPort);
            if (s.SMTPUser != "")
            {
                smtp.Credentials = new NetworkCredential(s.SMTPUser, s.SMTPPassword);
            }
            smtp.EnableSsl = s.SMTPSSL;
            smtp.Send(s.MailFrom, ToEmail, Subject, Body);
        }

    }
}

