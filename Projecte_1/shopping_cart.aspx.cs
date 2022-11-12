using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projecte_1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GoHome(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
        protected void GoCheckout(object sender, EventArgs e)
        {
            Response.Redirect("checkout.aspx");
        }
        

    }
}