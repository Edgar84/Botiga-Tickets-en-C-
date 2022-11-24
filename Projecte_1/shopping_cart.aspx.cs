using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.News.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Microsoft;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Projecte_1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
 
            String newProductCart = "";

            if (Request.Cookies["carret"] != null)
            {
                // Si la cookie existeix agafem el seu valor
                newProductCart = Request.Cookies["carret"].Value;
                addProducts(newProductCart);
            }
            

        }
        protected void addProducts(String newProductCart) {

            String[] filmsInCart = newProductCart.Split('-');
            String[] priceForProducts = new string[5];
            int count = 0;

            foreach (String film in filmsInCart) {
                
                String[] infoCart = film.Split(',');

                if(infoCart.Length == 4) { 
                    String nom = infoCart[0];
                    String base_price = infoCart[1];
                    String desc = infoCart[2];
                    String quant = infoCart[3];

                    //Crear cada producte
                    HtmlGenericControl card = new HtmlGenericControl("div");
                    card.ID = nom.Replace(" ", "_");
                    card.Attributes["class"] = "card mb-3";
                    productCardContainer.Controls.Add(card);

                    HtmlGenericControl card_body = new HtmlGenericControl("div");
                    card_body.Attributes["class"] = "card-body";
                    card.Controls.Add(card_body);

                    HtmlGenericControl row = new HtmlGenericControl("div");
                    row.Attributes["class"] = "row justify-content-between";
                    card_body.Controls.Add(row);

                    HtmlGenericControl col_1 = new HtmlGenericControl("div");
                    col_1.Attributes["class"] = "col-12 col-md-8 d-flex flex-row align-items-center mb-3 mb-md-0 flex-md-nowrap flex-wrap";
                    row.Controls.Add(col_1);

                    HtmlGenericControl card_body_img = new HtmlGenericControl("div");
                    card_body_img.Attributes["class"] = "card-body_img mb-3 mb-md-0";
                    col_1.Controls.Add(card_body_img);

                    HtmlGenericControl img = new HtmlGenericControl("img");
                    img.Attributes["class"] = "img-fluid rounded-3";
                    img.Attributes["style"] = "width: 65px;";
                    img.Attributes["src"] = "src/products/" + nom + ".jpg" ;
                    img.Attributes["alt"] = nom;
                    card_body_img.Controls.Add(img);

                    HtmlGenericControl ms_3 = new HtmlGenericControl("div");
                    ms_3.Attributes["class"] = "ms-3";
                    col_1.Controls.Add(ms_3);

                    HtmlGenericControl card_body_title = new HtmlGenericControl("h5");
                    card_body_title.Attributes["class"] = "card-body_title";
                    card_body_title.InnerText = nom;
                    ms_3.Controls.Add(card_body_title);

                    HtmlGenericControl price_base = new HtmlGenericControl("span");
                    price_base.Attributes["class"] = "text-primary euro";
                    price_base.InnerText = base_price;
                    ms_3.Controls.Add(price_base);

                    HtmlGenericControl card_body_decription = new HtmlGenericControl("p");
                    card_body_decription.Attributes["class"] = "small mb-0 card-body_decription";
                    card_body_decription.InnerText = desc;
                    ms_3.Controls.Add(card_body_decription);

                    HtmlGenericControl col_2 = new HtmlGenericControl("div");
                    col_2.Attributes["class"] = "col-12 col-md-4 d-flex flex-row align-items-center card-body_details";
                    row.Controls.Add(col_2);

                    HtmlGenericControl div = new HtmlGenericControl("div");
                    div.Attributes["class"] = "d-flex";
                    col_2.Controls.Add(div);

                    Button select = new Button();
                    select.Attributes["class"] = "form-control";
                    select.ID = "select_" + nom.Replace(" ", "");
                    select.Attributes["runat"] = "server";
                    select.Text = quant;
                    div.Controls.Add(select);

                    HtmlGenericControl div2 = new HtmlGenericControl("div");
                    div.Controls.Add(div2);

                    Button plus = new Button();
                    plus.ID = "select_" + nom.Replace(" ", "") + "plus";
                    plus.Attributes["class"] = "form-control";
                    plus.Text = "+";
                    plus.Click += new EventHandler(((sender, e) => edit(sender, e, card, nom, base_price, desc, "plus")));
                    div2.Controls.Add(plus);

                    Button less = new Button();
                    less.ID = "select_" + nom.Replace(" ", "") + "less";
                    less.Attributes["class"] = "form-control";
                    less.Text = "-";
                    less.Click += new EventHandler(((sender, e) => edit(sender, e, card, nom, base_price, desc, "less")));
                    div2.Controls.Add(less);

                    HtmlGenericControl text_center = new HtmlGenericControl("div");
                    text_center.Attributes["class"] = "text-center align-items-center d-flex";
                    col_2.Controls.Add(text_center);

                    HtmlGenericControl price = new HtmlGenericControl("h5");
                    price.Attributes["class"] = "mb-0 euro";
                    int quantity = int.Parse(quant);
                    int pro_price = int.Parse(base_price);
                    String total = (quantity * pro_price).ToString();
                    price.InnerText = total;
                    text_center.Controls.Add(price);

                    /* Sumar/Restar/Borrar */


                    LinkButton delete = new LinkButton();
                    delete.ID = "dlt-" + nom.Replace(" ", "");
                    delete.Attributes["class"] = "trash-delete fas fa-trash-alt text-muted";
                    delete.Click += new EventHandler(((sender, e) => deleteToCart(card)));
                    delete.Attributes["Text"] = "";
                    col_2.Controls.Add(delete);


                    priceForProducts[count] = total;
                    count++;
                }

            }
            totalCart(priceForProducts);
        }

        protected void edit(object sender, EventArgs e, HtmlGenericControl card, String nom, String base_price, String desc, String type)
        {
            
            HttpCookie cookieCaret = Request.Cookies["carret"];
            String newProductCart = cookieCaret.Value;
            String[] filmsInCart = newProductCart.Split('-');
            consoleLog.Text = "";
            for (int i = 0; i < filmsInCart.Length - 1; i++) {
                if (filmsInCart[i].Substring(0, filmsInCart[i].IndexOf(',')).Equals(card.ID.Replace("_", " ")))
                {
                    
                    String[] texts = filmsInCart[i].Split(',');
                if (texts.Length == 4)
                {
                    int total = 0;
                    switch (type)
                    {
                        case "plus":
                            total = int.Parse(texts[3]) + 1;
                            break;
                        case "less":
                            total = int.Parse(texts[3]) - 1;
                            if (total == 0)
                            {
                                deleteToCart(card);
                            }
                            break;
                    }
                    //consoleLog.Text = texts[0] + "," + texts[1] + "," + texts[2] + "," + total.ToString() + "-";
                    String productSumado = nom + "," + base_price + "," + desc + "," + total.ToString();
                    newProductCart = newProductCart.Replace(filmsInCart[i], productSumado);
                    // Afegir-la a la cookie
                    Response.Cookies["carret"].Value = newProductCart;
                }
                else {
                    consoleLog.Text = "Noo no nooo";
                }
                }

            }
            Response.Redirect(Request.RawUrl);
            

        }
        /*
        protected void edit(object sender, EventArgs e, HtmlGenericControl card, String type)
        {
            //Modifiquem la cookie amb el producte borrat
            HttpCookie cookieCaret = Request.Cookies["carret"];
            String newProductCart = cookieCaret.Value;
            String[] filmsInCart = newProductCart.Split('-');

            for (int i = 0; i < filmsInCart.Length - 1; i++)
            {
                if (filmsInCart[i].Substring(0, filmsInCart[i].IndexOf(',')).Equals(card.ID.Replace("_", " ")))
                {
                    
                    // Si la pel·licula es a dins li sumem només la quantitat a comprar
                    int total = 0;
                    switch (type)
                    {
                        case "plus":
                            total = int.Parse(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1)) + 1;
                            break;
                        case "less":
                            total = int.Parse(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1)) - 1;
                            if (total == 0) {
                                deleteToCart(sender, e, card);
                            }
                            break;
                    }
                    //total = int.Parse(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1)) + 1;
                    String productSumado = filmsInCart[i].Replace(filmsInCart[i].Substring(filmsInCart[i].LastIndexOf(',') + 1), total.ToString());
                    consoleLog.Text = productSumado;
                    newProductCart = newProductCart.Replace(filmsInCart[i], productSumado);
                    // Afegir-la a la cookie
                    Response.Cookies["carret"].Value = newProductCart;
                       
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        */
        protected void deleteToCart(HtmlGenericControl card)
        {
            //Modifiquem la cookie amb el producte borrat
            HttpCookie cookieCaret = Request.Cookies["carret"];
            String newProductCart = cookieCaret.Value;
            String[] filmsInCart = newProductCart.Split('-');
            for (int i = 0; i < filmsInCart.Length - 1; i++)
            {
                if(filmsInCart[i].Substring(0, filmsInCart[i].IndexOf(',')).Equals(card.ID.Replace("_", " ")))
                {
                    String productToDelete = filmsInCart[i] + "-";
                    String newCookiecontent = newProductCart.Replace(productToDelete, string.Empty);
                    cookieCaret.Value = newCookiecontent;
                    cookieCaret.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookieCaret);
                }
            }
            Response.Redirect(Request.RawUrl);
        }
        protected void totalCart(String[] priceForProducts)
        {
            int total = 0;
            int count = 0;
            foreach (String product in priceForProducts) {
                count++;
                if (Int32.TryParse(product, out int price)){
                    total += price;
                    totalPrice.Text = total.ToString();
                    totalItems.Text = "Tens " + count + " productes al carret.";
                }
                
            }
            
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