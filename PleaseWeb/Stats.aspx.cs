using System;
using System.Web;
using System.Web.UI;
using System.Linq;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Stats : System.Web.UI.Page
    {

        private BroadcastSystem system
        {
            get
            {
                return Global.system;
//                if (Application["system"] == null)
//                {
//                    Application["system"] = new BroadcastSystem();
//                }
//                return (BroadcastSystem)Application["system"];
            }
        }

        protected void Page_Load(object sender, EventArgs args)
        {
            int subs = system.Subscribers.Count;
            int requests = system.Requests.Count;
            int open = (from PleaseBLL.Request r in system.Requests where r.Closed == false select r).Count();
            lblMessage.Text = String.Format("{0} subscriber(s)<br/>" +
                "{1} request(s)<br/>" +
                "{2} open request(s)<br/>" +
                                            "Mail server: {3}", subs, requests, open, Global.system.Settings.SMTPServer);
        }
    }
}

