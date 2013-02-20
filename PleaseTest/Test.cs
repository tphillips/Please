using System;
using NUnit.Framework;
using PleaseBLL;

namespace PleaseTest
{
	[TestFixture()]
	public class Test
	{

        [Test()]
        public void FullTest()
        {
            using (BroadcastSystem s = new BroadcastSystem("./"))
            {
                s.Settings.ThreadEmails = false;
                s.PurgeAll();
                s.AddSubscriber(Subscriber.Create("Sam", "sam.smith@gmail.com", "123456789"));
                s.AddSubscriber(Subscriber.Create("Sam Work", "sam@work.co.uk", "123456789"));
                s.AddRequest(Request.Create("Sam", "sam.smith@gmail.com", "123456789", "16th Feb 2013"));
            }
        }

        [Test()]
        public void AddSubscriber()
        {
            using (BroadcastSystem s = new BroadcastSystem("./"))
            {
                s.AddSubscriber(Subscriber.Create("Sam", "sam.smith@gmail.com", "123456789"));
            }
        }

        [Test()]
        public void SendRequest()
        {
            using (BroadcastSystem s = new BroadcastSystem("./"))
            {
                s.AddRequest(Request.Create("Sam", "sam.smith@gmail.com", "123456789", "16th Feb 2013"));
            }
        }

        [Test()]
        public void SendResponse()
        {
            using (BroadcastSystem s = new BroadcastSystem("./"))
            {
                s.ProcessResponse("635e5b96-a163-4d72-b086-3fc4758fc734", "cc2ea4d2-8807-40f9-9b07-47c7329b6d7f");
            }
        }

        [Test()]
        public void Purge()
        {
            using (BroadcastSystem s = new BroadcastSystem("./"))
            {
                s.Purge();
            }
        }

	}
}

