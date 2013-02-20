using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Request : System.Web.UI.Page
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

        protected void cmdRequestClick(object sender, EventArgs args)
        {
            if (Page.IsValid)
            {
                try
                {
                    system.AddRequest(PleaseBLL.Request.Create(txtName.Text, txtEmail.Text, txtSMS.Text, txtDate.Text));
                }
                catch(PleaseBLL.SubscriptionRequiredException)
                {
                    Response.Redirect("Requested.aspx?message=You must subscribe first!");
                    Response.End();
                }
                Response.Redirect("Requested.aspx");
            }
        }

    }
}

