/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;

namespace PleaseBLL
{

    [Serializable]
    public class Subscriber
    {

        public DateTime CreateDate { get; set; }

        public string GUID
        {
            get;
            set;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string SMS { get; set; }

        public Subscriber()
        {
        }

        public static Subscriber Create(string name, string email, string sms)
        {
            Subscriber s = new Subscriber() { GUID = Guid.NewGuid().ToString(), CreateDate = DateTime.Now, Name = name, Email = email.ToLower(), SMS = sms };
            return s;
        }

        public void SendUnsubNotification(SystemSettings settings)
        {
            Message m = new Message(); 
            m.Body = settings.EmailBody_Unsubscribe.Replace("$name", this.Name);
            m.To = Name;
            m.ToEmail = Email;
            m.ToSMS = SMS;
            m.Subject = settings.EmailSubject_Unsubscribe;
            m.Send(settings);
        }

        public void SendWelcomeMessage(SystemSettings settings)
        {
            Message m = new Message(); 
            m.Body = settings.EmailBody_SubscriberWelcome.Replace("$name", this.Name);
            m.To = Name;
            m.ToEmail = Email;
            m.ToSMS = SMS;
            m.Subject = settings.EmailSubject_SubscriberWelcome;
            m.Send(settings);
        }

        public Message SendRequest(Request r, SystemSettings settings)
        {
            Message m = new Message(); 
            m.Body = string.Format("{0}", r.Message.Replace("$name", Name).Replace("$link", r.CreateResponseUrl(this, settings)));
            m.Subject = settings.EmailSubject_NewRequest;
            m.To = Name;
            m.ToEmail = Email;
            m.ToSMS = SMS;
            m.Send(settings);
            return m;
        }

        public Message SendCloseNotification(Request req, string message, SystemSettings settings)
        {
            Message m = new Message();
            m.Subject = settings.EmailSubject_RequestAcceptedSubscribers;
            m.Body = message;
            m.To = Name;
            m.ToEmail = Email;
            m.ToSMS = SMS;
            m.Send(settings);
            return m;
        }
    }
}

