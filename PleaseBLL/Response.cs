/*
 * Community Broadcast System
 * Tristan Phillips
 * Feb 2013
*/ 

using System;

namespace PleaseBLL
{

    [Serializable]
	public class Response
	{

        public DateTime CreateDate { get; set; }

        public Subscriber Subscriber
        {
            get;
            set;
        }

        public Request Request
        {
            get;
            set;
        }

		public Response()
		{
		}

        public static Response Create(Subscriber sub, Request req)
        {
            Response r = new Response();
            r.Subscriber = sub;
            r.Request = req;
            r.CreateDate = DateTime.Now;
            return r;
        }

	}
}

