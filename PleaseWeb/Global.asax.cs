using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using PleaseBLL;

namespace PleaseWeb
{
    public class Global : System.Web.HttpApplication
    {
		
        public static BroadcastSystem system;

        protected virtual void Application_Start(Object sender, EventArgs e)
        {
            Global.system = new BroadcastSystem(Server.MapPath("~/"));
        }
		
        protected virtual void Session_Start(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Application_BeginRequest(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Application_EndRequest(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Application_Error(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Session_End(Object sender, EventArgs e)
        {
        }
		
        protected virtual void Application_End(Object sender, EventArgs e)
        {
            Global.system.Save();
        }
    }
}

