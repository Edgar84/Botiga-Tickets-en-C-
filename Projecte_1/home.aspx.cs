using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.News.DataModel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using ListItem = System.Web.UI.WebControls.ListItem;

namespace Projecte_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //String path = @"E:\\ZZZ-DAM2\\M13\\Projecte 1 - 2DAM\\Projecte_1\\Projecte_1\\src\\products\\";   // <---- Classe
            String path = @"G:\\ZZZ-DAM2\\M13\\Projecte 1 - 2DAM\\Projecte_1\\Projecte_1\\src\\products\\";     // <---- Casa
            DirectoryInfo productsdir = new DirectoryInfo(path);
            FileInfo[] fitxersPelicules = productsdir.GetFiles("*.txt");
            FileInfo[] imatgesPelicules = productsdir.GetFiles("*.jpg");
            addFourProducts(fitxersPelicules, imatgesPelicules, path);
        }

        protected void addFourProducts(FileInfo[] fitxersPelicules, FileInfo[] imatgesPelicules, String path) {

            if (fitxersPelicules.Length < 1)
            {
                //consolelog.Attributes.Add("class", consolelog.Attributes["class"].ToString().Replace("d-none", ""));
                consolelog.CssClass = consolelog.CssClass.Replace("d-none", "");
                consolelog.Text = "No hi ha productes a mostrar.";
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    String infoTxt = System.IO.File.ReadAllText(path + fitxersPelicules[i].Name);
                    String[] infoTiket = infoTxt.Split(',');
                    String filmName = fitxersPelicules[i].Name.Substring(0, ((String)fitxersPelicules[i].Name).Length - 4);

                    // Comprovar que no falten dades al txt i que hi ha una imatge associada al txt
                    if (infoTiket.Length == 3 && filmName.StartsWith(imatgesPelicules[i].Name.Substring(0, ((String)imatgesPelicules[i].Name).Length - 4)))
                    {

                        //Crear cada producte
                        HtmlGenericControl div_col = new HtmlGenericControl("div");
                        div_col.Attributes["class"] = "col";
                        productContainer.Controls.Add(div_col);

                        HtmlGenericControl div_card = new HtmlGenericControl("div");
                        div_card.Attributes["class"] = "card";
                        div_col.Controls.Add(div_card);

                        HtmlGenericControl img = new HtmlGenericControl("img");
                        img.Attributes["class"] = "card-img-top";
                        img.Attributes["src"] = filmName == imatgesPelicules[i].Name.Substring(0, ((String)imatgesPelicules[i].Name).Length - 4) ? "src/products/" + imatgesPelicules[i].Name : "src/img/default.PNG";
                        img.Attributes["alt"] = imatgesPelicules[i].Name.Substring(0, ((String)imatgesPelicules[i].Name).Length - 4);
                        div_card.Controls.Add(img);

                        HtmlGenericControl div_card_body = new HtmlGenericControl("div");
                        div_card_body.Attributes["class"] = "card-body text-center";
                        div_card.Controls.Add(div_card_body);

                        HtmlGenericControl card_title = new HtmlGenericControl("h5");
                        card_title.Attributes["class"] = "card-title";
                        card_title.InnerText = filmName;
                        div_card_body.Controls.Add(card_title);

                        HtmlGenericControl card_text = new HtmlGenericControl("p");
                        card_text.Attributes["class"] = "card-text";
                        card_text.InnerText = infoTiket[2];
                        div_card_body.Controls.Add(card_text);

                        HtmlGenericControl price = new HtmlGenericControl("h4");
                        price.Attributes["class"] = "card-text text-danger";
                        price.InnerText = infoTiket[1] + "€";
                        div_card_body.Controls.Add(price);

                        DropDownList select = new DropDownList();
                        select.Attributes["class"] = "form-select form-select-sm mb-3";
                        select.ID = "select_" + filmName.Replace(" ", "");
                        select.Attributes["runat"] = "server";
                        select.Items.Add(new ListItem("", ""));
                        for (int x = 1; x <= 10; x++)
                        {
                            select.Items.Add(new ListItem(x.ToString(), x.ToString()));
                        }
                        div_card_body.Controls.Add(select);

                        Button button = new Button();
                        button.Attributes["class"] = "btn btn-outline-danger";
                        button.ID = "btn-" + filmName.Replace(" ", "");
                        button.Attributes["runat"] = "server";
                        button.Click += new EventHandler(((sender, e) => addToCart(sender, e, filmName, infoTiket[1], infoTiket[2], select, infoTxt)));
                        //button.Click += new EventHandler(((sender, e) => addToCart(infoTxt, select)));
                        button.Text = "Afegir al carret";
                        div_card_body.Controls.Add(button);
                    }
                    
                }
            }
        }
        protected void addToCart(object sender, EventArgs e, String name, String price, String desc, DropDownList select, String infoTxt)
        {

            // Guardar la cookie amb els productes
            String newProductCart = "";

            if (Request.Cookies["carret"] != null)
            {
                // Si la cookie existeix agafem el seu valor
                newProductCart = Request.Cookies["carret"].Value;
                String[] filmsInCart = newProductCart.Trim().Split('-');
                // Comprovem si la pel·licula ja está dins la cookie
                if (Array.Exists(filmsInCart, element => element.StartsWith(name)))
                {
                    for (int i = 0; i < filmsInCart.Length - 1; i++)
                    {
                        if (filmsInCart[i].Substring(0, filmsInCart[i].IndexOf(',')).Equals(name))
                        {
                            // Si la pel·licula es a dins li sumem només la quantitat a comprar
                            int total = int.Parse(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1)) + int.Parse(select.SelectedValue);
                            String productSumado = name + "," + price + "," + desc + "," +  total.ToString();

                            newProductCart = newProductCart.Replace(filmsInCart[i], productSumado);
                            // Afegir-la a la cookie
                            Response.Cookies["carret"].Value = newProductCart;
                        }
                    }
                }
                else
                {
                    // Si la pel·licula no está dins la cookie, la afegim
                    newProductCart += name + "," + price + "," + desc + "," + select.SelectedValue + "-";
                    Response.Cookies["carret"].Value = newProductCart;
                }
            }
            else
            {
                // Si la cookie no existeix la creem i li doenm caducitat
                newProductCart = name + "," + price + "," + desc + "," + select.SelectedValue + "-";
                Response.Cookies["carret"].Value = newProductCart;
                Response.Cookies["carret"].Expires = DateTime.Now.AddDays(1);
            }
        }
        /*protected void addToCart(object sender, EventArgs e, String name, String price, String desc, DropDownList select) {

            // Guardar la cookie amb els productes
            String newProductCart = "";
            
            if (Request.Cookies["carret"] != null)  
            {
                // Si la cookie existeix agafem el seu valor
                newProductCart = Request.Cookies["carret"].Value;
                String[] filmsInCart = newProductCart.Trim().Split('-');
                // Comprovem si la pel·licula ja está dins la cookie
                if (Array.Exists(filmsInCart, element => element.StartsWith(name)))
                {
                    for (int i = 0; i < filmsInCart.Length - 1; i++)
                    {
                        if (filmsInCart[i].Substring(0, filmsInCart[i].IndexOf(',')).Equals(name))
                        {
                            // Si la pel·licula es a dins li sumem només la quantitat a comprar
                            int total = int.Parse(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1)) + int.Parse(select.SelectedValue);
                            String productSumado = filmsInCart[i].Replace(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1), total.ToString());

                            newProductCart = newProductCart.Replace(filmsInCart[i], productSumado);
                            // Afegir-la a la cookie
                            Response.Cookies["carret"].Value = newProductCart;
                        }
                    }
                }
                else
                {
                    // Si la pel·licula no está dins la cookie, la afegim
                    newProductCart += name + "," + price + "," + desc + "," + select.SelectedValue + "-";
                    Response.Cookies["carret"].Value = newProductCart;
                }
            }
            else
            {
                // Si la cookie no existeix la creem i li doenm caducitat
                newProductCart = name + "," + price + "," + desc + "," + select.SelectedValue + "-";
                Response.Cookies["carret"].Value = newProductCart;
                Response.Cookies["carret"].Expires = DateTime.Now.AddDays(1);
            }
        }*/
        protected void borrarCookies(object sender, EventArgs e) {
            if (Request.Cookies["carret"] != null)
            {
                HttpCookie currentUserCookie = HttpContext.Current.Request.Cookies["carret"];
                HttpContext.Current.Response.Cookies.Remove("carret");
                currentUserCookie.Expires = DateTime.Now.AddDays(-10);
                currentUserCookie.Value = null;
                HttpContext.Current.Response.SetCookie(currentUserCookie);
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