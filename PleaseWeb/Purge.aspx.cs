using System;
using System.Web;
using System.Web.UI;
using PleaseBLL;

namespace PleaseWeb
{
    public partial class Purge : System.Web.UI.Page
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
            system.PurgeAll();
        }
    }
}

