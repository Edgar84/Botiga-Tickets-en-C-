using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Projecte_1
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.AppendHeader("Refresh", "4;url=home.aspx");

        }
        protected void goToCart(object sender, EventArgs e)
        {
            Response.Redirect("shopping_cart.aspx");
        }
        protected void GoHome(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
}