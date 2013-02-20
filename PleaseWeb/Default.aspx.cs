
using System;
using System.Web;
using System.Web.UI;

namespace PleaseWeb
{
    public partial class Default : System.Web.UI.Page
    {
		
        protected void Page_Load(object sender, EventArgs args)
        {
            Response.Redirect("Stats.aspx");
        }
    }
}

