using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Respond : System.Web.UI.Page
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
            string req = Request["guid"];
            string sub = Request["sub"];
            try
            {
                system.ProcessResponse(req, sub);
                lblMessage.Text = system.Settings.UI_AcceptedRequestThanks;
            }
            catch(RequestFulfilledException)
            {
                lblMessage.Text = system.Settings.UI_RequestAlreadyFulfilled;
            }
            catch(RequestNotFoundException)
            {
                lblMessage.Text = "The request you are offering to help with cannot be found.";
            }
            catch(SubscriberNotFoundException)
            {
                lblMessage.Text = "Your subscription cannot be found.";
            }
            catch(Exception e)
            {
                lblMessage.Text = e.GetType().ToString();
            }
        }
    }
}

