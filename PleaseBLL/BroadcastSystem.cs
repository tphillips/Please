/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Linq;

namespace PleaseBLL
{
    public class BroadcastSystem : IDisposable
    {

        private List<Request> requests;
        private List<Response> responses;
        private List<Subscriber> subscribers;
        public SystemSettings Settings;
        public bool diskLocked = false;
        public string Path;
        private Logger log;

        public List<Subscriber> Subscribers 
        { 
            get { return subscribers; }
            set
            {
                subscribers = value;
                Save();
            }
        }

        public List<Request> Requests 
        { 
            get { return requests; }
            set 
            { 
                requests = value;
                Save();
            }
        }

        public List<Response> Responses 
        { 
            get { return responses; }
            set 
            { 
                responses = value;
                Save();
            }
        }

        public BroadcastSystem(string path)
        {
            Path = path;
            log = new Logger(path + "/Log.txt");
            Load();
        }

        public void Purge()
        {
            log.Log("Purging");
            Subscribers = new List<Subscriber>();
            Requests = new List<Request>();
            Responses = new List<Response>();
            Save();
        }

        public void PurgeAll()
        {
            log.Log("Purging all");
            Settings = SystemSettings.Default();
            Purge();
        }


        public void Dispose()
        {
            //Save();
        }

        public void Save()
        {
            while (diskLocked) { System.Threading.Thread.Sleep(100); }
            //log.Log("Saving");
            diskLocked = true;
            Serialize(Subscribers, "Subscribers.xml");
            Serialize(Requests, "Requests.xml");
            Serialize(Responses, "Responses.xml");
            Serialize(Settings, "Settings.xml");
            diskLocked = false;
        }

        public void Load()
        {
            while (diskLocked) { System.Threading.Thread.Sleep(100); }
            //log.Log("Loading");
            diskLocked = true;
            try 
            { 
                Settings = (SystemSettings) Deserialize("Settings.xml");
            }
            catch 
            {
                Settings = SystemSettings.Default();
            }

            try 
            { 
                subscribers = (List<Subscriber>) Deserialize("Subscribers.xml");
            }
            catch 
            {
                subscribers = new List<Subscriber>();
            }

            try 
            { 
                requests = (List<Request>) Deserialize("Requests.xml");
            }
            catch 
            {
                requests = new List<Request>();
            }

            try 
            { 
                responses = (List<Response>) Deserialize("Responses.xml");
            }
            catch 
            {
                responses = new List<Response>();
            }
            diskLocked = false;
        }

        public void AddSubscriber(Subscriber s)
        {
            int c = (from Subscriber ss in Subscribers where ss.Email == s.Email select ss).Count();
            if (c > 0) { throw new SubscriptionExistsException(); }
            log.Log(string.Format("New subscriber {0} {1}", s.Name, s.Email));
            Subscribers.Add(s);
            Save();
            s.SendWelcomeMessage(Settings);
        }

        public void RemoveSubscriber(string email)
        {
            Subscriber sub = null;
            try
            {
                sub = (from Subscriber s in Subscribers where s.Email == email.ToLower() select s).First();
                log.Log(string.Format("Unsubscribing {0}", email));
                Subscribers.Remove(sub);
                sub.SendUnsubNotification(Settings);
                Save();
            }
            catch{}
        }

        public void AddRequest(Request r)
        {
            if (Settings.RequireRequestorsToBeSubscribers)
            {
                int c = (from Subscriber s in Subscribers where s.Email == r.FromEmail select s).Count();
                if (c == 0) { throw new SubscriptionRequiredException(); }
            }
            log.Log(string.Format("New request from {0} for {1}", r.FromName, r.RequestText));
            r.Message = Settings.EmailBody_NewRequest.Replace("$help", r.RequestText);
            r.Message = r.Message.Replace("$requestor", r.FromName);
            Requests.Add(r);
            Save();
            foreach(Subscriber s in Subscribers)
            {
                //log.Log(string.Format("Sending request to {0}", s.Email));
                Message m = s.SendRequest(r, Settings);
                r.Messages.Add(m);
                r.Recipients.Add(s);
            }
            r.Sent = true;
            r.SentDate = DateTime.Now;
            Save();
        }

        public void ProcessResponse(string requestGuid, string subGuid)
        {
            // Find request
            Request req = null;
            try
            {
                req = (from Request r in Requests where r.GUID == requestGuid select r).First();
            }
            catch 
            {
                throw new RequestNotFoundException();
            }
            if (req == null) { throw new RequestNotFoundException(); } 
            // Find subscriber
            Subscriber sub = null;
            try
            {
                sub = (from Subscriber s in Subscribers where s.GUID == subGuid select s).First();
            }
            catch 
            {
                throw new SubscriberNotFoundException();
            }
            if (sub == null) { throw new SubscriberNotFoundException(); }
            // Log the response
            Responses.Add(Response.Create(sub, req));
            // Already closed?
            if (req.Closed) { throw new RequestFulfilledException(); }
            // Close and notify
            log.Log(string.Format("Response from {0}({1}) to the request from {2}({3}) for {4}", sub.Name, sub.Email, req.FromName, req.FromEmail, req.RequestText));
            req.Closed = true;
            req.ClosedDate = DateTime.Now;
            req.ClosedBy = sub;
            Save();
            // Notify requestor
            req.NotifyAccepted(sub, Settings);
            // Notify list
            foreach(Subscriber s in Subscribers)
            {
                if (s.Email != req.FromEmail)
                {
                    string mess = Settings.EmailBody_RequestAcceptedSubscribers.Replace("$name", s.Name);
                    mess = mess.Replace("$requestor", req.FromName);
                    mess = mess.Replace("$volunteer", sub.Name);
                    mess = mess.Replace("$help", req.RequestText);
                    Message m = s.SendCloseNotification(req, mess, Settings);
                    req.Messages.Add(m);
                }
            }
            // After emails sent, save again
            Save();
        }

        private object Deserialize(string fileName)
        {
            using (StreamReader r = new StreamReader(Path + "/" + fileName))
            {
                SoapFormatter f = new SoapFormatter();
                object ret = f.Deserialize(r.BaseStream);
                r.Close();
                return ret;
            }
        }

        private void Serialize(object graph, string fileName)
        {
            using (StreamWriter w = new StreamWriter(Path + "/" + fileName, false))
            {
                SoapFormatter f = new SoapFormatter();
                f.Serialize(w.BaseStream, graph);
                w.Close();
            }
        }

    }
}

