
using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Unsubscribe : System.Web.UI.Page
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
        
        protected void cmdUnsubscribeClick(object sender, EventArgs args)
        {
            if (Page.IsValid)
            {
                system.RemoveSubscriber(txtEmail.Text);
                Response.Redirect("Unsubscribed.aspx");
            }
        }

    }
}

