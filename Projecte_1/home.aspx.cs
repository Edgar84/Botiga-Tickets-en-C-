using Microsoft.SharePoint.Client;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Projecte_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Només omplir la llista
            {
                String path = "E:\\ZZZ-DAM2\\M13\\Projecte 1 - 2DAM\\Projecte_1\\Projecte_1\\src\\products\\";
                DirectoryInfo productsdir = new DirectoryInfo(path);
                FileInfo[] fitxersPelicules = productsdir.GetFiles("*.txt");
                FileInfo[] imatgesPelicules = productsdir.GetFiles("*.jpg");
                addFourProducts(fitxersPelicules, imatgesPelicules, path);
            }
        }

        protected void addFourProducts(FileInfo[] fitxersPelicules, FileInfo[] imatgesPelicules, String path) {

            for (var i = 0; i < fitxersPelicules.Length; i++)
            {
                String imgSrc = "";
                if (fitxersPelicules[i].Name.Substring(0, 4) == imatgesPelicules[i].Name.Substring(0, 4)) {
                    imgSrc = path + imatgesPelicules[i].Name;
                }

                if (i < 4)
                {
                    //consolelog.Text += fitxersPelicules[i].Name + "<br/>";
                    HtmlGenericControl div_col = new HtmlGenericControl("div");
                    div_col.Attributes["class"] = "col";
                    productContainer.Controls.Add(div_col);

                    HtmlGenericControl div_card = new HtmlGenericControl("div");
                    div_card.Attributes["class"] = "card";
                    div_col.Controls.Add(div_card);

                    HtmlGenericControl img = new HtmlGenericControl("img");
                    img.Attributes["class"] = "card-img-top";
                    img.Attributes["src"] = fitxersPelicules[i].Name.Substring(0, 4) == imatgesPelicules[i].Name.Substring(0, 4) ? path + imatgesPelicules[i].Name : "broken";
                    img.Attributes["alt"] = fitxersPelicules[i].Name.Substring(0, 4) == imatgesPelicules[i].Name.Substring(0, 4) ? imatgesPelicules[i].Name : "broken";
                    div_col.Controls.Add(img);

                    sdf
                }
            }
        }



        protected void goToCart(object sender, EventArgs e)
        {
            Response.Redirect("shopping_cart.aspx");
        }
        protected void goHome(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
    }
    
}