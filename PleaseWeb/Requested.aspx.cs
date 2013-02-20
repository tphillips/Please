using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Requested : System.Web.UI.Page
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
            if (!String.IsNullOrEmpty(Request["message"]))
            {
                lblMessage.Text = Request["message"];
            }
            else
            {
                lblMessage.Text = system.Settings.UI_RequestBroadcasted;
            }
        }

    }
}

