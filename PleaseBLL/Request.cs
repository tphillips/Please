/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;
using System.Collections.Generic;

namespace PleaseBLL
{

    [Serializable]
	public class Request
	{

        public DateTime CreateDate { get; set; }
        public string GUID { get; set; }
        public string FromName { get; set; }
        public string FromEmail { get; set; }
        public string FromSMS { get; set; }
        public string RequestText { get; set; }
        public string Message { get; set; }
        public bool Sent { get; set; }
        public DateTime SentDate { get; set; }
        public List<Subscriber> Recipients { get; set; }
        public List<Message> Messages { get; set; }
        public List<Response> Responses { get; set; }
        public bool Closed { get; set; }

        public Subscriber ClosedBy
        {
            get;
            set;
        }

        public DateTime ClosedDate { get; set; }

		public Request()
		{

		}

        public static Request Create(string from, string fromEmail, string fromSms, string request)
        {
            Request ret = new Request();
            ret.CreateDate = DateTime.Now;
            ret.GUID = Guid.NewGuid().ToString();
            ret.FromName = from;
            ret.FromEmail = fromEmail.ToLower();
            ret.FromSMS = fromSms;
            ret.RequestText = request;
            ret.Closed = false;
            ret.Sent = false;
            ret.Recipients = new List<Subscriber>();
            ret.Responses = new List<Response>();
            ret.Messages = new List<Message>();
            return ret;
        }

        public string CreateResponseUrl(Subscriber subscriber, SystemSettings s)
        {
            return string.Format("{0}?guid={1}&sub={2}", s.LinkUrl, GUID, subscriber.GUID);
        }

        public void NotifyAccepted(Subscriber sub, SystemSettings settings)
        {
            string message = settings.EmailBody_RequestAcceptedRequestor;
            message = message.Replace("$name", this.FromName).Replace("$acceptor", sub.Name).Replace("$help", this.RequestText);
            new Message(){ Subject = settings.EmailSubject_RequestAcceptedRequestor ,ToEmail = this.FromEmail, Body = message}.Send(settings);
        }
	}
}

