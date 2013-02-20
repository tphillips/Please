
using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Subscribe : System.Web.UI.Page
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

        protected void cmdSubscribeClick(object sender, EventArgs args)
        {
            if (Page.IsValid)
            {
                try
                {
                    system.AddSubscriber(PleaseBLL.Subscriber.Create(txtName.Text, txtEmail.Text, txtSMS.Text));
                } 
                catch(PleaseBLL.SubscriptionExistsException)
                {
                    Response.Redirect("Subscribed.aspx?message=You are already subscribed.");
                }
                Response.Redirect("Subscribed.aspx");
            }
        }
    }
}

